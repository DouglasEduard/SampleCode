import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdimnProductsComponent } from './adimn-products.component';

describe('AdimnProductsComponent', () => {
  let component: AdimnProductsComponent;
  let fixture: ComponentFixture<AdimnProductsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdimnProductsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdimnProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
