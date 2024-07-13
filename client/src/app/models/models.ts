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
