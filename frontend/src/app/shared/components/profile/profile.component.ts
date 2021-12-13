import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { UsuarioDTO } from '../../models/DTOs/authenticationDTOs/CredencialesDTO.model';

@Component({
  selector: 'div[app-profile]',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  @Input() user : UsuarioDTO
  
  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

}
