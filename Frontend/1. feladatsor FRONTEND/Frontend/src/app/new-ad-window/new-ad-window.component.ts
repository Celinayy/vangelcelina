import { Component } from '@angular/core';
import { BackendService } from '../services/backend.service';
import { KategoriaModel } from '../models/ingatlan-model';
import { catchError, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-new-ad-window',
  templateUrl: './new-ad-window.component.html',
  styleUrls: ['./new-ad-window.component.css']
})
export class NewAdWindowComponent {

  public kategoriak: KategoriaModel[] = []

  public kategoriaId: number = 1;
  public hirdetesDatuma: any | Date = new Date;
  public leiras: string = "";
  public tehermentes: boolean = false;
  public kepUrl: string = "";

  public errorMessage: string = ""

  constructor(public backend: BackendService, public router: Router, public toastr: ToastrService) {
    this.backend.getKategoriak().subscribe((resp) => {
      this.kategoriak = resp;
    })
  }


  handleSubmit() {
    this.backend.postIngatlan({
      "kategoriaId": this.kategoriaId,
      "hirdetesDatuma": this.hirdetesDatuma,
      "leiras": this.leiras,
      "tehermentes": this.tehermentes,
      "kepUrl": this.kepUrl,
    }).pipe(catchError((err: HttpErrorResponse) => {
      this.errorMessage = err.message
      this.toastr.error("Sikertelen művelet!")
      return throwError(() => err.error)
    }))
    .subscribe(() => {
      this.router.navigate(["/offers"])
      this.toastr.success("Sikeres ingatlan hírdetés feladás!")
    })
  }
}
