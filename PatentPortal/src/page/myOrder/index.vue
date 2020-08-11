<template>
    <div class="sys-page">
        <el-tabs v-model="activeName" type="border-card"  @tab-click="toggleTab">
            <el-tab-pane label="我的出售" name="sale">
                <SaleBuy :info="activeName" :type="'my'"></SaleBuy>
            </el-tab-pane>
            <el-tab-pane label="我的求购" name="buy">
                <SaleBuy :info="activeName" :type="'my'"></SaleBuy>
            </el-tab-pane>
            <el-tab-pane label="我的收藏" name="collection">
                我的收藏
            </el-tab-pane>
        </el-tabs>
        <SideButton :page="'home'"></SideButton>
    </div>
</template>

<script>
    import SideButton from '../../components/SideButton'
    import SaleBuy from '../../components/SaleBuy'

  export default {
      name: 'myOrder',
      components: { SideButton,SaleBuy },
      data() {
          return {
              activeName: this.$store.state.activeName,
          }
      },
      methods: {
          toggleTab(tab) {
              this.$store.commit('toggleMyOrderTab',tab.name)
          },
      },
      watch: {
          '$store.state.activeName': function (newValue) {
                this.activeName = newValue;
          }
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
