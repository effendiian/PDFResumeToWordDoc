// TODO: Boilerplate 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HireabilityXMLConversionLibrary.Core.Contacts
{
	// TODO: Description.
	public class ContactMethod
	{
		#region Attributes

		// Flags
		private bool _isPersonal;
		private bool _isBusiness;
		private bool _isEmail;
		private bool _isAddress;
		private bool _isNumber;
		private bool _initialized;
		private string _type;
		private string _flag;

		// Attributes
		private PostalAddress _address;
		private PhoneNumber _telephone;
		private MailAddress _email;

		#endregion

		#region Properties

		public bool IsPersonal
		{
			get { return this._isPersonal; }
		}

		public bool IsBusiness
		{
			get { return this._isBusiness; }
		}

		public bool IsAddress
		{
			get
			{
				return this._isAddress;
			}
		}

		public bool IsPhoneNumber
		{
			get
			{
				return this._isNumber;
			}
		}

		public bool IsEmail
		{
			get
			{
				return this._isEmail;
			}
		}

		public bool Initialized
		{
			get
			{
				return this._initialized;
			}
		}

		public string Type
		{
			get { return this._type; }
		}

		public string Flag
		{
			get { return this._flag; }
		}

		public PostalAddress Address
		{
			get { return this._address; }
		}

		public PhoneNumber Number
		{
			get { return this._telephone; }
		}

		public MailAddress Email
		{
			get { return this._email; }
			set { this._email = value; }
		}
		
		#endregion

		#region Constructor / Initialization

		public ContactMethod(string type, string flag)
		{
			_setType(type);
			_setFlag(flag);
			_init();
		}

		private void _init()
		{
			if (_isPersonal == _isBusiness)
			{
				this._initialized = false;
				return;
			}
			else {
				if (_isEmail)
				{
					SetEmail("");
				}
				else if (_isAddress)
				{
					this._address = new PostalAddress();
				}
				else if (_isNumber)
				{
					this._telephone = new PhoneNumber();
				}
				else
				{
					this._initialized = false;
					return;
				}

				this._initialized = true;
				return;
			}
		}

		private void _setType(string type)
		{
			this._isAddress = false;
			this._isEmail = false;
			this._isNumber = false;
			this._type = type;

			switch (type)
			{
				case ContactInfo.ADDRESS:
					this._isAddress = true;
					break;
				case ContactInfo.EMAIL:
					this._isEmail = true;
					break;
				case ContactInfo.NUMBER:
					this._isNumber = true;
					break;
				default:
					this._isAddress = false;
					this._isEmail = false;
					this._isNumber = false;
					break;
			}
		}

		private void _setFlag(string flag)
		{
			this._isBusiness = false;
			this._isPersonal = false;
			this._flag = flag;

			switch (flag)
			{
				case ContactInfo.BUSINESS:
					this._isBusiness = true;
					break;
				case ContactInfo.PERSONAL:
				case ContactInfo.MOBILE:
					this._isPersonal = true;
					break;
			}
		}

		public bool SetEmail(string email)
		{
			if (this._initialized)
			{
				if (this._isEmail)
				{
					this._email = new MailAddress(email);
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		#endregion


	}
}
