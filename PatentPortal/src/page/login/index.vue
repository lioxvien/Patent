<template>
    <div class="sys-login">
        <div class="login-header">
            <h1 class="logo">高智</h1>
            <el-row>
                <el-col :span="6" v-for="(item,index) in headerList" :key="index">
                   <div class="tabList" :style="'backgroundImage: url(' + item.icon+')'">
                       <h1>{{item.titleCN}}</h1>
                       <p>{{item.titleEN}}</p>
                   </div>
                </el-col>
            </el-row>
        </div>
        <div class="login-area">
<!--            <div class="logo">-->
<!--                <h2 class="title">adsb后台管理系统</h2>-->
<!--            </div>-->
            <div class="login-box">
                <h1 class="title">手机号登录</h1>
                <div class="form-group">
                    <el-form :model="loginForm" :rules="loginRules" ref="loginForm" label-position="left" label-width="0px">
                        <el-form-item prop="name">
                            <el-input v-model="loginForm.name" type="text"  placeholder="请输入手机号">
                                <i slot="prepend" class="el-icon-mobile-phone"></i>
                            </el-input>
                        </el-form-item>
                        <el-form-item prop="password">
                            <el-input v-model="loginForm.password" type="password"  placeholder="请输入密码">
                                <i slot="prepend" class="el-icon-lock"></i>
                            </el-input>
                        </el-form-item>
                        <el-form-item prop="imgVerificationCode" class="noLineHeight">
                            <el-input v-model="loginForm.imgVerificationCode" type="text"  placeholder="请输入验证码" style="width: 180px;vertical-align: 13px;"></el-input>
                            <Identify></Identify>
                        </el-form-item>
                        <el-form-item prop="phoneVerificationCode">
                            <el-input v-model="loginForm.phoneVerificationCode" type="password"  placeholder="请输入短信验证码" style="width: 180px" @keyup.enter.native="submitForm"></el-input>
                            <el-button type="success" size="medium">获取验证码</el-button>
                        </el-form-item>
                        <el-button class="btn-login" type="primary" @click="submitForm()">登录</el-button>
                    </el-form>
                    <div v-if="sysMsg" class="err-msg">{{sysMsg}}</div>
                </div>
            </div>
        </div>
        <SideButton :page="'login'"></SideButton>
    </div>
</template>

<script>
    import { mapState, mapActions } from 'vuex';
    import Identify from '../../components/Identify'
    import SideButton from '../../components/SideButton'

    export default {
        name: 'login',
        components: {Identify, SideButton},
        data() {
            return {
                loginForm: {
                    name: '',
                    password: '',
                    imgVerificationCode: '',
                    phoneVerificationCode: '',
                },
                loginRules: {
                    name: [
                        {required: true, message: '', trigger: 'blur'}
                    ],
                    password :[
                        {required: true, message: '', trigger: 'blur'}
                    ],
                    imgVerificationCode :[
                        {required: true, message: '', trigger: 'blur'}
                    ],
                    phoneVerificationCode :[
                        {required: true, message: '', trigger: 'blur'}
                    ]
                },
                sysMsg: '',
                headerList: [
                    {
                        titleCN: '专利文献下载',
                        titleEN: 'DATA DOWNLOAD',
                        icon: require('../../assets/images/loginIcon.svg')
                    },{
                        titleCN: '专利资源最多',
                        titleEN: 'MOST RESOURCES',
                        icon: require('../../assets/images/loginIcon.svg')
                    },{
                        titleCN: '业内价格最低',
                        titleEN: 'LOWEST PRICES',
                        icon: require('../../assets/images/loginIcon.svg')
                    },{
                        titleCN: '不成功退款',
                        titleEN: 'FAILED REFUND',
                        icon: require('../../assets/images/loginIcon.svg')
                    }
                ]
            }
        },
        computed: {
            ...mapState({
                lang: state => state.lang,
                theme: state => state.theme
            })
        },
        beforeMount(){
            // 初始化错误信息。保证单独点击input时可以弹出正确的错误提示
            this.setErrMsg()
        },
        methods: {
            ...mapActions({
                login: 'auth/loginByEmail',
                loadLang: 'loadLang'
            }),
            submitForm(){
                this.$refs.loginForm.validate((valid) => {
                    if (valid) {
                        this.login({
                            username: this.loginForm.name,
                            password: this.loginForm.password
                        }).then(res => {
                            if(res.code===0){
                                this.$router.push('home');
                            } else {
                                this.sysMsg = res.message
                            }
                        })
                    } else {
                        return false
                    }
                });
            },
            setErrMsg(){
                // this.loginRules.name[0].message = this.$t('global.errMsg.inputRequired', {cont: this.$t('global.username')})
                // this.loginRules.password[0].message = this.$t('global.errMsg.inputRequired', {cont: this.$t('global.password')})
                this.loginRules.name[0].message = '手机号必填';
                this.loginRules.password[0].message = '密码必填';
                this.loginRules.imgVerificationCode[0].message = '图片验证码必填';
                this.loginRules.phoneVerificationCode[0].message = '手机验证码必填';
            }
        }
    }
</script>
<style>
    .el-input-group__append, .el-input-group__prepend {
        background-color: #eee;
        padding: 0 15px;
    }
    .sys-login .form-group .el-input__inner {
        border-radius: 0px;
    }
    .noLineHeight > .el-form-item__content{
        line-height: normal!important;
    }
</style>

