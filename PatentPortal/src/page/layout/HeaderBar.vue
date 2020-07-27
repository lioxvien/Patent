<template>
    <div class="sys-header">
        <div class="logo">
            <slot name="logo"></slot>
        </div>
        <slot name="topnav"></slot>
        <div class="hearder-main">
            <ul class="userInfo">
                <li>
                    <span class="order" @click="myOrder">我的订单</span>
                </li>
                <li>
                    <span class="points" @click="pointsMall">积分商城</span>
                </li>
                <li>
                    <span class="register" @click="pointsMall">免费注册</span>
                </li>
                <li>
                    <span>您好，</span>
                    <span class="loginBtn">登录</span>
                    <el-dropdown @command="userOperation" v-if="$store.state['user/name']">
                        <span class="user">{{username}}<i class="el-icon-caret-bottom el-icon--right"></i></span>
                        <el-dropdown-menu slot="dropdown">
                            <el-dropdown-item command="editPaw">{{$t('global.editpassword')}}</el-dropdown-item>
                            <el-dropdown-item command="logout">{{$t('global.logout')}}</el-dropdown-item>
                        </el-dropdown-menu>
                    </el-dropdown>
                </li>
            </ul>
            <div>
                <el-input placeholder="请输入内容" v-model="headerSearch.context" style="width: 70%">
                    <el-select v-model="headerSearch.select" slot="prepend" placeholder="授权号" style="width: 90px">
                        <el-option label="授权号" value="1"></el-option>
                        <el-option label="订单号" value="2"></el-option>
                        <el-option label="专利号" value="3"></el-option>
                    </el-select>
                    <el-button slot="append" icon="el-icon-search"></el-button>
                </el-input>
                <el-button>发布出售</el-button>
                <el-button>发布求购</el-button>
            </div>
            <ul class="buyBtn">
                <li>
                    <el-button type="text">一手专利</el-button>
                </li>
                <li>
                    <el-button type="text">优先预定</el-button>
                </li>
                <li>
                <el-button type="text">放心购买</el-button>
                </li>
            </ul>
        </div>
        <el-dialog title="修改密码" :visible.sync="dialog.editPaw.show" :modal-append-to-body="false" custom-class="editPawDialog">
            <el-form :model="editPaw" :rules="editPawRules" ref="editPaw" label-width="100px" >
                <el-form-item label="旧密码" prop="oldPaw">
                    <el-input v-model="editPaw.oldPaw" auto-complete="off"></el-input>
                </el-form-item>
                <el-form-item label="新密码" prop="newPaw">
                    <el-input v-model="editPaw.newPaw" auto-complete="off"></el-input>
                </el-form-item>
                <el-form-item label="确认新密码" prop="confirmNewPaw">
                    <el-input v-model="editPaw.confirmNewPaw" auto-complete="off"></el-input>
                </el-form-item>
            </el-form>
            <div class="textC">
                <el-button type="primary" @click="editPawSubmit">保存</el-button>
            </div>
        </el-dialog>
    </div>
</template>

<script>
    import { mapState, mapActions } from 'vuex'

    export default {
        name: 'HeaderBar.vue',
        data() {
            return {
                headerSearch: {
                    select:'',
                    context: ''
                },
                dialog: {
                    editPaw: {show: false}
                },
                editPaw: {
                    oldPaw: '',
                    newPaw: '',
                    confirmNewPaw: ''
                },
                editPawRules: {
                    oldPaw: [
                        {required: true, message: '请输入旧密码', trigger: 'blur'}
                    ],
                    newPaw: [
                        {required: true, message: '请输入新密码', trigger: 'blur'},
                        {min: 8, max: 20, message: '长度在 8 到 20 个字符', trigger: 'blur'},
                        {
                            // eslint-disable-next-line
                            validator(rule, value, callback, source, options) {
                                var errors = [];
                                if(!/^[a-z0-9]+$/.test(value)) {
                                    console.log("不符合输入规则")
                                    errors.push("请输入字母或特殊字符")
                                }
                                callback(errors);
                            }
                        }
                    ],
                confirmNewPaw: [
                    {required: true, message: '请再次输入新密码', trigger: 'blur'},
                    {min: 8, max: 20, message: '长度在 8 到 20 个字符', trigger: 'blur'},
                    {
                        // eslint-disable-next-line
                        validator(rule, value, callback, source, options) {
                            var errors = [];
                            if(!/^[a-z0-9]+$/.test(value)) {
                                console.log("不符合输入规则")
                                errors.push("请输入字母或特殊字符")
                            }
                             callback(errors);
                        }
                    }
                ]
            }
            }
        },
        computed: {
            // ...mapState({
            //   username: state => state.user.name,
            //   lang: state => state.lang
            // })
        },
        methods: {
              // ...mapActions({
              //   sysLogout: 'auth/logout',
              //   loadLang: 'loadLang'
              // }),
            userOperation(command){
               switch(command){
                    case 'logout':
                        this.logout()
                        break
                    case 'editPaw':
                        this.dialog.editPaw.show = true
                        break
                    case 'mailCenter':
                        this.$router.push('mailCenter');
                        break;
                    }
            },
            logout() {
                console.log('登出')
            },
            editPawSubmit(){
                console.log('提交修改密码')
            },
            pointsMall() {
                console.log('积分商城');
            },
            myOrder() {
                console.log('我的订单');
            },
        }
    }
</script>

<style scoped>
</style>
