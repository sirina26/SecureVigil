<template>
    <div class="main-content">
        <div class="main-content-inner">
            <div  id="breadcrumbs">
                <ul class="breadcrumb">
                    <li>
                        <i class="ace-icon fa fa-home home-icon"></i>
                        <a href="index">Accueil</a>
                    </li>

                </ul><!-- /.breadcrumb -->

            </div>
            <div class="page-content">

                <div align="center">
                    <img src="assets/images/sekurtek.png"/>

                </div>

            </div>
        </div>
    </div>
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
                vigileList: [],
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