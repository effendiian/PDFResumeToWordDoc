using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core.Employment
{
	// TODO: Description and Boilerplate.
	public class EmploymentHistory
	{
		#region Attributes

		private List<string> _employers; // List of employer names.
		private Dictionary<string, List<PositionHistory>> _history; // List of associated position histories.
		private bool _initialized;

		#endregion

		#region Properties

		public List<string> Employers
		{
			get { return this._employers; }
		}

		public Dictionary<string, List<PositionHistory>> History
		{
			get { return this._history; }
		}

		public bool Initialized
		{
			get { return this._initialized; }
		}

		#endregion

		#region Constructor / Initialization.

		public EmploymentHistory()
		{
			_init();
		}

		public EmploymentHistory(string employer)
		{
			_init();
			AddHistory(employer, null);
		}

		public EmploymentHistory(string employer, PositionHistory history)
		{
			_init();
			AddHistory(employer, history);
		}

		private void _init()
		{
			_employers = new List<string>();
			_history = new Dictionary<string, List<PositionHistory>>();
			
			this._initialized = true;
		}

		public void AddHistory(string employer, PositionHistory history)
		{
			if (!_employers.Contains(employer))
			{
				_employers.Add(employer);
			}
			
			if (_history.ContainsKey(employer))
			{
				List<PositionHistory> temp = _history[employer];

				if (temp != null) { temp = new List<PositionHistory>(); }

				temp.Add(history);
				_history[employer] = temp;
			}
			else
			{
				_history.Add(employer, new List<PositionHistory> { history });
			}
		}

		#endregion

	}
}
