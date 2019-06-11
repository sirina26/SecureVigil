<template>

    <div class="main-content">
        <div class="main-content-inner">
            <div  id="breadcrumbs">
                <ul class="breadcrumb">
                    <li>
                        <i class="ace-icon fa fa-home home-icon"></i>
                        <a href="index">Accueil</a>
                    </li>

                    <li class="active">Zone</li>

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


                <div>
                    <div class="mb-4">
                        <h1 v-if="mode == 'create'">Créer une Zone</h1>
                        <h1 v-else>Editer une Zone</h1>
                    </div>

                    <form @submit="onSubmit($event)">

                        <template v-if="item !== null">
                            <div class="form-group">
                                <label class="required col-sm-2">Nom</label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.zoneName" class="form-control" required>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="required col-sm-2">Adresse</label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.zoneAdresse" class="form-control" required>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="required col-sm-2">Nombre Agent Jour </label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.nbrAgentJour" class="form-control" required>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="required col-sm-2">Nombre Agent Nuit </label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.nbrAgentNuit" class="form-control" required>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="required col-sm-2">Nombre Chien Jour </label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.nbrChienJour" class="form-control" required>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="required col-sm-2">Nombre Chien Nuit </label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.nbrChienNuit" class="form-control" required>
                                </div>
                            </div>

                            <p></p>

                            <div class="form-group col-xs-12">
                                <br>
                                <div class=" modal-footer no-margin-top col-xs-12">
                                    <button type="reset" class="btn btn-danger">Annuler</button>
                                    <button type="submit" class="btn btn-success">Enregistrer</button>

                                </div>
                            </div>

                        </template>


                    </form>

                </div>


            </div>


        </div>
    </div>

</template>


<script>
    import {createZoneAsync} from "../../api/ZoneApi";

    export default {
        props: {
            contratId:{
                type: Number,
                default: null
            }
        },

        data () {
            return {
                item: {},
                mode: null,
                zoneid: null,
                errors: [],
            }
        },

        async mounted() {

            this.item.contratId = this.contratId
            this.mode = this.$route.params.mode;
            this.zoneId = this.$route.params.id;
            if(this.mode == 'edit') {
                try {
                    const item = await getZoneAsync(this.zoneid);
                    this.item = item;

                }
                catch(e) {
                    console.error(e);
                    this.$router.replace('./');
                }
            }
            console.log(this.item);

        },

        methods: {
            async onSubmit(e) {
                e.preventDefault();

                var errors = [];
                //this.errors = errors;

                if(errors.length == 0) {
                    try {
                        if(this.mode == 'create') {
                            this.item.contratId = this.$route.params.id;
                            await createZoneAsync(this.item);
                        }
                        else {
                            await updateZoneAsync(this.item);
                            debugger;
                        }

                        this.$router.replace('/client');
                    }
                    catch(e) {
                        console.error(e);
                    }
                }
            }
        }
    }
</script>

<style lang="scss">

</style>