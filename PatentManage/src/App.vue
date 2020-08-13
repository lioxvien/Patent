<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>

<script>
    import Cookie from 'js-cookie'
export default {
  name: 'App',
    beforeMount(){
        // 首次加载/刷新时判断当前是否在登录状态
        if (Cookie.get('patent-manage-token')) {
            this.$store.dispatch('auth/relogin')
        }
        // 加载默认语言包
        // let defLang = Cookie.get('lang') || this.$i18n.locale
        // this.$store.dispatch("loadLang", defLang)
    }
}
</script>
