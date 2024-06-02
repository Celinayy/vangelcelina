import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainWindowComponent } from './main-window/main-window.component';
import { JourneysWindowComponent } from './journeys-window/journeys-window.component';
import { RegisterWindowComponent } from './register-window/register-window.component';

const routes: Routes = [
  { path: "", component:  MainWindowComponent},
  { path: "registration", component:  RegisterWindowComponent},
  { path: "journeys", component:  JourneysWindowComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
