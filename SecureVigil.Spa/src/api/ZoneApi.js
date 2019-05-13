import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/zone";



export async function getZoneByContratId(id) {
    return await getAsync(`${endpoint}/contrat/${id}`);
}
