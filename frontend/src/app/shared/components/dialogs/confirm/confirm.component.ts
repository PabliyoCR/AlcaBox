import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm',
  templateUrl: './confirm.component.html',
  styleUrls: ['./confirm.component.scss']
})
export class ConfirmComponent implements OnInit {

  @Output() procederEvent = new EventEmitter<any>();
  
  titulo = "";
  mensaje = "";
  params : any;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<ConfirmComponent>) { }

  ngOnInit(): void {
    this.titulo = this.data.titulo
    this.mensaje = this.data.mensaje
    this.params = this.data.params
  }

  proceder(){
    this.procederEvent.emit(this.params);
    this.dialogRef.close()
  }

}
