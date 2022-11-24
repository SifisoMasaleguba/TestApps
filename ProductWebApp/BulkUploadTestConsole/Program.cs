using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ProductWebApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BulkUploadTestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-AU");
                string ProductList = JsonConvert.SerializeObject(MapProduct(), Formatting.Indented);
                
                string ApiUrl = "http://localhost:802/ProductWebApp/api/v1/products/addbulkproduct";
               PostRequest(ApiUrl, ProductList);
            }
            catch (Exception exc)
            {
                throw exc;
            }
           
        }
          private static string PostRequest(string url, string ProductListjson)
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                string result = "";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(ProductListjson);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                try
                {
                    using (var response = httpWebRequest.GetResponse() as HttpWebResponse)
                    {
                        if (httpWebRequest.HaveResponse && response != null)
                        {
                            using (var reader = new StreamReader(response.GetResponseStream()))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                }
                catch (WebException e)
                {
                    if (e.Response != null)
                    {
                        using (var errorResponse = (HttpWebResponse)e.Response)
                        {
                            using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                            {
                                string error = reader.ReadToEnd();
                                result = error;
                            }
                        }

                    }
                }

                return result;

            }

        

        public static List<Product> MapProduct() {
            try
            {
                List<Product> products = new List<Product>();
                var filePath = @"C:\Temp\Products.xlsx";
                string sFileExtension = Path.GetExtension(filePath).ToLower();
                ISheet sheet;
            
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
              
                if (sFileExtension == ".xls")    
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(stream);
                    sheet = hssfwb.GetSheetAt(0);
                }
                else   
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(stream);
                    sheet = hssfwb.GetSheetAt(0);
                }
                IRow headerRow = sheet.GetRow(0);
               
                    for (int row = 0; row <= sheet.LastRowNum; row++)
                    {
                        if (row == 0) continue;  //first row has headings
                        if (sheet.GetRow(row) != null) //check if row only contains empty cells 
                        {   
                            var dateCellValue = sheet.GetRow(row).GetCell(2).DateCellValue.ToString("yy-MM-dd");
                            var ReleaseDate = DateTime.ParseExact(dateCellValue, "yy-MM-dd", CultureInfo.GetCultureInfo("en-AU"));
                          Product product =new Product() 
                          { 
                            Name = sheet.GetRow(row).GetCell(0).StringCellValue,
                            Price = (float)sheet.GetRow(row).GetCell(1).NumericCellValue,
                            ReleaseDate = ReleaseDate.ToString("yyyy-MM-dd")
                          };
                         products.Add(product);
                         }
                    }

                }
                return products;            
            }
            catch (Exception exc)
            {

                throw exc;
            }

        }
     
    }
}
