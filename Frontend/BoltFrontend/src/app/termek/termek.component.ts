import { Component, Inject, OnInit } from '@angular/core';
import { TermekModel } from '../models/termek-model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TermekService } from '../services/termek.service';

@Component({
  selector: 'app-termek',
  templateUrl: './termek.component.html',
  styleUrls: ['./termek.component.scss']
})
export class TermekComponent implements OnInit {

  public termek!:TermekModel;

  constructor(private backend:TermekService,
              @Inject(MAT_DIALOG_DATA) public data: TermekModel,
              public dialogRef: MatDialogRef<TermekComponent>)
  { 
    this.termek = {
      nev: data.nev,
      ar: data.ar,
      kedvezmeny:data.kedvezmeny,
      id: data.id,
      kepUrl: data.kepUrl,
      leiras: data.leiras
    }
  }

  ngOnInit(): void {
  }

  kedvezmenyMegvaltozas(event:any) {
    this.termek.kedvezmeny = event.target.value/100;
  }

  mentes() {
    this.backend.updateTermek(this.termek).subscribe((data:TermekModel) => {
      this.termek = data;
      this.dialogRef.close(this.termek);
    });
  }
    
}
