import { Component } from '@angular/core';
import { BackendService } from '../backend.service';
import { JourneyShort } from '../journey';
import { catchError, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-window',
  templateUrl: './register-window.component.html',
  styleUrls: ['./register-window.component.css']
})
export class RegisterWindowComponent {

  public journeyId: number = 1;
  public name: string = "";
  public email: string = "";
  public numberOfParticipants: number = 0;
  public lastCovidVaccineDate: string = "";
  public acceptedConditions: boolean = false;

  public errorMessage: string |null = null;

  public journeyShorts: JourneyShort[] = []


  constructor(public backend: BackendService,
    public toastr: ToastrService,
    public router: Router,
  ) {
    this.backend.getJourneysShort().subscribe((journeyShorts) => {
      this.journeyShorts = journeyShorts
    })
  }



  public handleClick() {
    this.backend.postReserve({
      "journeyId": this.journeyId,
      "name": this.name,
      "email": this.email,
      "numberOfParticipants": this.numberOfParticipants,
      "lastCovidVaccineDate": this.lastCovidVaccineDate,
      "acceptedConditions": this.acceptedConditions,
    }).pipe(catchError((err: HttpErrorResponse) => {
      this.toastr.error(err.error)
      this.errorMessage = err.error
      return throwError(() => err)
    }))
      .subscribe(() => {
        this.router.navigate(["/journeys"])
        this.toastr.success(`Regisztrációját ${this.journeyId}-s azonosítószámon rögzítettük!`);
      })
  }

}
