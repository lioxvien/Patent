// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import 'sysStatic/css/base.scss'
import '../mock/index'
// require('../mock/index.js')

import 'babel-polyfill'
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './store'
import axios from './util/ajax'
import echarts from 'echarts'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import i18n from './util/i18n'

Vue.prototype.$axios = axios;
Vue.prototype.$echarts = echarts
Vue.config.productionTip = false
Vue.use(ElementUI, {
    i18n: (key, value) => i18n.t(key, value)
});
/* eslint-disable no-new */
new Vue({
    router,
    axios,
    store,
    render: h => h(App)
}).$mount('#app');
