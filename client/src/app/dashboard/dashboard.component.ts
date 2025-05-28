import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AccountService } from '../_services/account.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { InsuranceReportService } from '../_services/insuracereport.service';
import { InsuranceReport } from '../_models/insurance-report';
import { InsuranceReportComponent } from "../insurance-report/insurance-report.component";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, FormsModule, InsuranceReportComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {


   http= inject (HttpClient);
    users:any;
    ngOnInit(): void {
      this.fetchReports();

    }
    accountService = inject(AccountService);
    private router= inject (Router);
    insuranceReportService = inject(InsuranceReportService);
    reports: InsuranceReport[] = [];

  
    model: any= {};

    fetchReports(){
      this.insuranceReportService.getReports().subscribe({
        next:(data)=>{
          this.reports=data;
          console.log("fetched reports",data);
        },
        error: (err) => console.error('Failed to load reports:', err)


      })

    }
    logout(){
      this.accountService.logout();
      this.router.navigateByUrl('/')
    }
  }
