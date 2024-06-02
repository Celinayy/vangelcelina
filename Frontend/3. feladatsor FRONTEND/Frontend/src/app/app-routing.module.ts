import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainWindowComponent } from './main-window/main-window.component';
import { RatingWindowComponent } from './rating-window/rating-window.component';

const routes: Routes = [
  { path: "", component: MainWindowComponent },
  { path: "*", component: MainWindowComponent },
  { path: "rating", component: RatingWindowComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
