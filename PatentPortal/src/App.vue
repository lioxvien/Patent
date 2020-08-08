<template>
  <div id="app" style="height: 100%">
    <router-view></router-view>
  </div>
</template>

<script>
    import Cookies from 'js-cookie'
export default {
  name: 'App',
    beforeMount() {
      if (Cookies.get('gaozhi-isLogin')) {
          this.$store.dispatch('auth/relogin');
      }
    }
}
</script>
