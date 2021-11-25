import { Component, Input, OnInit } from '@angular/core';
import { Card } from '../../models/site/card.model';

@Component({
  selector: '[app-card-info]',
  templateUrl: './card-info.component.html',
  styleUrls: ['./card-info.component.scss']
})
export class CardInfoComponent implements OnInit {

  @Input() data: Card = {
    image : "",
    title : "",
    services : [] 
  };
  
  constructor() { }

  ngOnInit(): void {
  }

}
