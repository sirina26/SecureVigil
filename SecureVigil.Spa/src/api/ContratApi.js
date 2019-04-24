import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/user";


export async function getAllContratAsync() {
    return await getAsync(`${endpoint}/GetAll`);
}
