import { Routes } from "@angular/router";
import { HomePageComponent } from "./pages/home-page/home-page.component";
import { LoginComponent } from "./pages/login/login.component";
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
