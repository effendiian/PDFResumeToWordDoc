using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HireabilityXMLConversionLibrary.Core.CSV
{
	// TODO: Class boilerplate and description.
	public class CSVConversion : XMLConversion
	{

		
		private CsvDocument _csvDoc;
		private XmlDocument _xmlDoc;

		public CSVConversion()
		{
			_csvDoc = new CsvDocument();
		}

		
	}
}
