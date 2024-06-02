import { Component } from '@angular/core';
import { BackendService } from '../services/backend.service';
import { IngatlanModel } from '../models/ingatlan-model';

@Component({
  selector: 'app-ads-window',
  templateUrl: './ads-window.component.html',
  styleUrls: ['./ads-window.component.css']
})
export class AdsWindowComponent {


  public dataSource: IngatlanModel[] = [];
  displayedColumns: string[] = ['kategoria', 'leiras', 'hirdetesDatuma', 'tehermentes', 'kepUrl'];

  constructor(public backend: BackendService) {
    this.backend.getIngatlanok().subscribe((ingatlanokFromBackend) => {
      this.dataSource = ingatlanokFromBackend
    })
  }
}
