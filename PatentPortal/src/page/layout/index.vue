<template>
  <div class="wrapper">
    <template v-if="layout =='left'">
      <header-bar v-once>
        <p slot="logo">
            <img :src="logoIcon" alt="">
        </p>
      </header-bar>
      <nav-bar :layout="layout"></nav-bar>
    </template>
    <template v-if="layout == 'top'">
      <header-bar>
        <p slot="logo" style="height: 100%">
            <img :src="logoIcon" alt="">
        </p>
<!--        <template slot="topnav">-->
<!--          <nav-bar :layout="layout"></nav-bar>-->
<!--        </template>-->
      </header-bar>
    </template>
    <div class="sys-content" :class="layout">
<!--      <tag-nav></tag-nav>-->
      <keep-alive :include="tagNavList">
        <router-view></router-view>
      </keep-alive>
    </div>
  </div>
</template>

<script>
  import HeaderBar from './HeaderBar'
  import NavBar from './NavBar'
  import TagNav from './TagNav'

  export default {
    computed: {
      layout(){
        return this.$store.state.navbarPosition
      },
      tagNavList(){
        return this.$store.state.tagNav.cachedPageName
      }
    },
    components:{
      HeaderBar,
      NavBar,
      TagNav,
    },
      data() {
          return {
              logoIcon: require('../../assets/images/SanYouLogo.png')
        }
      }
  }
</script>
