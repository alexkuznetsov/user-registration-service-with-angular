import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { RegistrationService } from "../../services/registrationService";
import {
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule,
    Validators,
} from "@angular/forms";
import {
    ApiService,
    CountryModel,
    ProvinceModel,
} from "../../services/apiService";
import { delay, map, Observable, of, Subject, switchMap, tap } from "rxjs";
import { MatError, MatFormField, MatLabel } from "@angular/material/form-field";
import { MatOption, MatSelect } from "@angular/material/select";
import { AsyncPipe, NgFor, NgIf } from "@angular/common";
import { MatCard, MatCardContent, MatCardTitle } from "@angular/material/card";
import {
    MatSnackBar,
    MatSnackBarRef,
    TextOnlySnackBar,
} from "@angular/material/snack-bar";
import { MatButton, MatButtonModule } from "@angular/material/button";

@Component({
    selector: "app-set-location",
    standalone: true,
    imports: [
        MatFormField,
        MatSelect,
        MatLabel,
        MatOption,
        NgFor,
        NgIf,
        AsyncPipe,
        MatCard,
        MatCardTitle,
        MatCardContent,
        MatError,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
    ],
    templateUrl: "./set-location.component.html",
    styleUrl: "./set-location.component.css",
})
export class SetLocationComponent implements OnInit {
    registerForm = new FormGroup(
        {
            country: new FormControl(null, [Validators.required]),
            province: new FormControl(null, [Validators.required]),
        },
        { validators: [] }
    );

    public countries: Subject<CountryModel[]> = new Subject();
    public provinces: Subject<ProvinceModel[]> = new Subject();

    constructor(
        private router: Router,
        private registrationService: RegistrationService,
        private api: ApiService,
        private _snackBar: MatSnackBar
    ) {
        this.countries.next([]);
        this.provinces.next([]);
    }

    ngOnInit(): void {
        let state = this.registrationService.val();
        if (!state?.personal) {
            this.router.navigate([""]);
        } else {
            this.api.loadCountries().subscribe((data) => {
                this.countries.next(data.records);
            });
        }
    }

    countryChanged() {
        let c = this.registerForm.get("country")?.value;
        this.provinces.next([]);
        this.registerForm.get("province")?.reset();
        this.api.loadProvinces(c + "").subscribe((data) => {
            this.provinces.next(data.records);
        });
    }

    register() {
        if (!this.registerForm.valid) {
            return;
        } else {
            this.registrationService.saveLocation(this.registerForm.value);
            let shackBarRef: MatSnackBarRef<TextOnlySnackBar>;
            this.api.register(<any>this.registrationService.val()).subscribe(
                (d) =>
                    of(d)
                        .pipe(
                            // If registration was successfull, then clear state
                            // and navigate to the first step
                            tap(() => {
                                shackBarRef = this._snackBar.open(
                                    "User registration success"
                                );
                            }),
                            delay(1000),
                            tap(() => {
                                shackBarRef.dismiss();
                            }),
                            tap(() => {
                                this.router.navigate([""]);
                                this.registrationService.clear();
                            })
                        )
                        .subscribe(),
                (error) => {
                    of(error.error)
                        .pipe(
                            tap((d) => {
                                this._snackBar
                                    .open(d.message, "Ok")
                                    .afterDismissed()
                                    .subscribe(() => {
                                        this.router.navigate([""]);
                                        this.registrationService.clear();
                                    });
                            })
                        )
                        .subscribe();
                }
            );
        }
    }
}
