import axios from 'axios';

const http = axios.create({
    baseURL: "http://localhost:53041"
});

export default {

    get(id) {
        return http.get(`/api/User/${id}`)
    }
}