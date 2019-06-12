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

import ContratEdit from './components/contrat/ContratEdit.vue'
import ContratList from './components/contrat/ContratList.vue'

import ZoneEdit from './components/zone/ZoneEdit.vue'

import MissionEdit from './components/mission/MissionEdit.vue'

import  VigileEdit from './components/vigile/VigileEdit.vue'
import  VigileList from './components/vigile/VigileList.vue'

const routes = [
    { path: '', component: Home, beforeEnter: requireAuth },
    
    { path: '/login', component: Login },
    { path: '/logout', component: Logout, beforeEnter: requireAuth },
    { path: '/logout', component: Logout, beforeEnter: requireAuth },
    
    { path: '/client', component: ClientList, beforeEnter: requireAuth },
    { path: '/client/:mode([create|edit]+)/:id?', component: ClientEdit, beforeEnter: requireAuth },       

    { path: '/contrat', component: ContratList, beforeEnter: requireAuth },
    { path: '/contrat/:mode([create|edit]+)/:id?', component: ContratEdit, beforeEnter: requireAuth },

    { path: '/zone/:mode([create|edit]+)/:id?', component: ZoneEdit, beforeEnter: requireAuth },

    { path: '/mission/:mode([create|edit]+)/:id?', component: MissionEdit, beforeEnter: requireAuth },

    { path: '/vigile', component: VigileList, beforeEnter: requireAuth },
    { path: '/vigile/:mode([create|edit]+)/:id?', component: VigileEdit, beforeEnter: requireAuth },
];

export default new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});