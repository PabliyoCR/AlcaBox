import { Component, OnInit } from '@angular/core';
import { Card } from 'src/app/shared/models/site/card.model';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {

  cards : Card[] = [
    {
      image : "assets/images/homepage/camion.jpg",
      title : "Transporte Multimodal",
      services : [
        "Transporte Aéreo",
        "Transporte Marítimo LCL / FCL",
        "Transporte Terrestre LTL / FTL"
      ]
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
