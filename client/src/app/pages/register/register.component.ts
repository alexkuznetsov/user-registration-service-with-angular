import {
    FormGroup,
    FormControl,
    Validators,
    FormsModule,
    ReactiveFormsModule,
} from "@angular/forms";
import { Component } from "@angular/core";
import { Router, RouterLink } from "@angular/router";
import { MatToolbar } from "@angular/material/toolbar";
import { MatCard, MatCardContent, MatCardTitle } from "@angular/material/card";
import { MatError, MatFormField, MatHint } from "@angular/material/form-field";
import { MatIcon } from "@angular/material/icon";
import { NgIf } from "@angular/common";
import { MatInput } from "@angular/material/input";
import { MatCheckbox } from "@angular/material/checkbox";
import { PasswordValidator } from "../../validators/passwordValidator";
import { RegistrationService } from "../../services/registrationService";
import { MatButtonModule } from "@angular/material/button";

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
        MatButtonModule,
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
        },
        // add custom Validators to the form, to make sure that password and passwordConfirm are equal
        {
            validators: [
                PasswordValidator.validateMatching,
                PasswordValidator.validateComplexity,
            ],
        }
    );

    constructor(
        private router: Router,
        private registrationService: RegistrationService
    ) {}

    register() {
        if (!this.registerForm.valid) {
            return;
        } else {
            this.registrationService.savePersonal(this.registerForm.value);
            this.router.navigate(["/location"]);
        }
    }
}
