import { ComponentFixture, TestBed } from "@angular/core/testing";

import { SetLocationComponent } from "./set-location.component";
import { provideAnimationsAsync } from "@angular/platform-browser/animations/async";
import { provideHttpClient } from "@angular/common/http";

describe("SetLocationComponent", () => {
    let component: SetLocationComponent;
    let fixture: ComponentFixture<SetLocationComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [SetLocationComponent],
            providers: [provideAnimationsAsync(), provideHttpClient()],
        }).compileComponents();

        fixture = TestBed.createComponent(SetLocationComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
