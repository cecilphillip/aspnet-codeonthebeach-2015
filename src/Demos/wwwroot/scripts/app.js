import SessionService from 'scripts/SessionService';
import {inject} from 'aurelia-framework';

@inject(SessionService)
export class App {

    constructor(service) {
        this.service = service;
    }

    activate() {
        return this.service.getSessions()
            .then(resp => {
                this.sessions = resp.content;
            });
    }
}