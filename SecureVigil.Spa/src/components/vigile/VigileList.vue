<template>
    <div class="main-content">
        <div class="main-content-inner">
            <div  id="breadcrumbs">
                <ul class="breadcrumb">
                    <li>
                        <i class="ace-icon fa fa-home home-icon"></i>
                        <a href="index">Accueil</a>
                    </li>

                    <li class="active">Vigile</li>

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
                    <a href="#modal-vigile" role="button" class="green" data-toggle="modal"><button class="btn btn-primary" > Enregistrer un vigile</button> </a>
                </h4>

                <br/>


                <table class="table table-striped table-hover table-bordered">
                    <thead>
                    <tr>
                        <th>Nom</th>
                        <th>Prénom</th>
                        <th>Téléphone</th>
                        <th>Adresse</th>
                    </tr>
                    </thead>

                    <tbody>
                    <tr v-if="vigileList.length == 0">
                        <td colspan="6" class="text-center">Il n'y a actuellement aucun vigile.</td>
                    </tr>

                    <tr v-for="v of vigileList">
                        <td>{{ v.firstName }}</td>
                        <td>{{ v.lastName }}</td>
                        <td>{{ v.phone}}</td>
                        <td>{{ v.adresse }}</td>
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


                <div id="modal-vigile" class="modal fade" tabindex="-1">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">

                            <div class="modal-body no-padding">
                                <vigile-edit :mode="'create'" v-on:refreshList="refreshList"></vigile-edit>
                            </div>

                        </div><!-- /.modal-content -->
                    </div><!-- /.modal-dialog -->
                </div>

            </div>
        </div>
    </div>
</template>

<script>
    import {createVigileAsync, getVigileListAsync} from '../../api/VigilApi'
    import AuthService from '../../services/AuthService'
    import {getUserIdAsync} from '../../api/UserApi'
    import DateTime from 'luxon/src/datetime.js'
    import VigileEdit from '../vigile/VigileEdit'

    export default {
        components:{
            VigileEdit
        },
        data() {
            return {
                vigileList: [],
                pageNumber: 0,
                id: 0,
                vigiles: null
            }
        },

        props: {
            size: {
                vigileList: {
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
                    this.$router.replace('/vigile');
                }
            }
        },

        methods: {
            async refreshList() {
                try {
                    // this.commentList = await getCommentListAsync();
                    this.vigileList = await getVigileListAsync();
                    // console.log(this.commentList.propositionDate);
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

            vigileClicked(vigile) {
                this.$set(vigile, 'isVisible', !vigile.isVisible);
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
                if (this.vigileList !== "undefined") {
                    let l = this.vigileList.length,
                        s = this.size;
                    console.log(this.vigileList.values);
                    return Math.floor(l / s);
                }

            },
            paginatedData() {
                const start = this.pageNumber * this.size,
                    end = start + this.size;
                return this.vigileList.slice(start, end);
            }
        }
    }
</script>

<style lang="scss">

</style>