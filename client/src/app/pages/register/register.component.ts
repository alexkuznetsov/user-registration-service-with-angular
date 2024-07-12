import {
    FormGroup,
    FormControl,
    Validators,
    FormsModule,
    ReactiveFormsModule,
} from "@angular/forms";
import { Component, OnInit } from "@angular/core";
//import { CustomValidators } from '../../custom-validator';
//import { AuthService } from '../../services/auth-service/auth.service';
import { tap } from "rxjs";
import { Router, RouterLink } from "@angular/router";
import { MatToolbar } from "@angular/material/toolbar";
import { MatCard, MatCardContent, MatCardTitle } from "@angular/material/card";
import { MatError, MatFormField, MatHint } from "@angular/material/form-field";
import { MatIcon } from "@angular/material/icon";
import { NgIf } from "@angular/common";
import { MatInput } from "@angular/material/input";
import { MatCheckbox } from "@angular/material/checkbox";

@Component({
    selector: "app-register",
    templateUrl: "./register.component.html",
    styleUrls: ["./register.component.css"],
    standalone: true,
    imports: [
        FormsModule,
        MatCardTitle,
        MatCardContent,
        RouterLink,
        MatInput,
        MatToolbar,
        MatCard,
        MatFormField,
        MatIcon,
        MatError,
        MatHint,
        ReactiveFormsModule,
        NgIf,
        MatCheckbox,
    ],
})
export class RegisterComponent {
    registerForm = new FormGroup(
        {
            email: new FormControl(null, [
                Validators.required,
                Validators.email,
            ]),
            password: new FormControl(null, [Validators.required]),
            passwordConfirm: new FormControl(null, [Validators.required]),
            isAgree: new FormControl(null, []),
        }
        // add custom Validators to the form, to make sure that password and passwordConfirm are equal
        //{ validators: CustomValidators.passwordsMatching }
    );

    constructor(
        private router: Router //private authService: AuthService
    ) {}

    register() {
        if (!this.registerForm.valid) {
            console.log("form is invalid");
            return;
        } else {
            console.log("form valid");
            console.log("val", this.registerForm.value);
        }
        // this.authService.register(this.registerForm.value).pipe(
        //   // If registration was successfull, then navigate to login route
        //   tap(() => this.router.navigate(['../login']))
        // ).subscribe();
    }
}
