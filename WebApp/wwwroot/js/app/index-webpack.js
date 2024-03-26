import Vue from 'vue';
import axios from 'axios';
import { cacheAdapterEnhancer } from 'axios-extensions';

Vue.config.devtools = false;
Vue.config.productionTip = false

const http = axios.create({
    baseURL: '/',
    headers: {
        'Cache-Control': 'no-cache',
        'Cache-control': 'no-store',
        'Pragma': 'no-cache',
        'Expires': '0'
    },
    adapter: cacheAdapterEnhancer(axios.defaults.adapter, { enabledByDefault: false }),
});

window.Vue = Vue;
window.http = http;
