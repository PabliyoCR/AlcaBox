import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantenimientoEstadosComponent } from './mantenimiento-estados.component';

describe('MantenimientoEstadosComponent', () => {
  let component: MantenimientoEstadosComponent;
  let fixture: ComponentFixture<MantenimientoEstadosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MantenimientoEstadosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MantenimientoEstadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
