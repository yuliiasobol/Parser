using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Parser
{
	static class PdfFileManager
	{
		public static object Color { get; private set; }

		public static void Write()
		{
			var doc = new Document();
			PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\apen\Desktop\Document.pdf", FileMode.Create));
			doc.Open();

			iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(@"C:\Users\apen\Desktop\images.jpg");
			jpg.Alignment = Element.ALIGN_CENTER;
			doc.Add(jpg);

			PdfPTable table = new PdfPTable(3);
			PdfPCell cell = new PdfPCell(new Phrase("Simple table",
			  new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
			  iTextSharp.text.Font.NORMAL, new BaseColor(System.Drawing.Color.Orange))));
			cell.BackgroundColor = new BaseColor(System.Drawing.Color.Wheat);
			cell.Padding = 5;
			cell.Colspan = 3;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			table.AddCell(cell);
			table.AddCell("Col 1 Row 1");
			table.AddCell("Col 2 Row 1");
			table.AddCell("Col 3 Row 1");
			table.AddCell("Col 1 Row 2");
			table.AddCell("Col 2 Row 2");
			table.AddCell("Col 3 Row 2");
			jpg = iTextSharp.text.Image.GetInstance(@"C:\Users\apen\Desktop\left.jpg");
			cell = new PdfPCell(jpg);
			cell.Padding = 5;
			cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			table.AddCell(cell);
			cell = new PdfPCell(new Phrase("Col 2 Row 3"));
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
			table.AddCell(cell);
			jpg = iTextSharp.text.Image.GetInstance(@"C:\Users\apen\Desktop\right.jpg");
			cell = new PdfPCell(jpg);
			cell.Padding = 5;
			cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			table.AddCell(cell);
			doc.Add(table);
			doc.Close();

		}
	}
}
