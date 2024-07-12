import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";

@Injectable({
    providedIn: "root",
})
export class ApiService {
    constructor(private httpClient: HttpClient) {}

    loadCountries(): Observable<GetCountriesResponse> {
        let base = environment.BASE_URL;
        let re = this.httpClient.get<GetCountriesResponse>(
            `${base}/api/countries`
        );
        return re;
    }

    loadProvinces(countryId: string): Observable<GetProvincesResponse> {
        let base = environment.BASE_URL;
        let re = this.httpClient.get<GetProvincesResponse>(
            `${base}/api/provinces/${countryId}`
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
            `${base}/api/register`,
            model,
            {
                headers: h,
                responseType: "json",
            }
        );
    }
}

export type SaveRegistrationResponse = {
    status: boolean;
    message?: string;
};

export type GetCountriesResponse = {
    status: boolean;
    records: CountryModel[];
};

export type GetProvincesResponse = {
    status: boolean;
    records: ProvinceModel[];
};

export type CountryModel = {
    id: string;
    name: string;
};

export type ProvinceModel = {
    id: string;
    name: string;
};
