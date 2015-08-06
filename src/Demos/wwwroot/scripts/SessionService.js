import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-http-client';

@inject(HttpClient)
export default class SessionService
{
    constructor (http) {
        this.http = http;
    }

    getSessions() {
        return this.http.get('/api/sessions/list');
    }
}