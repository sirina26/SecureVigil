<template>
    <section class="phot">
        <div class="container">
            <h1 class="jumbotron-heading">Bienvenue sur SekurTek</h1>
            <select>
                <option v-for="c of clientList" @click="getcontratList(c.clientId)"/>
            </select>
            <br>


            <div v-if ="contratList.length >0">
                <select>
                    <option v-for="c of contratList" @click="getZoneList(c.contratId)"></option>
                </select>
                <br>
            </div>
            <p>
             
            </p>
        </div>
    </section>
</template>



<script>

    import { getClientListAsync } from '../api/clientApi'
    import { getContratByClientId } from '../api/ContratApi'
    import { getZoneByContratId } from '../api/ZoneApi'
    import { getMissionByZoneId } from '../api/MissionApi'

    export default {
        data() {
            return {
                clientList : [],
                contratList:[],
                zoneList : [],
                missionList: [],
            }
        },
        async mounted () {
            this.clientList  = await getClientListAsync();

        },
        async getcontratList (id) {this.contratList = await getContratByClientId(id)}
    }
</script>

<style lang="scss">

</style>