<template>
    <div class="sys-page">
        <el-tabs v-model="activeName" type="border-card"  @tab-click="toggleTab">
            <el-tab-pane label="出售商品" name="sale">
                <SaleBuy :info="activeName"></SaleBuy>
            </el-tab-pane>
            <el-tab-pane label="求购商品" name="buy">
                <SaleBuy :info="activeName"></SaleBuy>
            </el-tab-pane>
        </el-tabs>
        <SideButton :page="'home'"></SideButton>
    </div>
</template>

<script>
    import SideButton from '../../components/SideButton'
    import SaleBuy from '../../components/SaleBuy'

  export default {
      name: 'home',
      components: { SideButton,SaleBuy },
      data() {
          return {
              activeName: 'sale',
          }
      },
      methods: {
          toggleTab(tab) {
              this.activeName = tab.name;
          },
      }
  }
</script>

<style scoped>
    .sys-page >>> .el-tabs--border-card>.el-tabs__header{
        background: #fca851;
    }
    .sys-page >>> .el-tabs--border-card>.el-tabs__header .el-tabs__item {
        color: #303133;
    }
    .sys-page >>> .el-tabs--border-card>.el-tabs__header .el-tabs__item.is-active {
        font-size: 15px;
    }
</style>
