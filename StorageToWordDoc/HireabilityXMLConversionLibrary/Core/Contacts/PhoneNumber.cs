// TODO: Phone number boilerplate.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core.Contacts
{
	// TODO: Description.
	public class PhoneNumber
	{

		#region Attributes

		private int _countrycode = 1; // US = 1.
		private int _areacode; // = (###)
		private int _subscriber; // = ###-####	

		#endregion

		#region Properties

		public string Number
		{
			get
			{
				string cc = "" + this._countrycode;
				string ac = "(" + this._areacode + ")";
				string substr = "" + this._subscriber;
				string sub = "" + substr.Substring(0, 3) + " - " + substr.Substring(3, substr.Length - 3);
				return cc + " " + ac + " " + sub;
			}
		}

		public int CountryCode
		{
			get { return this._countrycode; }
			set
			{
				this._countrycode = value;
			}
		}

		public int AreaCode
		{
			get { return this._areacode; }
			set { this._areacode = value; }
		}

		public int SubscriberNumber
		{
			get { return this._subscriber; }
			set { this._subscriber = value; }
		}

		#endregion

		#region Constructor

		public PhoneNumber() { }

		public PhoneNumber(int country, int area, int sub)
		{
			this.CountryCode = country;
			this.AreaCode = area;
			this.SubscriberNumber = sub;
		}

		#endregion


	}
}
