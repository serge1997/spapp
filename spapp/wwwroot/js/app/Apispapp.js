class ApiSpApp {
    #baseURL = "https://localhost:7089/api/";
    constructor() { }

    get(url, params) {
        return axios.get(`${this.#baseURL}${url}`, { params: params })
    }
}

const ApiSpapp = new ApiSpApp();