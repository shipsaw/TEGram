import axios from 'axios';
import store from '../store/index'

const http = axios.create({
    baseURL: "https://localhost:44315"
});

export default {

    get(id) {
        return http.get(`/api/User/${id}`)
    },

    getPhotos() {
        return http.get(`/api/User/feed`)
    },

    updateUserLikes(id) {
        return http.put(`/api/Photo/like/${id}`, {
            headers: { "Authorization": `Bearer ${store.state.token}` }
        })
    }
}