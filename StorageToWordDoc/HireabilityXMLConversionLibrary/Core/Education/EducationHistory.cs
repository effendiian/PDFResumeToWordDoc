using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core.Education
{
	// TODO: Boilerplate / etc.
	public class EducationHistory
	{
		#region Attributes

		private List<SchoolHistory> _history; // List of associated position histories.
		private bool _initialized;

		#endregion

		#region Properties
		
		public List<SchoolHistory> History
		{
			get { return this._history; }
		}

		public bool Initialized
		{
			get { return this._initialized; }
		}

		#endregion

		#region Constructor / Initialization.

		public EducationHistory()
		{
			_init();
		}
		
		public EducationHistory(SchoolHistory history)
		{
			_init();
			AddHistory(history);
		}

		private void _init()
		{
			_init();
			_history = new List<SchoolHistory>();

			this._initialized = true;
		}

		public void AddHistory(SchoolHistory history)
		{
			_history.Add(history);
		}

		#endregion

	}
}
