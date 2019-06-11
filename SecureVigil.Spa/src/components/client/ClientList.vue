<template>
    <div class="main-content">
        <div class="main-content-inner">
            <div  id="breadcrumbs">
                <ul class="breadcrumb">
                    <li>
                        <i class="ace-icon fa fa-home home-icon"></i>
                        <a href="index">Accueil</a>
                    </li>

                    <li class="active">Client</li>

                </ul><!-- /.breadcrumb -->

            </div>
            <div class="page-content">

                <div class="page-header">
                    <h1>
                        Client
                        <small>
                            <i class="ace-icon fa fa-angle-double-right"></i>
                            Gestion des contrats des clients
                        </small>
                    </h1>
                </div><!-- /.page-header --><br/>


                <h4 class="pink">
                    <i class="ace-icon fa fa-hand-o-right icon-animated-hand-pointer blue"></i>
                    <a href="#modal-client" role="button" class="green" data-toggle="modal"><button class="btn btn-primary" > Enregistrer un client</button> </a>
                </h4>

                <br/>

                <div align="">
                    <div v-if="clients !== null">
                        <!--<span style="cursor: pointer;"><h2><strong><a @click.prevent="clientClicked">{{ '+' }}</a> &nbsp; Client </strong></h2></span>-->
                        <div v-for="cl in clients" :key="cl.clientId">
                <span style="cursor: pointer;"><h4><strong><a class="btn btn-outline-info" @click.prevent="clientClicked(cl)">{{ cl.isVisible ? '-' : '+' }}</a>  Client : {{ cl.clientFirstName }} - {{ cl.clientLastName }}
                <router-link class="btn btn-default" target="_blank"  :to="`/contrat/create/`+cl.clientId"><i class="fa fa-plus"></i> Contrat
                   </router-link> &nbsp;

                    <a href="" role="button" class="green" data-toggle="modal"><button class="btn btn-warning" ><i class="fa fa-edit"></i> Détail client</button> </a>

                </strong></h4></span>

                            <template v-if="cl.isVisible">
                                <div v-for="c in cl.contracts" :key="c.contractId">
                                    <div style="margin-left: 4em; margin-top: -1em;">
                            <span style="cursor: pointer; margin-left: 30px;"><h4><strong><a class="btn btn-outline-info" style="text: white;" @click.prevent="contractClicked(c)">{{ c.isVisible ? '-' : '+' }}</a> Contrat : {{ c.contractId }} - {{ formatDate(c.contractBeginDate) }} - {{ formatDate(c.contractEndDate) }}
                            <router-link class="btn btn-default" target="_blank" :to="`/zone/create/`+c.contractId"><i class="fa fa-plus"></i> Zone
                    </router-link>
                                <!--<client-edit :mode="'edit'" :clientId ="cl.clientId"></client-edit>  -->
                            </strong></h4>
                            </span>

                                    </div>
                                    <template v-if="c.isVisible">
                                        <div v-for="z in c.zones" :key="z.zoneId">
                                            <div style="margin-left: 7em; margin-top: 1em;">
                                    <span style="cursor: pointer;"><h4><strong><a class="btn btn-outline-info" style="text: white;" @click.prevent="zoneClicked(z)">{{z.isVisible ? '-' : '+'}}</a> Zone : {{ z.zoneId }} - {{ z.zoneName }} - {{ z.nbrAgentJour }} Agents(journée)  - {{ z.nbrAgentNuit }} Agents(nuit)  - {{ z.nbrChienJour }} Chiens(journée) - {{ z.nbrChienNuit }} Chiens(nuit)
                                    <router-link class="btn btn-default" :to="`/mission/create/`+z.zoneId"><i class="fa fa-plus"></i> Mission
                    </router-link>
                                    </strong></h4></span>
                                            </div>

                                            <template v-if="z.isVisible">
                                                <div v-for="m in z.missions" :key="m.missionId">
                                                    <div style="margin-left: 12em; margin-top: 1em;">
                                                        <span style="cursor: pointer"><h4><strong> Mission : {{ m.missionId }} - {{ DateTime(m.missionBeginDate) }}  - {{ DateTime(m.missionEndDate) }}  - {{ m.missionRules}}</strong></h4></span>
                                                    </div>
                                                </div><br/>
                                            </template>
                                        </div>
                                    </template>
                                </div>
                            </template>
                        </div>
                    </div>

                </div>


                <div id="modal-client" class="modal fade" tabindex="-1">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">

                            <div class="modal-body no-padding">
                                <client-edit :mode="'create'" v-on:refreshList="refreshList"></client-edit>
                            </div>

                        </div><!-- /.modal-content -->
                    </div><!-- /.modal-dialog -->
                </div>

            </div>
        </div>
    </div>
</template>

<script>
    import {getClientAsync, getClientListAsync, deleteClientAsync} from '../../api/clientApi'
    import {getMissionTreeAsync} from '../../api/MissionApi'
    import AuthService from '../../services/AuthService'
    //import {getUserIdAsync, getUserTypeAsync} from'../../api/UserApi'
    import {getUserIdAsync} from '../../api/UserApi'
    import DateTime from 'luxon/src/datetime.js'
    import ClientEdit from './ClientEdit'
    import ContratEdit from '../contrat/ContratEdit'

    export default {
        components:{
            ClientEdit,
            ContratEdit
        },
        data() {
            return {
                clientList: [],
                pageNumber: 0,
                id: 0,
                clients: null
            }
        },

        props: {
            size: {
                clientList: {
                    type: Array,
                    required: true
                },

                required: false,
                default: 4
            }
        },

        async mounted() {

            await this.refreshList();
            this.id = await getUserIdAsync();
            //            this.type = await getUserTypeAsync();

            if (this.mode == 'edit') {
                try {
                    const item = await getUserIdAsync(this.id);

                    // Here we transform the date, because the HTML date input expect format "yyyy-MM-dd"

                    this.item = item;
                } catch (e) {
                    console.error(e);
                    this.$router.replace('/client');
                }
            }
        },

        methods: {
            async refreshList() {
                try {
                    // this.commentList = await getCommentListAsync();
                    this.clientList = await getClientListAsync();
                    this.clients = await getMissionTreeAsync();
                    console.log(this.clients);
                    // console.log(this.commentList.propositionDate);
                } catch (e) {
                    console.error(e);
                }
            },

            async deleteClient(clientId) {
                try {
                    await deleteClientAsync(clientId);
                    await this.refreshList();
                } catch (e) {
                    console.error(e);
                }
            },

            nextPage() {
                this.pageNumber++;
            },

            prevPage() {
                this.pageNumber--;
            },

            clientClicked(client) {
                this.$set(client, 'isVisible', !client.isVisible);
            },

            contractClicked(contract) {
                this.$set(contract, 'isVisible', !contract.isVisible);
            },

            zoneClicked(zone) {
                this.$set(zone, 'isVisible', !zone.isVisible);
            },

            formatDate(date) {

                console.log(date);
                return DateTime.fromISO(date).toFormat('dd/LL/yyyy');
            },

            DateTime(date) {

                console.log(date);
                return DateTime.fromISO(date).toFormat('dd/LL/yyyy HH:mm');
            },


        },

        computed: {
            auth: () => AuthService,
            pageCount() {
                if (this.clientList !== "undefined") {
                    let l = this.clientList.length,
                        s = this.size;
                    console.log(this.clientList.values);
                    return Math.floor(l / s);
                }

            },
            paginatedData() {
                const start = this.pageNumber * this.size,
                    end = start + this.size;
                return this.clientList.slice(start, end);
            }
        }
    }
</script>

<style lang="scss">

</style>