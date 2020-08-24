// import HelloWorld from '@/components/HelloWorld'
const Layout = () => import(/* webpackChunkName: 'index' */ '../page/layout')

const staticRoute = [
    {
      path: '/',
      redirect:'/login'
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
      path: '/exchange',
      component: Layout,
      children:[
        {
            path: '',
            component: () => import('../page/exchange')
        }
      ]
    },
    {
        "path": "/user",
        component: Layout,
        children:[
            {
                path: '',
                component: () => import('../page/user')
            }
        ]
    },
    {
        "path": "/sale",
        component: Layout,
        children:[
            {
                path: '',
                component: () => import('../page/sale')
            }
        ]
    },
    {
        "path": "/buy",
        component: Layout,
        children:[
            {
                path: '',
                component: () => import('../page/buy')
            }
        ]
    },
    {
        "path": "/complaintReview",
        component: Layout,
        children:[{
            path: '',
            component: () => import('../page/complaintReview')
        }]
    },
  ]
export default  staticRoute
