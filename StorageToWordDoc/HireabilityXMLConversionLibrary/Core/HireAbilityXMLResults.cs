// TODO: Boilerplate
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core
{
	// TODO: Description.
	public class HireAbilityXMLResults
	{
		#region Attributes

		private int _id;
		private string _rid;
		private string _lang;
		private string _xmlns;
		private string _xmlnsxsi;
		private string _schemaLocation;
		private DateTime _timeStamp;
		private ProcessingErrors _procErrors;

		#endregion

		#region Properties

		/// <summary>
		/// The id for the XML results.
		/// </summary>
		public int ID
		{
			get { return this._id; }
			set { this._id = value; }
		}

		/// <summary>
		/// The rid for the XML results.
		/// </summary>
		public string RID
		{
			get { return this._rid; }
			set { this._rid = value; }
		}

		/// <summary>
		/// Language for the XML results.
		/// </summary>
		public string Language
		{
			get { return this._lang; }
			set { this._lang = value; }
		}

		/// <summary>
		/// Returns the XML namespace.
		/// </summary>
		public string Namespace
		{
			get { return this._xmlns; }
			set { this._xmlns = value; }
		}

		/// <summary>
		/// Returns the xsi namespace.
		/// </summary>
		public string NamespaceXSI
		{
			get { return this._xmlnsxsi; }
			set { this._xmlnsxsi = value; }
		}

		/// <summary>
		/// Returns the schema location.
		/// </summary>
		public string SchemaLocation
		{
			get { return this._schemaLocation; }
			set { this._schemaLocation = value; }
		}

		/// <summary>
		/// Returns the time of download.
		/// </summary>
		public DateTime TimeStamp
		{
			get { return this._timeStamp; }
			set { this._timeStamp = value; }
		}
		
		#endregion
	}
}
