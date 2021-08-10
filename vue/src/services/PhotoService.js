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
        return http.get(`/api/user/${id}`, {
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

    addProfilePhoto(profilePhotoURL, id) {
        return http.post(`/api/user/${id}/profile`, "\"" + profilePhotoURL + "\"", {
            headers: { "Content-Type": "application/json", "Authorization": `Bearer ${store.state.token}` }
        })
    },

    addGalleryPhoto(galleryPhotoURL) {
        return http.post(`/api/photo`, "\"" + galleryPhotoURL + "\"", {
            headers: { "Content-Type": "application/json", "Authorization": `Bearer ${store.state.token}` }
        })
    },

    addNewComment(comment, id) {
        return http.post(`/api/photo/${id}/comment`, "\"" + comment + "\"", {
            headers: { "Content-Type": "application/json", "Authorization": `Bearer ${store.state.token}` }
        })
    }

}