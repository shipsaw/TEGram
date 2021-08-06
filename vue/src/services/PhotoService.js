import axios from 'axios';
import store from '../store/index'

const http = axios.create({
    baseURL: "https://localhost:44315"
});

export default {

    get(id) {
        return http.get(`/api/User/${id}`, {
            headers: { "Authorization": `Bearer ${store.state.token}` }
        })
    },

    getPhotos() {
        return http.get(`/api/photo/feed`, {
            headers: { "Authorization": `Bearer ${store.state.token}` }
        })
    },

    updateUserLikes(id) {
        return http.put(`/api/Photo/${id}`, {
            headers: { "Authorization": `Bearer ${store.state.token}` }},
            { params: { action: id } }
        )
    }
}