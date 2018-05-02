import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import VeeValidate from 'vee-validate';


Vue.use(VueRouter);
Vue.use(VeeValidate);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/about', component: require('./components/about/about.vue.html') },
    { path: '/gallery', component: require('./components/gallery/gallery.vue.html') },
    { path: '/signup', component: require('./components/signup/signup.vue.html') },
    { path: '/admin', component: require('./components/admin/admin.vue.html') },
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});


