<template>
    <section class="phot">
        <div class="container">
            <h1 class="jumbotron-heading">Bienvenue sur Secure Vigil</h1>
            <p>
                {{ContratList}}
             
            </p>
        </div>
    </section>
</template>


<script>
import {getAllContratAsync} from "../api/ContratApi";

export default {

    data() {
        return {
            ContratList: [],
        }
    },
    
    async mounted() {
        this.ContratList = await getAllContratAsync();
    }
}
</script>
<style type="text/css" lang="scss">
.phot{
    background-size: cover
}

</style>