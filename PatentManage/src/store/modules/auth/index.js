import Cookies from 'js-cookie'
import axios from '@/util/ajax'
import Auth from '@/util/auth'
import {Message} from "element-ui";
import router from "../../../router";

const state = {
    token: '',
    navList: [],
};

const mutations = {
    setNavList: (state, data) => {
        state.navList = data
    },
    getNavList:()=> {
      return  state.navList ;
    },
    setToken: (state, data) => {
        if(data){
            Auth.setToken(data);
            Auth.setLoginStatus()
        } else {
            Auth.removeToken();
            Auth.removeLoginStatus()
        }
        state.token = data
    }
};

const actions = {
    // 邮箱登录
    loginByEmail({ commit }, userInfo) {
        return new Promise((resolve) => {
            console.log('发送登录请求');
            axios({
                url: '/user/login',
                method: 'post',
                data: {
                    "username":userInfo.username,
                    "password":userInfo.password
                }
            }).then(res => {
                console.log('发送登录请求成功')
                if(res.code===0){
                    console.log('登录成功')
                    commit('setToken', res.token);
                    commit('user/setName', res.name, { root: true });
                }else{
                    Message.error(res.error);
                }
                resolve(res)
            })
        });
    },

    // 登出
    logout({commit}) {
        return new Promise((resolve) => {
            commit('setToken', '');
            commit('user/setName', '', { root: true });
            commit('tagNav/removeTagNav', '', {root: true});
            resolve()
        })
    },

    // // 重新获取用户信息及Token
    // // TODO: 这里不需要提供用户名和密码，实际中请根据接口自行修改
    relogin({dispatch, commit, state}){
        return new Promise((resolve) => {
            // 根据Token进行重新登录
            let token = Cookies.get('token'),
                userName = Cookies.get('userName');

            // 重新登录时校验Token是否存在，跳转到login页面
            if(!token){
                this.$router.push('/login')
            } else {
                commit('setToken', token)
            }
            // 刷新/关闭浏览器再进入时获取用户名
            commit('user/setName', decodeURIComponent(userName), { root: true });
            dispatch("getNavList").then(()=>{
                commit('setNavList', state.navList)
            });
            resolve()
        })
    },

    // 获取该用户的菜单列表
    getNavList({commit}){
        return new Promise((resolve) =>{
            axios({
                url: '/auth/getNavList',
                method: 'get',
            }).then((res) => {
                commit("setNavList", res.data);
                resolve(res)
            })
        })
    },

    // 将菜单列表扁平化形成权限列表
    getPermissionList({state}){
        return new Promise((resolve) =>{
            let permissionList = [];
            // 将菜单数据扁平化为一级
            function flatNavList(arr){
                for(let v of arr){
                    if(v.child && v.child.length){
                        flatNavList(v.child)
                    } else{
                        permissionList.push(v)
                    }
                }
            }
            flatNavList(state.navList);
            resolve(permissionList)
        })
    }
};

export default {
    namespaced: true,
    state,
    mutations,
    actions
}
