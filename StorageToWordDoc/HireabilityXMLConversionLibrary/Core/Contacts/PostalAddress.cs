// TODO: Boilerplate.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core.Contacts
{
	// TODO: Description
	public class PostalAddress
	{

		#region Attributes

		public string _countrycode;
		public int _postalcode;
		public string _region;
		public string _municipality;
		public string _streetline;

		#endregion

		#region Properties

		/// <summary>
		/// Returns the Address as one-line.
		/// </summary>
		public string Address
		{
			get
			{
				return this._streetline + ", " + this._municipality + ", " + this._region + ", " + this._postalcode;
			}
		}

		public string CountryCode
		{
			get { return this._countrycode; }
			set { this._countrycode = value.ToUpper().Trim(); }
		}

		public int PostalCode
		{
			get { return this._postalcode; }
			set { this._postalcode = value; }
		}

		public string Region
		{
			get { return this._region; }
			set { this._region = value.ToUpper().Trim(); }
		}

		public string Municipality
		{
			get { return this._municipality; }
			set { this._municipality = value.Trim(); }
		}

		public string Street
		{
			get { return this._streetline; }
			set { this._streetline = value.Trim(); }
		}

		#endregion

		#region Constructors

		public PostalAddress() { }

		public PostalAddress(string street, string city, string state, int zipcode)
		{
			this.Street = street;
			this.Municipality = city;
			this.Region = state;
			this.CountryCode = "";
			this.PostalCode = zipcode;
		}

		public PostalAddress(string street, string city, string state, string country, int zipcode)
		{
			this.Street = street;
			this.Municipality = city;
			this.Region = state;
			this.CountryCode = country;
			this.PostalCode = zipcode;
		}

		#endregion

		#region Methods

		public string GetAddress()
		{
			return this.Address;
		}

		public string GetAddress(bool oneline)
		{
			return this.Address;
		}

		public string GetAddress(bool oneline, bool international)
		{
			if (oneline)
			{
				if (international)
				{
					return this._streetline + ", " + this._municipality + ", " + this._region + ", " + this._countrycode + ", " + this._postalcode;
				}
				else
				{
					return this.Address;
				}
			}
			else
			{
				if (international)
				{
					return this._streetline + ", \n" + this._municipality + ", " + this._region + ", " + this._countrycode + ", " + this._postalcode;
				}
				else
				{
					return this._streetline + ", \n" + this._municipality + ", " + this._region + ", " + this._postalcode;
				}
			}
		}

		#endregion

	}
}
