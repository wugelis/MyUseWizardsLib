using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyUseWizardsLib.Data
{
	/// <summary>
	/// DBConn ���K�n�y�z�C
	/// </summary>
	public class DBConn
	{
		public DBConn()
		{
			//
			// TODO: �b���[�J�غc�禡���{���X
			//
		}

		public string Connect()
		{
            string cn = frmORMappingWindow.ConnectionInfo.ConnectionString; //ConfigurationManager.AppSettings["CDCDDbConfig"];
			return cn;
		}
	}
}
