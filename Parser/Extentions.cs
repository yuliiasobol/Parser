using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
	public static class Extentions
	{
		public static string f(this string currentString, params object [] parameters)
		{
			return String.Format(currentString, parameters);
		}
	}
}
