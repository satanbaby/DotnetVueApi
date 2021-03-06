import Vue from 'vue'
import Router from 'vue-router'
import 'bootstrap/js/dist/modal';

import Home from '@/components/Home'
import Login from '@/components/page/Login'


import Products from '@/components/page/Product'
import PrdMan from '@/components/page/PrductMan'
import Order from '@/components/page/Order'
import Registered from '@/components/page/Registered'
import Member from '@/components/page/Member'
Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      // name: 'Home',
      component: Home,
      children: [
        {
          path: '',
          name: 'Product',
          component: Products,
       },{
          path: 'pruductman',
          name: 'PrdMan',
          component: PrdMan,
       },{
          path: 'order',
          name: 'Order',
          component: Order,
        },{
          path: 'member',
          name: 'Member',
          component: Member,
        },
      ]
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },{
      path: '/registered',
      name: 'Registered',
      component: Registered,
    }
  ]
})
