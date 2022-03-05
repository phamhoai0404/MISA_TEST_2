import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'

import CA from './view/cash/CA.vue'
import CAProcess from './view/cash/CAProcess.vue'
import CAReceipt from './view/cash/CAReceipt.vue'
import Overview from './view/overview/Overview.vue'
import AccountList from './view/account_object/AccountList.vue'
// import AccountDetail from './view/account_object/AccountDetail.vue'



import VCalendar from 'v-calendar';
import Paginate from 'vuejs-paginate'


Vue.use(require('vue-shortkey')) //Dùng để sử dụng phím tắt


Vue.use(VueRouter) //Thực hiện sử dụng vue router
Vue.use(VCalendar) //Thực hiện thư viện của datepiker


Vue.component('paginate', Paginate) //Thực hiện thư viện sử dụng phân trang

Vue.config.productionTip = false

//Thiết lập router
const routes = [
    { path: '/', component: AccountList },
    { path: '/overview', component: Overview },
    { path: '/account', component: AccountList },
    {
        path: '/CA',
        component: CA,
        children: [{
                path: '/CA/',
                component: CAProcess
            },
            {
                path: '/CA/CAProcess',
                component: CAProcess
            },
            {
                path: '/CA/CAReceipt',
                component: CAReceipt
            }
        ]
    },
]

const router = new VueRouter({
    mode: 'history', //Xóa dấu # ở thanh URL
    routes // short for `routes: routes`
})

//Thực hiện để thực hiện hành động bên ngoài click của thành phần nào đó
Vue.directive('click-outside', {
    bind: function(el, binding, vnode) {
        window.event = function(event) {
            if (!(el == event.target || el.contains(event.target) || event.target.id == "clickFunction")) {
                vnode.context[binding.expression](event);
            }
        };
        document.body.addEventListener('click', window.event)
    },
});

new Vue({
    router,
    render: h => h(App),
}).$mount('#app')