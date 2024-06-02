import { Component } from '@angular/core';
import { BackendService } from '../backend.service';
import { Location } from '@angular/common';
import { LocationModel } from '../location-model';
import { ViewpointModel } from '../viewpoint-model';

@Component({
  selector: 'app-main-window',
  templateUrl: './main-window.component.html',
  styleUrls: ['./main-window.component.css']
})
export class MainWindowComponent {

  public viewpoints: ViewpointModel[] = []
  public locations: LocationModel[] = [];
  public selectedLocation: LocationModel | null = null;

  constructor(public backend: BackendService) {
    this.backend.getLocations().subscribe((locations) => {
      this.locations = locations;
    })
  }


  public getViewPoints() {
    this.backend.getViewPointsByName(this.selectedLocation!.locationName).subscribe((resp) => {
      this.viewpoints = resp
    })
  }

}
