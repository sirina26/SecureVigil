<template>
    <div>
        <div class="mb-4">
            <h1 v-if="mode == 'create'">Créer une zone</h1>
            <h1 v-else>Editer Un contrat</h1>
        </div>

        <form @submit="onSubmit($event)">

            <template v-if="item !== null">
                <div class="form-group">
                    <input type="text" v-model="item.clientId" class="form-control" required>
                </div>   

                <select class=form-control>
                    <label class="required">Nom de client</label>
                    
                    <option value=un>Un</option>
                    <option value=deux>Deux</option>
                    <option value=trois>Trois</option>
                </select>

                <div class="form-group">
                    <label class="required">Date de début</label>
                    <input type="date" v-model="item.beginDate" class="form-control" required>
                </div>  

                <div class="form-group">
                    <label class="required">Date de fin</label>
                    <input type="date" v-model="item.endDate" class="form-control" required>
                </div>  

            <button type="submit" class="btn btn-primary">Sauvegarder</button>
            </template>
        </form>
        
    </div>
</template>

<script>
    import { getContratAsync, createContratAsync, updateContratAsync } from '../../api/contratApi'
    import { DateTime } from 'luxon'

    export default {
        data () {
            return {
                item: {},
                mode: null,
                contratid: null,
                errors: [],
            }
        },

        async mounted() {
            
            this.mode = this.$route.params.mode;
            this.contratid = this.$route.params.id;
            if(this.mode == 'edit') {
                try {
                    const item = await getContratAsync(this.Contratid);
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
                            await createContratAsync(this.item);
                        }
                        else {
                            await updateContratAsync(this.item);
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