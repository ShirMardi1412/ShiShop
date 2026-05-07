using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class EmployeeDB : BaseDB<Employee>
    {
        protected override string GetTableName()
        {
            return "employees";
        }

        protected override string GetPrimaryKeyName()
        {
            return "EmployeeID";
        }

        protected override async Task<Employee> CreateModelAsync(object[] row)
        {
            Employee e = new Employee();

            e.EmployeeID = int.Parse(row[0].ToString());
            e.Password = row[1].ToString();
            e.NationalID = row[2].ToString();
            e.IsManager = bool.Parse(row[3].ToString());
            e.PhoneNumber = row[4].ToString();
            e.HourRage = int.Parse(row[5].ToString());
            e.IsActivie = bool.Parse(row[6].ToString());

            return e;
        }


        // התחברות עם תעודת זהות וסיסמא - 1 מסמל פעיל, 0 מסמן לא פעיל
        public async Task<Employee> LoginAsync(string nationalId, string password)
        {
            Dictionary<string, object> p = new()
            {
                { "NationalId", nationalId },
                { "Password", password },
                { "IsActive", 1 }
            };

            List<Employee> list = await SelectAllAsync(p);

            if (list.Count == 1)
                return list[0];

            return null;
        }

        public async Task UpdatePhoneAsync(int employeeId, string phone)
        {
            Dictionary<string, object> fields = new()
            {
                { "PhoneNumber", phone }
            };

            Dictionary<string, object> where = new()
            {
                { "employeeID", employeeId }
            };

            await UpdateAsync(fields, where);
        }

        // עדכון שכר לעובד מסוים
        public async Task UpdateWageAsync(int employeeId, int wage)
        {
            Dictionary<string, object> fields = new()
    {
        { "HourRage", wage }
    };

            Dictionary<string, object> where = new()
    {
        { "employeeID", employeeId }
    };

            await UpdateAsync(fields, where);
        }

        // פיטורים - הופך עובד ללא פעיל
        public async Task SetActiveAsync(int employeeId, bool active)
        {
            Dictionary<string, object> fields = new()
    {
        { "IsActive", active }
    };

            Dictionary<string, object> where = new()
    {
        { "employeeID", employeeId }
    };

            await UpdateAsync(fields, where);
        }

        // מראה רשימה של כל העובדים שעדיין פעילים
        public async Task<List<Employee>> GetAllEmployeesAsync(bool includeInactive = true)
        {
            if (includeInactive)
                return await SelectAllAsync();

            Dictionary<string, object> p = new()
    {
        { "IsActive", 1 }
    };
            return await SelectAllAsync(p);
        }

        //  עדכון סיסמא
        public async Task UpdatePasswordAsync(int employeeId, string password)
        {
            Dictionary<string, object> fields = new()
    {
        { "Password", password }
    };

            Dictionary<string, object> where = new()
    {
        { "employeeID", employeeId }
    };

            await UpdateAsync(fields, where);
        }


        // עדכון תעודת זהות
        public async Task UpdateNationalIDAsync(int employeeId, string nationalId)
        {
            Dictionary<string, object> fields = new()
    {
        { "NationalID", nationalId }
    };

            Dictionary<string, object> where = new()
    {
        { "employeeID", employeeId }
    };

            await UpdateAsync(fields, where);
        }


        // עדכון הרשאת מנהל/עובד
        public async Task UpdateManagerStatusAsync(int employeeId, bool isManager)
        {
            Dictionary<string, object> fields = new()
    {
        { "IsManager", isManager }
    };

            Dictionary<string, object> where = new()
    {
        { "employeeID", employeeId }
    };

            await UpdateAsync(fields, where);
        }


        // אפשרות לעדכון הכל בבת אחת
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            // יצירת מילון של כל השדות שניתן לעדכן
            Dictionary<string, object> fields = new()
    {
        { "Password", employee.Password },
        { "NationalID", employee.NationalID },
        { "IsManager", employee.IsManager },
        { "PhoneNumber", employee.PhoneNumber },
        { "HourRage", employee.HourRage }, // מיפוי לפי הפעולה הקודמת שלך
        { "IsActive", employee.IsActivie }    // מיפוי לפי הפעולה הקודמת שלך
    };

            // הגדרת התנאי - לפי ה-ID של העובד שהתקבל
            Dictionary<string, object> where = new()
    {
        { "employeeID", employee.EmployeeID }
    };

            await UpdateAsync(fields, where);
        }



        // רשימת משתמש חדש
        public async Task<Employee> RegisterEmployeeAsync(Employee employee)
        {
            // יצירת המילון לפי שמות המשתנים המדויקים במודל שלך
            Dictionary<string, object> fields = new()
    {
        // הערה: בדרך כלל לא שולחים את EmployeeID כי הוא נוצר אוטומטית במסד הנתונים
        { "Password", employee.Password },
        { "NationalID", employee.NationalID },
        { "IsManager", employee.IsManager },
        { "PhoneNumber", employee.PhoneNumber },
        { "HourRage", employee.HourRage }, 
        { "IsActive", employee.IsActivie }  
    };

            // שימוש בפעולה מה-BaseDB שמחזירה את האובייקט שנוצר
            return await InsertGetObjAsync(fields);
        }

    }
}



