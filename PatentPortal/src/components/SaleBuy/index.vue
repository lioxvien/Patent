<template>
    <div class="saleBuy">
        <Condition></Condition>
        <div class="sort">
            <p :class="sort==='default'?'cur':''" @click="changSort('default')">智能排序</p>
            <p :class="sort==='price'?'cur':''" @click="changSort('price')">价格排序</p>
            <p :class="sort==='date'?'cur':''" @click="changSort('date')">发布日期排序</p>
        </div>
        <el-table
            :data="tableData.body"
            stripe
            style="width: 100%">
            <el-table-column type="index" label="序号" align="center"></el-table-column>
            <el-table-column prop="authorizationNumber" label="授权号" align="center"></el-table-column>
            <el-table-column prop="commodityType" label="商品类型" align="center"></el-table-column>
            <el-table-column prop="commodityName" label="商品名称" align="center"></el-table-column>
            <el-table-column sortable prop="price" label="出售价格" align="center"></el-table-column>
            <el-table-column prop="commodityStauts" label="商品状态" align="center"></el-table-column>
            <el-table-column sortable prop="date" label="发布日期" align="center"></el-table-column>
            <el-table-column prop="phone" label="联系电话" align="center"></el-table-column>
            <el-table-column label="操作" width="280px">
                <template slot-scope="scope">
                    <el-button size="mini" @click="rowClick(scope.row,'wechat')">微信</el-button>
                    <el-button size="mini" @click="rowClick(scope.row,'wechat')">QQ</el-button>
                    <el-button size="mini" @click="rowClick(scope.row,'complaint')">投诉</el-button>
                    <!--                            <el-button size="mini" @click="rowClick(scope.row,'complaintNumber')">投诉数量</el-button>-->
                </template>
            </el-table-column>
        </el-table>
        <el-pagination class="sys-fy" layout="total, sizes, prev, pager, next, jumper"
                       :page-sizes="tableData.pageSizes"
                       :total="tableData.tableSize" :paginationTotal="tableData.tableSize"
                       @size-change="tableSizeChange" @current-change="pageChange">
        </el-pagination>
    </div>
</template>
<script>
    import Condition from '../../components/Condition'
    export default{
        name: 'saleBuy',
        props:['info'],
        components: {  Condition },
        data() {
            return {
                tableData: {
                    tableSize: 0,
                    body: [],
                    pageSize: 20,//每页的数据条数
                    pageSizes:[20,50,100], //更换每页显示数量
                    currentPage: 1,//默认开始页面
                    btnColumnShow: true
                },
                sort: 'default'
            }
        },
        methods: {
            tableSizeChange(val) {//更改每页显示的数量
                this.tableData.pageSize = val;
                this.getList();
            },
            pageChange(currentPage) {//更改页数
                this.tableData.currentPage = currentPage;
                this.getList();
            },
            getList() {
                let url =this.info ==='buy'? '/getBuyGoodsList': '/getSaleGoodsList'
                this.$axios({
                    url: url,
                    method: 'get',
                }).then(res=>{
                    if(res.code === 0) {
                        let data = res.data;
                        this.tableData.body = data.slice((this.tableData.currentPage - 1) * this.tableData.pageSize,this.tableData.currentPage * this.tableData.pageSize);
                        this.tableData.tableSize = data.length;
                    }
                })
            },
            changSort(type) {
                this.sort = type;
            },
            rowClick(row,type) {
                if (!this.$store.state.user.name) {
                    this.$router.push('/login')
                    return
                }
                console.log(row,type)
            }
        },
        watch: {
            info: function() {
                this.getList()
            }
        },
        mounted () {
            this.getList()
        }
    }
</script>
<style>
    .s-canvas {
        display: inline-block;
    }
</style>
