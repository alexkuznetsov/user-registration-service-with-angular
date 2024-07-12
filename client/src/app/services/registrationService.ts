import { Injectable } from "@angular/core";

@Injectable({
    providedIn: "root",
})
export class RegistrationService {
    private state?: any;

    savePersonal(value: any) {
        if (!this.state) {
            this.state = {};
        }
        this.state.personal = value;
    }

    saveLocation(value: any) {
        if (!this.state) {
            this.state = {};
        }
        this.state.location = value;
    }

    clear() {
        this.state = {};
    }

    val() {
        return this.state;
    }
}
