namespace API;


public class InsuranceReportDto
{
    public required  string SchemeName { get; set; }
    public  required string PolicyName { get; set; }  public DateTime PolicyStartDate { get; set; }
    public DateTime PolicyEndDate { get; set; }
    public DateTime InitialEffectiveDate { get; set; }
    public DateTime ReportStartDate { get; set; }
    public DateTime ReportEndDate { get; set; }
    public DateTime ReportDate { get; set; }
    public decimal ClaimsProcessed { get; set; }
    public decimal ClaimsNotProcessed { get; set; }
    public decimal ClaimsNotReported { get; set; }  
    public required string SubmittedBy { get; set; } 
}