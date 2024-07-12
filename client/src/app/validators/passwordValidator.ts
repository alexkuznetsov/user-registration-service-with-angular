import { AbstractControl, ValidationErrors } from "@angular/forms";

export class PasswordValidator {
    static validateMatching(control: AbstractControl): ValidationErrors | null {
        const password = control.get("password")?.value;
        const passwordConfirm = control.get("passwordConfirm")?.value;

        // Check if passwords are matching. If not then add the error 'passwordsNotMatching: true' to the form
        if (
            password === passwordConfirm &&
            password !== null &&
            passwordConfirm !== null
        ) {
            return null;
        } else {
            return { passwordsNotMatching: true };
        }
    }

    static validateComplexity(
        control: AbstractControl
    ): ValidationErrors | null {
        const password = control.get("password")?.value;

        if (password !== null && check(password)) {
            return null;
        } else {
            return { passwordsComplexity: true };
        }

        function check(password: string): boolean {
            const r = /^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$/;

            return r.test(password);
        }
    }
}
