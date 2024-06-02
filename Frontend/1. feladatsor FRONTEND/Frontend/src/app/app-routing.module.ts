import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainWindowComponent } from './main-window/main-window.component';
import { AdsWindowComponent } from './ads-window/ads-window.component';
import { NewAdWindowComponent } from './new-ad-window/new-ad-window.component';

const routes: Routes = [
  { path: "", component: MainWindowComponent },
  { path: "offers", component: AdsWindowComponent },
  { path: "newad", component: NewAdWindowComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
