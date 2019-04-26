// Vue router setup
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

import requireAuth from './helpers/requireAuth';

// Components
import Home from './components/Home.vue'
import Login from './components/Login.vue'
import Logout from './components/Logout.vue'

import ClientEdit from './components/client/ClientEdit.vue'
import ClientList from './components/client/ClientList.vue'


const routes = [
    { path: '', component: Home, beforeEnter: requireAuth },
    
    { path: '/login', component: Login },
    { path: '/logout', component: Logout, beforeEnter: requireAuth },
    { path: '/logout', component: Logout, beforeEnter: requireAuth },
    { path: '/client', component: ClientList, beforeEnter: requireAuth },
    { path: '/client/:mode([create|edit]+)/:id?', component: ClientEdit, beforeEnter: requireAuth },       
];

export default new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});