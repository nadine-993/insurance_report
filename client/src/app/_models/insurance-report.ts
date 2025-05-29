export interface InsuranceReport{
  schemeName: string;
  policyName: string;
  policyStartDate: Date;
  policyEndDate: Date;
  initialEffectiveDate: Date;
  reportStartDate: Date;
  reportEndDate: Date;
  reportDate: Date;
  claimsProcessed: number;
  claimsNotProcessed: number;
  claimsNotReported: number;
  submittedBy: string; // ✅ Add this

}