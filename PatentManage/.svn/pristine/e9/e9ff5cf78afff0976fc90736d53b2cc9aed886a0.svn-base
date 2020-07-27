/**
 * axios全局配置
 * TODO: 拦截器全局配置，根据实际情况修改
 */
import Vue from "vue";
import axios from 'axios'
import store from '../store'
import router from '../router'
import { Message } from 'element-ui'
import Auth from '@/util/auth'
import state from "../store/modules/auth";

var getTokenLock = false,
    CancelToken = axios.CancelToken,
    requestList = [];

// 发起请求前
let loadingInstance = null;

// 状态码错误信息
const codeMessage = {
    200: '服务器成功返回请求的数据。',
    201: '新建或修改数据成功。',
    202: '一个请求已经进入后台排队（异步任务）。',
    204: '删除数据成功。',
    400: '发出的请求有错误，服务器没有进行新建或修改数据的操作。',
    401: '用户没有权限（登录令牌过期）。',
    403: '用户得到授权，但是访问是被禁止的。',
    404: '发出的请求针对的是不存在的记录，服务器没有进行操作。',
    406: '请求的格式不可得。',
    410: '请求的资源被永久删除，且不会再得到的。',
    422: '当创建一个对象时，发生一个验证错误。',
    500: '服务器发生错误，请检查服务器。',
    502: '网关错误。',
    503: '服务不可用，服务器暂时过载或维护。',
    504: '网关超时。',
};


/**
 * Token校验
 * @param {function} cancel - 中断函数
 * @param {function} callback -  回调
 * @description 校验Token是否过期，如果Token过期则根据配置采用不同方法获取新Token
 *              自动获取Token：过期时自动调用获取Token接口。注意：当有任一请求在获取Token时，其余请求将顺延，直至新Token获取完毕
 *              跳转授权Token：过期时中断当前所有请求并跳转到对应页面获取Token。注意：跳转页面授权最佳实现应在授权页面点击触发
 */
function checkToken(cancel, callback){
    if(!Auth.hasToken()){
        // 自动获取Token
        if(Auth.tokenTimeoutMethod == "getNewToken"){
            // 如果当前有请求正在获取Token
            if(getTokenLock){
                setTimeout(function(){
                    checkToken(cancel, callback)
                }, 500)
            } else {
                getTokenLock = true;
                store.dispatch("auth/getNewToken").then(() => {
                    console.log("已获取新token");
                    callback();
                    getTokenLock = false
                })
            }
        }
        // 跳转授权Token
        if(Auth.tokenTimeoutMethod == "jumpAuthPage" && Auth.isLogin()){
            if(router.currentRoute.path != '/auth'){
                // BUG: 无法保证一定会中断所有请求
                cancel();
                router.push('/auth')
            }
        }
    } else {
        callback()
    }
}

/**
 * 阻止短时间内的重复请求
 * @param {string} url - 当前请求地址
 * @param {function} c - 中断请求函数
 * @description 每个请求发起前先判断当前请求是否存在于RequestList中，
 *              如果存在则取消该次请求，如果不存在则加入RequestList中，
 *              当请求完成后500ms时，清除RequestList中对应的该请求。
 */
function stopRepeatRequest(url, c){
    for( let i = 0; i < requestList.length; i++){
        if(requestList[i] == url){
            c();
            return
        }
    }
    requestList.push(url)
}

// 超时设置
const service = axios.create({
    // 请求超时时间
    timeout: 50000
});


// baseURL 本地测试
// axios.defaults.baseURL = 'http://39.104.97.248:8888/api';
// axios.defaults.baseURL = 'http://192.168.50.253:8888/api';
// axios.defaults.baseURL = 'http://127.0.0.1:8888/api';
// 192.168.50.127

axios.defaults.withCredentials = true;  //允许跨域
// http request 拦截器
// 每次请求都为http头增加Authorization字段，其内容为token
service.interceptors.request.use(
    config => {
        if (!config.LOADINGHIDE) {
            loadingInstance = Vue.prototype.$loading({
                lock: true,
                text: "Loading",
                spinner: "el-icon-loading",
                background: "rgba(0, 0, 0, 0.7)"
            });
        }


        config.headers.Token = state.state.token;

        return config
    },
    err => {
        return Promise.reject(err);
    }
);

// http response 拦截器
// 针对响应代码确认跳转到对应页面
service.interceptors.response.use(
    response => {
        // 导出
        const headers = response.headers;
        if (headers['content-type'] === 'application/octet-stream') {
            loadingInstance && loadingInstance.close();
            return response.data
        }
        loadingInstance && loadingInstance.close();

        for( let i = 0; i < requestList.length; i++){
            if(requestList[i] == response.config.url){
                // 注意，不能保证500ms必定执行，详情请了解JS的异步机制
                setTimeout(function(){
                requestList.splice(i,1)
                }, 500);
                break
            }
        }
        return Promise.resolve(response.data)
    },
    error => {
        loadingInstance && loadingInstance.close();
        if (error){
            // 请求配置发生的错误
            if (!error.response) {
                return console.log('Error', error.message);
            }

            // 获取状态码
            const status = error.response.status;
            const errortext = codeMessage[status] || error.response.statusText;
            // 提示错误信息
            Vue.prototype.$message({
                message: errortext +status,
                type: "error"
            });

            // 错误状态处理
            if (status === 401) {
                router.push('login')
            } else if (status === 403) {
                router.push('login')
            } else if (status >= 404 && status < 422) {
                router.push('error/404')
            }
        }
        return Promise.reject(error);
    }
);

export default service;
