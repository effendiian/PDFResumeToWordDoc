// TODO: Boilerplate.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core.Contacts
{
	// TODO: Description
	public class PersonName
	{
		#region Attributes

		private string _format;
		private string _given;
		private string _middle;
		private string _family;

		#endregion

		#region Properties

		public string FormattedName
		{
			get { return this._format; }
			set { this._format = value; }
		}

		public string GivenName
		{
			get { return this._given; }
			set { this._given = value; }
		}

		public string MiddleName
		{
			get { return this._middle; }
			set { this._middle = value; }
		}

		public string FamilyName
		{
			get { return this._family; }
			set { this._family = value; }
		}

		#endregion

		#region Constructor

		public PersonName()
		{
			this._format = "";
			this._given = "";
			this._middle = "";
			this._family = "";
		}

		public PersonName(string full, string first, string last)
		{
			this._format = full;
			this._given = first;
			this._middle = "";
			this._family = last;
		}

		public PersonName(string full, string first, string middle, string last)
		{
			this._format = full;
			this._given = first;
			this._middle = middle;
			this._family = last;
		}

		#endregion
	}
}
