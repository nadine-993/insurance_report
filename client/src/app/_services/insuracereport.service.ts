import { HttpClient, HttpHeaders } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { Observable } from "rxjs";
import { InsuranceReport } from '../_models/insurance-report'; // ✅ your interface

@Injectable({
    providedIn: 'root'
})
export class InsuranceReportService{
private http=inject (HttpClient);
baseUrl = 'http://localhost:5091/api/insurancereport';
private getAuthHeaders(): HttpHeaders {
  const token = localStorage.getItem('basicAuth');
  return new HttpHeaders({
    'Authorization': `Basic ${token}`
  });
}

    createReport(report: InsuranceReport): Observable<InsuranceReport> {
        return this.http.post<InsuranceReport>(this.baseUrl, report, {
          headers:this.getAuthHeaders(),
        });
      }
    
      getReports(): Observable<InsuranceReport[]> {
        return this.http.get<InsuranceReport[]>(this.baseUrl,{
          headers:this.getAuthHeaders(),
        } );
      }
    
      getReport(id: number): Observable<InsuranceReport> {
        return this.http.get<InsuranceReport>(`${this.baseUrl}/${id}`, {
          headers:this.getAuthHeaders(),
        });
      }
      

}