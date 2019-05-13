<template>
    <section class="phot">
        <div class="container">
            <h1 class="jumbotron-heading">Bienvenue sur SekurTek</h1>
            <select v-on:change="getContratList($event)">
                <option v-for="c in clientList" :value="c.clientId"> <div v-if=" typeof c === 'string'"> {{c}} </div> <div v-else>@{{c.firstName + " " + c.lastName}}</div> </option>
            </select>
            <br>


            <div v-if ="contratList.length >0">
                <select v-on:change="getZoneList($event)">
                    <option v-for="c in contratList" :value="c.contratId"> <div v-if="typeof c === 'string'"> {{c}} </div> <div v-else>{{c.beginDate + " " + c.endDate}}</div> </option>
                </select>
                <br>
            </div>
            <br>

            <div v-if ="zoneList.length >0">
                <select v-on:change="getMissionList($event)">
                    <option v-for="z in zoneList" :value="z.zoneId"> <div v-if="typeof z === 'string'"> {{z}} </div> <div v-else>@{{z.zoneName }} </div> </option>
                </select>
                <br>
            </div>

            <div v-if ="missionList.length >0">
                <select v-on:change="NeedToBeImplemented($event)">
                    <option v-for="m in missionList" :value="m.missionId">  <div v-if="typeof m === 'string'"> {{m}} </div> <div v-else>@{{m }} </div> </option>
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
            this.clientList.push("select a client");
            let clients  = await getClientListAsync();
            for (let i of clients) this.clientList.push(i);

        },

        methods: {
            async getContratList($event) {
                this.contratList = [];
                this.contratList.push("choose a contrat");
                let contrats = await getContratByClientId(parseInt(event.target.value));
                for( let i of contrats) this.contratList.push(i);
                this.zoneList = [];
                this.missionList = [];
            },
            async getZoneList($event) {
                this.zoneList.push("Select a zone");
                let zones = await getZoneByContratId(parseInt(event.target.value));
                for( let i of zones) this.zoneList.push(i);
                this.missionList = [];
            },

            async getMissionList($event) {
                this.missionList.push("Select a mission");
                let missions = await getMissionByZoneId(parseInt(event.target.value));
                for( let i of missions) this.missionList.push(i);


            },
        }
    }
</script>

<style lang="scss">

</style>