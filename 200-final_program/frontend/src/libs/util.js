import axios from 'axios';
import config from '../../my_config.json'

let util = {

};
util.title = function (title) {
    title = title ? title + ' - ' + config.base.name : config.base.name;
    window.document.title = title;
};

const ajaxUrl = '/api/';

util.ajaxUrl = ajaxUrl;

export default util;
