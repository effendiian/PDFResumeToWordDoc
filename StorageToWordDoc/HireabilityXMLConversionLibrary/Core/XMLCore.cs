// TODO: Boilerplate.
using HireabilityXMLConversionLibrary.Core.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HireabilityXMLConversionLibrary.Core
{
	// TODO: Class description.
	public class XMLCore
	{
		#region Constants

		// TODO: Create the constants for each XMLConversion code.
		// Conversion Codes.
		public const string XML_CSV = "XML to CSV";
		public const string CSV_XML = "CSV to XML";

		#endregion

		#region Attributes

		// Base attributes
		private string _filename;
		private string _blob;
		private XmlDocument _xmldoc;

		// Storage
		private Dictionary<string, XMLConversion> _conversions; // Conversions are saved here.

		// Flags
		private bool _initialized;

		#endregion

		#region Properties

		/// <summary>
		/// FileName returns this XML
		/// file's filename.
		/// </summary>
		public string FileName
		{
			get { return this._filename; }
		}

		/// <summary>
		/// Content returns the XML file
		/// as a full text file.
		/// </summary>
		public string Content
		{
			get { return this._blob; }
		}

		// TODO: Create properties for each of the conversions.
		public XmlDocument CoreDocument
		{
			get { return this._xmldoc; }
		}

		public CsvDocument CSVDocument
		{
			get
			{
				// Have we initialized?
				if(!_initialized) { return null; }

				// Does it exist in the dictionary?
				return _conversions[XML_CSV].GetDocument();
			}
		}

		// public CSVCore CSV;		
		// public XMLCore XML;

		// Flags
		/// <summary>
		/// <summary>
		/// Initialized returns true if
		/// the file has been initialized.
		/// </summary>
		public bool Initialized
		{
			get { return this._initialized; }
		}

		#endregion


		// TODO: Focus on speed.

		#region Constructors / initialization

		// TODO: Constructor should take the filepath to an XML object.
		/// <summary>
		/// XMLCore(string) takes the filename for an xml document
		/// and creates an XmlDocument wrapper from it.
		/// </summary>
		/// <param name="filename">Filename of the xml file.</param>
		public XMLCore(string filename)
		{
			this._filename = filename;
			this._init();
		}

		/// <summary>
		/// _init() is used by the constructors to initialize the class.
		/// </summary>
		private void _init()
		{
			this._initialized = false;

			try
			{
				this._xmldoc = new XmlDocument();
				this._xmldoc.Load(this._filename);

				this._conversions = new Dictionary<string, XMLConversion>();
				this._conversions.Add(XML_CSV, null);

				this._initialized = true;
				return;
			}
			catch (Exception ex)
			{
				this._initialized = false;
				throw ex;
			}
		}

		#endregion

		// TODO: Methods set up to convert to different formats.


		// TODO: Focus on turning into a CSV file.





	}
}
