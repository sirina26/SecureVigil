import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/vigil";



export async function createVigileAsync(model) {
    return await postAsync(endpoint, model);
}


export async function getVigileListAsync() {
    return await getAsync(endpoint);
}

export async function updateVigilAsync(model) {
    return await putAsync(`${endpoint}/${model.vigilId}`, model);
}

export async function deleteClientAsync(clientId) {
    return await deleteAsync(`${endpoint}/${clientId}`);
}

