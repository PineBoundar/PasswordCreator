/*************************************************************************
  警告!
  このソースコードは自動生成されたものです
  このファイルを直接編集すると、編集した内容が失われる可能性があります
 *************************************************************************/
using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;
using PasswordCreator.Models;

namespace PasswordCreator.ViewModels
{
	partial class MainWindowViewModel : ModelBase
	{
		private ICommand _AppendCommand;
		public  ICommand AppendCommand
		{
			get
			{
				if (_AppendCommand == null)
				{
					_AppendCommand = new RelayCommand(ExecuteAppendCommand);
				}
				return _AppendCommand;
			}
		}
		private ICommand _UpdateCommand;
		public  ICommand UpdateCommand
		{
			get
			{
				if (_UpdateCommand == null)
				{
					_UpdateCommand = new RelayCommand(ExecuteUpdateCommand, CanEditDataCommand);
				}
				return _UpdateCommand;
			}
		}
		private ICommand _DeleteCommand;
		public  ICommand DeleteCommand
		{
			get
			{
				if (_DeleteCommand == null)
				{
					_DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanEditDataCommand);
				}
				return _DeleteCommand;
			}
		}
		private ICommand _SearchCommand;
		public  ICommand SearchCommand
		{
			get
			{
				if (_SearchCommand == null)
				{
					_SearchCommand = new RelayCommand(ExecuteSearchCommand);
				}
				return _SearchCommand;
			}
		}
		private ICommand _ImportCommand;
		public  ICommand ImportCommand
		{
			get
			{
				if (_ImportCommand == null)
				{
					_ImportCommand = new RelayCommand(ExecuteImportCommand);
				}
				return _ImportCommand;
			}
		}
		private ICommand _ExportCommand;
		public  ICommand ExportCommand
		{
			get
			{
				if (_ExportCommand == null)
				{
					_ExportCommand = new RelayCommand(ExecuteExportCommand);
				}
				return _ExportCommand;
			}
		}
		private ICommand _AboutCommand;
		public  ICommand AboutCommand
		{
			get
			{
				if (_AboutCommand == null)
				{
					_AboutCommand = new RelayCommand(ExecuteAboutCommand);
				}
				return _AboutCommand;
			}
		}
		private ICommand _HelpCommand;
		public  ICommand HelpCommand
		{
			get
			{
				if (_HelpCommand == null)
				{
					_HelpCommand = new RelayCommand(ExecuteHelpCommand);
				}
				return _HelpCommand;
			}
		}
		private ICommand _ClearCommand;
		public  ICommand ClearCommand
		{
			get
			{
				if (_ClearCommand == null)
				{
					_ClearCommand = new RelayCommand(ExecuteClearCommand);
				}
				return _ClearCommand;
			}
		}
	}
}
