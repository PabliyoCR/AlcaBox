import { Component, OnInit } from '@angular/core';
import { Router }from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'div[app-hero]',
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.scss']
})
export class HeroComponent implements OnInit {

  constructor(public router : Router, private userService : UserService) { }

  ngOnInit(): void {
  }

  isAuthenticated(): boolean {
    return this.userService.isAuthenticated();
  }

  isAuthorizated(roles : string[]){
    return this.userService.isAuthorizated(roles);
  }

  logOut(){
    this.userService.logOut();
  }

}
