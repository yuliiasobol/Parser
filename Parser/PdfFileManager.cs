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
	public class PdfFileManager
	{
		private Document currentDocument;
		private Document CurrentDocument
		{
			get
			{
				if (this.currentDocument == null)
				{
					this.currentDocument = new Document();
					PdfWriter.GetInstance(this.CurrentDocument, new FileStream(@"..\Sources\Document.pdf", FileMode.Create));
					this.CurrentDocument.Open();
				}
				return this.currentDocument;
			}
		}

		private BaseFont CustomFonts
		{
			get
			{
				string[] fontNames = { "Segoe UI.ttf", "Calibri.ttf", "Arial.ttf", "Tahoma.ttf" };
				string fontFile = null;

				foreach (string name in fontNames)
				{
					fontFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), name);
					if (!File.Exists(fontFile))
						fontFile = null;
					else break;
				}

				if (fontFile == null)
					throw new FileNotFoundException("Ни один шрифт не найден.");


				FontFactory.Register(fontFile);
				return BaseFont.CreateFont(fontFile, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

			}
		}



		public void Write()
		{
			iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(@"..\Sources\images.jpg");
			jpg.Alignment = Element.ALIGN_CENTER;
			this.CurrentDocument.Add(jpg);

			PdfPTable table = new PdfPTable(3);
			PdfPCell cell = new PdfPCell(new Phrase("Simple table", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16, iTextSharp.text.Font.NORMAL, new BaseColor(System.Drawing.Color.Orange))));
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
			jpg = iTextSharp.text.Image.GetInstance(@"..\Sources\left.jpg");
			cell = new PdfPCell(jpg);
			cell.Padding = 5;
			cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
			table.AddCell(cell);
			cell = new PdfPCell(new Phrase("Col 2 Row 3"));
			cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
			cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
			table.AddCell(cell);


			jpg = iTextSharp.text.Image.GetInstance(@"..\Sources\right.jpg");
			cell = new PdfPCell(jpg);
			cell.Padding = 5;
			cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
			table.AddCell(cell);


			this.CurrentDocument.Add(table);


			this.CurrentDocument.Close();

		}

		private void Write(ArticleData articleData)
		{
			PdfPTable table = new PdfPTable(1);

			PdfPCell titleCell = new PdfPCell()
			{
				BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY,
				BorderColor = iTextSharp.text.BaseColor.DARK_GRAY,
				BorderWidth = 1,
				Phrase = new Phrase(articleData.Title, new iTextSharp.text.Font(this.CustomFonts, 24, iTextSharp.text.Font.NORMAL,
						new BaseColor(System.Drawing.Color.Ivory))),
				Padding = 5,
				HorizontalAlignment = Element.ALIGN_CENTER,
				VerticalAlignment = Element.ALIGN_CENTER
			};

			PdfPCell bodyCell = new PdfPCell()
			{
				BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY,
				BorderColor = iTextSharp.text.BaseColor.DARK_GRAY,
				BorderWidth = 1,
				Phrase = new Phrase(articleData.Body, new iTextSharp.text.Font(this.CustomFonts, 14, iTextSharp.text.Font.NORMAL,
						new BaseColor(System.Drawing.Color.Ivory))),
				Padding = 5,
				HorizontalAlignment = Element.ALIGN_LEFT,
				VerticalAlignment = Element.ALIGN_LEFT
			};

			PdfPCell footerCell = new PdfPCell()
			{
				BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY,
				BorderColor = iTextSharp.text.BaseColor.DARK_GRAY,
				BorderWidth = 1,
				Phrase = new Phrase("footer(c)", new iTextSharp.text.Font(this.CustomFonts, 14, iTextSharp.text.Font.NORMAL,
						new BaseColor(System.Drawing.Color.Ivory))),
				Padding = 5,
				HorizontalAlignment = Element.ALIGN_CENTER,
				VerticalAlignment = Element.ALIGN_CENTER
			};


			table.AddCell(titleCell);

			table.AddCell(bodyCell);
			table.AddCell(footerCell);


			this.CurrentDocument.Add(table);
		}


		public void WriteArticles(List<ArticleData> articlesCollections)
		{
			foreach (var currentArticle in articlesCollections)
				this.Write(currentArticle);

			this.CurrentDocument.Close();
		}
	}
}
