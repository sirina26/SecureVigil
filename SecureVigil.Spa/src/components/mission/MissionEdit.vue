<template>
    <div>
        <div class="mb-4">
            <h1 v-if="mode == 'create'">Ajouter une mission</h1>
            <h1 v-else>Editer une mission</h1>
        </div>

        <form @submit="onSubmit($event)">

            <template v-if="item !== null">
                <div class="form-group">
                    <label class="required">Début Mission</label>
                    <input type="datetime-local" v-model="item.beginDate" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Fin Mission</label>
                    <input type="datetime-local" v-model="item.endDate" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Objet de Mission</label>
                    <input type="text" v-model="item.missionRules" class="form-control" required>
                </div>


                <button type="submit" class="btn btn-primary">Sauvegarder</button>
            </template>
        </form>
    </div>
</template>

<script>
    import {createMissionAsync} from "../../api/MissionApi";

    export default {
        props: {
            zoneId:{
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

            this.item.zoneId = this.zoneId
            this.mode = this.$route.params.mode;
            this.missionId = this.$route.params.id;
            if(this.mode == 'edit') {
                try {
                    const item = await getMissionAsync(this.zoneid);
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
                            this.item.zoneId = this.$route.params.id;
                            await createMissionAsync(this.item);
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