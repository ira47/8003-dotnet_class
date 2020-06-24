import axios from 'axios';

var state = {
};

const mutations = {
};

const actions = {
    insert ({ commit }, { book, callback}) {
        axios.post('/book/new', book)
            .then((rsp) => {
                rsp = rsp.data;
                callback(rsp);
            })
            .catch((error) => {
                callback(null, error);
                console.error(error.message);
            });
    },
    set({ commit }, { book, callback}) {
        axios.post('/book/set', book)
            .then((rsp) => {
                rsp = rsp.data;
                callback(rsp);
            })
            .catch((error) => {
                callback(null, error);
                console.error(error.message);
            });
    },
    remove({ commit }, { id, callback }) {
        axios.post('/book/del', { id })
            .then((rsp) => {
                rsp = rsp.data;
                callback(rsp);
            })
            .catch((error) => {
                callback(null, error);
                console.error(error.message);
            });
    },
    get ({ commit }, { id, callback}) {
        axios.get('/book/get/' + id)
            .then((rsp) => {
                rsp = rsp.data;
                callback(rsp);
            })
            .catch((error) => {
                callback(null, error);
                console.error(error.message);
            });
    },
    query({ commit }, { index, count = 10, query = {}, callback}) {
        axios.post('/book/query/', {
            index, count, query
        })
        .then((rsp) => {
            rsp = rsp.data;
            callback(rsp);
        })
        .catch((error) => {
            callback(null, error);
            console.error(error.message);
        });
    },
    read({ commit }, { read, callback }) {
        axios.post('/read/new/', read)
        .then((rsp) => {
            rsp = rsp.data;
            callback(rsp);
        })
        .catch((error) => {
            callback(null, error);
            console.error(error.message);
        });
    }
};

const getters = {
};

export default {
    namespaced: true,
    state,
    mutations,
    getters,
    actions
};