<template>
    <div class="sys-page">
        <el-tabs v-model="activeName" type="border-card"  @tab-click="toggleTab">
            <el-tab-pane label="出售商品" name="sale">出售商品</el-tab-pane>
            <el-tab-pane label="求购商品" name="buy">
                <el-table
                    :data="tableData.body"
                    stripe
                    style="width: 100%">
                    <el-table-column
                        type="index"
                        label="序号">
                    </el-table-column>
                    <el-table-column
                        prop="authorizationNumber"
                        label="授权号">
                    </el-table-column>
                    <el-table-column
                        prop="commodityType"
                        label="商品类型">
                    </el-table-column>
                    <el-table-column
                        prop="commodityName"
                        label="商品名称">
                    </el-table-column>
                    <el-table-column
                        sortable
                        prop="price"
                        label="出售价格">
                    </el-table-column>
                    <el-table-column
                        prop="commodityStauts"
                        label="商品状态">
                    </el-table-column>
                    <el-table-column
                        sortable
                        prop="date"
                        label="发布日期">
                    </el-table-column>
                    <el-table-column
                        prop="phone"
                        label="联系电话">
                    </el-table-column>
                    <el-table-column label="操作">
                        <template slot="scope">
                            <el-button>微信</el-button>
                            <el-button>QQ</el-button>
                        </template>
                    </el-table-column>
                </el-table>
                <el-pagination class="sys-fy" layout="total, sizes, prev, pager, next, jumper"
                               :total="tableData.tableSize" :paginationTotal="tableData.tableSize"
                               @size-change="tableSizeChange" @current-change="pageChange">
                </el-pagination>
            </el-tab-pane>
        </el-tabs>

    </div>
</template>

<script>
  export default {
      name: 'home',
      data() {
          return {
              activeName: 'sale',
              tableData: {
                  tableSize: 0,
                  body: [],
                  pageSize: 10,//每页的数据条数
                  currentPage: 1,//默认开始页面
                  btnColumnShow: true
              }
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
              this.$axios({
                  url: '/getBuyGoodsList',
                  method: 'get',
              }).then(res=>{
                    if(res.code === 0) {
                        let data = res.data;
                        this.tableData.body = data.slice((this.tableData.currentPage - 1) * this.tableData.pageSize,this.tableData.currentPage * this.tableData.pageSize);
                        this.tableData.tableSize = data.length;
                    }
              })
          },
          toggleTab(tab) {
              if (tab.name === 'buy') {
                  this.getList();
              }
          }
      }
  }
</script>

<style scoped>

</style>
