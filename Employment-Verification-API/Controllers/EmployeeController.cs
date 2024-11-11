using Employment_Verification_API.ApplicationDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Employment_Verification_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(EmployeeContext context, ILogger<EmployeeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("verify-employment")]
        public async Task<IActionResult> VerifyEmployment([FromBody] VerifyRequest request)
        {
            try
            {
                if (request == null || (!IsValidInput(request) || IsEmptyInput(request)))
                {
                    if (IsEmptyInput(request))
                    {
                        _logger.LogWarning("Empty Input.");
                    }
                    else if (request != null)
                    {
                        _logger.LogWarning("Invalid Input." + JsonSerializer.Serialize<VerifyRequest>(request));
                    }
                    return BadRequest(new { message = "Invalid input." });
                }

                bool isVerified = await _context.Employees.AnyAsync(e =>
                    e.EmployeeID == request.EmployeeID &&
                    e.CompanyName == request.CompanyName &&
                    e.VerificationCode == request.VerificationCode);

                return Ok(new { verified = isVerified });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem();
            }
        }

        private bool IsValidInput(VerifyRequest request)
        {
            var regex = new Regex("^[a-zA-Z0-9 ]*$");  // Basic sanitization
            return regex.IsMatch(request.CompanyName) && regex.IsMatch(request.VerificationCode);
        }

        private bool IsEmptyInput(VerifyRequest request)
        {
            return string.IsNullOrWhiteSpace(request.CompanyName) && string.IsNullOrWhiteSpace(request.VerificationCode);
        }
    }
}

public class VerifyRequest
{
    public int EmployeeID { get; set; }
    public required string CompanyName { get; set; }
    public required string VerificationCode { get; set; }
}