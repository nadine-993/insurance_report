import { Component, inject, OnInit } from '@angular/core';
import { InsuranceReportService } from '../_services/insuracereport.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { InsuranceReport } from '../_models/insurance-report'; 
import { FormsModule, NgForm } from '@angular/forms';


@Component({
    selector: 'app-insurance-report',
    imports: [FormsModule],
    templateUrl: './insurance-report.component.html',
    styleUrls: ['./insurance-report.component.css'] // ✅
})
export class InsuranceReportComponent   {
    http= inject (HttpClient);
    insurancereportservice= inject(InsuranceReportService);
    

    model: InsuranceReport = {
      schemeName: '',
      policyName: '',
      policyStartDate: new Date(),
      policyEndDate: new Date(),
      initialEffectiveDate: new Date(),
      reportStartDate: new Date(),
      reportEndDate: new Date(),
      reportDate: new Date(),
      claimsProcessed: 0,
      claimsNotProcessed: 0,
      claimsNotReported: 0,
      submittedBy:''
    };
    
     

    
  
  submitReports(form: NgForm) {
    this.insurancereportservice.createReport(this.model).subscribe({
      next: response => {
        console.log('Report submitted:', response),
        form.resetForm();
      },
      error: err => console.error('Submission error:', err)

    },
  
  );
  }
 



}
