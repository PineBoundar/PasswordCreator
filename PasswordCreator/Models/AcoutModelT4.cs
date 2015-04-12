/*************************************************************************
  警告!
  このソースコードは自動生成されたものです
  このファイルを直接編集すると、編集した内容が失われる可能性があります
 *************************************************************************/
using System;
using System.Reflection;

namespace PasswordCreator.Models 
{
	static class AboutModel
	{

		public static string Title
		{
			get
			{
				AssemblyTitleAttribute a =
				    GetExecutingAssembleCustomAttributes<AssemblyTitleAttribute>();
				return (a == null) ? "" : a.Title;
			}
		}

		public static string Product
		{
			get
			{
				AssemblyProductAttribute a =
				    GetExecutingAssembleCustomAttributes<AssemblyProductAttribute>();
				return (a == null) ? "" : a.Product;
			}
		}

		public static string Copyright
		{
			get
			{
				AssemblyCopyrightAttribute a =
				    GetExecutingAssembleCustomAttributes<AssemblyCopyrightAttribute>();
				return (a == null) ? "" : a.Copyright;
			}
		}

		public static string Company
		{
			get
			{
				AssemblyCompanyAttribute a =
				    GetExecutingAssembleCustomAttributes<AssemblyCompanyAttribute>();
				return (a == null) ? "" : a.Company;
			}
		}

		public static string Description
		{
			get
			{
				AssemblyDescriptionAttribute a =
				    GetExecutingAssembleCustomAttributes<AssemblyDescriptionAttribute>();
				return (a == null) ? "" : a.Description;
			}
		}

		public static string Version
		{
			get
			{
				return MyAssembly.GetName().Version.ToString();
			}
		}

        private static T GetExecutingAssembleCustomAttributes<T>()
			where T : Attribute
        {
            object[] attributes = MyAssembly.GetCustomAttributes(typeof(T), false);
			if(attributes.Length == 0) return null;
			return (T)attributes[0];
        }
		private static Assembly MyAssembly
		{
			get
			{
				return Assembly.GetExecutingAssembly();
			}
		}
	}
}

