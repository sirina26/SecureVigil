<template>
    <div>
        <div class="mb-4">
            <h1 v-if="mode == 'create'">Créer un client</h1>
            <h1 v-else>Editer profil d'un client</h1>
        </div>

        <form @submit="onSubmit($event)">

            <template v-if="item !== null">
                <div class="form-group">
                    <label class="required">Nom</label>
                    <input type="text" v-model="item.lastName" class="form-control" required>
                </div>   

                 <div class="form-group">
                    <label class="required">Prénom </label>
                    <input type="text" v-model="item.firstName" class="form-control" required>
                </div>  

                <div class="form-group">
                    <label class="required">Numéro de téléphone</label>
                    <input type="text" v-model="item.clientPhone" class="form-control" required>
                </div>  

                 <div class="form-group">
                    <label class="required">Adresse</label>
                    <input type="text" v-model="item.clientAdresse" class="form-control" required>
                </div>           
               
            <button type="submit" class="btn btn-primary">Sauvegarder</button>
            </template>
        </form>
    </div>
</template>

<script>
    import { getClientAsync, createClientAsync, updateClientAsync } from '../../api/clientApi'
    import { DateTime } from 'luxon'

    export default {
        data () {
            return {
                item: {},
                mode: null,
                clientid: null,
                errors: [],
            }
        },

        async mounted() {
            
            this.mode = this.$route.params.mode;
            this.clientid = this.$route.params.id;
            if(this.mode == 'edit') {
                try {
                    const item = await getClientAsync(this.clientid);
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
                            await createClientAsync(this.item);
                        }
                        else {
                            await updateClientAsync(this.item);
                            debugger;
                        }

                        this.$router.replace('./');
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