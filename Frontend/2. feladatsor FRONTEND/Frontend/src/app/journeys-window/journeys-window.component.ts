import { Component } from '@angular/core';
import { BackendService } from '../backend.service';
import { Journey } from '../journey';

@Component({
  selector: 'app-journeys-window',
  templateUrl: './journeys-window.component.html',
  styleUrls: ['./journeys-window.component.css'],
})
export class JourneysWindowComponent {


  displayedColumns: string[] = ['destination', 'vehicle',
    'departure', 'numberOfParticipants', 'description', 'pictureUrl'];
  dataSource: Journey[] = [];

  constructor(public backend: BackendService) {
    this.backend.getJourneys().subscribe((resp) => {
      this.dataSource = resp
    })
  }

}
