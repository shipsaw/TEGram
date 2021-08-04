import axios from 'axios';

export default {

    login(user) {
        return axios.post('/login', user)
    },

    register(user) {
        return axios.post('/register', user)
    }

    //Get sample of 50 recent photos
    //get photos by user
    //POST for new photos
    //delete
    //add, delete favorites from favorite list




}