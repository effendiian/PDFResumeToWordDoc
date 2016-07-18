// TODO: Boilerplate.
using HireabilityXMLConversionLibrary.Core.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HireabilityXMLConversionLibrary.Core
{
	// TODO: Class description.
	public class XMLCore
	{
		#region Constants

		// TODO: Create the constants for each XMLConversion code.
		// Conversion Codes.
		public const string XML_CSV = "XML to CSV";
		public const string CSV_XML = "CSV to XML";
		public const string PRODUCT_CODE = "";

		#endregion

		#region Attributes

		// Base attributes
		private string _filename;
		private string _blob;
		private XmlDocument _xmldoc;
		
		// Flags
		private bool _initialized;

		#endregion

		#region Properties

		/// <summary>
		/// FileName returns this XML
		/// file's filename.
		/// </summary>
		public string FileName
		{
			get { return this._filename; }
		}

		/// <summary>
		/// Content returns the XML file
		/// as a full text file.
		/// </summary>
		public string Content
		{
			get { return this._blob; }
		}

		// TODO: Create properties for each of the conversions.
		public XmlDocument CoreDocument
		{
			get { return this._xmldoc; }
		}
		
		// public XMLCore XML;

		// Flags
		/// <summary>
		/// <summary>
		/// Initialized returns true if
		/// the file has been initialized.
		/// </summary>
		public bool Initialized
		{
			get { return this._initialized; }
		}

		public HireAbilityXMLResults ParserResults
		{
			get; set;
		}

		public StructuredXMLResume StructuredResume
		{
			get; set;
		}

		public NonXMLResume Resume
		{
			get; set;
		}

		#endregion


		// TODO: Focus on speed.

		#region Constructors / initialization

		// TODO: Constructor should take the filepath to an XML object.
		/// <summary>
		/// XMLCore(string) takes the filename for an xml document
		/// and creates an XmlDocument wrapper from it.
		/// </summary>
		/// <param name="filename">Filename of the xml file.</param>
		public XMLCore(string filename)
		{
			this._filename = filename;
			this._init();
		}

		/// <summary>
		/// _init() is used by the constructors to initialize the class.
		/// </summary>
		private void _init()
		{
			this._initialized = false;

			try
			{
				this._xmldoc = new XmlDocument();
				this._xmldoc.Load(this._filename);

				ParserResults = new HireAbilityXMLResults();
				StructuredResume = new StructuredXMLResume();
				Resume = new NonXMLResume();

				Parse(this._filename);
				this._initialized = true;
				return;
			}
			catch (Exception ex)
			{
				this._initialized = false;
				throw ex;
			}
		}

		#endregion

		// TODO: Methods set up to convert to different formats.


		// TODO: Focus on turning into a CSV file.
		public string GetAttribute(string attr, XmlReader reader)
		{
			if (reader.HasAttributes)
			{
				if (reader.GetAttribute(attr) != null)
				{
					return reader[attr];
				}
			}
			return "";
		}


		public void Parse(string xmlDoc)
		{
			// Read the nodes.
			using (XmlReader reader = XmlReader.Create(xmlDoc))
			{
				while (reader.Read())
				{
					// Only detect start elements.
					if (reader.IsStartElement() && reader.NodeType == XmlNodeType.Element)
					{
						// Get element name and perform a case-switch statement on it.
						switch (reader.Name)
						{
							case "HireAbilityXMLResults":
								if (reader.HasAttributes)
								{
									ParserResults.ID = Int32.Parse(GetAttribute("id", reader));
									ParserResults.RID = GetAttribute("rid", reader);
								}
								break;
							case "Resume":
								if (reader.HasAttributes)
								{
									ParserResults.Language = reader.GetAttribute("xml:lang");
									ParserResults.Namespace = reader.GetAttribute("xmlns");
									ParserResults.NamespaceXSI = reader.GetAttribute("xmlns:xsi");
									ParserResults.SchemaLocation = reader.GetAttribute("xsi:schemaLocation");
								}
								break;
							case "PersonName":
								// // Formatted Name
								reader.ReadToFollowing("FormattedName");
								if (reader.HasValue)
								{
									StructuredResume.ContactInfo.PersonName.FormattedName = reader.Value.Trim();
								}
								
								// // First Name
								reader.ReadToFollowing("GivenName");
								if (reader.HasValue) { StructuredResume.ContactInfo.FirstName = reader.Value; }
								
								// // Middle Name
								reader.ReadToFollowing("MiddleName");
								if (reader.HasValue) { StructuredResume.ContactInfo.MiddleName = reader.Value; }
								
								// // Last Name
								reader.ReadToFollowing("FamilyName");
								if (reader.HasValue) { StructuredResume.ContactInfo.LastName = reader.Value; }
								break;
							case "PostalAddress":
								// // Country Code
								reader.ReadToFollowing("CountryCode");
								if (reader.HasValue) { StructuredResume.ContactInfo.PersonalAddress.CountryCode = reader.Value; }

								// // Postal Code
								reader.ReadToFollowing("PostalCode");
								if (reader.HasValue) { StructuredResume.ContactInfo.PersonalAddress.PostalCode = reader.Value; }

								// // Region
								reader.ReadToFollowing("Region");
								if (reader.HasValue) { StructuredResume.ContactInfo.PersonalAddress.Region = reader.Value; }

								// // Municipality
								reader.ReadToFollowing("Municipality");
								if (reader.HasValue) { StructuredResume.ContactInfo.PersonalAddress.Municipality = reader.Value; }

								// // Delivery Address // // Address Line
								reader.ReadToFollowing("AddressLine");
								if (reader.HasValue) { StructuredResume.ContactInfo.PersonalAddress.Street = reader.Value; }
								break;
							case "Use":
								string use = "personal";
								if (reader.HasValue)
								{
									use = reader.Value.Trim();
								}

								switch (use)
								{
									case "personal":
										reader.ReadToFollowing("Telephone");
										reader.ReadToDescendant("InternationalCountryCode");
										if (reader.HasValue) { StructuredResume.ContactInfo.PersonalNumber.CountryCode = Int32.Parse(reader.Value.Trim()); }

										reader.ReadToFollowing("AreaCityCode");
										if (reader.HasValue) { StructuredResume.ContactInfo.PersonalNumber.AreaCode = Int32.Parse(reader.Value.Trim()); }
										
										reader.ReadToFollowing("SubscriberNumber");
										if (reader.HasValue) { StructuredResume.ContactInfo.PersonalNumber.SubscriberNumber = Int32.Parse(reader.Value.Trim()); }

										reader.ReadToFollowing("Extension");
										if (reader.HasValue) { StructuredResume.ContactInfo.PersonalNumber.Extension = Int32.Parse(reader.Value.Trim()); }
										break;

									case "business":
										reader.ReadToFollowing("Telephone");
										reader.ReadToDescendant("InternationalCountryCode");
										if (reader.HasValue) { StructuredResume.ContactInfo.BusinessNumber.CountryCode = Int32.Parse(reader.Value.Trim()); }

										reader.ReadToFollowing("AreaCityCode");
										if (reader.HasValue) { StructuredResume.ContactInfo.BusinessNumber.AreaCode = Int32.Parse(reader.Value.Trim()); }

										reader.ReadToFollowing("SubscriberNumber");
										if (reader.HasValue) { StructuredResume.ContactInfo.BusinessNumber.SubscriberNumber = Int32.Parse(reader.Value.Trim()); }

										reader.ReadToFollowing("Extension");
										if (reader.HasValue) { StructuredResume.ContactInfo.BusinessNumber.Extension = Int32.Parse(reader.Value.Trim()); }
										break;
								}
								break;
							case "InternetEmailAddress":
								if (reader.HasValue && !StructuredResume.ContactInfo.HasPersonalEmail) { StructuredResume.ContactInfo.PersonalEmail = reader.Value.Trim(); }
								break;
							case "EmployerOrg":
								string employer = "";

								reader.ReadToFollowing("EmployerOrgName");
								if (reader.HasValue) {
									employer = reader.Value.Trim();

									Employment.PositionHistory experience = new Employment.PositionHistory();

									reader.ReadToFollowing("PositionHistory");
									reader.ReadToFollowing("Title");
									if (reader.HasValue) { experience.Title = reader.Value.Trim(); }

									reader.ReadToFollowing("PositionLocation");
									reader.ReadToFollowing("Region");
									if (reader.HasValue) { experience.Region = reader.Value.Trim(); }

									reader.ReadToFollowing("Municipality");
									if (reader.HasValue) { experience.Municipality = reader.Value.Trim(); }

									reader.ReadToFollowing("Description");
									if (reader.HasValue) { experience.Description = reader.Value.Trim(); }

									// reader.Ree



									//StructuredResume.EmploymentHistory.AddHistory()
								}

								break;
							case "Error":
								ProcessingErrors proc = new ProcessingErrors();
								if (reader.HasAttributes) { proc.ID = Int32.Parse(GetAttribute("id", reader)); }

								// // Error Code
								reader.ReadToDescendant("ErrorCode");
								if (reader.HasValue) { proc.ErrorCode = reader.Value.Trim(); }
								
								// // Error Message
								reader.ReadToDescendant("ErrorMessage");
								if (reader.HasValue) { proc.ErrorMessage = reader.Value.Trim(); }
								
								ParserResults.Errors.Add(proc);
								break;
						}
					}
				}
								

				// // Resume
				reader.ReadToDescendant("Resume");

				// // Processing Errors




















				while (reader.Read())
				{
					if ((reader.NodeType == XmlNodeType.Element))
					{
						switch (reader.Name)
						{
							case "HireAbilityXMLResults":
								if (reader.HasAttributes)
								{
									ParserResults.ID = Int32.Parse(reader.GetAttribute("id"));
									ParserResults.RID = reader.GetAttribute("rid");
								}
								break;
							case "Resume":
								if (reader.HasAttributes)
								{
									ParserResults.Language = reader.GetAttribute("xml:lang");
									ParserResults.Namespace = reader.GetAttribute("xmlns");
									ParserResults.NamespaceXSI = reader.GetAttribute("xmlns:xsi");
									ParserResults.SchemaLocation = reader.GetAttribute("xsi:schemaLocation");
								}
								break;
							case "GivenName":
								StructuredResume.ContactInfo.FirstName = reader.Value;

								break;





						}
					}
				}
			}
		}



	}
}
