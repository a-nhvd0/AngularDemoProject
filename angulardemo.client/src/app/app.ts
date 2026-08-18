import { HttpClient } from '@angular/common/http';
import { Component, OnInit, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App implements OnInit {
  isLoggedIn = false;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    
  }

  logout(): void {

  }

  protected readonly title = signal('AngularDemo.client');
}
