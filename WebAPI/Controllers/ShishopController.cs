using DBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShishopController : ControllerBase
    {
        private readonly EmployeeDB employeeDb = new EmployeeDB();
        private readonly ShiftDB shiftDb = new ShiftDB();

        // GET: api/Shishop/GetNextShift/5
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Shift>> GetNextShift(int employeeId)
        {
            // 1. שליפת כל המשמרות (נשתמש בשם המחלקה המפורש Shift במקום var)
            List<Shift> allShifts = await shiftDb.GetAllShiftsAsync();

            if (allShifts == null) return NotFound("Database is empty.");

            // 2. כתיבה בסגנון SQL (LINQ Query Syntax)
            // אנחנו מחפשים משמרת ששייכת לעובד, ושהתאריך שלה הוא מהיום והלאה
            Shift nextShift = (from s in allShifts
                               where s.EmployCode == employeeId
                               && s.DateTime.Date >= DateTime.Now.Date // השוואה לפי תאריך בלבד (בלי שעות)
                               orderby s.DateTime
                               select s).FirstOrDefault();

            // 3. בדיקה אם נמצאה תוצאה
            if (nextShift == null)
            {
                return NotFound("No upcoming shifts found for this employee.");
            }

            return Ok(nextShift);
        }

        // POST: api/Shishop/Login
        [HttpPost]
        public async Task<ActionResult<Employee>> Login([FromBody] LoginRequest request)
        {
            // Validation for missing fields
            if (request == null || string.IsNullOrEmpty(request.NationalId) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("National ID and password are required.");
            }

            // Attempt login via the database layer
            Employee employee = await employeeDb.LoginAsync(request.NationalId, request.Password);

            if (employee == null)
            {
                // Note: Returning Unauthorized for both wrong password and inactive status for security
                return Unauthorized("Invalid credentials or inactive user account.");
            }

            return Ok(employee);
        }
    }

    // Data Transfer Object (DTO) for Login
    public class LoginRequest
    {
        public string NationalId { get; set; }
        public string Password { get; set; }
    }
}