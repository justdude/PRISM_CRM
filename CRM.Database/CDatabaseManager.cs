﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Database
{
	public class CDatabaseManager
	{
		private  SqlConnection modConnection;

		public static string ConnectionString = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=CRM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

		public CDatabaseManager()
		{
			modConnection = new SqlConnection(ConnectionString);
		}

		public SqlDataReader Execute(string command)
		{
			SqlCommand cmd = null;
			SqlDataReader reader = null;

			try
			{
				if (modConnection.State == System.Data.ConnectionState.Closed)
					modConnection.Open();
				cmd = new SqlCommand(command, modConnection);

				reader = cmd.ExecuteReader();
				return reader;
			}
			catch(Exception ex)
			{
				if (reader != null)
					reader.Close();

				Close();
			}
			return reader;
		}

		public void Close()
		{
			if (modConnection == null)
				return;
			try
			{
				modConnection.Close();
			}
			catch
			{}
		}

		public bool ExecuteNonQuery(string command)
		{
			SqlCommand cmd = null;
			SqlDataReader reader = null;
			int res = 0;

			try
			{
				if (modConnection.State == System.Data.ConnectionState.Closed)
					modConnection.Open();
				cmd = new SqlCommand(command, modConnection);

				res = cmd.ExecuteNonQuery();
			}
			catch(Exception ex)
			{

			}
			finally
			{
				if (reader!=null)
					reader.Close();

				if (modConnection!=null)
					modConnection.Close();
			}
			return res == 1;
		}


	}
}
