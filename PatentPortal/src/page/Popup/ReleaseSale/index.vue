<template>
<!--    为什么要隐藏弹窗的关闭按钮？因为dialogVisible是父组件传进来的，子组件中不可以修改，只可以通过$emit触发父组件中的事件来修改-->
    <el-dialog :visible.sync="dialogVisible" width="70%" :show-close="false" :title="title">
        <el-form :inline="true" :model="releaseForm" class="demo-form-inline" align="center">
            <el-form-item v-for="(item,index) in releaseList" style="width: 40%">
                <span class="formLabel">{{item.label}}</span>
                <el-select v-if="index===1||index===5||index===7" v-model="releaseForm.authorization" style="width: 71%">
                    <el-option v-for="ite in item.options" :label="ite.type" :value="ite.value"></el-option>
                </el-select>
                <el-input v-else-if="index===6" v-model="releaseForm.date" :readonly="true" style="width: 75%"></el-input>
                <el-input v-else v-model="releaseForm.authorization" style="width: 75%"></el-input>
            </el-form-item>
            <el-form-item style="width: 100%">
                <el-button type="info" plain @click="close">关闭</el-button>
                <el-button type="primary" @click="close">确定</el-button>
            </el-form-item>
        </el-form>
    </el-dialog>
</template>

<script>
    export default {
        name: "ReleaseSale",
        props:['dialogVisible','title'],
        data() {
            return {
                releaseForm: {
                    authorization: '',
                    date: new Date().toLocaleString()
                },
                releaseList: [
                    {
                        label: '授权号',
                    },{
                        label: '商品类型',
                        options: [{
                            type: "发明专利",
                            value: 0
                        },{
                            type: "实用新型专利",
                            value: 1
                        },{
                            type: "商标",
                            value: 2
                        }]
                    },{
                        label: '商品名称',
                    }, {
                        label: '商品领域',
                    }, {
                        label: '出售价格',
                    }, {
                        label: '商品状态',
                        options: [{
                            type: "授权下证书",
                            value: 0
                        },{
                            type: "授权未缴费",
                            value: 1
                        }]
                    }, {
                        label: '发布日期',
                    }, {
                        label: '联系电话',
                    },

                ]
            }
        },
        methods:{
            close() {
                console.log(34)
                // this.saleDialogVisible = false;
                this.$emit('closeDialog',false)
            }
        }
    }
</script>

<style scoped>
 .formLabel {
     padding-right: 2%;
 }
</style>
