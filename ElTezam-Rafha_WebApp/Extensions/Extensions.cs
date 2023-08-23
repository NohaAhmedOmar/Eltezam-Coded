using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Eltezam_Coded.Extensions
{
    public static class Extensions
    {
        public static DataTable ToDataTable<T>(this List<T> values)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in values)
            {
                var Values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    Values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        public static DataTable ToDataTableSingleRecord<T>(this T value)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {

                values[i] = Props[i].GetValue(value, null);
            }
            dataTable.Rows.Add(values);

            return dataTable;

        }
        public static List<T> ConvertDataTableToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public static string ToddmmyyHijri(this DateTime date)
        {
            string day, month, year;
            day = date.Day.ToString();
            month = date.Month.ToString();
            year = date.Year.ToString();

            return date.Day < 10 ? ("0" + date.Day.ToString()) : (date.Day.ToString() + "-" + (date.Month < 10 ? "0" + date.Month.ToString() : date.Month.ToString()) + "-" + date.Year.ToString());
        }
        public static string AddZeros(this int number)
        {
            var numberformat = number.ToString();
            string outstring = "";
            if (numberformat.Length < 9)
            {
                for (int i = 0; i < 9 - numberformat.Length; i++)
                {
                    outstring += "0";
                }
                return outstring + numberformat;
            }
            return numberformat;
        }
    }
}
public static class IdentityHelpers
{
    public static Task EnableIdentityInsert<T>(this DbContext context) => SetIdentityInsert<T>(context, enable: true);
    public static Task DisableIdentityInsert<T>(this DbContext context) => SetIdentityInsert<T>(context, enable: false);

    private static Task SetIdentityInsert<T>(DbContext context, bool enable)
    {
        var entityType = context.Model.FindEntityType(typeof(T));
        var value = enable ? "ON" : "OFF";
        return context.Database.ExecuteSqlRawAsync(
            $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}");
    }

    public async static Task SaveChangesWithIdentityInsert<T>(this DbContext context)
    {
        try
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            await context.EnableIdentityInsert<T>();
            await context.SaveChangesAsync();
            await context.DisableIdentityInsert<T>();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {

        }
    }

}
public static class DeleteStatement
{
    public static async Task Delete<T>(this DbContext context) where T : class
    {
        var entityType = context.Model.FindEntityType(typeof(T));


        await context.Database.ExecuteSqlRawAsync($"Delete  ");
    }
}