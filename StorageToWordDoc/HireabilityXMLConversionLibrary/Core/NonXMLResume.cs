// TODO: Boilerplate

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core
{
	// TODO: Description.
	public class NonXMLResume
	{
		#region Attributes

		private int _id;
		private string _docTitle;
		private string _docData;
		
		#endregion

		#region Properties
		/// <summary>
		/// ID returns the id of the
		/// NonXMLResume node.
		/// </summary>
		public int ID
		{
			get { return this._id; }
			set { this._id = value; }
		}

		/// <summary>
		/// DocumentTitle returns the
		/// title of the document.
		/// </summary>
		public string DocumentTitle
		{
			get { return this._docTitle; }
			set { this._docTitle = value; }
		}

		/// <summary>
		/// DocumentData returns the
		/// data from the XML Document.
		/// </summary>
		public string DocumentData
		{
			get { return this._docData; }
			set { this._docData = value; }
		}

		/// <summary>
		/// HasData returns true if this
		/// resume object is NOT empty.
		/// </summary>
		public bool HasData
		{
			get
			{
				return (!String.IsNullOrEmpty(_docData.Trim()));
			}
		}

		#endregion

	}
}
