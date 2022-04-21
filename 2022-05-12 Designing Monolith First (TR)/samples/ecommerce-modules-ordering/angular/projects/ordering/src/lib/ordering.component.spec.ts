import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { OrderingComponent } from './ordering.component';

describe('OrderingComponent', () => {
  let component: OrderingComponent;
  let fixture: ComponentFixture<OrderingComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ OrderingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
