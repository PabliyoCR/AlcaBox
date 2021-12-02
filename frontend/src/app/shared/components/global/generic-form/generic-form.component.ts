import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FORM } from 'src/app/shared/models/Form.model';

@Component({
  selector: 'div[app-generic-form]',
  templateUrl: './generic-form.component.html',
  styleUrls: ['./generic-form.component.scss']
})
export class GenericFormComponent implements OnInit {
  edit : boolean = false

  @Input() genericFormGroup : FormGroup
  @Input() controls : FORM[]
  @Input() metadata : {title :string, pk: { name: string, type: string}}

  @Output() submitForm = new EventEmitter<any>();

  element : any

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
    this.genericFormGroup.reset()
    this.genericFormGroup.patchValue({[this.metadata.pk.name] : 0})
    if(this.element){
      this.edit = true
      this.genericFormGroup.patchValue(this.element)
    }
  }

  submit(){
    if(this.genericFormGroup.invalid){
      return
    }
    this.submitForm.emit({ formValue : this.genericFormGroup.getRawValue(), edit : this.edit})
    this.bsModalRef.hide()
  }

}
