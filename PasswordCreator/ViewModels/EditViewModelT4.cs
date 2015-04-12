/*************************************************************************
  警告!
  このソースコードは自動生成されたものです
  このファイルを直接編集すると、編集した内容が失われる可能性があります
 *************************************************************************/
using System;
using Microsoft.TeamFoundation.MVVM;
using System.Windows.Input;

namespace PasswordCreator.ViewModels
{
	partial class EditViewModel : ModelBase
	{
		private string SiteName_;
		public string SiteName
		{
			get
			{
				return SiteName_;
			}
			set
			{
				SiteName_ = value;

				try
				{
					model_.SiteName = value;
					base.UpdateErrors("SiteName", "");
				}
				catch (Exception ex)
				{
					base.UpdateErrors("SiteName", ex.Message);
				}
				RaisePropertyChanged("SiteName");
				RaisePropertyChanged("Error");
			}
		}
		private string Url_;
		public string Url
		{
			get
			{
				return Url_;
			}
			set
			{
				Url_ = value;

				try
				{
					model_.Url = value;
					base.UpdateErrors("Url", "");
				}
				catch (Exception ex)
				{
					base.UpdateErrors("Url", ex.Message);
				}
				RaisePropertyChanged("Url");
				RaisePropertyChanged("Error");
			}
		}
		private string UserId_;
		public string UserId
		{
			get
			{
				return UserId_;
			}
			set
			{
				UserId_ = value;

				try
				{
					model_.UserId = value;
					base.UpdateErrors("UserId", "");
				}
				catch (Exception ex)
				{
					base.UpdateErrors("UserId", ex.Message);
				}
				RaisePropertyChanged("UserId");
				RaisePropertyChanged("Error");
			}
		}
		private string Password_;
		public string Password
		{
			get
			{
				return Password_;
			}
			set
			{
				Password_ = value;

				try
				{
					model_.Password = value;
					base.UpdateErrors("Password", "");
				}
				catch (Exception ex)
				{
					base.UpdateErrors("Password", ex.Message);
				}
				RaisePropertyChanged("Password");
				RaisePropertyChanged("Error");
			}
		}
		private string Note_;
		public string Note
		{
			get
			{
				return Note_;
			}
			set
			{
				Note_ = value;

				try
				{
					model_.Note = value;
					base.UpdateErrors("Note", "");
				}
				catch (Exception ex)
				{
					base.UpdateErrors("Note", ex.Message);
				}
				RaisePropertyChanged("Note");
				RaisePropertyChanged("Error");
			}
		}
		private string Category_;
		public string Category
		{
			get
			{
				return Category_;
			}
			set
			{
				Category_ = value;

				try
				{
					model_.Category = value;
					base.UpdateErrors("Category", "");
				}
				catch (Exception ex)
				{
					base.UpdateErrors("Category", ex.Message);
				}
				RaisePropertyChanged("Category");
				RaisePropertyChanged("Error");
			}
		}
		private ICommand _OkCommand;
		public  ICommand OkCommand
		{
			get
			{
				if (_OkCommand == null)
				{
					_OkCommand = new RelayCommand(ExecuteOkCommand, CanExecuteOkCommand);
				}
				return _OkCommand;
			}
		}
		private ICommand _CancelCommand;
		public  ICommand CancelCommand
		{
			get
			{
				if (_CancelCommand == null)
				{
					_CancelCommand = new RelayCommand(ExecuteCancelCommand);
				}
				return _CancelCommand;
			}
		}
		private ICommand _GenerateCommand;
		public  ICommand GenerateCommand
		{
			get
			{
				if (_GenerateCommand == null)
				{
					_GenerateCommand = new RelayCommand(ExecuteGenerateCommand);
				}
				return _GenerateCommand;
			}
		}

	}
}

