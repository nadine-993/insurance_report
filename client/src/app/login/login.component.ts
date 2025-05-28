import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AccountService } from '../_services/account.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
    selector: 'app-login',
    imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, FormsModule],
    templateUrl: './login.component.html',
    styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  http= inject (HttpClient);
  users:any;
  ngOnInit(): void {
    this.getUsers()
  }
  accountService = inject(AccountService);
  private router= inject (Router);

  model: any= {};
  login(){
    this.accountService.login(this.model).subscribe({

      next: response =>  {
        console.log('Login success:', response);
        this.router.navigateByUrl('/dashboard')
        
      },
      error: error => console.log(error)
    })
  }
  logout(){
    this.accountService.logout();
  }
  getUsers(){
    this.http.get('http://localhost:5091/api/users').subscribe({
      next: response=> this.users=response,

      error:error=> console.log(error),
      complete:()=> console.log(this.users)
    })
  }

}
