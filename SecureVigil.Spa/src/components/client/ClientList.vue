<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Gestion de client </h1>
            <div>
                <router-link class="btn btn-primary" :to="`./create`"><i class="fa fa-plus"></i> Ajouter un client </router-link>
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

                <tr  v-for="i of clientList">
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
    </div>
</template>

<script>
    import { getClientAsync,getClientListAsync, deleteClientAsync } from '../../api/clientApi'
    import AuthService from '../../services/AuthService'
    //import {getUserIdAsync, getUserTypeAsync} from'../../api/UserApi'
    import {getUserIdAsync} from'../../api/UserApi'

    export default {
        data() {
            return {
                clientList:[],
                pageNumber: 0, 
                id : 0,
            }
        },
        props:{
            size:{
                 clientList:{
                type:Array,
                required:true
            },
            //type:Number,
            required:false,
            default: 4
            }
        },
        async mounted() {
           
            await this.refreshList();
            this.id = await getUserIdAsync();     
//            this.type = await getUserTypeAsync();  
             
            if(this.mode == 'edit') {
                try {
                    const item = await getUserIdAsync(this.id);
                     
                    // Here we transform the date, because the HTML date input expect format "yyyy-MM-dd"
                    
                    this.item = item;
                }
                catch(e) {
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
                    console.log(this.clientList);
                    // console.log(this.commentList.propositionDate);
                }
                catch(e) {
                    console.error(e);
                }
            },

            async deleteClient(clientId) {
                try {
                    await deleteClientAsync(clientId);
                    await this.refreshList();
                }
                catch(e) {
                    console.error(e);
                }
            },

            nextPage(){
                 this.pageNumber++;
            },
            
            prevPage(){
                this.pageNumber--;
            }
        },
        computed:
        {
            auth: () => AuthService,
            pageCount(){  
                if(this.clientList !== "undefined")          
                {
                    let l = this.clientList.length,
                    s = this.size;
                    console.log(this.clientList.values);
                    return Math.floor(l/s);
                }
                
            },
            paginatedData(){
                const start = this.pageNumber * this.size,
                end = start + this.size;
                return this.clientList.slice(start, end);
            } 
        }  
     }
</script>

<style lang="scss">

</style>