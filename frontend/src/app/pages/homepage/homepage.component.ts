import { Component, OnInit } from '@angular/core';
import { Card } from 'src/app/shared/models/front/card.model';

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
    },
    {
      image : "assets/images/homepage/aduana.jpg",
      title : "Gestión Aduanera",
      services : [
        "Trámites Aduanales",
        "Cobertura logística a nivel mundial para importaciones y exportaciones"
      ]
    },
    {
      image : "assets/images/homepage/moving.jpg",
      title : "Servicio Courier",
      services : [
        "Paquetería desde locker en Miami hasta la puerta de tu casa"
      ]
    },
    {
      image : "assets/images/homepage/courier.jpg",
      title : "Freight Fowarder",
      services : [
        "Recolecciones de mercadería",
        "Embalajes",
        "Seguro"
      ]
    },
    {
      image : "assets/images/homepage/compra.jpg",
      title : "Compras en Línea",
      services : [
        "Asesorías",
        "Reportes"
      ]
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
