import './main.vendors'
import './main.auth'
import AuthService from './services/AuthService'
import Vue from 'vue'
import App from './components/App.vue'
import router from './main.router'
import ElementUi from 'element-ui'

Vue.config.productionTip = false;
Vue.use(ElementUi, {size: 'small', zIndex: 3000});

const main = async() => {
  await AuthService.init();

  new Vue({
    router,
    render: h => h(App)
  }).$mount('#app')
};
import VueA11yDialog from 'vue-a11y-dialog'

Vue.use(VueA11yDialog)
main();