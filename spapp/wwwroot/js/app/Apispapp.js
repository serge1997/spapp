class ApiSpApp {
    #baseURL = "https://localhost:7089/api/";
    constructor() { }

    get(url, params) {
        return axios.get(`${this.#baseURL}${url}`, { params: params })
    }

    put(url, data = null, params = null) {
        return axios.put(`${this.#baseURL}${url}`, data, { params: params })
    }

    post(url, data) {
        return axios.post(`${this.#baseURL}${url}`, data);
    }
}

const ApiSpapp = new ApiSpApp();