/*************************************************************************
  警告!
  このソースコードは自動生成されたものです
  このファイルを直接編集すると、編集した内容が失われる可能性があります
 *************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordCreator.Models {
    class PasswordItem : INotifyPropertyChanged {
        private readonly ValidationContext _validationContext;
        public event PropertyChangedEventHandler PropertyChanged;

        public PasswordItem() {
			_validationContext = new ValidationContext(this, null, null);
			Category = "その他";
			Date = DateTime.Now;
        }
        protected virtual void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
		private string _SiteName;
		[Key, Column(Order = 0)][Required]
		[StringLength(100, ErrorMessage="100文字以内で設定してください。")]
        public string SiteName {
			get {
				return _SiteName;
			}
			set {
				_validationContext.MemberName = "SiteName";
				Validator.ValidateProperty(value, _validationContext);
				_SiteName = value;
				RaisePropertyChanged("SiteName");
			}
		}
		private string _Url;
		
		[StringLength(200, ErrorMessage="200文字以内で設定してください。")]
        public string Url {
			get {
				return _Url;
			}
			set {
				_validationContext.MemberName = "Url";
				Validator.ValidateProperty(value, _validationContext);
				_Url = value;
				RaisePropertyChanged("Url");
			}
		}
		private string _UserId;
		[Key, Column(Order = 1)][Required]
		[StringLength(50, ErrorMessage="50文字以内で設定してください。")]
        public string UserId {
			get {
				return _UserId;
			}
			set {
				_validationContext.MemberName = "UserId";
				Validator.ValidateProperty(value, _validationContext);
				_UserId = value;
				RaisePropertyChanged("UserId");
			}
		}
		private string _Password;
		
		[StringLength(64, ErrorMessage="64文字以内で設定してください。")]
        public string Password {
			get {
				return _Password;
			}
			set {
				_validationContext.MemberName = "Password";
				Validator.ValidateProperty(value, _validationContext);
				_Password = value;
				RaisePropertyChanged("Password");
			}
		}
		private string _Note;
		
		[StringLength(100, ErrorMessage="100文字以内で設定してください。")]
        public string Note {
			get {
				return _Note;
			}
			set {
				_validationContext.MemberName = "Note";
				Validator.ValidateProperty(value, _validationContext);
				_Note = value;
				RaisePropertyChanged("Note");
			}
		}
		private string _Category;
		
		
        public string Category {
			get {
				return _Category;
			}
			set {
				_validationContext.MemberName = "Category";
				Validator.ValidateProperty(value, _validationContext);
				_Category = value;
				RaisePropertyChanged("Category");
			}
		}
		private DateTime _Date;
		
		
        public DateTime Date {
			get {
				return _Date;
			}
			set {
				_validationContext.MemberName = "Date";
				Validator.ValidateProperty(value, _validationContext);
				_Date = value;
				RaisePropertyChanged("Date");
			}
		}

		public void SetProperties (PasswordItem source)
		{
			SiteName = source.SiteName;
			Url = source.Url;
			UserId = source.UserId;
			Password = source.Password;
			Note = source.Note;
			Category = source.Category;
			Date = source.Date;
		}

        public object GetColumnValue(string column_name)
        {
            switch (column_name)
            {
				case "SiteName":
					return SiteName;
				case "Url":
					return Url;
				case "UserId":
					return UserId;
				case "Password":
					return Password;
				case "Note":
					return Note;
				case "Category":
					return Category;
				case "Date":
					return Date;
                default:
                    return null;
            }
		}
    }
}

