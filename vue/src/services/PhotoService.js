import axios from 'axios';
import store from '../store/index'

const http = axios.create({
    baseURL: "https://capstonetegram.azurewebsites.net"
});

// export default {

//     get(id) {
//         return axios.get(`/api/User/${id}`)
//     },

//     getPhotos() {
//         return axios.get(`/api/Photo/feed`)
//     },

//     updateUserLikes(id) {
//         return axios.put(`/api/Photo/${id}`, {})
//     }
// }

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

    getPhotoById(id) {
        return http.get(`/api/photo/${id}`, {
            headers: { "Authorization": `Bearer ${store.state.token}` }
        })
    },

    getPhotoFaves() {
        return http.get(`/api/photo/favorites`, {
            headers: { "Authorization": `Bearer ${store.state.token}` }
        })
    },



    updateUserLikes(id) {

        return http.put(`/api/photo/${id}`, {

            headers: { "Authorization": `Bearer ${store.state.token}` }
        }, { params: { action: 'like' } })

    },

    updateUserFavorites(id) {

        return http.put(`/api/photo/${id}`, {

            headers: { "Authorization": `Bearer ${store.state.token}` }
        }, { params: { action: 'favorite' } })


    },

    // addNewPhoto(id) {
    //     return http.put(`/api/Photo/like/${id}`, {
    //         headers: { "Authorization": `Bearer ${store.state.token}` }
    //     })
    // }

}