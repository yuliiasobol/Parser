using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Parser
{
	public class ParseManager
	{

		private HtmlWeb htmlWeb { get; set; }
		public string HostUrl { get; set; }
		public string ParseExpression { get; set; }
		public List<string> FoundWorlds { get; set; }
		public int PageNumCount { get; set; }

		public List<ArticleData> ArticlesCollection { get; set; }

		public ParseManager()
		{
			this.ArticlesCollection = new List<ArticleData>();
			this.FoundWorlds = new List<string>();
			this.htmlWeb = new HtmlWeb() { AutoDetectEncoding = false };
		}

		public void Parse()
		{
			HtmlDocument currentPageDoc = null;
			HtmlNodeCollection currentArticles = null;
			//List<string> filteredarticles = null;

			for (int i = 1; i < this.PageNumCount; i++)
			{
				currentPageDoc = this.htmlWeb.Load(this.HostUrl.f(i));
				currentArticles = currentPageDoc.DocumentNode.SelectNodes(this.ParseExpression);
				var filteredarticles =
					currentArticles.Where(n => n.ChildNodes[1].InnerText.Contains(this.FoundWorlds.First())).ToList();


				foreach (var current in filteredarticles)
				{
					ArticlesCollection.Add(new ArticleData(){Title = current.ChildNodes[1].InnerText, Body = current.ChildNodes[3].InnerText});
				}
			}
		}
	}
}
