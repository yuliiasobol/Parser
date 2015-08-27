using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Parser
{
	class Program
	{
		static void Main(string[] args)
		{


			//int lastPageNum = 100;

			//var webGet = new HtmlWeb() { AutoDetectEncoding = false };
			//var doc = webGet.Load("http://r3zslyr3zsl.owl.e.s55.ru.wbprx.com/");

			//List<string> listResults=new List<string>();


			//HtmlNodeCollection articles =
			//	doc.DocumentNode.SelectNodes(
			//		"//body/div[@id='layout']/div[@class='inner']/div[@class='content_left']/div[@class='posts_list']/div[@class='posts shortcuts_items']/div[@class='post shortcuts_item']");/*/h1[@class='title']*/


			//var firstSubmainNodeName = articles.Where(n => n.ChildNodes[1].InnerText.Contains("Оптимизация")).Select(n => n.ChildNodes[0].InnerText).ToList();


            //using(StreamWriter writer= new  StreamWriter(@"C:\Users\v-ysobol\Desktop\myPDF.pdf"))
            //{
            //	writer.Write(firstSubmainNodeName[0]);
            //}

			//PdfFileManager.Write();

			ParseManager parserManager = new ParseManager()
			{
				HostUrl = "http://r3zslyr3zsl.owl.e.s55.ru.wbprx.com/",
				FoundWorlds = new List<string>() {"Оптимизация"},
				ParseExpression =
					"//body/div[@id='layout']/div[@class='inner']/div[@class='content_left']/div[@class='posts_list']/div[@class='posts shortcuts_items']/div[@class='post shortcuts_item']"
			};





			Console.ReadLine();
			
		}
	}
}
