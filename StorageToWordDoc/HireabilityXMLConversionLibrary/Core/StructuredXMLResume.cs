// TODO: Boilerplate.
using HireabilityXMLConversionLibrary.Core.Contacts;
using HireabilityXMLConversionLibrary.Core.Education;
using HireabilityXMLConversionLibrary.Core.Employment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core
{
	// TODO: Description.
	public class StructuredXMLResume
	{

		#region Attributes

		private ContactInfo _contactInfo;
		private EmploymentHistory _employmentHistory;
		private EducationHistory _educationHistory;
		private bool _initialized = false;

		#endregion

		#region Properties

		public ContactInfo ContactInfo
		{
			get { return this._contactInfo; }
		}

		public EmploymentHistory EmploymentHistory
		{
			get { return this._employmentHistory; }
		}

		public EducationHistory EducationHistory
		{
			get { return this._educationHistory; }
		}

		public bool Initialized
		{
			get { return this._initialized; }
		}

		#endregion

		#region Constructor / Initializer

		public StructuredXMLResume()
		{
			_init();
		}

		public StructuredXMLResume(ContactInfo contactInfo, EmploymentHistory employment, EducationHistory education)
		{
			_init();

			this._contactInfo = contactInfo;
			this._employmentHistory = employment;
			this._educationHistory = education;
		}

		private void _init()
		{
			_contactInfo = new ContactInfo();
			_employmentHistory = new EmploymentHistory();
			_educationHistory = new EducationHistory();

			_initialized = true;
		}

		#endregion

	}
}
