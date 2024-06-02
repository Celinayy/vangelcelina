import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IngatlanModel, KategoriaModel } from '../models/ingatlan-model';

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  public url: string = "http://localhost:5000/api"
  public ingatlanok: IngatlanModel[] = [];
  public kategoriak: KategoriaModel[] = [];


  constructor(public connection: HttpClient) { }




  getIngatlanok() {
    return this.connection.get<IngatlanModel[]>(`${this.url}/ingatlan`)
  }

  getKategoriak() {
    return this.connection.get<KategoriaModel[]>(`${this.url}/kategoriak`)
  }

  postIngatlan(input: {
    "kategoriaId": number,
    "hirdetesDatuma": Date,
    "leiras": string,
    "tehermentes": boolean,
    "kepUrl": string,
  }) {
    return this.connection.post<IngatlanModel[]>(`${this.url}/ujingatlan`, input)
  }


}
