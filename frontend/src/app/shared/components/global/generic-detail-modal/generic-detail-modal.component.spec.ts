import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericDetailModalComponent } from './generic-detail-modal.component';

describe('GenericDetailModalComponent', () => {
  let component: GenericDetailModalComponent;
  let fixture: ComponentFixture<GenericDetailModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenericDetailModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GenericDetailModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
