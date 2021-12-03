import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-maintenance',
  templateUrl: './maintenance.component.html',
  styleUrls: ['./maintenance.component.scss']
})
export class MaintenanceComponent implements OnInit {

  panelOpenState = false;
  
  constructor( private userService : UserService) { }

  ngOnInit(): void {
  }

  isAuthorizated(roles : string[]){
    return this.userService.isAuthorizated(roles);
  }

}
