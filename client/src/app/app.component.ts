import { RouterOutlet } from "@angular/router";
import { Component } from "@angular/core";
import { APP_BASE_HREF } from "@angular/common";
import { environment } from "../environments/environment";

@Component({
    selector: "app-root",
    standalone: true,
    imports: [RouterOutlet],
    templateUrl: "./app.component.html",
    styleUrl: "./app.component.css",
})
export class AppComponent {
    title = "client";
}
