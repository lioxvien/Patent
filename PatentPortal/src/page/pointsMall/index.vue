<template>
    <div class="sys-page">
        <p style="padding-left: 20px">
            <span>我的积分：</span>
            <span>{{myPoints}}</span>
            <el-button style="margin-left: 20px">积分详情</el-button>
        </p>
        <h1 class="earnTitle">-- 赚积分 --</h1>
        <el-container class="earnpoints">
            <el-main>
                <el-row :gutter="24">
                    <el-col v-for="(item,index) in eranList.slice(0,4)" :span="6" class="cardBox">
                        <el-card :body-style="{ padding: '0px' }">
                            <p>{{item.way}}</p>
                            <el-button>{{item.buttonText}}</el-button>
                        </el-card>
                    </el-col>
                </el-row>
                <el-row :gutter="24">
                    <el-col v-for="(item,index) in eranList.slice(4)" :span="8" class="cardBox">
                        <el-card :body-style="{ padding: '0px' }">
                            <p>{{item.way}}</p>
                            <el-button>{{item.buttonText}}</el-button>
                        </el-card>
                    </el-col>
                </el-row>
            </el-main>
            <el-aside width="20%">
                <el-card :body-style="{ padding: '0px' }">
                    签到领积分
                    <p>第一天签到1积分</p>
                    <p>第二天签到2积分</p>
                    <p>第三天签到3积分</p>
                    <p>第四天签到4积分</p>
                    <p>第五天签到5积分</p>
                    <p>第六天签到6积分</p>
                    <p>第七天签到7积分</p>
                </el-card>
            </el-aside>
        </el-container>
        <h1 class="payTitle">-- 花积分 --</h1>
        <el-container class="paypoints">
            <el-main>
                <el-table
                    :data="tableData"
                    border
                    style="width: 100%">
                    <el-table-column
                        prop="project"
                        label="服务项目"  align="center">
                    </el-table-column>
                    <el-table-column
                        prop="number"
                        label="数量/期限/价格" align="center">
                    </el-table-column>
                    <el-table-column
                        prop="points"
                        label="积分"  align="center">
                    </el-table-column>
                    <el-table-column label="兑换" align="center">
                        <template slot-scope="scope">
                            <el-button type="text" size="mini" @click="exchange(row.scope)">兑换</el-button>
                        </template>
                    </el-table-column>
                </el-table>
            </el-main>
            <el-aside width="46%">
                <el-row :gutter="24">
                    <el-col v-for="(item,index) in payList" :span="8">
                        <el-card>
                            <p :class="index===4?'title cur':'title'">{{item.title}}</p>
                            <p class="intro">{{item.intro}}</p>
                        </el-card>
                    </el-col>
                </el-row>
            </el-aside>
        </el-container>
        <LuckDraw></LuckDraw>
    </div>
</template>

<script>
    import LuckDraw from '../../components/luckDraw'
  export default {
      name: 'pointsmall',
      components:{ LuckDraw },
      data() {
          return {
              myPoints: 3000,
              eranList: [
                  {
                  way: '发布求购专利信息每条1积分',
                  buttonText: '发布求购'
              },{
                  way: '绑定工作QQ100积分',
                  buttonText: '发布商品'
              },{
                  way: '绑定微信100积分',
                  buttonText: '发布商品'
              },{
                  way: '发布一条商品',
                  buttonText: '发布商品'
              },{
                  way: '发布一条商品',
                  buttonText: '发布商品'
              },{
                  way: '发布一条商品',
                  buttonText: '发布商品'
              },{
                  way: '发布一条商品',
                  buttonText: '发布商品'
              }],
              payList:[
                  {
                      title: '实用攥写',
                      intro: '50代金券'
                  },{
                      title: '专利热推',
                      intro: '7天'
                  },{
                      title: '商标注册',
                      intro: '50代金券'
                  },{
                      title: '登录项目提交',
                      intro: '1件免费'
                  },{
                      title: '点击抽奖',
                      intro: ''
                  },{
                      title: '年费代缴',
                      intro: '五件免费'
                  },{
                      title: '商标注册',
                      intro: '一件免费'
                  },{
                      title: '发明攥写',
                      intro: '100代金券'
                  },{
                      title: '富硒小米',
                      intro: '2斤'
                  }
              ],
              tableData: [
                  {
                  project: '体验金牌会员',
                  number: '永久',
                  points: '500',
              }, {
                  project: '着录项目提交',
                  number: '1',
                  points: '500',
              }, {
                  project: '年费代缴',
                  number: '10件',
                  points: '500',
              }, {
                  project: '专利热推',
                  number: '3天',
                  points: '1000',
              },{
                  project: '红黄谷富硒小米',
                  number: '7斤',
                  points: '2000',
              }, {
                  project: '商标注册',
                  number: '￥199',
                  points: '2000',
              }]
          }
      },
      methods: {
          getPoints() {
              this.$axios({
                  url: '/getMyPoints?' + this.$store.state.user.name,
                  method: get,
              }).then(res => {
                  if (res.code === 0) {
                      this.myPoints = res.data.points;
                  }
              })
          },
          exchange() {
              console.log('exchange')
          }
      }
  }
</script>

<style scoped>
    .paypoints >>> .el-table thead {
        color: #303133;
        font-size: 16px;
    }
</style>
