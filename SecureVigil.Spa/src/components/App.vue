<template>
    <!-- <div id="app" :class="classObject" class="main"> -->
    <div id="app">
    <body class="no-skin">
    <div id="navbar" class="navbar navbar-default          ace-save-state">
        <div class="div clasontainer ace-save-state" id="navbar-container">
            <button type="button" class="navbar-toggle menu-toggler pull-left" id="menu-toggler" data-target="#sidebar">
                <span class="sr-only">Toggle sidebar</span>

                <span class="icon-bar"></span>

                <span class="icon-bar"></span>

                <span class="icon-bar"></span>
            </button>

            <div class="navbar-header pull-left">
                <a href="index" class="navbar-brand">
                    <small>
                        <i class=""></i>
                        SekurTek
                    </small>
                </a>
            </div>

            <div class="navbar-buttons navbar-header" role="navigation">
                <ul class="nav ace-nav">
                    <li class="light-blue dropdown-modal">
                        <a data-toggle="dropdown" href="#" class="dropdown-toggle">
                            <span class="user-info">
                                <small>Bonjour,</small>

                            </span>

                            <i class="ace-icon fa fa-caret-down"></i>
                        </a>

                        <ul class="user-menu dropdown-menu-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">

                            <li class="eborder-top">
                                <a href=""><i class="fa fa-user"></i> Admin</a>
                            </li>

                            <li class="divider"></li>

                            <li class="eborder-top">
                                <a href="#modal-utilisateur" role="button" class="" data-toggle="modal"><i class="fa fa-user"></i> Profile d'utilisateur</a>
                            </li>

                            <li class="divider"></li>

                            <li>
                                <router-link class="nav-link" to="/client/"><i class="fa fa-power-off"></i> Déconnexion</router-link>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div><!-- /.navbar-container -->
    </div>

    <div class="main-container ace-save-state" id="main-container">

        <div id="sidebar" class="sidebar responsive ace-save-state">

            <ul class="nav nav-list">
                <li class="col-lg-12">
                    <a href="">
                        <i class="menu-icon fa fa-home"></i>
                        <span class="menu-text"> Accueil </span>
                    </a>

                    <b class="arrow"></b>
                </li>

                <li class="col-lg-12">
                    <router-link class="nav-link" to="/client/" >
                        <i class="menu-icon fa fa-male"></i>
                        <span class="menu-text">
                          Client
                        </span>

                    </router-link>
                    <b class="arrow"></b>
                </li>

            </ul><!-- /.nav-list -->

            <div class="sidebar-toggle sidebar-collapse" id="sidebar-collapse">
                <i id="sidebar-toggle-icon" class="ace-icon fa fa-angle-double-left ace-save-state" data-icon1="ace-icon fa fa-angle-double-left" data-icon2="ace-icon fa fa-angle-double-right"></i>
            </div>
        </div>


        <router-view></router-view>


        <div class="footer">
            <div class="footer-inner">
                <div class="footer-content">
                <span class="bigger-120">
                    SekurTek &copy; 2019
                </span>

                    &nbsp; &nbsp;
                    <span class="action-buttons">
                    <a href="#">
                        <i class="ace-icon fa fa-twitter-square light-blue bigger-150"></i>
                    </a>

                    <a href="#">
                        <i class="ace-icon fa fa-facebook-square text-primary bigger-150"></i>
                    </a>

                    <a href="#">
                        <i class="ace-icon fa fa-rss-square orange bigger-150"></i>
                    </a>
                </span>
                </div>
            </div>
        </div>

        <a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
            <i class="ace-icon fa fa-angle-double-up icon-only bigger-110"></i>
        </a>
    </div><!-- /.main-container -->

    </body>
    </div>
</template>

<script>

import AuthService from '../services/AuthService'
import '../directives/requiredProviders'
import { state } from "../state"
//import {getUserIdAsync, getUserTypeAsync} from'../api/UserApi'
import {getUserIdAsync} from'../api/UserApi'


export default {

    name: "app",
    components: {

    },

    data() {
        return {
            state,
            //type: false,
        }
    },




    computed: {
        auth: () => AuthService,
        
        isLoading() {
            return this.state.isLoading;
        },


    }
}
</script>

<style lang="scss" scoped>
.progress {
  margin: 0px;
  padding: 0px;
  height: 5px;
}

a.router-link-active {
  font-weight: bold;
}
</style>

<style lang="scss">
@import "../styles/global.scss";
</style>