using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
	public class PdfReportController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult StaticPdfReport()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
			var stream = new FileStream(path, FileMode.Create);

			Document document = new Document(PageSize.A4);
			PdfWriter.GetInstance(document,stream);

			document.Open();
			Paragraph paragraph = new Paragraph("Traversal Rezervasyon PDF Raporu");
			document.Add(paragraph);
			document.Close();
			return File("/pdfreports/dosya1.pdf", "application/pdf","dosya1.pdf");
		}

		public IActionResult StaticCustomerReport()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");
			var stream = new FileStream(path, FileMode.Create);

			Document document = new Document(PageSize.A4);
			PdfWriter.GetInstance(document, stream);

			document.Open();
			PdfPTable pdfPTable = new PdfPTable(3);
			pdfPTable.AddCell("Kullanici Adi");
			pdfPTable.AddCell("Kullanici Soyadi");
			pdfPTable.AddCell("Kullanici TC");

			pdfPTable.AddCell("Dogu Berkan");
			pdfPTable.AddCell("Koroglu");
			pdfPTable.AddCell("11111111111");

			pdfPTable.AddCell("Bulent Mert");
			pdfPTable.AddCell("Yapici");
			pdfPTable.AddCell("222222222222");

			pdfPTable.AddCell("Yekta");
			pdfPTable.AddCell("Cetintas");
			pdfPTable.AddCell("3333333333333");

			document.Add(pdfPTable);
			document.Close();
			return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya2.pdf");
		}
	}
}
