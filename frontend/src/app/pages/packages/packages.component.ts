import { Component, OnInit, ViewChild } from '@angular/core';
import { PaqueteDTO } from 'src/app/shared/models/DTOs/PaqueteDTO.model';
import { PackageService } from 'src/app/shared/services/package.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-packages',
  templateUrl: './packages.component.html',
  styleUrls: ['./packages.component.scss']
})
export class PackagesComponent implements OnInit {

  paquetes : PaqueteDTO[] = []
  displayedColumns: string[] = ['paquete_Id', 'descripcion', 'usuario', 'fechaRegistro', 'peso', 'arancel', 'estado', 'precio'];
  //dataSource = new MatTableDataSource<PaqueteDTO>(this.paquetes);

  //@ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private packageService : PackageService) { 
    //this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void { 
    this.getPaquetes()
  }

  getPaquetes() : void{
    this.packageService.getPaquetes().subscribe( res => {
      this.paquetes = res
      console.log(this.paquetes);
    })
    
  }
}
