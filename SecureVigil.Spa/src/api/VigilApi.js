import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/vigil";



export async function createVigileAsync(model) {
    return await postAsync(endpoint, model);
}


export async function getVigileListAsync() {
    return await getAsync(endpoint);
}
