import { Component, OnInit } from '@angular/core';
import { Router }from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { UserService } from 'src/app/shared/services/user.service';
import { UsuarioDTO } from '../../models/DTOs/authenticationDTOs/CredencialesDTO.model';
import { ProfileComponent } from '../profile/profile.component';

@Component({
  selector: 'div[app-hero]',
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.scss']
})
export class HeroComponent implements OnInit {

  bsModalRef?: BsModalRef;
  
  constructor(public router : Router, private userService : UserService, private modalService: BsModalService) { }

  ngOnInit(): void {
  }

  isAuthenticated(): boolean {
    return this.userService.isAuthenticated();
  }

  isAuthorizated(roles : string[]){
    return this.userService.isAuthorizated(roles);
  }

  goHome(){
    this.router.navigate([''])
  }

  logOut(){
    this.userService.logOut();
    this.router.navigateByUrl('login');
  }

  openProfile(){
    this.userService.getUserByEmail().subscribe(res => {
      console.log(res);
      //this.bsModalRef = this.modalService.show(ProfileComponent,{ 
      //  initialState : { 
      //    user : res
      //  }
      //});
    })
  }

}
