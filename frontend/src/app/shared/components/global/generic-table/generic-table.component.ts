import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FORM, FORM_OPT } from 'src/app/shared/models/Form.model';
import { GenericConfirmComponent } from '../generic-confirm/generic-confirm.component';
import { GenericDetailModalComponent } from '../generic-detail-modal/generic-detail-modal.component';
import { GenericFormComponent } from '../generic-form/generic-form.component';

@Component({
  selector: 'div[app-generic-table]',
  templateUrl: './generic-table.component.html',
  styleUrls: ['./generic-table.component.scss']
})
export class GenericTableComponent implements OnInit {
  
  @Input() data : { 
    genericDetail : {
      dataSource : MatTableDataSource<any>, infoToDisplay : FORM_OPT[], displayCols : string[]
    },
    genericForm : {
      genericFormGroup : FormGroup
      controls : FORM[]
    }
  }
  @Input() metadata : {title :string, pk: { name: string, type: string}}

  @Output() submitForm = new EventEmitter<any>();
  @Output() deleteConfirmed = new EventEmitter<any>();

  // @ViewChild(MatPaginator) paginator: MatPaginator;
  bsModalRef?: BsModalRef;
  
  constructor(private modalService: BsModalService) { }

  ngOnInit(): void {
    this.data.genericDetail.displayCols.push('acciones')
  }

  showDetail(e : Event, row : any){
    const target = e.target as HTMLElement
    if(!target.classList.contains('action')){
      this.bsModalRef = this.modalService.show(GenericDetailModalComponent,{ initialState : { data : row, title : this.metadata.title } });
    }
  }

  openFormCreate(){
    this.bsModalRef = this.modalService.show(GenericFormComponent,{ 
      initialState : { 
        genericFormGroup : this.data.genericForm.genericFormGroup,
        controls : this.data.genericForm.controls,
        metadata : this.metadata,
      } 
    });
    this.bsModalRef.content.submitForm.subscribe((res : any) => {
      this.submitForm.emit(res)
    })
  }

  openFormEdit(element : any){
    this.bsModalRef = this.modalService.show(GenericFormComponent,{ 
      initialState : { 
        genericFormGroup : this.data.genericForm.genericFormGroup,
        controls : this.data.genericForm.controls,
        metadata : this.metadata,
        element
      } 
    });
    this.bsModalRef.content.submitForm.subscribe((res : any) => {
      this.submitForm.emit(res)
    })
  }

  deleteItem(element : any){
    this.bsModalRef = this.modalService.show(GenericConfirmComponent,{ 
      initialState : { 
        title : "Borrar Item",
        message : `¿Deseas borrar este ${this.metadata.title}?`,
        confirmText : "Borrar",
        data : element
      } 
    });
    this.bsModalRef.content.confirmed.subscribe((pk : any) => {
      this.deleteConfirmed.emit(pk)
    })
  }
}
