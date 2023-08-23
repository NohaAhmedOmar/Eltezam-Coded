using Eltezam_Coded.DomainModels;
using Eltezam_Coded.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.OleDb;
using System.Net.Http.Headers;

namespace Eltezam_Coded.Services
{
    public interface IUploadExcelSheetService
    {
        public  Task<ResponseModel> PostExcelSheet(IFormFile FormFile,Dictionary<string,string>Mappings);
    }
    public class UploadExcelSheetService: IUploadExcelSheetService
    {
        private readonly CodedContext _context;
        public UploadExcelSheetService(CodedContext _context) => this._context = _context;

 


        public async Task<ResponseModel> PostExcelSheet(IFormFile FormFile, Dictionary<string, string> Mappings)
        {
            List<string> nums = new List<string>();

            try
            {
                //get file name
                var filename = ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                string[] tokens = filename.Split('.');
                string format = tokens[tokens.Length - 1].ToLower();
                if (format != "xlsx".ToLower() && format != "xls".ToLower())
                {
                    // ViewBag.TypeError = "Invalid File Format";
                    return new ResponseModel { IsSuccess = false };
                }
                else
                {
                    //get path
                    var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                    if (!Directory.Exists(MainPath))
                    {
                        Directory.CreateDirectory(MainPath);
                    }

                    //get file path 
                    var filePath = Path.Combine(MainPath, FormFile.FileName);
                    using (System.IO.Stream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await FormFile.CopyToAsync(stream);
                    }

                    string extension = Path.GetExtension(filename);


                    string conString = string.Empty;

                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                            conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                        case ".xlsx": //Excel 07 and above.
                            conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                    }
                    DataTable dt = new DataTable();
                    conString = string.Format(conString, filePath);
                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                // string sheetName = "Sheet1";
                                connExcel.Close();


                                string SheetName = "Sheet1";
                                //Read Data from First Sheet.
                                connExcel.Open();
                                cmdExcel.CommandText = $"SELECT * From [{SheetName}$]";
                                odaExcel.SelectCommand = cmdExcel;
                                odaExcel.Fill(dt);

                                //for (int i = 0; i < dt.Rows.Count; i++)
                                //{
                                //    nums.Add(dt.Rows[i]["Phone"].ToString());

                                //}
                                connExcel.Close();
                            }
                        }
                    }

                    conString = "Data Source=.;Initial Catalog=CRM_Database;Integrated Security=True";

                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name.
                            sqlBulkCopy.DestinationTableName = "dbo.Leads";

                            // Map the Excel columns with that of the database table, this is optional but good if you do
                            // 
                            foreach (var item in Mappings)
                            {
                                sqlBulkCopy.ColumnMappings.Add(item.Key, item.Value);
                            }
                        


                            con.Open();
                            sqlBulkCopy.WriteToServer(dt);
                            con.Close();
                        }
                    }

                    //ViewBag.Message = "File Imported and excel data saved into database";
                    return new ResponseModel { IsSuccess = true };
                }
                //var res = await _context.Database.ExecuteSqlRawAsync($"PostUploadedSheet 'Sheet1','Uploaded' ");
                //if (res > 0)
                //{
                //    UploadedExcelSheet uploadedExcel = new UploadedExcelSheet();
                //    uploadedExcel.Name = "Sheet1";
                //    uploadedExcel.status = "Uploaded";
                //    uploadedExcel.UploadedAt = DateTime.Now;
                //    return uploadedExcel;

                //}
                //else
                //{
                //    return new UploadedExcelSheet { Name = "Sheet1", status = "Failed", UploadedAt = DateTime.Now };
                //}
            }
            catch (Exception e)
            {
               // int count = 0;

                // ViewBag.Error = e.Message;
                //List<string>copy=new List<string>();
                //foreach (var item in nums)
                //{
                //    copy.Add(item);
                //}
                //copy.Sort();
                //for (int i = 0; i < nums.Count; i++)
                //{
                //    for (int j = i + 1; j < nums.Count; j++)
                //    {
                //        if (nums[i] == nums[j])
                //            count++;
                //        else
                //            continue;
                //    }
                //}
                //if (count != 0)
                //    //    ViewBag.count = count;
                //    return new UploadedExcelSheet { status = "Faild", DuplicatesCount = count };
                //else
                //    return new UploadedExcelSheet { status = "Faild", DuplicatesCount = nums.Count() };
                return new ResponseModel { IsSuccess = false };
            }

        }
    }
}
