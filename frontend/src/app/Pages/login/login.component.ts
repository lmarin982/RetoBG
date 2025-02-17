import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { api_url } from '../../Configs/ApiUrl';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [ReactiveFormsModule],
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private router: Router, private fb: FormBuilder, private http: HttpClient) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.login();
    }
  }

  login() {

    const loginData = this.loginForm.value
    this.http.post(`${api_url.usuario}/auth`, loginData).subscribe(
      (res) => {
        localStorage.setItem('isLoggedIn', 'true');
        this.router.navigate(['/home']);
      },
      (error) => {
        console.error(error);
      }
    )
  }
}
