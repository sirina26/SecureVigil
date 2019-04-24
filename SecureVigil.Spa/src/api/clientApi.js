import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/client";

export async function getClientListAsync() {
    return await getAsync(endpoint);
}

export async function getIdAsync(email) {
    return await getAsync(`${endpoint}/${email}`);
}

export async function getClientAsync(clientId) {
    return await getAsync(`${endpoint}/${clientId}`);
}

export async function createClientAsync(model) {
    return await postAsync(endpoint, model);
}

export async function updateClientAsync(model) {
    return await putAsync(`${endpoint}/${model.clientId}`, model);
}

export async function deleteClientAsync(clientId) {
    return await deleteAsync(`${endpoint}/${clientId}`);
}

