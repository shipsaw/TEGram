import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import HomeFeed from '@/components/HomeFeed.vue'
import Gallery from '@/views/Gallery.vue'
import FavoriteList from '@/components/FavoriteList.vue'
import UploadPhoto from '@/components/UploadPhoto.vue'
import PhotoDetails from '@/components/PhotoDetails.vue'
import FriendGallery from '@/views/FriendGallery.vue'


Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [{
            path: '/',
            name: 'home',
            component: Home,
            meta: {
                requiresAuth: true
            }
        },
        {
            path: "/login",
            name: "login",
            component: Login,
            meta: {
                requiresAuth: false
            }
        },
        {
            path: "/logout",
            name: "logout",
            component: Logout,
            meta: {
                requiresAuth: false
            }
        },
        {
            path: "/register",
            name: "register",
            component: Register,
            meta: {
                requiresAuth: false
            }
        },
        {
            path: "/api/User/feed",
            name: "pic-feed",
            component: HomeFeed,
            meta: {
                requiresAuth: false
            }

        },
        {
            path: "/api/User/gallery",
            name: "user-gallery",
            component: Gallery,
            meta: {
                requiresAuth: false
            }
        },
        {
            path: "/api/User/favorites",
            name: "user-faves",
            component: FavoriteList,
            meta: {
                requiresAuth: false
            }
        },
        {
            path: "/api/User/newPhoto",
            name: "new-photo",
            component: UploadPhoto,
            meta: {
                requiresAuth: false
            }
        },
        {
            path: "/api/User/details/:id",
            name: "full-details",
            component: PhotoDetails,
            meta: {
                requiresAuth: false
            }
        },

        {
            path: "/api/User/:id",
            name: 'friends-gallery',
            component: FriendGallery,
            meta: {
                requiresAuth: false
            }
        },

        {
            path: "api/photo",
            name: 'photo',
            component: UploadPhoto,
            meta: {
                requiresAuth: false
            }
        }

    ]
})



router.beforeEach((to, from, next) => {
    // Determine if the route requires Authentication
    const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

    // If it does and they are not logged in, send the user to "/login"
    if (requiresAuth && store.state.token === '') {
        next("/login");
    } else {
        // Else let them go to their next destination
        next();
    }
});

export default router;