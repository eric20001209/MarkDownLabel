using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace MarkDownLabel
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。

		/// </summary>

		public static string m_sServer1 = "";
		public static string m_sServer2 = "";
		public static string m_sDBName1 = "";
		public static string m_sDBName2 = "";
		public static string m_sUser1 = "";
		public static string m_sUser2 = "";
		public static string m_sPass1 = "";
		public static string m_sPass2 = "";
		public static bool m_bSql1Good = false;
		public static bool m_bSql2Good = false;
		public static System.Data.SqlClient.SqlConnection myConnection1;
		public static System.Data.SqlClient.SqlConnection myConnection2;
		public static string m_sPrinterName = "Receipt";
		public static int m_nPaperWidth = 30;
		public static string m_sFontName = "Arial";
		public static string m_sFontSize = "10";
		public static string m_sFontStyle = "Regular";
		public static FontStyle m_tFontStyle = FontStyle.Bold;
		public static int m_nLine1Position = 0;
		public static int m_nLine2Position = 10;
		public static int m_nLine3Position = 25;
		public static int m_nLine4Position = 90;
		public static int m_nLine5Position = 100;
        public static int m_nLine6Position = 140;
		public static int m_nLine0Position = 0;
		public static int m_nLine7Position = 0;

		[STAThread]
		static void Main()
		{
			LoadConfig();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
		public static bool LoadConfig()
		{
			string sPath = AppDomain.CurrentDomain.BaseDirectory + "markdownlabel.ini";
			if (!File.Exists(sPath))
			{
				string sd = @"server1=localhost
name1=rst374
user1=eznz
pass1=9seqxtf7
printer_name=receipt
font_name=Arial
font_size=10
font_style=Regular
line1_position=48
line2_position=70
line3_position=0
line4_position=130
line5_position=170
line6_position=85
line0_position=60
line7_position=70
				";
				File.WriteAllText(sPath, sd);
				return false;
			}
			StreamReader sr = File.OpenText(sPath);
			string s = sr.ReadToEnd() + "\r";
			sr.Close();
			m_sServer1 = GetValue(s, "server1");
			m_sDBName1 = GetValue(s, "name1");
			m_sUser1 = GetValue(s, "user1");
			m_sPass1 = GetValue(s, "pass1");
			m_sPrinterName = GetValue(s, "printer_name");
			m_sFontName = GetValue(s, "font_name");
			m_sFontSize = GetValue(s, "font_size");
			m_sFontStyle = GetValue(s, "font_style");
			
			m_nLine1Position = Program.MyIntParse(GetValue(s, "line1_Position"));
			m_nLine2Position = Program.MyIntParse(GetValue(s, "line2_Position"));
			m_nLine3Position = Program.MyIntParse(GetValue(s, "line3_Position"));
			m_nLine4Position = Program.MyIntParse(GetValue(s, "line4_Position"));
			m_nLine5Position = Program.MyIntParse(GetValue(s, "line5_Position"));
            m_nLine6Position = Program.MyIntParse(GetValue(s, "line6_Position"));
			m_nLine0Position = Program.MyIntParse(GetValue(s, "line0_Position"));
			m_nLine7Position = Program.MyIntParse(GetValue(s, "line7_Position"));

			if (m_sFontName == "")
				m_sFontName = "Arial";
			if(m_sFontSize == "")
				m_sFontSize = "10";
			if(m_sFontStyle == "")
				m_sFontStyle = "Regular";
			
			return true;
		}
		public static string GetValue(string s, string skey)
		{
			string sl = s.ToLower();
			skey = skey.ToLower();
			string sRet = "";
			int p = sl.IndexOf(skey);
			if (p >= 0)
			{
				p += 1 + skey.Length;
				int q = sl.IndexOf("\r", p);
				if (q <= p)
					return "";
				sRet = s.Substring(p, q - p);
			}
			return sRet;
		}
		public static bool IsInt(string s)
		{
			int n;
			return int.TryParse(s, out n);
		}
		public static void ShowParseException(string s)
		{
			MessageBox.Show("Input string is not in correct format:" + s);
		}
		public static long MyLongParse(string s)
		{
			s = s.Trim();
			if (s == null || s == "")
				return 0;

			long n = 0;
			try
			{
				n = long.Parse(s);
			}
			catch
			{
				ShowParseException(s);
			}
			return n;
		}
		public static int MyIntParse(string s)
		{
			s = s.Trim();
			if (s == null || s == "")
				return 0;
			return (int)MyDoubleParse(s);
		}
		public static double MyDoubleParse(string s)
		{
			if (s == null)
				return 0;
			s = s.Trim();
			if (s == "")
				return 0;
			s = s.Trim();
			if (s.IndexOf("(") == 0 && s.IndexOf(")") == s.Length - 1)
			{
				s = s.Replace("(", "");
				s = s.Replace(")", "");
				s = "-" + s;
			}
			double d = 0;
			try
			{
				d = double.Parse(s);
			}
			catch
			{
				ShowParseException(s);
			}
			return d;
		}
		public static bool MyBooleanParse(string s)
		{
			if (s == null)
				return false;
			s = s.Trim();
			if (s == "" || s == "0")
				return false;
			else if (s == "1")
				return true;
			else if (s == "on")
				return true;
			else if (s == "true")
				return true;
			else if (s == "True")
				return true;
			else if (s == "On")
				return true;
			else if (s == "ON")
				return true;
			else if (s == "TRUE")
				return true;
			else if (s == "off")
				return false;

			bool b = false;
			try
			{
				b = Boolean.Parse(s);
			}
			catch
			{
				ShowParseException(s);
			}
			return b;
		}
		public static void Trim(ref string s)
		{
			if (s == null)
				return;
			s = s.TrimStart(null);
			s = s.TrimEnd(null);
		}
		public static double MyMoneyParse(string s)
		{
			if (s == null)
				return 0;
			s = s.Trim();
			if (s == "")
				return 0;

			double d = 0;
			try
			{
				d = double.Parse(s, NumberStyles.Currency, null);
			}
			catch
			{
				ShowParseException(s);
			}
			return d;
		}
		public static void ShowExp(string sc, Exception e)
		{
			MessageBox.Show("SQL error:" + e.ToString() + "\r\nsc=" + sc, "Database Query Error");
		}
		public static string EncodeQuote(string s)
		{
			if (s == null)
				return null;
			string ss = "";
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '\'')
					ss += '\''; //double it for SQL query
				ss += s[i];
			}
			return ss;
		}
	}
}
