import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LocationModel } from './location-model';
import { ViewpointModel } from './viewpoint-model';

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  public url: string = "https://viewpoint.jedlik.cloud/api/"


  constructor(public connection: HttpClient) {

  }


  getLocations() {
    return this.connection.get<LocationModel[]>(`${this.url}/locations`)
  }


  getViewPointsByName(name: string) {
    return this.connection.get<ViewpointModel[]>(`${this.url}/locations/${name}/viewpoints`)
  }

  getViewPoints() {
    return this.connection.get<ViewpointModel[]>(`${this.url}/viewpoints`)
  }


  postRate(input: {
    "viewpointId": number,
    "email": string,
    "rating": number,
    "comment": string
  }) {
    return this.connection.post(`${this.url}/rate`,
      input
    )
  }
}
