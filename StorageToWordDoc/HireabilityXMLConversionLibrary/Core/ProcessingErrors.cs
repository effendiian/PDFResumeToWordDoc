// TODO: Boilerplate.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core
{
	// TODO: Description.
	public class ProcessingErrors
	{
		#region Attributes

		private int _id;
		private int _code = 0;
		private string _msg = "";

		#endregion

		#region Properties

		/// <summary>
		/// ID returns the error's id.
		/// </summary>
		public int ID
		{
			get { return this._id; }
			set { this._id = value; }
		}

		/// <summary>
		/// ErrorCode returns the
		/// error's code.
		/// </summary>
		public int ErrorCode
		{
			get { return this._code; }
			set { this._code = value; }
		}

		/// <summary>
		/// ErrorMessage returns the
		/// message the error has.
		/// </summary>
		public string ErrorMessage
		{
			get { return this._msg; }
			set { this._msg = value; }
		}

		/// <summary>
		/// HasError returns true if
		/// it has an error message or
		/// an error code.
		/// </summary>
		public bool HasError
		{
			get
			{
				return (!String.IsNullOrEmpty(_msg.Trim()) || this._code > 0);
			}
		}

		#endregion

	}
}
