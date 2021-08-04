import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
});

export default {

    get(id) {
        return http.get(`/api/User/${id}`)
    }
}