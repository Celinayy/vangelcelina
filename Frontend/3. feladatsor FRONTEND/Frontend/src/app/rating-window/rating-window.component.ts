import { Component } from '@angular/core';
import { BackendService } from '../backend.service';
import { ViewpointModel } from '../viewpoint-model';
import { Toast, ToastrService } from 'ngx-toastr';
import { catchError, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rating-window',
  templateUrl: './rating-window.component.html',
  styleUrls: ['./rating-window.component.css']
})
export class RatingWindowComponent {

  public viewpoint: ViewpointModel | null = null;
  public viewpoints: ViewpointModel[] = [];
  public email: string = "";
  public rating: number = 1;
  public comment: string = "";
  public hiba: string = "";

  constructor(public backend: BackendService, public toastr: ToastrService, public route: Router) {
    backend.getViewPoints().subscribe((viewpoints) => {
      this.viewpoints = viewpoints
    })
  }

  public handleClick() {
    this.backend.postRate(
      { "viewpointId": this.viewpoint!.id, "email": this.email, "rating": this.rating, "comment": this.comment }
    ).pipe(catchError((err: HttpErrorResponse) => {
      for (const message of err.error.name ?? []) {
        this.toastr.error(message)
      }
      this.hiba = err.error.message;
      return throwError(() => err)
    }))
      .subscribe(() => {
        this.route.navigate(["/"])
        this.toastr.success("Sikeres!");
      })

  }


}
