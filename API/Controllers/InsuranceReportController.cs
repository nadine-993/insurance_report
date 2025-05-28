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
    public async Task<ActionResult<InsuranceReport>> CreateReport(InsuranceReport report)
    {
        _context.InsuranceReports.Add(report);
        await _context.SaveChangesAsync();
        return Ok(report);
    }

    // GET: api/insurancereport
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InsuranceReport>>> GetReports()
    {
        return await _context.InsuranceReports.ToListAsync();
    }

    // GET: api/insurancereport/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InsuranceReport>> GetReport(int id)
    {
        var report = await _context.InsuranceReports.FindAsync(id);
        if (report == null) return NotFound();

        return report;
    }
}
