// TODO: Boilerplate

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core
{
	// TODO: Description
	public abstract class XMLDocument
	{
		// TODO: Constants

		// XML Results
		public abstract HireAbilityXMLResults ParserResults
		{
			get; set;
		}

		public abstract StructuredXMLResume StructuredResume
		{
			get; set;
		}

		public abstract NonXMLResume Resume
		{
			get; set;
		}

		// Structured XML Resume


		// Non XML Resume

		// TODO: Attributes

		// TODO: Properties
		
		// TODO: Constructors / initialization

		// TODO: Methods

	}
}
