import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/mission";



export async function getMissionByZoneId(id) {
    return await getAsync(`${endpoint}/zone/${id}`);
}

export async function getMissionTreeAsync() {
    return await getAsync(`${endpoint}/getMissionTree`);
}