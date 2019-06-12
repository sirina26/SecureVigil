<template>
    <div class="">
        <div class="mb-4">
            <h1 v-if="mode == 'create'">Créer un vigile</h1>
            <h1 v-else>Editer profil d'un vigile</h1>
        </div>


        <form @submit="onSubmit($event)">

            <template v-if="item !== null">
                <div class="form-group">
                    <label class="required col-sm-2">Nom</label>
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
                    <label class="required col-sm-2">Téléphone</label>
                    <div class="col-xs-12">
                        <input type="text" v-model="item.phone" class="form-control" required>
                    </div>
                </div>

                <div class="form-group">
                    <label class="required col-sm-2">Adresse</label>
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

                        this.$emit("refreshList")

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