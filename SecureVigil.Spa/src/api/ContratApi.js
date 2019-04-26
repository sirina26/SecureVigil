import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/contrat";

export async function getContratListAsync() {
    return await getAsync(endpoint);
}

export async function getIdAsync(email) {
    return await getAsync(`${endpoint}/${email}`);
}

export async function getContratAsync(contratId) {
    return await getAsync(`${endpoint}/${contratId}`);
}

export async function createContratAsync(model) {
    return await postAsync(endpoint, model);
}

export async function updateContratAsync(model) {
    return await putAsync(`${endpoint}/${model.contratId}`, model);
}

export async function deleteContratAsync(contratId) {
    return await deleteAsync(`${endpoint}/${contratId}`);
}

