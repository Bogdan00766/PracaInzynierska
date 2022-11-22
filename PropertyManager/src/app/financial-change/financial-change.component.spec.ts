import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FinancialChangeComponent } from './financial-change.component';

describe('FinancialChangeComponent', () => {
  let component: FinancialChangeComponent;
  let fixture: ComponentFixture<FinancialChangeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FinancialChangeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FinancialChangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
