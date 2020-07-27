// import HelloWorld from '@/components/HelloWorld'
const Layout = () => import(/* webpackChunkName: 'index' */ '../page/layout')

const staticRoute = [
    {
      path: '/',
      redirect:'/home'
    },
    {
      path: '/error',
      component: () => import(/* webpackChunkName: 'error' */ '../page/error'),
      children: [
        // {
        //   path: '401',
        //   component: () => import(/* webpackChunkName: 'error' */ '../page/error/401')
        // },
        // {
        //   path: '403',
        //   component: () => import(/* webpackChunkName: 'error' */ '../page/error/403')
        // },
        {
          path: '404',
          component: () => import(/* webpackChunkName: 'error' */ '../page/error/404')
        },
        // {
        //   path: '500',
        //   component: () => import(/* webpackChunkName: 'error' */ '../page/error/500')
        // }
      ]
    },

    {
      path: '/login',
      component: () => import(/* webpackChunkName: 'login' */ '../page/login')
    },
    {
      path: '/home',
      component: Layout,
      children:[
        {
            path: '',
            component: () => import('../page/home')
        }
      ]
    },
  ]
export default  staticRoute
