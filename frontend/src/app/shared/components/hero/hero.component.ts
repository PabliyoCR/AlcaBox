import { Component, OnInit } from '@angular/core';
import { Router }from '@angular/router';

@Component({
  selector: 'div[app-hero]',
  templateUrl: './hero.component.html',
  styleUrls: ['./hero.component.scss']
})
export class HeroComponent implements OnInit {

  routes = [
    {
      'name': 'inicio',
      'path' : ''
    },
    {
      'name': 'paqueteria',
      'path' : 'packages'
    },
    {
      'name': 'reportes',
      'path' : 'reports'
    },
    {
      'name': 'acerca de',
      'path' : 'about'
    },
    {
      'name': 'ayuda',
      'path' : 'help'
    }
  ]

  constructor(public router : Router) { }

  ngOnInit(): void {
  }

}
