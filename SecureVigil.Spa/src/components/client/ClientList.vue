<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Gestion de client </h1>
            <div>
                <router-link class="btn btn-primary" :to="`./create`"><i class="fa fa-plus"></i> Ajouter un client
                </router-link>
            </div>
        </div>

        <table class="table table-striped table-hover table-bordered">
            <thead>
            <tr>
                <th>Nom</th>
                <th>Prénom</th>
                <th>Numéro de téléphone</th>
                <th>Adresse</th>
            </tr>
            </thead>

            <tbody>
            <tr v-if="clientList.length == 0">
                <td colspan="6" class="text-center">Il n'y a actuellement aucun client.</td>
            </tr>

            <tr v-for="i of clientList">
                <td>{{ i.firstName }}</td>
                <td>{{ i.lastName }}</td>
                <td>{{ i.clientPhone}}</td>
                <td>{{ i.clientAdresse }}</td>
            </tr>
            </tbody>
        </table>
        <button
                :disabled="pageNumber === 0"
                @click="prevPage">
            Précédent
        </button>
        <button
                :disabled="pageNumber > pageCount -1"
                @click="nextPage">
            Suivant
        </button>

        <div v-if="clients !== null">
            <!--<span style="cursor: pointer;"><h2><strong><a @click.prevent="clientClicked">{{ '+' }}</a> &nbsp; Client </strong></h2></span>-->
            <div v-for="cl in clients" :key="cl.clientId">
                <span style="cursor: pointer;"><h3><strong><a @click.prevent="clientClicked(cl)">{{ cl.isVisible ? '-' : '+' }}</a>  Client : {{ cl.clientFirstName }} - {{ cl.clientLastName }}</strong></h3></span>

                <template v-if="cl.isVisible">
                    <div v-for="c in cl.contracts" :key="c.contractId">
                        <div style="margin-left: 3em; margin-top: -1em;">
                            <span style="cursor: pointer; margin-left: 30px;"><h4><strong><a
                                    @click.prevent="contractClicked(c)">{{ c.isVisible ? '-' : '+' }}</a> Contrat : {{ c.contractId }} - {{ formatDate(c.contractBeginDate) }} - {{ formatDate(c.contractEndDate) }}</strong></h4></span>
                        </div>

                        <template v-if="c.isVisible">
                            <div v-for="z in c.zones" :key="z.zoneId">
                                <div style="margin-left: 5em; margin-top: -1em;">
                                    <span style="cursor: pointer;"><h4><strong><a @click.prevent="zoneClicked(z)">{{z.isVisible ? '-' : '+'}}</a> Zone : {{ z.zoneId }} - {{ z.zoneName }}</strong></h4></span>
                                </div>

                                <template v-if="z.isVisible">
                                    <div v-for="m in z.missions" :key="m.missionId">
                                        <div style="margin-left: 8em; margin-top: 1em;">
                                            <span style="cursor: pointer"><h4><strong> Mission : {{ m.missionId }} - {{ formatDate(m.missionBeginDate) }}</strong></h4></span>
                                        </div>

                                    </div>
                                </template>
                            </div>
                        </template>
                    </div>
                </template>
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

    export default {
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
                return DateTime.fromISO(date).toFormat('dd/LL/yyyy');
            }
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