using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class InvoiceDB : BaseDB<Invoice>
    {
        protected override string GetTableName()
        {
            return "invoices";
        }

        protected override string GetPrimaryKeyName()
        {
            return "InvoiceID";
        }

        protected override async Task<Invoice> CreateModelAsync(object[] row)
        {
            Invoice inv = new Invoice();

            inv.InvoiceID = int.Parse(row[0].ToString());

            // Converting SQL DateTime to the custom Time model
            DateTime dt = DateTime.Parse(row[1].ToString());
            inv.InvoiceDateTime.ConvertIntToTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);

            inv.EmployeeID = row[2] != DBNull.Value ? int.Parse(row[2].ToString()) : 0;
            inv.Hours = row[3] != DBNull.Value ? int.Parse(row[3].ToString()) : 0;
            inv.Amount = row[4] != DBNull.Value ? int.Parse(row[4].ToString()) : 0;

            return inv;
        }

        /// <summary>
        /// Updates only the Amount and Hours columns for a specific invoice
        /// </summary>
        public async Task UpdateAmountAndHoursAsync(int invoiceId, int amount, int hours)
        {
            Dictionary<string, object> fields = new()
            {
                { "Amount", amount },
                { "Hours", hours }
            };

            Dictionary<string, object> where = new()
            {
                { "InvoiceID", invoiceId }
            };

            await UpdateAsync(fields, where);
        }

        /// <summary>
        /// Registers a new invoice in the database
        /// </summary>
        public async Task<Invoice> AddInvoiceAsync(Invoice invoice)
        {
            // Convert Time model back to string/DateTime for SQL
            DateTime dt = new DateTime(
                invoice.InvoiceDateTime.year,
                invoice.InvoiceDateTime.month,
                invoice.InvoiceDateTime.day,
                invoice.InvoiceDateTime.hour,
                invoice.InvoiceDateTime.minute, 0);

            Dictionary<string, object> fields = new()
            {
                { "InvoiceDateTime", dt },
                { "EmployeeID", invoice.EmployeeID },
                { "Hours", invoice.Hours },
                { "Amount", invoice.Amount }
            };

            return await InsertGetObjAsync(fields);
        }
        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await SelectAllAsync();
        }

    }
}