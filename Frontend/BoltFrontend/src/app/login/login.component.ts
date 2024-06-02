import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public email: string = "kottra.richard@jedlik.eu";
  public password: string = "";

  constructor(public backend:LoginService) { }

  ngOnInit(): void {
  }

  Belepes() {
    this.backend.login(this.email, this.password);
  }

}
