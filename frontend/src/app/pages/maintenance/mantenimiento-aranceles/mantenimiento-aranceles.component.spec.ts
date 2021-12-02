import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantenimientoArancelesComponent } from './mantenimiento-aranceles.component';

describe('MantenimientoArancelesComponent', () => {
  let component: MantenimientoArancelesComponent;
  let fixture: ComponentFixture<MantenimientoArancelesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MantenimientoArancelesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MantenimientoArancelesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
