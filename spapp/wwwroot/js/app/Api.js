export class Api {
    baseUrl = location.href + "/api";

    constructor() { }

    async get(url, params) {
        return axios.get(url, { params: params });
    }
    
}