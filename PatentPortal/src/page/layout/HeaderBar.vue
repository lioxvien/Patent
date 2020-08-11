<template>
    <div class="sys-header">
        <div class="logo">
            <slot name="logo"></slot>
        </div>
        <slot name="topnav"></slot>
        <div class="hearder-main">
            <ul class="userInfo">
                <li>
                    <el-dropdown @command="seeOrder">
                        <span class="order">
                            我的订单
                            <i class="el-icon-caret-bottom el-icon--right"></i>
                        </span>
                        <el-dropdown-menu slot="dropdown">
                            <el-dropdown-item command="collection">我的收藏</el-dropdown-item>
                            <el-dropdown-item command="sale">出售商品</el-dropdown-item>
                            <el-dropdown-item command="buy">求购商品</el-dropdown-item>
<!--                            <el-dropdown-item command="paid">已支付订单</el-dropdown-item>-->
                        </el-dropdown-menu>
                    </el-dropdown>
                </li>
                <li>
                    <span class="points" @click="toPage('/pointsmall')">积分商城</span>
                </li>
                <li v-if="!$store.state.user.name">
                    <span class="register" @click="toLogin(0)">免费注册</span>
                </li>
                <li>
                    <span>您好，</span>
                    <span v-if="!$store.state.user.name" class="loginBtn" @click="toLogin(1)">登录</span>
                    <el-dropdown @command="userOperation" v-else>
                        <span class="user">{{username}}<i class="el-icon-caret-bottom el-icon--right"></i></span>
                        <el-dropdown-menu slot="dropdown">
                            <el-dropdown-item command="invitation">我的邀请码</el-dropdown-item>
                            <el-dropdown-item command="modifyQQ">我的QQ</el-dropdown-item>
                            <el-dropdown-item command="myCode">我的二维码</el-dropdown-item>
                            <el-dropdown-item command="editPaw">修改密码</el-dropdown-item>
                            <el-dropdown-item command="editPhone">修改注册手机号</el-dropdown-item>
                            <el-dropdown-item command="logout">退出登录</el-dropdown-item>
                        </el-dropdown-menu>
                    </el-dropdown>
                </li>
                <li>
                    <span class="index" @click="toPage('/home')">首页</span>
                </li>
            </ul>
            <div>
                <el-input placeholder="授权号/商品名称/商品领域" v-model="headerSearch.context" class="headerSearch">
                    <el-select v-model="headerSearch.select" slot="prepend" placeholder="授权号" style="width: 90px">
                        <el-option label="授权号" value="1"></el-option>
                        <el-option label="订单号" value="2"></el-option>
                        <el-option label="专利号" value="3"></el-option>
                    </el-select>
                    <el-button slot="append" icon="el-icon-search"></el-button>
                </el-input>
                <el-button @click="release(0)">发布出售</el-button>
                <el-button @click="release(1)">发布求购</el-button>
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
                <el-button type="primary" @click="editSubmit('editPaw')">保存</el-button>
            </div>
        </el-dialog>
        <el-dialog title="我的邀请码" :visible.sync="dialog.invitation.show" :modal-append-to-body="false" custom-class="editPawDialog">
           <p class="invitation">SJFUIF5966352</p>
        </el-dialog>
        <el-dialog title="我的QQ" :visible.sync="dialog.modifyQQ.show" :modal-append-to-body="false" custom-class="editPawDialog">
            <el-input v-model="myQQ" class="myQQ"></el-input>
            <el-button type="primary" @click="editSubmit('modifyQQ')">确定</el-button>
        </el-dialog>
        <el-dialog title="我的二维码" :visible.sync="dialog.myCode.show" :modal-append-to-body="false" custom-class="editPawDialog">
            <img :src="myCodeImg" alt="" class="myCode">
            <el-button type="text" class="refresh">刷新</el-button>
        </el-dialog>
        <el-dialog title="修改手机号" :visible.sync="dialog.editPhone.show" :modal-append-to-body="false" custom-class="editPawDialog">
            <el-form :model="editPhone" :rules="editPawRules" ref="editPhone" label-width="100px" >
                <el-form-item label="原手机号" prop="oldPhone">
                    <el-input v-model="editPhone.oldPhone" auto-complete="off"></el-input>
                </el-form-item>
                <el-form-item label="密码" prop="password">
                    <el-input v-model="editPhone.password" auto-complete="off"></el-input>
                </el-form-item>
                <el-form-item label="新手机号" prop="newPhone">
                    <el-input v-model="editPhone.newPhone" auto-complete="off"></el-input>
                </el-form-item>
            </el-form>
            <div class="textC">
                <el-button type="primary" @click="editSubmit('editPhone')">保存</el-button>
            </div>
        </el-dialog>
        <ReleaseSale :dialogVisible="saleDialogVisible" :title='titleDialog' @closeDialog="closeSaleDialog"></ReleaseSale>
    </div>
</template>

<script>
    import { mapState, mapActions } from 'vuex'
    import ReleaseSale from '../Popup/ReleaseSale'

    export default {
        name: 'HeaderBar.vue',
        components:{ ReleaseSale },
        data() {
            return {
                myCodeImg: require('../../assets/images/code.jpg'),
                headerSearch: {
                    select:'',
                    context: ''
                },
                dialog: {
                    invitation: {show: false},
                    modifyQQ: {show: false},
                    myCode: {show: false},
                    editPaw: {show: false},
                    editPhone: {show: false},
                },
                myQQ: '549809311',
                editPaw: {
                    oldPaw: '',
                    newPaw: '',
                    confirmNewPaw: ''
                },
                editPhone:{
                    oldPhone: '',
                    password: '',
                    newPhone: ''
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
            },
                saleDialogVisible: false,
                titleDialog: '发布出售',
                activeName: 'sale'
            }
        },
        computed: {
            ...mapState({
              username: state => state.user.name,
              lang: state => state.lang
            })
        },
        methods: {
              ...mapActions({
                sysLogout: 'auth/logout',
                // loadLang: 'loadLang'
              }),
            userOperation(command){
               switch(command){
                   case 'invitation':
                       this.dialog.invitation.show = true
                       break;
                   case 'modifyQQ':
                       this.dialog.modifyQQ.show = true
                       break;
                   case 'myCode':
                       this.dialog.myCode.show = true
                       break;
                    case 'editPaw':
                        this.dialog.editPaw.show = true
                        break
                    case 'editPhone':
                        this.dialog.editPhone.show = true
                        break;
                   case 'logout':
                       this.sysLogout()
                       break
                }
            },
            seeOrder(command) {
                this.$store.commit('toggleMyOrderTab',command)
                this.$router.push('/myOrder')
            },
            toLogin(type) {
                this.$router.push({path:'/login',query: type})
            },
            editSubmit(value){
                console.log('提交修改密码')
                this.dialog[value].show = false;
            },
            toPage(path) {
                this.$router.push({path: path})
            },
            release(type) { // 发布按钮  0 出售 1 求购
                this.saleDialogVisible = true;
                type? this.titleDialog='发布求购':this.titleDialog='发布出售'
            },
            closeSaleDialog(value) {
                this.saleDialogVisible = value;

            },

        }
    }
</script>

<style scoped>
    .sys-header >>> .el-input-group__append ,
    .sys-header >>> .el-input-group__prepend {
        background-color: #ffa64a;
    }
</style>
