using Models;
using DBL;
namespace ConsoleUnitTesting1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //            //EmployeeDB db = new EmployeeDB();

            //            //Console.WriteLine("--- מתחיל בדיקות למחלקת EmployeeDB --- \n");

            //            //// 1. בדיקת התחברות (Login)
            //            //Console.WriteLine("בדיקה 1: התחברות...");
            //            //Employee emp = await db.LoginAsync("123456789", "1234");
            //            //if (emp != null)
            //            //    Console.WriteLine($"התחברות הצליחה! ברוך הבא: {emp.EmployeeID}");
            //            //else
            //            //    Console.WriteLine("התחברות נכשלה (משתמש לא קיים או לא פעיל).");

            //            //// 2. עדכון מספר טלפון
            //            //Console.WriteLine("\nבדיקה 2: עדכון טלפון לעובד 1...");
            //            //await db.UpdatePhoneAsync(1, "050-1234567");
            //            //Console.WriteLine("עדכון טלפון בוצע.");

            //            //// 3. עדכון שכר
            //            //Console.WriteLine("\nבדיקה 3: עדכון שכר לעובד 1...");
            //            //await db.UpdateWageAsync(1, 55);
            //            //Console.WriteLine("עדכון שכר בוצע.");

            //            //// 4. שינוי סטטוס פעיל/לא פעיל (פיטורים)
            //            //Console.WriteLine("\nבדיקה 4: הפיכת עובד 2 ללא פעיל...");
            //            //await db.SetActiveAsync(2, false);
            //            //Console.WriteLine("סטטוס עובד עודכן.");

            //            //// 5. שליפת רשימת עובדים
            //            //Console.WriteLine("\nבדיקה 5: שליפת כל העובדים הפעילים...");
            //            //List<Employee> activeEmployees = await db.GetAllEmployeesAsync(includeInactive: false);
            //            //Console.WriteLine($"נמצאו {activeEmployees.Count} עובדים פעילים:");
            //            //foreach (var e in activeEmployees)
            //            //{
            //            //    Console.WriteLine($"- ID: {e.EmployeeID}, שכר שעתי: {e.HourRage}");
            //            //}

            //            //Console.WriteLine("\n--- סיום בדיקות ---");
            //            //Console.ReadLine();








            //            ShiftDB sdb = new ShiftDB();

            //            Console.WriteLine("--- מתחיל בדיקות למחלקת ShiftDB --- \n");

            //            // 1. הוספת משמרת חדשה
            //            Console.WriteLine("בדיקה 1: הוספת משמרת חדשה למערכת...");
            //            Shift newShift = new Shift
            //            {
            //                ShiftDate = DateTime.Now.AddDays(1), // משמרת למחר
            //                ShiftType = ShiftTypeEnum.Morning,
            //                StartTime = new TimeSpan(08, 00, 00), // 08:00
            //                EndTime = new TimeSpan(16, 00, 00),   // 16:00
            //                EmployeeID = 0 // בינתיים ללא עובד
            //            };

            //            Shift createdShift = await sdb.AddShiftAsync(newShift);
            //            if (createdShift != null && createdShift.ShiftID > 0)
            //                Console.WriteLine($"משמרת נוצרה בהצלחה! מזהה משמרת: {createdShift.ShiftID}");
            //            else
            //                Console.WriteLine("נכשלה יצירת המשמרת.");


            //            // 2. שליפת משמרות לפי תאריך (של מחר)
            //            Console.WriteLine($"\nבדיקה 2: שליפת משמרות לתאריך {DateTime.Now.AddDays(1).ToShortDateString()}...");
            //            List<Shift> tomorrowShifts = await sdb.GetShiftsByDateAsync(DateTime.Now.AddDays(1));
            //            Console.WriteLine($"נמצאו {tomorrowShifts.Count} משמרות לתאריך המבוקש.");
            //            foreach (var s in tomorrowShifts)
            //            {
            //                Console.WriteLine($"- ID: {s.ShiftID}, סוג: {s.ShiftType}, שעות: {s.StartTime} - {s.EndTime}");
            //            }


            //            // 3. שיבוץ עובד למשמרת שזה עתה יצרנו
            //            if (createdShift != null)
            //            {
            //                Console.WriteLine($"\nבדיקה 3: שיבוץ עובד 1 למשמרת {createdShift.ShiftID}...");
            //                await sdb.AssignEmployeeToShiftAsync(createdShift.ShiftID, 1);
            //                Console.WriteLine("שיבוץ עובד עודכן במסד הנתונים.");
            //            }


            //            // 4. בדיקת שליפת משמרות של עובד ספציפי
            //            Console.WriteLine("\nבדיקה 4: שליפת כל המשמרות של עובד מס' 1...");
            //            List<Shift> employeeShifts = await sdb.GetShiftsByEmployeeAsync(1);
            //            Console.WriteLine($"לעובד 1 רשומות {employeeShifts.Count} משמרות במערכת.");


            //            // 5. מחיקת המשמרת שייצרנו (לצורך ניקוי הבדיקה)
            //            if (createdShift != null)
            //            {
            //                Console.WriteLine($"\nבדיקה 5: מחיקת משמרת זמנית {createdShift.ShiftID}...");
            //                await sdb.DeleteShiftAsync(createdShift.ShiftID);
            //                Console.WriteLine("המשמרת נמחקה.");
            //            }

            //            Console.WriteLine("\n--- סיום בדיקות ShiftDB ---");
            //            Console.ReadLine();

            //        }
            //    }
            //}


            InvoiceDB invDb = new InvoiceDB();

            Console.WriteLine("--- Starting tests for InvoiceDB --- \n");

            // 1. Create and Register a new Invoice
            Console.WriteLine("Test 1: Adding a new invoice...");

            Invoice newInv = new Invoice();
            // Setting the custom Time model
            newInv.InvoiceDateTime.ConvertIntToTime(2024, 5, 20, 14, 30);
            newInv.EmployeeID = 1; // Assuming employee 1 exists
            newInv.Hours = 180;
            newInv.Amount = 9000;

            Invoice createdInv = await invDb.AddInvoiceAsync(newInv);

            if (createdInv != null)
                Console.WriteLine($"Successfully added! New Invoice ID: {createdInv.InvoiceID}");
            else
                Console.WriteLine("Failed to add invoice.");


            // 2. Update Amount and Hours
            Console.WriteLine($"\nTest 2: Updating Amount and Hours for Invoice ID: {createdInv?.InvoiceID ?? 1}...");

            int targetId = createdInv?.InvoiceID ?? 1;
            int newAmount = 9500;
            int newHours = 190;

            await invDb.UpdateAmountAndHoursAsync(targetId, newAmount, newHours);
            Console.WriteLine("Update completed.");


            // 3. Select all invoices and print them
            Console.WriteLine("\nTest 3: Retrieving all invoices from DB...");

            List<Invoice> allInvoices = await invDb.GetAllInvoicesAsync();

            Console.WriteLine($"Found {allInvoices.Count} invoices:");
            foreach (var inv in allInvoices)
            {
                // Accessing the custom Time model properties
                string dateStr = $"{inv.InvoiceDateTime.day}/{inv.InvoiceDateTime.month}/{inv.InvoiceDateTime.year}";

                Console.WriteLine($"- [ID: {inv.InvoiceID}] Date: {dateStr}, EmpID: {inv.EmployeeID}, Hours: {inv.Hours}, Amount: {inv.Amount}");
            }

            Console.WriteLine("\n--- End of tests ---");
            Console.ReadLine();

        }
    }
}
