import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {

  message = "";

  user = {
    email: "",
    password: ""
  };


  constructor(private authService: AuthService) { }

  login() {
    this.authService.login(this.user).subscribe({
      next: (res) => {
        this.authService.saveToken(res.token);
        this.message = "Login successful";
      },
      error: () => {
        this.message = "Invalid email or password";
      }
    });
  }


}
