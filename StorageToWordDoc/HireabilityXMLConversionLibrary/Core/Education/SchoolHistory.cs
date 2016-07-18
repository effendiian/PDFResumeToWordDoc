using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core.Education
{
	// TODO: Boilerplate and Description.
	public class SchoolHistory : IComparable
	{

		#region Attributes

		private string _name;
		private string _schoolType;
		private string _degreeName;
		private string _degreeMajor;
		private DateTime _degreeDate;

		#endregion

		#region Properties

		public string SchoolName
		{
			get { return this._name; }
			set { this._name = value; }
		}

		public string SchoolType
		{
			get { return this._schoolType; }
			set { this._schoolType = value; }
		}

		public string Degree
		{
			get { return "" + DegreeName + " of " + DegreeMajor; }
		}

		public string DegreeName
		{
			get { return this._degreeName; }
			set { this._degreeName = value; }
		}

		public string DegreeMajor
		{
			get { return this._degreeMajor; }
			set { this._degreeMajor = value; }
		}

		public DateTime DegreeDate
		{
			get { return this._degreeDate; }
			set { this._degreeDate = value; }
		}

		public string DegreeYear
		{
			get { return "" + DegreeDate.Year; }
		}

		#endregion

		#region Constructor / Initialization

		public SchoolHistory(string name, string type, string degree, string major, DateTime year)
		{
			this._name = name;
			this._schoolType = type;
			this._degreeName = degree;
			this._degreeMajor = major;
			this._degreeDate = year;
		}


		#endregion
		
		#region Methods

		public int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}

		#endregion


	}
}
