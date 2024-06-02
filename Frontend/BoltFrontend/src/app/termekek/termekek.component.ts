import { Component, OnInit, ViewChild } from '@angular/core';
import { TermekModel } from '../models/termek-model';
import { TermekService } from '../services/termek.service';
import { LoginService } from '../services/login.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { TermekComponent } from '../termek/termek.component';

@Component({
  selector: 'app-termekek',
  templateUrl: './termekek.component.html',
  styleUrls: ['./termekek.component.scss']
})
export class TermekekComponent implements OnInit {

  public columnsToDisplay = ['gombok', 'nev', 'kepUrl',
                             'leiras', 'ar', 'csokkentettar'];
  public dataSource = new MatTableDataSource<TermekModel>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  
  constructor(private backend:TermekService,
              public loginbackend:LoginService,
              public dialog: MatDialog)
  { 
    this.refresh();
  }

  ngOnInit(): void {
  }

  szerkeszt(termek:TermekModel) {
    this.dialog.open(TermekComponent, {
      data: termek
    }).afterClosed().subscribe((data) =>{
      this.refresh();
    });

  }
  refresh() {
    this.backend.getAllTermek().subscribe((data) => {
      this.dataSource.data = data;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
  })
  }

}
