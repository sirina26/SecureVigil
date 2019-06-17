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
                            Gestion des vigiles
                        </small>
                    </h1>
                </div><!-- /.page-header --><br/>


                <div>
                    <div class="mb-4">
                        <h1 v-if="mode == 'create'">Ajouter un vigile</h1>
                        <h1 v-else>Editer un vigile</h1>
                    </div>

                    <form @submit="onSubmit($event)">

                        <template v-if="item !== null">

                            <div class="form-group">
                                <label class="required col-sm-2">Nom </label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.lastName" class="form-control" required>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="required col-sm-2">Prénom </label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.firstName" class="form-control" required>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="required col-sm-2">Téléphone </label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.phone" class="form-control" required>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="required col-sm-2">Adresse </label>
                                <div class="col-xs-12">
                                    <input type="text" v-model="item.adresse" class="form-control" required>
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
    import {createVigileAsync} from '../../api/VigilApi'


    export default {
        data () {
            return {
                isDisplayed: false,
                item: {},
                vigileid: null,
                errors: [],
            }
        },

        props:{
            mode: null
        },

        async mounted() {
            this.mode = this.$route.params.mode;
            this.vigileid = this.$route.params.id;
            if(this.mode == 'edit') {
                try {
                    console.log("this item"+this.item.firstName);
                    const item = await getVigileAsync(this.vigileid);
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
                            await createVigileAsync(this.item);                                                    
                        }
<<<<<<< HEAD
                        this.$emit("refreshList")
=======

                        this.$router.replace('/vigile');
>>>>>>> 0b1bea8534b2a19474a2821ecfd4dffe7ae56252

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