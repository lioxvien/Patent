<template>
    <div class="sys-page">
        <div class="page-content">
            <app-section title="用户">
                <app-search>
                    <el-form :inline="true" :model="selectForm" ref="selectForm" size='mini'>
                        <el-form-item label="工作组名称" size='mini'>
                            <el-input v-model="selectForm.groupName" placeholder="请输入用户"></el-input>
                        </el-form-item>
                        <el-form-item label="工作组成立时间">
                            <el-date-picker
                                v-model="selectForm.time"
                                type="daterange"
                                range-separator="至"
                                value-format="yyyy-MM-dd"
                                start-placeholder="开始日期"
                                end-placeholder="结束日期">
                            </el-date-picker>
                        </el-form-item>
                        <el-form-item label="最后发言时间">
                            <el-date-picker
                                v-model="selectForm.groupLastSpeechtime"
                                type="daterange"
                                range-separator="至"
                                value-format="yyyy-MM-dd"
                                start-placeholder="开始日期"
                                end-placeholder="结束日期">
                            </el-date-picker>
                        </el-form-item>
                        <el-form-item>
                            <el-button type="success" icon="el-icon-search" @click="getList">搜索</el-button>
                            <el-button type="warning" icon="el-icon-refresh" @click="resetSearch">重置</el-button>
                        </el-form-item>
                    </el-form>
                </app-search>
                <!-- 工具条 -->
                <app-toolbar>
                    <el-button size="mini" type="warning" icon="el-icon-download" class="toolBarBtn" @click="exportOrderReport">导出</el-button>
                </app-toolbar>
                <!-- 表格 -->
                <el-table ref="multipleTable" :data="tableData.body" tooltip-effect="dark" border
                          :row-class-name="tableRowClassName"
                          style="width: 100%;margin-bottom: 20px;">
                    <el-table-column type="index" label="序号" width="64" align="center"></el-table-column>
                    <el-table-column prop="groupName" label="工作组名称" align="center" min-width="140"></el-table-column>
                    <el-table-column prop="commonConcern" label="组关注" :show-overflow-tooltip="true" align="center" min-width="140"></el-table-column>
                    <el-table-column prop="activeGrade" label="活跃度" align="center"></el-table-column>
                    <el-table-column prop="groupNum" label="工作组人数" align="center"></el-table-column>
                    <el-table-column prop="groupMember" label="工作组成员" align="center">
                        <template slot-scope="scope">
                            <el-button round type="warning" plain icon="el-icon-user-solid" size="mini"
                                       @click.stop="viewMembers(scope.row)">查看成员
                            </el-button>
                        </template>
                    </el-table-column>
                    <el-table-column prop="historicalNews" label="历史消息" align="center">
                        <template slot-scope="scope">
                            <el-button round type="warning" plain icon="el-icon-chat-dot-round" size="mini"
                                       @click.stop="viewHistoryNews(scope.row)">查看历史消息
                            </el-button>
                        </template>
                    </el-table-column>
                    <el-table-column label="操作" width="200" align="center">
                        <template slot-scope="scope">
                            <el-button round type="primary" icon="el-icon-edit" size="mini"
                                       @click.stop="editGroup(scope.row)">编辑
                            </el-button>
                            <el-button round type="danger" icon="el-icon-delete" size="mini"
                                       @click.stop="removeOne(scope.row.groupName)">删除
                            </el-button>
                        </template>
                    </el-table-column>
                </el-table>
                <el-pagination class="sys-fy" layout="total, sizes, prev, pager, next, jumper"
                               :total="tableData.tableSize" :paginationTotal="tableData.tableSize"
                               @size-change="tableSizeChange" @current-change="pageChange">
                </el-pagination>
            </app-section>
        </div>
    </div>
</template>

<script>
    import AppSection from "../../components/AppSection/index";
    import AppSearch from "../../components/AppSearch/index";
    import AppToolbar from "../../components/AppToolbar/index";
    export default {
        components: {AppSection, AppSearch, AppToolbar},
        name: 'workgroupMembers',
        data() {
            return {
                selectForm: {
                    groupName: '',
                    // groupNum: '',
                    time: '',
                    groupLastSpeechtime: '',
                    spokesman: '',
                    message: '',
                    spokesTime: ''
                },
                tableData: {
                    tableSize: 0,
                    body: [],
                    pageSize: 10,//每页的数据条数
                    currentPage: 1,//默认开始页面
                    btnColumnShow: true,
                },
                formLabelWidth: "120px",
                title: '用户',
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
                // let url = `/record/page?pageSize=${this.tableData.pageSize}&pageNumber=${this.tableData.currentPage}`;
                // let normName = this.selectForm.normName;
                // let recordYear = this.selectForm.dataYear;
                // let time = this.selectForm.time;
                // if (normName !== '') {
                //     url = url + '&normName=' + normName;
                // }
                // if (recordYear !== '') {
                //     url = url + "&recordYear=" + recordYear;
                // }
                // if (time !== '') {
                //     url = url + "&startTime=" + time[0] + "&endTime=" + time[1];
                // }
                // this.$axios.get(url).then(res => {
                //     this.tableData.body = res.data.list;
                //     this.tableData.tableSize = res.data.totalElements;
                // })
                let data = [
                    {
                        groupId: '01',
                        groupName: '航线组',
                        commonConcern: '国内航线',
                        activeGrade: '活跃',
                        groupNum: 130
                    },
                    {
                        groupId: '02',
                        groupName: '机场组',
                        commonConcern: '大兴机场',
                        activeGrade: '非常活跃',
                        groupNum: 230
                    }
                ];
                let data1 = [];
                let groupName = this.selectForm.groupName;
                let groupNum = this.selectForm.groupNum;
                let time = this.selectForm.time;
                if (time !== '') {
                    // url = url + "&startTime=" + time[0] + "&endTime=" + time[1];
                }
                if (data1.length !== 0) {
                    this.tableData.body = data1.slice((this.tableData.currentPage - 1) * this.tableData.pageSize, this.tableData.currentPage * this.tableData.pageSize);
                    this.tableData.tableSize = data1.length;
                    return;
                }
                this.tableData.body = data.slice((this.tableData.currentPage - 1) * this.tableData.pageSize,this.tableData.currentPage * this.tableData.pageSize);
                this.tableData.tableSize = data.length;
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
            exportOrderReport() {
                console.log('导出工作组')
            },
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

