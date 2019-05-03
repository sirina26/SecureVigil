<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Gestion de contrat </h1>
            <div>
                <router-link class="btn btn-primary" :to="`./create`"><i class="fa fa-plus"></i> Ajouter un contrat </router-link>
            </div>
        </div>

        <table class="table table-striped table-hover table-bordered">
       <thead>
                <tr> 
                    <th>Nom</th>                                  
                    <th>Prénom</th>               
                    <th>Date de début</th>               
                    <th>Date de fin</th>               
                </tr>
            </thead>

            <tbody>
                <tr v-if="contratList.length == 0">
                    <td colspan="6" class="text-center">Il n'y a actuellement aucun contrat.</td>
                </tr>

                <tr  v-for="i of contratList">
                    <td>{{ i.firstName }}</td>     
                    <td>{{ i.lastName }}</td>                    
                    <td>{{ i.beginDate}}</td>                                   
                    <td>{{ i.endDate }}</td>                    
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
    import { getContratAsync,getContratListAsync, deleteContratAsync } from '../../api/contratApi'
    import AuthService from '../../services/AuthService'
    //import {getUserIdAsync, getUserTypeAsync} from'../../api/UserApi'
    import {getUserIdAsync} from'../../api/UserApi'

    export default {
        data() {
            return {
                contratList:[],
                pageNumber: 0, 
                id : 0,
            }
        },
        props:{
            size:{
                contratList:{
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
                    this.$router.replace('/contrat');
                }
            }

        },

        methods: {
            
            async refreshList() {
                try {   
                    // this.commentList = await getCommentListAsync();
                    this.contratList = await getContratListAsync();
                    console.log(this.contratList);
                    // console.log(this.commentList.propositionDate);
                }
                catch(e) {
                    console.error(e);
                }
            },

            async deleteContrat(contratId) {
                try {
                    await deleteContratAsync(contratId);
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
                if(this.contratList !== "undefined")          
                {
                    let l = this.contratList.length,
                    s = this.size;
                    console.log(this.contratList.values);
                    return Math.floor(l/s);
                }
                
            },
            paginatedData(){
                const start = this.pageNumber * this.size,
                end = start + this.size;
                return this.contratList.slice(start, end);
            } 
        }  
     }
</script>

<style lang="scss">

</style>