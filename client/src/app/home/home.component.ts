import { Component, inject, OnInit } from '@angular/core';
import { LoginComponent } from "../login/login.component";
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-home',
    imports: [LoginComponent],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})
export class HomeComponent  {

 

}
