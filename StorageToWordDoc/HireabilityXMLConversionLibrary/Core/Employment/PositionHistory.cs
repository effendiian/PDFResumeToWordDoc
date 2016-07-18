using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core.Employment
{
	// TODO: Boilerplate + Description
	public class PositionHistory : IComparable
	{

		#region Attributes

		private string _job;
		private string _region;
		private string _municipality;
		private string _description;
		private DateTime _start;
		private DateTime _end;

		#endregion

		#region Properties

		public string Title
		{
			get { return this._job; }
			set { this._job = value; }
		}

		public string Region
		{
			get { return this._region; }
			set { this._region = value; }
		}

		public string Municipality
		{
			get { return this._municipality; }
			set { this._municipality = value; }
		}

		public string Address
		{
			get { return this._municipality + ", " + this._region; }
		}

		public string Description
		{
			get { return this._description; }
			set { this._description = value; }
		}

		public DateTime StartDate
		{
			get { return this._start; }
			set { this._start = value; }
		}

		public DateTime EndDate
		{
			get { return this._end; }
			set { this._end = value; }
		}

		public string Start
		{
			get { return GetStartDate(); }
			set { SetStartDate(value); }
		}

		public string End
		{
			get { return GetEndDate(); }
			set { SetEndDate(value); }
		}

		#endregion

		#region Constructor / Initialization

		#endregion

		#region Methods

		// TODO: DateTime calculations and parsing.

		public int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}

		public string GetStartDate()
		{
			return DateToString(StartDate);
		}

		public void SetStartDate(DateTime date)
		{
			this._start = date;
		}
		public void SetStartDate(string date)
		{
			// TODO: Parse date.
		}

		public string GetEndDate()
		{
			return DateToString(StartDate);
		}

		public void SetEndDate(DateTime date)
		{
			this._end = date;
		}

		public void SetEndDate(string date)
		{
			// TODO: Parse date.
		}

		public string DateToString(DateTime date)
		{
			return DateToString(date, false);
		}

		public string DateToString(DateTime date, bool includeDay)
		{
			// Determine month day and year.
			string month = "" + StartDate.Month;
			string year = "" + StartDate.Year;
			string day = "";

			if (includeDay)
			{
				day = "" + StartDate.Day + "/";
			}

			// Return format.
			return "" + day + month + "/" + year;
		}

		#endregion

	}
}
