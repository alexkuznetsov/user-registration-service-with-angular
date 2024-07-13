import { Routes } from "@angular/router";
import { RegisterComponent } from "./pages/register/register.component";
import { SetLocationComponent } from "./pages/set-location/set-location.component";

export const routes: Routes = [
    {
        path: "",
        component: RegisterComponent,
    },
    {
        path: "location",
        component: SetLocationComponent,
    },
];
