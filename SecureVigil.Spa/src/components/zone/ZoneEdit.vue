<template>
    <div>
        <div class="mb-4">
            <h1 v-if="mode == 'create'">Créer une zone</h1>
            <h1 v-else>Editer une zone</h1>
        </div>

        <form @submit="onSubmit($event)">

            <template v-if="item !== null">
                <div class="form-group">
                    <label class="required">Nom</label>
                    <input type="text" v-model="item.zoneName" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Adresse </label>
                    <input type="text" v-model="item.zoneAdresse" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Longitude</label>
                    <input type="text" v-model="item.longitude" class="form-control" required>
                </div>

                <div class="form-group">
                    <label class="required">Latitude</label>
                    <input type="text" v-model="item.latitude" class="form-control" required>
                </div>

                <div class="form-group">
                    <select id="pet-select">
                        <option value="">--Sélectionner--</option>
                        <option value="dog">Dog</option>
                    </select>
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
                zoneid: null,
                errors: [],
            }
        },

        async mounted() {

            this.mode = this.$route.params.mode;
            this.zoneid = this.$route.params.id;
            if(this.mode == 'edit') {
                try {
                    const item = await getZoneAsync(this.zoneid);
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
                            await createZoneAsync(this.item);
                        }
                        else {
                            await updateZoneAsync(this.item);
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