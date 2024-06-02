import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  public token: string = "";

  constructor(private http:HttpClient) { 
    this.token = sessionStorage.getItem("token")??"";
  }

  login(email: string, password: string) {
    sessionStorage.removeItem("token");
    this.token = "";

    this.http.post("http://localhost:8000/api/login", {
      "email": email,
      "password": password 
    }).subscribe( (data:any) => {
        this.token = data.token
        sessionStorage.setItem("token", this.token);
    });
  }

  logout() {
    const headers = new HttpHeaders( {
      'content-type': 'application/json',
      'Authorization': 'Bearer '+this.token
    });
    this.http.post("http://localhost:8000/api/logout", {}, {headers}).subscribe( () => {
      this.token = "";
      sessionStorage.removeItem("token");
    });
  }
}
