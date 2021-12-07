import { ChangeDetectorRef, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import{  FormGroup, FormControl, Validators, FormBuilder}from'@angular/forms'
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { PaqueteCreacionDTO } from 'src/app/shared/models/DTOs/PaqueteDTO.model';
import { FORM, FORM_OPT } from 'src/app/shared/models/Form.model';
import { FormService } from 'src/app/shared/services/form.service';
import { PackageService } from 'src/app/shared/services/package.service';

@Component({
  selector: 'div[app-formulario-paquete]',
  templateUrl: './formulario-paquete.component.html',
  styleUrls: ['./formulario-paquete.component.scss']
})
export class FormularioPaqueteComponent implements OnInit {
  
  @ViewChild('formPaquete') formPaquete : ElementRef;

  @Output() updatePaquetesEvent = new EventEmitter();

  edit : boolean = false;

  paqueteForm: FormGroup; 
  
  controls : FORM[] = [
    { id : "tracking", type : "number", placeholder: "Tracking" },
    { id : "usuario", type : "autocomplete", placeholder : "Usuario (Cédula)"},
    { id : "fechaRegistro", type : "date", placeholder: "Fecha De Registro"},
    { id : "descripcion", type : "textarea", placeholder : "Descripcion"},
    { id : "peso", type : "number", placeholder: "Peso"},
    { id : "arancel", type : "select", placeholder: "Arancel"},
    { id : "estado", type : "select", placeholder: "Estado"},
    { id : "precio", type : "number", placeholder: "Precio"}
  ]

  options: FORM_OPT[] = [];
  filteredOptions: Observable<FORM_OPT[]>;

  constructor(private fb : FormBuilder, private packageService : PackageService, private formService : FormService, private cdr: ChangeDetectorRef) { 
    this.paqueteForm = this.fb.group({
      paqueteId: [{ value: 0, disabled: true }, Validators.required],
      tracking: [null, Validators.required],
      usuario: [null, Validators.required],
      fechaRegistro: [null, Validators.required],
      descripcion: [null, Validators.required],
      peso: [null, Validators.required],
      arancel: [null, Validators.required],
      estado: [null, Validators.required],
      precio: [null, Validators.required]
    });

    this.filteredOptions =  this.paqueteForm.controls["usuario"].valueChanges.pipe(
      startWith(''),
      map(value => (typeof value === 'string' ? value : "")),
      map(name => (name ? this._filter(name) : this.options.slice()))
    );

    this.formService.formEditSubject.subscribe(res => {
      this.edit = true;
      // Relleno de campos para editar
      this.paqueteForm.controls['paqueteId'].setValue(res.paqueteId)
      this.paqueteForm.controls['tracking'].setValue(res.tracking)
      this.paqueteForm.controls['usuario'].setValue({ name : res.usuario.cedula, value : res.usuario.id, display : res.usuario.nombre})
      this.paqueteForm.controls['fechaRegistro'].setValue(res.fechaRegistro)
      this.paqueteForm.controls['descripcion'].setValue(res.descripcion)
      this.paqueteForm.controls['peso'].setValue(res.peso)
      this.paqueteForm.controls['arancel'].setValue(res.arancel.arancelId)
      this.paqueteForm.controls['estado'].setValue(res.estado.estadoId)
      this.paqueteForm.controls['precio'].setValue(res.tracking)
    })

    this.formService.formCreateSubject.subscribe(res => {
      this.edit = false;
      this.paqueteForm.reset()
      this.paqueteForm.controls['paqueteId'].setValue(0)
      this.paqueteForm.controls['fechaRegistro'].setValue(new Date())
    })
  }

  ngOnInit(): void {
    this.fillOptions()
  }

  guardarPaquete(){
    if(this.paqueteForm.invalid){
      return
    }

    var form = this.paqueteForm.getRawValue();

    var paquete : PaqueteCreacionDTO  = {
      paqueteId : form.paqueteId,
      tracking : form.tracking,
      arancelId : form.arancel,
      descripcion : form.descripcion,
      fechaRegistro : form.fechaRegistro,
      estadoId : form.estado,
      precio : form.precio,
      peso : form.peso,
      usuarioId : form.usuario.value
    }
    
    if(!this.edit){
      this.packageService.crearPaquete(paquete).subscribe( res => {
        (document.getElementById('closeModalBtn') as HTMLButtonElement).click()
        this.updatePaquetesEvent.emit()
        this.formService.successToast("Guardado Exitósamente", 'bottom-start')
        /* var myModal = new bootstrap.Modal(this.formPaquete.nativeElement, { keyboard: false })
        myModal.hide() */
      })
    }else{
      this.packageService.actualizarPaquete(paquete).subscribe( res => {
        (document.getElementById('closeModalBtn') as HTMLButtonElement).click()
        this.updatePaquetesEvent.emit()
        this.formService.successToast("Guardado Exitósamente", 'bottom-start')
      })
    }
  }

  fillOptions(){
    this.controls.filter(ctrl => ctrl.type === 'select').forEach(ctrl => {
      this.formService.getFormOpts(ctrl.id, `${ctrl.id}Id`, 'nombre').subscribe(res => {
        var control = this.controls.find(c => c.id == ctrl.id);
        if(control){
          control.options = res;
        }
      })
    })

    this.formService.getUsersByRole('Usuario').subscribe(res => {
      res.forEach( usuario => {
        this.options.push({ name : usuario.cedula, value : usuario.id, display : usuario.nombre})
      })
    })
  }

  displayFn(opt: FORM_OPT): string {
    return opt && opt.name ? opt.name : '';
  }

  private _filter(name: string): FORM_OPT[] {
    const filterValue = name.toLowerCase();
    return this.options.filter(option => option.name.toLowerCase().includes(filterValue))
  }

  getNombreUsuario(){
    try{
      return this.paqueteForm.controls["usuario"].value.display
    }catch{}
  }
}
