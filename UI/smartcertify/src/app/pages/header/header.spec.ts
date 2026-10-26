import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';

import { Header } from './header';

describe('HeaderComponent', () => {
  let fixture: ComponentFixture<Header>;
  let component: Header;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Header],     // standalone component
      providers: [provideRouter([])], // żeby routerLink działał w teście
    }).compileComponents();

    fixture = TestBed.createComponent(Header);
    component = fixture.componentInstance;
    fixture.detectChanges(); // odpala ngOnInit + render
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
