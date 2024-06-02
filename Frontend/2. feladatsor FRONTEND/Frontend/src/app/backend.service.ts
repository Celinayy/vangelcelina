import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Journey, JourneyShort } from './journey';

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  public journeys: Journey[] = []
  public journeysShort: JourneyShort[] = []

  public url: string = "https://utazasi-iroda.jedlik.cloud/api/"

  constructor(public connection: HttpClient) { }


  public getJourneysShort() {
    return this.connection.get<JourneyShort[]>(`${this.url}journeys/short`)
  }

  public getJourneys() {
    return this.connection.get<Journey[]>(`${this.url}journeys`)
  }

  public postReserve(input: {
    "journeyId": number,
    "name": string,
    "email": string,
    "numberOfParticipants": number,
    "lastCovidVaccineDate": string,
    "acceptedConditions": boolean
  }) {
    return this.connection.post(`${this.url}reserve`, input)
  }


}
