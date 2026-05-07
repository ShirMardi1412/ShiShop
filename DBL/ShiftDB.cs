using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBL
{
    public class ShiftDB : BaseDB<Shift>
    {
        protected override string GetTableName() => "shifts";
        protected override string GetPrimaryKeyName() => "ShiftID"; // Corrected to ID based on SQL conventions

        
        /// Maps a database row to a Shift model instance using precise column indices.
       
        protected override async Task<Shift> CreateModelAsync(object[] row)
        {
            Shift s = new Shift();
            s.ShiftId = int.Parse(row[0].ToString());
            s.DateTime = DateTime.Parse(row[1].ToString());

            if (Enum.TryParse(row[2].ToString(), out Shift.ShiftType parsedType))
            {
                s.Type = parsedType;
            }

            s.Start = DateTime.Parse(row[3].ToString());
            s.End = DateTime.Parse(row[4].ToString());

            if (row[5] != null && row[5] != DBNull.Value)
                s.EmployCode = int.Parse(row[5].ToString());
            else
                s.EmployCode = 0;

            return s;
        }

        
        /// Retrieves all shifts from the database.
        
        public async Task<List<Shift>> GetAllShiftsAsync()
        {
            return await SelectAllAsync();
        }

        
        /// Inserts a new shift using the exact column names from your SQL schema.
        
        public async Task<Shift> AddShiftAsync(Shift shift)
        {
            Dictionary<string, object> fields = new()
            {
                { "ShiftDate", shift.DateTime },
                { "ShiftType", shift.Type.ToString() },
                { "StartTime", shift.Start },
                { "EndTime", shift.End },
                { "EmployeeID", shift.EmployCode == 0 ? null : (object)shift.EmployCode }
            };
            return await InsertGetObjAsync(fields);
        }

        
        /// Updates the assigned employee for a specific shift.
        
        public async Task AssignEmployeeToShiftAsync(int shiftId, int? employeeId)
        {
            Dictionary<string, object> updateFields = new()
            {
                { "EmployeeID", employeeId }
            };

            Dictionary<string, object> filterFields = new()
            {
                { "ShiftID", shiftId }
            };

            await UpdateAsync(updateFields, filterFields);
        }

        
        /// Deletes a shift record using a filter dictionary.
        
        public async Task DeleteShiftAsync(int id)
        {
            Dictionary<string, object> filter = new()
            {
                { "ShiftID", id }
            };

            await DeleteAsync(filter);
        }
    }
}