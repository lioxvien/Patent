<template>
    <div class="sys-login">
        <div class="login-area">
            <div class="logo">
                <h2 class="title">adsb后台管理系统</h2>
            </div>
            <div class="form-group">
                <el-form :model="loginForm" :rules="loginRules" ref="loginForm" label-position="left" label-width="0px">
                    <el-form-item prop="name">
                        <el-input v-model="loginForm.name" type="text"  placeholder="请输入用户名"></el-input>
                    </el-form-item>
                    <el-form-item prop="password">
                        <el-input v-model="loginForm.password" type="password"  placeholder="请输入密码" @keyup.enter.native="submitForm"></el-input>
                    </el-form-item>
                    <a class="btn-login" type="primary" @click="submitForm()">登录</a>
                </el-form>
                <div v-if="sysMsg" class="err-msg">{{sysMsg}}</div>
            </div>
        </div>
    </div>
</template>

<script>
    import { mapState, mapActions } from 'vuex';

    export default {
        name: 'login',
        data() {
            return {
                loginForm: {
                    name: '',
                    password: '',
                },
                loginRules: {
                    name: [
                        {required: true, message: '', trigger: 'blur'}
                    ],
                    password :[
                        {required: true, message: '', trigger: 'blur'}
                    ]
                },
                sysMsg: ''
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
                this.loginRules.name[0].message = '用户名必填';
                this.loginRules.password[0].message = '密码必填';
            }
        }
    }
</script>
