import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-panel',
  standalone: false,
  templateUrl: './panel.html',
  styleUrl: './panel.css',
})
export class Panel {

  newUser = {
    login: "",
    password: "",
    name: "",
    lastname: "",
    patronymic: "",
    email: "",
  };

  user = {
    name: "",
    password: ""
  };
  constructor(private http: HttpClient) { }

  createEmployee() {
    console.log(this.newUser);
    this.http.post('/api/Employee/Create', this.newUser).subscribe(
      (result) => {
        console.log('Successfuly fetched data');
      },
      (error) => {
        console.error(error);
      }
    );
  }

  search() {
    this.http.get('/api/Employee/Index').subscribe(
      (result) => {
        console.log('Successfuly fetched data');
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
