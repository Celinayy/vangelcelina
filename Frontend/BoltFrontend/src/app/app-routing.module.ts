import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TermekekComponent } from './termekek/termekek.component';

const routes: Routes = [
  {
    path:"**",
    component: TermekekComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
