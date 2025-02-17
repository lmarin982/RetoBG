import { Component, OnInit } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [RouterOutlet, RouterLink, MatIconModule],
  templateUrl: './mainLayout.component.html',
  styleUrls: ['./mainLayout.component.scss'],
})
export class MainLayoutComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit() {}

  logout() {
    localStorage.removeItem('isLoggedIn');
    this.router.navigate(['/login']);
    console.log('User logged out');
  }
}
