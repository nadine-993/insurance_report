using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;
public class InsuranceReportController : BaseApiController
{
    private readonly DataContext _context;

    public InsuranceReportController(DataContext context)
    {
        _context = context;
    }

    // POST: api/insurancereport
    [HttpPost]
    public async Task<ActionResult<InsuranceReport>> CreateReport(InsuranceReportDto dto)
    {


        var report = new InsuranceReport
        {
            SchemeName = dto.SchemeName,
            PolicyName = dto.PolicyName,
            ReportDate = dto.ReportDate,
            PolicyStartDate = dto.PolicyStartDate,
            PolicyEndDate = dto.PolicyEndDate,
            InitialEffectiveDate = dto.InitialEffectiveDate,
            ReportStartDate = dto.ReportStartDate,
            ReportEndDate = dto.ReportEndDate,
            ClaimsProcessed = dto.ClaimsProcessed,
            ClaimsNotProcessed = dto.ClaimsNotProcessed,
            ClaimsNotReported = dto.ClaimsNotReported,
            SubmittedBy = dto.SubmittedBy,
        };

        _context.InsuranceReports.Add(report);
        await _context.SaveChangesAsync();
        return Ok(report);
    }

    // GET: api/insurancereport
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InsuranceReport>>> GetReports()
    {
        var username = User.Identity?.Name;
        var userReports = await _context.InsuranceReports
            .Where(r => r.SubmittedBy == username)
            .ToListAsync();

        return userReports;
    }

    // GET: api/insurancereport/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InsuranceReport>> GetReport(int id)
    {
        var report = await _context.InsuranceReports.FindAsync(id);
        if (report == null) return NotFound();

        return report;
    }

[HttpDelete("{id}")]
[Authorize]
public async Task<IActionResult> DeleteReport(int id)
{
    var report = await _context.InsuranceReports.FindAsync(id);
    if (report == null) return NotFound();

    if (report.SubmittedBy != User.Identity?.Name)
        return Forbid(); // ✅ prevent other users from deleting each other's reports

    _context.InsuranceReports.Remove(report);
    await _context.SaveChangesAsync();

    return NoContent();
}

}
