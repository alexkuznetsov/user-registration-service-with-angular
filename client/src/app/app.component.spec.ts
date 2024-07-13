import { TestBed } from "@angular/core/testing";
import { AppComponent } from "./app.component";
import { RegisterComponent } from "./pages/register/register.component";
import { provideRouter } from "@angular/router";
import { provideAnimationsAsync } from "@angular/platform-browser/animations/async";
import { provideHttpClient } from "@angular/common/http";
import { RouterTestingHarness } from "@angular/router/testing";

describe("AppComponent", () => {
    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [AppComponent],
            providers: [
                provideRouter([{ path: "", component: RegisterComponent }]),
                provideAnimationsAsync(),
                provideHttpClient(),
            ],
        }).compileComponents();
    });

    it("should create the app", () => {
        const fixture = TestBed.createComponent(AppComponent);
        const app = fixture.componentInstance;
        expect(app).toBeTruthy();
    });

    it(`should have the 'client' title`, () => {
        const fixture = TestBed.createComponent(AppComponent);

        const app = fixture.componentInstance;
        expect(app.title).toEqual("client");
    });

    it("should render title", async () => {
        // const fixture = TestBed.createComponent(AppComponent);
        // fixture.detectChanges();
        // const compiled = fixture.nativeElement as HTMLElement;
        // expect(compiled.querySelector("h3")?.textContent).toContain("Step 1");

        const harness = await RouterTestingHarness.create();
        // Navigate to the route to get your component
        const activatedComponent = await harness.navigateByUrl(
            "/",
            RegisterComponent
        );

        const fixture = harness.fixture;
        fixture.autoDetectChanges();
        const compiled = fixture.nativeElement as HTMLElement;
        expect(compiled.querySelector("h3")?.textContent).toContain("Step 1");
    });
});
