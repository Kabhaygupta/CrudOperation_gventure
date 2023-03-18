using CrudOperation_gventure.Models;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Colors;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace CrudOperation_gventure.Report
{
    public class PDFReport
    {
        public Products Products { get; set; }
        public string usd { get; set; }

        public PDFReport(Products products)
        {
            Products = products;
            GetUSD();
        }
        public byte[] pdf()
        {
            byte[] data;
            try
            {
                MemoryStream stream = new MemoryStream();
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdfDocument = new PdfDocument(writer);//itext7 use for making pdf doc /itextsharp
                using (var doc = new iText.Layout.Document(pdfDocument, PageSize.A4, false))
                {
                    Color bgColour = new DeviceRgb(255, 204, 204);
                    doc.SetBackgroundColor(bgColour);
                    Paragraph paragraph = new Paragraph("Invoice");
                    paragraph.SetBold().SetTextAlignment(TextAlignment.CENTER).SetUnderline();
                    doc.Add(paragraph);
                    doc.Add(new Paragraph("\n"));
                    paragraph = new Paragraph("Product ID : " + Convert.ToString(Products.P_Id));

                    doc.Add(paragraph);
                    doc.Add(new Paragraph("\n"));
                    paragraph = new Paragraph("Product Name : " + Convert.ToString(Products.P_Name));
                    doc.Add(paragraph);
                    doc.Add(new Paragraph("\n"));
                    paragraph = new Paragraph("Product Model :" + Convert.ToString(Products.P_Model));
                    doc.Add(paragraph);
                    doc.Add(new Paragraph("\n"));
                    paragraph = new Paragraph("Product Price USD : " + Convert.ToString(usd));
                    doc.Add(paragraph);
                }
                writer.Dispose();
                pdfDocument.Close();
                data = stream.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }



            return data;
        }

        public async void GetUSD()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://api.exchangeratesapi.io/v1/?access_key=KFDfNeWPNK1vwkC1ZfUagT9yhEUlD3Wm");
            request.Method = HttpMethod.Get;
            //request.Headers.Add("access_key", "KFDfNeWPNK1vwkC1ZfUagT9yhEUlD3Wm");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            var responseMsg = await response.Content.ReadAsStringAsync();
            JObject jobject = JObject.Parse(responseMsg);
            usd = (string)jobject.GetValue(@"rates\USD");

        }

    }
}
