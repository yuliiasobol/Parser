using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
   public class ArticleData
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public List<Uri> ImagesColletion { get; set; }
        public List<string> CodeSnippetCollection { get; set; }
	 
    }
}
