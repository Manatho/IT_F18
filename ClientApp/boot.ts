import './css/site.css';
import 'bootstrap';

import Vue from 'vue';
import Vuex, { StoreOptions, MutationTree, GetterTree, ActionTree, ActionContext } from 'vuex';
import VueRouter from 'vue-router';
import VeeValidate from 'vee-validate';


Vue.use(VueRouter);
Vue.use(VeeValidate);
Vue.use(Vuex);

const routes = [
    { path: '/', redirect: "/about"},
    { path: '/about', component: require('./components/about/about.vue.html') },
    { path: '/gallery', component: require('./components/gallery/gallery.vue.html') },
    { path: '/signup', component: require('./components/signup/signup.vue.html') },
    { path: '/admin', component: require('./components/admin/admin.vue.html') },
    { path: '/login', component: require('./components/auth/login.vue.html') },
];


class State{
    admin: boolean;
    
    constructor(){
        this.admin = false;
    }
}

const mutations: MutationTree<State> = {
    setAdmin(state, value : boolean) {
        state.admin = value;
    }
}

const getters: GetterTree<State, any> = {
    getAdmin(state): boolean {
        return state.admin;
    }
};

const actions: ActionTree<State, any> = {
    setAdmin(store, value: boolean){
        store.commit('setAdmin', value);
    }
}

const store: StoreOptions<State> = {
    state: new State(),
    mutations: mutations,
    getters: getters,
    actions: actions
}

const realstore = new Vuex.Store(store);

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html')),
    store: realstore
});


