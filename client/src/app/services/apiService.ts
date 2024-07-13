import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";
import {
    GetCountriesResponse,
    GetProvincesResponse,
    SaveRegistrationResponse,
} from "../models/models";

@Injectable({
    providedIn: "root",
})
export class ApiService {
    constructor(private httpClient: HttpClient) {}

    loadCountries(): Observable<GetCountriesResponse> {
        let base = environment.BASE_URL;
        let re = this.httpClient.get<GetCountriesResponse>(
            `${base}/api/v1/countries`
        );
        return re;
    }

    loadProvinces(countryId: string): Observable<GetProvincesResponse> {
        let base = environment.BASE_URL;
        let re = this.httpClient.get<GetProvincesResponse>(
            `${base}/api/v1/provinces/${countryId}`
        );
        return re;
    }

    register(data: {
        personal: {
            email: string;
            isAgree: boolean;
            password: string;
            passwordConfirm: string;
        };
        location: { country: string; province: string };
    }) {
        console.log("data", data);
        let model = {
            Login: data.personal.email,
            Password: data.personal.password,
            Password2: data.personal.passwordConfirm,
            AgreeToWork: data.personal.isAgree,
            ProvinceId: data.location.province,
        };

        let base = environment.BASE_URL;
        let h: HttpHeaders = new HttpHeaders();
        h.append("Content-Type", "application/json");
        return this.httpClient.post<SaveRegistrationResponse>(
            `${base}/api/v1/register`,
            model,
            {
                headers: h,
                responseType: "json",
            }
        );
    }
}
