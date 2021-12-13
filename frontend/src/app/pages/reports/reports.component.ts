import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { EstadoDTO, PaqueteDTO } from 'src/app/shared/models/DTOs/PaqueteDTO.model';
import { FORM_OPT } from 'src/app/shared/models/Form.model';
import { FormService } from 'src/app/shared/services/form.service';
import { environment } from 'src/environments/environment';
import jspdf from 'jspdf';
import html2canvas from 'html2canvas';  
import { KeyValue } from '@angular/common';
import { EstadosService } from 'src/app/shared/services/estados.service';
import { PackageService } from 'src/app/shared/services/package.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit {

  constructor(private formService : FormService, private http: HttpClient, private estadosService : EstadosService, private packageService : PackageService) { }

  @ViewChild('reporte') reporte: ElementRef;
  @ViewChild('contenidoReporte') contenidoReporte: ElementRef;
  reporteOculto = true

  reporteData : {
    titulo : string,
    data : Array<any>,
    fecha : Date
  }

  userControl = new FormControl(null, [Validators.required]);
  orderControl = new FormControl("FechaRegistro", [Validators.required]);
  fechaInicioControl = new FormControl();
  fechaFinalControl = new FormControl();

  options: FORM_OPT[] = [];
  filteredOptions: Observable<FORM_OPT[]>;

  estadosFormGroup : FormGroup
  estadosPaquetes : EstadoDTO[]

  ngOnInit(): void {
    this.filteredOptions = this.userControl.valueChanges.pipe(
      startWith(''),
      map(value => (typeof value === 'string' ? value : "")),
      map(name => (name ? this._filter(name) : this.options.slice()))
    );
    this.formService.getUsersByRole('Usuario').subscribe(res => {
      res.forEach( usuario => {
        this.options.push({ name : usuario.cedula, value : usuario.id, display : usuario.nombre})
      })
    })

    this.estadosService.getEstados().subscribe(res => {
      this.estadosPaquetes = res;
    })
  }

  reportePaquetesUsuario(){
    if(this.userControl.invalid){
      this.userControl.markAsTouched()
      return
    }
    this.http.get<PaqueteDTO[]>(`${environment.urlAPI}/Paquetes/User/${this.userControl.value.value}`).subscribe(res => {
      this.reporteData = {titulo :"Reporte Paquetes Asociados a Usuario", data : res, fecha : new Date()};
      this.imprimirReporte()
    });
  }

  reportePaquetesEstados(){
    const estados : string[] = []
    document.querySelectorAll('.reportePaqueteria').forEach( input => {
      if(input.querySelector('input:checked')){
        const value = input.getAttribute('ng-reflect-value')
        if(value){
          estados.push(value);
        }
      }
    })
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'responseType': 'json',
      'estados' : estados
    });
    this.http.get<PaqueteDTO[]>(`${environment.urlAPI}/Paquetes/Estados/`, { headers: headers }).subscribe(res => {
      this.reporteData = {titulo :"Reporte Paquetes según Estado", data : res, fecha : new Date()};
      this.imprimirReporte()
    });
  }

  reporteTotalPaquetes(){
    this.packageService.getPaquetes(this.orderControl.value).subscribe(res => {
      this.reporteData = {titulo :`Reporte Paquetes Totales Filtrados por: ${this.orderControl.value}`, data : res, fecha : new Date()};
      this.imprimirReporte()
    })
  }

  reporteContable(){
    if(!this.fechaInicioControl.value || !this.fechaFinalControl.value){
      return
    }
    const fechaInicio = this.fechaInicioControl.value.toLocaleDateString('en-US')
    const fechaFinal = this.fechaFinalControl.value.toLocaleDateString('en-US')
    this.packageService.getPaquetesPorFecha(fechaInicio, fechaFinal).subscribe(res => {

      let paquetesData : any[] = []
      let totalPaquetes = 0
      let totalPrecio = 0

      res.forEach(paq => {
        totalPaquetes += 1
        paquetesData.push({ ID : paq.paqueteId, Precio : paq.precio })
        totalPrecio += paq.precio
      })
      paquetesData.push({ TotalPaquetes : totalPaquetes })
      paquetesData.push({ PrecioTotal : totalPrecio })

      this.reporteData = {titulo :`Reporte Contable en Fecha Inicial: ${fechaInicio}, Fecha Final: ${fechaFinal}`, data : paquetesData, fecha : new Date()};
      this.imprimirReporte()
    })
  }

  reporteIngresosSistema(){
    this.http.get<any>(`${environment.urlAPI}/User/loginLogs`).subscribe(res => {
      this.reporteData = {titulo :"Reporte Ingresos Al Sistema", data : res, fecha : new Date()};
      this.imprimirReporte()
    });
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
      return this.userControl.value.display
    }catch{}
  }

  imprimirReporte(){
    this.reporteOculto = false; 
    setTimeout(() => {
      html2canvas(this.reporte.nativeElement).then((canvas) => {
        var imgData = canvas.toDataURL('image/png')
        var doc = new jspdf({orientation: 'portrait'})
        const imgProps= doc.getImageProperties(imgData);
        const pdfWidth = doc.internal.pageSize.getWidth();
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;

        doc.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight)
        doc.save("Reporte_"+ new Date +".pdf")
        this.reporteOculto = true;
      })
    }, 100);
  }

   onCompare(_left: KeyValue<any, any>, _right: KeyValue<any, any>): number {
    return 1;
  }
}
