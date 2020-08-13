<template>
    <div class="sys-page">
        <div class="page-content">
            <app-section title="投诉审核">
                <app-search>
                    <el-form :inline="true" :model="selectForm" ref="selectForm" size='mini'>
                        <el-form-item label="审核状态" size='small'>
                            <el-select v-model="selectForm.phone" placeholder="请选择审核状态">
                                <el-option v-for="item in options" :label="item.label" :value="item.value"></el-option>
                            </el-select>
                        </el-form-item>
                        <el-form-item label="授权号" size='small'>
                            <el-input v-model="selectForm.phone" placeholder="请输入授权号"></el-input>
                        </el-form-item>
                        <el-form-item label="商品名称" size='small'>
                            <el-input v-model="selectForm.phone" placeholder="请输入商品名称"></el-input>
                        </el-form-item>
                        <el-form-item>
                            <el-button type="primary" icon="el-icon-search" @click="getList">查询</el-button>
                            <el-button type="warning" icon="el-icon-refresh" @click="getList">重置</el-button>
                        </el-form-item>
                    </el-form>
                </app-search>
                <!-- 工具条 -->
                <app-toolbar>
                    <el-button size="small" type="warning" icon="el-icon-download" class="toolBarBtn" @click="exportOrderReport">导出</el-button>
                </app-toolbar>
                <!-- 表格 -->
                <el-table ref="multipleTable" :data="tableData.body" tooltip-effect="dark" border
                          :row-class-name="tableRowClassName"
                          style="width: 100%;margin-bottom: 20px;">
                    <el-table-column type="index" width="64" label="序号" align="center"></el-table-column>
                    <el-table-column prop="phone" label="授权号" :show-overflow-tooltip="true"  align="center"></el-table-column>
                    <el-table-column prop="allSale" label="商品类型" :show-overflow-tooltip="true" align="center"></el-table-column>
                    <el-table-column prop="sale" label="商品名称" align="center"></el-table-column>
                    <el-table-column prop="sale" label="商品领域" align="center"></el-table-column>
                    <el-table-column prop="sale" label="审核状态" align="center"></el-table-column>
                    <el-table-column prop="sale" label="出售/求购价格" align="center"></el-table-column>
                    <el-table-column prop="sale" label="商品状态" align="center"></el-table-column>
                    <el-table-column prop="sale" label="发布日期" align="center"></el-table-column>
                    <el-table-column prop="sale" label="联系电话" align="center"></el-table-column>
                    <el-table-column label="操作" align="center">
                        <template slot-scope="scope">
                            <el-button round type="warning" size="mini"
                                       @click.stop="editGroup(scope.row)">审核
                            </el-button>
                        </template>
                    </el-table-column>
                </el-table>
                <el-pagination class="sys-fy" layout="total, sizes, prev, pager, next, jumper"
                               :total="tableData.tableSize" :paginationTotal="tableData.tableSize"
                               :page-sizes="[10,20,50,100]" @size-change="tableSizeChange" @current-change="pageChange">
                </el-pagination>
            </app-section>
        </div>


        <el-dialog
            title="请选择禁用时间"
            :visible.sync="disableUserDialog"
            width="50%">
            <el-date-picker
                v-model="value1"
                type="daterange"
                range-separator="至"
                start-placeholder="开始日期"
                end-placeholder="结束日期"
                style="margin-left: 20px">
            </el-date-picker>
            <span slot="footer" class="dialog-footer">
                <el-button @click="disableUserDialog = false">取 消</el-button>
                <el-button type="primary" @click="submitDisable">确 定</el-button>
            </span>
        </el-dialog>
    </div>
</template>

<script>
    import AppSection from "../../components/AppSection/index";
    import AppSearch from "../../components/AppSearch/index";
    import AppToolbar from "../../components/AppToolbar/index";
    export default {
        components: {AppSection, AppSearch, AppToolbar},
        name: 'complaintReview',
        data() {
            return {
                selectForm: {
                    phone: ''
                },
                options: [
                    {
                        label: '审核中',
                        value: 1
                    }, {
                        label: '审核通过',
                        value: 2
                    },{
                        label: '审核失败',
                            value: 3
                    }
                ],
                tableData: {
                    tableSize: 0,
                    body: [],
                    pageSize: 10,//每页的数据条数
                    currentPage: 1,//默认开始页面
                    btnColumnShow: true,
                },
                formLabelWidth: "120px",
                title: '用户',
                disableUserDialog: false
            }
        },
        mounted() {
            this.getList();
            // this.getSelectGroupNumList();
        },
        methods: {
            filterMethod(query, item) {
                return item.label.indexOf(query) > -1;
            },
            getList() {//获取页面数据
                let url = `/getUserGoodsList?pageSize=${this.tableData.pageSize}&pageNumber=${this.tableData.currentPage}`;
                let selectPhone = this.selectForm.phone;
                if (selectPhone !== '') {
                    url = url + '&selectPhone=' + selectPhone;
                }
                this.$axios({
                    methods: 'get',
                    url:url
                }).then(res => {
                    this.tableData.body = res.data.list;
                    this.tableData.tableSize = res.data.totalElements;
                }).catch(err => {
                    console.log(err)
                })
            },
            tableRowClassName({row, rowIndex}) {//获取点击表格的索引
                row.index = rowIndex;
            },
            resetSearch() {//重置搜索框
                let obj = this.selectForm;
                Object.keys(obj).map(key => obj[key] = '');
                this.tableData.currentPage = 1;
                this.getList();
            },
            tableSizeChange(val) {//更改每页显示的数量
                this.tableData.pageSize = val;
                this.getList();
            },
            pageChange(currentPage) {//更改页数
                this.tableData.currentPage = currentPage;
                this.getList();
            },
            removeOne(e) {//删除首页列表其中一个
                this.$confirm('确认要删除 ' + e + ' 吗？').then(_ => {
                    this.tableData.body.splice(e.index, 1);
                    // this.$axios.get(`/record/delete/${e.id}`).then(res => {
                    //     if (res.code === 0) {
                    //         this.$message({
                    //             type: 'success',
                    //             message: '删除成功'
                    //         })
                    //     }
                    // })
                    this.$message({
                        type: 'success',
                        message: '删除成功'
                    })
                }).catch(_ => {
                    this.$message({
                        type: 'info',
                        message: '已取消删除'
                    });
                });
            },
            disableUser() {
                this.disableUserDialog = true;
            },
            exportOrderReport() {
                console.log('导出工作组')
            },
            submitDisable() {
                console.log('提交禁用');
                this.disableUserDialog = false;
            }
        }
    }
</script>
<style scoped>
    .el-dialog__title {
        font-size: 22px;
    }
    .userCol > div{
        color: #0aafe6;
        cursor: pointer;
    }
    .userCol{
        color: #0aafe6;
        cursor: pointer;
    }
    .el-main {
        padding: 0;
    }
    .historyMain {
        height: 450px;
        width: 90%;
        margin: 0 auto;
    }
    .historyMain >>> .el-scrollbar__wrap{
        overflow-x: hidden;
    }
    .el-divider--horizontal{
        margin: 16px 0;
    }
    .historyMain .historyRow .username {
        font-size: 16px;
        color: #222323;
        cursor: pointer;
    }
    .historyMain .historyRow .historyTime {
        text-align: center;
        line-height: 38px;
    }
    /*.historyMain.editHisNews {*/
    /*    height: 230px;*/
    /*    line-height: 20px;*/
    /*}*/
    /*.editHisNews >>> .el-divider--horizontal{*/
    /*    margin: 6px 0;*/
    /*}*/
    /*.historyMain.editHisNews .historyRow .username {*/
    /*    font-size: 14px;*/
    /*}*/
    .editMember >>> .el-form-item__content {
        line-height: 0px;
    }
</style>

