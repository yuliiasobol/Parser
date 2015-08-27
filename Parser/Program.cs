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

            //using(StreamWriter writer= new  StreamWriter(@"C:\Users\v-ysobol\Desktop\myPDF.pdf"))
            //{
            //	writer.Write(firstSubmainNodeName[0]);
            //}

			//PdfFileManager.Write();

			ParseManager parserManager = new ParseManager()
			{
				HostUrl = @"http://r3zslyr3zsl.owl.e.s55.ru.wbprx.com/page{0}/",
				FoundWorlds = new List<string>() {"o"},
				ParseExpression =
					"//body/div[@id='layout']/div[@class='inner']/div[@class='content_left']/div[@class='posts_list']/div[@class='posts shortcuts_items']/div[@class='post shortcuts_item']",
					PageNumCount = 2
			};


			parserManager.Parse();

			(new PdfFileManager()).WriteArticles(null);


			Console.ReadLine();
			
		}
	}
}
