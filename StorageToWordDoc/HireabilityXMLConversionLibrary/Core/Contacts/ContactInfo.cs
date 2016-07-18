// TODO: Boilerplate.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core.Contacts
{
	// TODO: Description.
	public class ContactInfo
	{

		#region Constants

		public const string EMAIL = "email";
		public const string ADDRESS = "address";
		public const string NUMBER = "telephone";
		public const string PERSONAL = "personal";
		public const string BUSINESS = "business";
		public const string HOME = "home";
		public const string WORK = "office";
		public const string MOBILE = "mobile";
		public const string OTHER = "other";

		#endregion

		#region Attributes

		private PersonName _name;
		private Dictionary<string, ContactMethod> _contacts;
		private bool _initialized;

		#endregion

		#region Properties

		// Name.
		public string ParsedName
		{
			get { return this._name.FormattedName; }
		}

		public string FullName
		{
			get
			{
				string _mid = " ";

				if (!String.IsNullOrEmpty(MiddleName))
				{
					_mid += MiddleName.Substring(0, 1) + ". ";
				}

				return FirstName + _mid + LastName; }
		}

		public string FirstName
		{
			get { return this._name.GivenName; }
			set { this._name.GivenName = value.Trim(); }
		}

		public string MiddleName
		{
			get { return this._name.MiddleName; }
			set { this._name.MiddleName = value.Trim(); }
		}

		public string LastName
		{
			get { return this._name.FamilyName; }
			set { this._name.FamilyName = value.Trim(); }
		}

		public PersonName PersonName
		{
			get { return this._name; }
		}

		// Contacts.
		public string PersonalEmail
		{
			get
			{
				if (!HasPersonalEmail)
				{
					return "";
				}
				else
				{
					return this._contacts[GetKey(EMAIL, PERSONAL)].Email.Address; 
				}
			}

			set
			{
				if (!HasPersonalEmail)
				{
					// Create new first.
					AddContactMethod(EMAIL, PERSONAL);
				}

				string key = GetKey(EMAIL, PERSONAL);
				this._contacts[key].Email = new System.Net.Mail.MailAddress(value);
			}
		}

		public string BusinessEmail
		{
			get
			{
				if (!HasBusinessEmail)
				{
					return "";
				}
				else
				{
					return this._contacts[GetKey(EMAIL, BUSINESS)].Email.Address;
				}
			}

			set
			{
				if (!HasBusinessEmail)
				{
					// Create new first.
					AddContactMethod(EMAIL, BUSINESS);
				}

				string key = GetKey(EMAIL, BUSINESS);
				this._contacts[key].Email = new System.Net.Mail.MailAddress(value);
			}
		}

		public PostalAddress PersonalAddress
		{
			get
			{
				if (!HasPersonalAddress)
				{
					return null;
				}
				else
				{
					return this._contacts[GetKey(ADDRESS, PERSONAL)].Address;
				}
			}

			set
			{
				if (!HasPersonalAddress)
				{
					// Create new first.
					AddContactMethod(ADDRESS, PERSONAL);
				}

				string key = GetKey(ADDRESS, PERSONAL);
				this._contacts[key].Address.CountryCode = value.CountryCode;
				this._contacts[key].Address.Municipality = value.Municipality;
				this._contacts[key].Address.Region = value.Region;
				this._contacts[key].Address.PostalCode = value.PostalCode;
				this._contacts[key].Address.Street = value.Street;
			}
		}

		public PostalAddress BusinessAddress
		{
			get
			{
				if (!HasBusinessAddress)
				{
					return null;
				}
				else
				{
					return this._contacts[GetKey(ADDRESS, BUSINESS)].Address;
				}
			}

			set
			{
				if (!HasBusinessAddress)
				{
					// Create new first.
					AddContactMethod(ADDRESS, BUSINESS);
				}

				string key = GetKey(ADDRESS, BUSINESS);
				this._contacts[key].Address.CountryCode = value.CountryCode;
				this._contacts[key].Address.Municipality = value.Municipality;
				this._contacts[key].Address.Region = value.Region;
				this._contacts[key].Address.PostalCode = value.PostalCode;
				this._contacts[key].Address.Street = value.Street;
			}
		}

		public PhoneNumber PersonalNumber
		{
			get
			{
				if (!HasPersonalNumber)
				{
					return null;
				}
				else
				{
					return this._contacts[GetKey(NUMBER, PERSONAL)].Number;
				}
			}

			set
			{
				if (!HasPersonalNumber)
				{
					// Create new first.
					AddContactMethod(NUMBER, PERSONAL);
				}

				string key = GetKey(NUMBER, PERSONAL);
				this._contacts[key].Number.CountryCode = value.CountryCode;
				this._contacts[key].Number.AreaCode = value.AreaCode;
				this._contacts[key].Number.SubscriberNumber = value.SubscriberNumber;
			}
		}

		public PhoneNumber BusinessNumber
		{
			get
			{
				if (!HasBusinessNumber)
				{
					return null;
				}
				else
				{
					return this._contacts[GetKey(NUMBER, BUSINESS)].Number;
				}
			}

			set
			{
				if (!HasPersonalNumber)
				{
					// Create new first.
					AddContactMethod(NUMBER, BUSINESS);
				}

				string key = GetKey(NUMBER, BUSINESS);
				this._contacts[key].Number.CountryCode = value.CountryCode;
				this._contacts[key].Number.AreaCode = value.AreaCode;
				this._contacts[key].Number.SubscriberNumber = value.SubscriberNumber;
			}
		}


		// Flags
		public bool Initialized
		{
			get { return this._initialized; }
		}

		public bool HasPersonalEmail
		{
			get
			{
				string key = PERSONAL + EMAIL;
				if (!this._contacts.ContainsKey(key))
				{
					return false;
				}
				else
				{
					ContactMethod temp = this._contacts[key];
					return (temp.IsPersonal && temp.IsEmail);
				}
			}
		}

		public bool HasBusinessEmail
		{
			get
			{
				string key = BUSINESS + EMAIL;
				if (!this._contacts.ContainsKey(key))
				{
					return false;
				}
				else
				{
					ContactMethod temp = this._contacts[key];
					return (temp.IsBusiness && temp.IsEmail);
				}
			}
		}

		public bool HasPersonalAddress
		{
			get
			{
				string key = PERSONAL + ADDRESS;
				if (!this._contacts.ContainsKey(key))
				{
					return false;
				}
				else
				{
					ContactMethod temp = this._contacts[key];
					return (temp.IsPersonal && temp.IsAddress);
				}
			}
		}

		public bool HasBusinessAddress
		{
			get
			{
				string key = BUSINESS + ADDRESS;
				if (!this._contacts.ContainsKey(key))
				{
					return false;
				}
				else
				{
					ContactMethod temp = this._contacts[key];
					return (temp.IsBusiness && temp.IsAddress);
				}
			}
		}

		public bool HasPersonalNumber
		{
			get
			{
				string key = PERSONAL + NUMBER;
				if (!this._contacts.ContainsKey(key))
				{
					return false;
				}
				else
				{
					ContactMethod temp = this._contacts[key];
					return (temp.IsPersonal && temp.IsPhoneNumber);
				}
			}
		}

		public bool HasBusinessNumber
		{
			get
			{
				string key = BUSINESS + NUMBER;
				if (!this._contacts.ContainsKey(key))
				{
					return false;
				}
				else
				{
					ContactMethod temp = this._contacts[key];
					return (temp.IsBusiness && temp.IsPhoneNumber);
				}
			}
		}

		#endregion

		#region Constructor / initialization

		/// <summary>
		/// Empty constructor for ContactInfo.
		/// </summary>
		public ContactInfo()
		{
			_init();
		}

		/// <summary>
		/// Initialization method used by the
		/// constructor.
		/// </summary>
		private void _init()
		{
			this._name = new PersonName();
			this._contacts = new Dictionary<string, ContactMethod>();

			// Add the initial necessary contact methods. More can be added later.
			AddContactMethod(EMAIL, PERSONAL);
			AddContactMethod(ADDRESS, PERSONAL); ;
			AddContactMethod(NUMBER, PERSONAL);
			AddContactMethod(NUMBER, MOBILE);
			
			this._initialized = true;
		}

		public ContactMethod CreateNewContactMethod(string type, string flag)
		{
			return new ContactMethod(type, flag);
		}

		public void AddContactMethod(string type, string flag)
		{
			string key = GetKey(type, flag);

			if (!_contacts.ContainsKey(key))
			{
				this._contacts.Add(key, null);
			}

			this._contacts[key] = CreateNewContactMethod(type, flag);
		}

		public void AddContactMethod(ContactMethod cm)
		{
			string key = GetKey(cm.Type, cm.Flag);

			if (!_contacts.ContainsKey(key))
			{
				this._contacts.Add(key, null);
			}

			this._contacts[key] = cm;
		}

		#endregion

		#region Methods

		public string GetKey(string type, string flag)
		{
			return GetKey(type, flag);
		}

		public ContactMethod GetContactMethod(string key)
		{
			if (!this._contacts.ContainsKey(key))
			{
				return null;
			}
			else
			{
				return this._contacts[key];
			}
		}

		public void SetContactMethod(ContactMethod cm)
		{
			string key = GetKey(cm.Type, cm.Flag);
			ContactMethod modify = GetContactMethod(key);

			if (modify != null)
			{
				switch (cm.Type)
				{
					case EMAIL:
						modify.Email = cm.Email;
						break;
					case NUMBER:
						modify.Number.CountryCode = cm.Number.CountryCode;
						modify.Number.AreaCode = cm.Number.AreaCode;
						modify.Number.SubscriberNumber = cm.Number.SubscriberNumber;
						break;
					case ADDRESS:
						modify.Address.CountryCode = cm.Address.CountryCode;
						modify.Address.Municipality = cm.Address.Municipality;
						modify.Address.PostalCode = cm.Address.PostalCode;
						modify.Address.Region = cm.Address.Region;
						modify.Address.Street = cm.Address.Street;
						break;
				}
			}
			else
			{
				AddContactMethod(cm);
			}
		}

		#endregion

	}
}
