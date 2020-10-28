using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Diagnostics;


namespace MarkDownLabel
{
	public partial class Form1 : Form
	{
		private SqlConnection myConnection;
		private SqlDataAdapter myAdapter;
		private SqlCommand myCommand;
		private DataSet dst = new DataSet();
//		private System.Drawing.Color sdcBackOrg = System.Drawing.Color.Gray;
//		private System.Drawing.Color sdcForeOrg = System.Drawing.Color.White;
//		private System.Drawing.Color sdcBackHigh = System.Drawing.Color.DarkBlue;
//		private System.Drawing.Color sdcForeHigh = System.Drawing.Color.Red;
		private PrintDocument printDoc = new PrintDocument();
//		private string m_sPrintMethod = "1";
		private string m_sPrintBuffer = "";
		private string[] m_sPrintLine = new string[8];
		private bool m_bPrintOwn = true;

		public Form1()
		{
			InitializeComponent();
			Init();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			lblCode.Text = "";
			lblName.Text = "";
			lblPrice.Text = "";
			lblMDBarcode.Text = "";
			txtBarcode.Focus();
		}
		private void Init()
		{
			printDoc.PrinterSettings.PrinterName = Program.m_sPrinterName;
			printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
			string sSecurityString = "User id=" + Program.m_sUser1 + ";Password=" + Program.m_sPass1 + ";Integrated Security=false;Connect Timeout=3";
			if (Program.m_sUser1 == "")
				sSecurityString = "Integrated Security=SSPI;";
			myConnection = new System.Data.SqlClient.SqlConnection("Initial Catalog=" + Program.m_sDBName1 + ";data source=" + Program.m_sServer1 + ";" + sSecurityString);
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
		{
			int y = 0; //vertical position;
			int lineHeight = 21;
			int size = 6;
			string s = "1";

			float fSize = (float)Program.MyDoubleParse(Program.m_sFontSize);
            Font printFont = new Font(Program.m_sFontName, fSize, Program.m_tFontStyle);
			Font smallFont = new Font(Program.m_sFontName, 7, Program.m_tFontStyle);
			Font printFontDefault = new Font(Program.m_sFontName, fSize, Program.m_tFontStyle);
			Font printFontBig = new Font(Program.m_sFontName, fSize + size, Program.m_tFontStyle);
            Font m_PrintFont = new Font("Arial Black", 25);
            //Font m_BarcodeFont = new Font("3 of 9 Barcode", 19);
            Font m_BarcodeFont = new Font("CODE 128",25);
			e.Graphics.DrawString(m_sPrintLine[1], printFont, Brushes.Black, 70, Program.m_nLine1Position);
			e.Graphics.DrawString(m_sPrintLine[2], printFont, Brushes.Black, 0, Program.m_nLine2Position);
            e.Graphics.DrawString(m_sPrintLine[6], printFont, Brushes.Black, 0, Program.m_nLine6Position);
			e.Graphics.DrawString(m_sPrintLine[3], m_PrintFont, Brushes.Black, 55, Program.m_nLine3Position);
			e.Graphics.DrawString(m_sPrintLine[4], m_BarcodeFont, Brushes.Black, 0, Program.m_nLine4Position);
            e.Graphics.DrawString(m_sPrintLine[5], printFont, Brushes.Black, 0, Program.m_nLine5Position);
			if (lblBestBefore.Text != "")
			{
				e.Graphics.DrawString(m_sPrintLine[0], smallFont, Brushes.Black, 120, Program.m_nLine0Position);
			}
			if (lblUsedBy.Text != "")
			{
				e.Graphics.DrawString(m_sPrintLine[7], smallFont, Brushes.Black, 0, Program.m_nLine7Position);
			}
			txtBarcode.Focus();
		}
		private void btnScan_Click(object sender, EventArgs e)
		{
			DoScanBarcode();
		}
		private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				DoScanBarcode();
		}
		private void DoScanBarcode()
		{
			string barcode = txtBarcode.Text.Trim();
			if(barcode == "")
			{
				MessageBox.Show("Please enter barcode or product code");
				return;
			}
			if(dst.Tables["scanbarcode"] != null)
				dst.Tables["scanbarcode"].Clear();
				
			int nRows = 0;
			string sc = " SELECT c.code, c.name, c.price1, c.best_before, c.used_by ";
			sc += " FROM code_relations c ";
			sc += " WHERE c.barcode = '" + Program.EncodeQuote(barcode) + "' ";
			try
			{
				myAdapter = new SqlDataAdapter(sc, myConnection);
				nRows = myAdapter.Fill(dst, "scanbarcode");
			}
			catch (Exception e)
			{
				Program.ShowExp(sc, e);
				return;
			}
			if(nRows == 0)
			{
				sc = " SELECT c.code, c.name, c.price1, c.best_before, c.used_by ";
				sc += " FROM code_relations c ";
				sc += " JOIN barcode b ON b.item_code = c.code ";
				sc += " WHERE b.barcode = '" + Program.EncodeQuote(barcode) + "' ";
				try
				{
					myAdapter = new SqlDataAdapter(sc, myConnection);
					nRows = myAdapter.Fill(dst, "scanbarcode");
				}
				catch (Exception e)
				{
					Program.ShowExp(sc, e);
					return;
				}
			}
			bool bInt = Program.IsInt(barcode);
			if (bInt && nRows == 0)
			{
				sc = " SELECT TOP 1 c.code, c.name, c.price1, c.best_before, c.used_by ";
				sc += " FROM code_relations c ";
				sc += " WHERE c.code = " + barcode;
				try
				{
					myAdapter = new SqlDataAdapter(sc, myConnection);
					nRows = myAdapter.Fill(dst, "scanbarcode");
				}
				catch (Exception e)
				{
					Program.ShowExp(sc, e);
					return;
				}
			}
			if(nRows <= 0)
			{
				MessageBox.Show("Not found");
				return;
			}
			
			DataRow dr = dst.Tables["scanbarcode"].Rows[0];
			string code = dr["code"].ToString();
			string name = dr["name"].ToString();
			string best_before = dr["best_before"].ToString();
			string used_by = dr["used_by"].ToString();
			double dbest_before = Program.MyDoubleParse(best_before);
			double dused_by = Program.MyDoubleParse(used_by);
			double dPrice = Program.MyDoubleParse(dr["price1"].ToString());

			if (dbest_before > 0)
			{
				best_before = DateTime.Now.AddDays(dbest_before).ToString("dd/MM/yyyy");
				lblBestBefore.Text = best_before;
			}
			if (dused_by > 0)
			{
				used_by = DateTime.Now.AddDays(dused_by).ToString("dd/MM/yyyy");
				lblUsedBy.Text = used_by;
			}

			lblCode.Text = code;
			lblName.Text = name;
            textBox1.Text = name;
			lblPrice.Text = dPrice.ToString("c");
			txtQty.Text = "1";
			txtMarkdownPrice.Focus();
		}
		private void btnPrint_Click(object sender, EventArgs e)
		{
			double dPrice = Program.MyMoneyParse(txtMarkdownPrice.Text);
            string barcode = GenerateBarcode();
			if(barcode == "")
				return;
			m_sPrintLine[0] = "BB:" + lblBestBefore.Text;
			m_sPrintLine[7] = "UB:" + lblUsedBy.Text;
            m_sPrintLine[1] = "Was " + lblPrice.Text;
            m_sPrintLine[6] = "";
            List<string> mylist = listBoxWordWrap2(lblName.Text,25);
            if (mylist.Count > 1)
            {
                m_sPrintLine[2] = mylist[0];
                m_sPrintLine[6] = mylist[1];
            }
            else
			    m_sPrintLine[2] = lblName.Text;
			m_sPrintLine[3] = dPrice.ToString("c");
            m_sPrintLine[4] = CreateBarcode128(GenerateBarcode(), 'B');
            //m_sPrintLine[4] = CreateBarcode128("MD00008123000700", 'B');
			m_sPrintLine[5] = barcode;
			
			int nQty = Program.MyIntParse(txtQty.Text);
			if(nQty <= 0)
				nQty = 1;
			for(int i=0; i<nQty; i++)
				printDoc.Print();
		}
//        private void createbarcode()
//        {
//            BarCodeControl code128 = new BarCodeControl();
//            code128.Symbology = KeepAutomation.Barcode.Symbology.Code128Auto;
//            code128.CodeToEncode = "Code128Csharp";

//            code128.ChecksumEnabled = true;
////            code128.ImageFormat = ImageFormat.Png;
//            code128.DisplayChecksum = true;

// //           code128.BarcodeUnit = BarcodeUnit.Pixel;
//            // Code 128 image resolution in DPI.
//            code128.DPI = 72;
//            // Code 128 bar module width (X dimention)
//            code128.X = 3;
//            // Code 128 bar module height (Y dimention)
//            code128.Y = 60;
//            // Image left margin size, a 10X is automatically added according to
//            code128.LeftMargin = 0;
//            // Image left margin size, a 10X is automatically added according to
//            code128.RightMargin = 0;
//            // Code 128 image top margin size
//            code128.TopMargin = 0;
//            // Code 128 image bottom margin size
//            code128.BottomMargin = 0;
//            // Code 128 image orientation, 0, 90, 180, 270 degrees supported.
//            code128.Orientation = KeepAutomation.Barcode.Orientation.Degree0;

//            // Set Code 128 human readable text

//            // Display human readable text
//            code128.DisplayText = true;
//            code128.TextFont = new Font("Arial", 10f, FontStyle.Regular);
//            // Space between barcode and text beneath.
//            code128.TextMargin = 6;

//            // Generate Code 128 barcodes in image format PNG
//            code128.generateBarcode(g);
//        }

        static char checkSum128(string data, int startcode)
        {
            int sum = startcode;
            for (int i = 0; i < data.Length; i++)
            {
                sum += (i + 1) * ((byte)(data[i]) - 32);
            }
            int remain = sum % 103;
            if (remain > 94)
                return (char)(remain + 100);
            else
                return (char)((sum % 103) + 32);
        }
        private string CreateBarcode128(string text, char CodeABC)
        {
            char Stop = (char)206;
            char StartCode =  (char)204;
            char check = checkSum128(text, (byte)StartCode - 100);
            return StartCode + text + (char)check + Stop;
        }

		private string GenerateBarcode()
		{
			string s = txtMarkdownPrice.Text;
			double dPrice = Program.MyMoneyParse(s);
			if (dPrice <= 0 && s != "0" && s != "0." && s != "0.0")
			{
				MessageBox.Show("Please enter a valid markdown price");
				txtMarkdownPrice.Focus();
				return "";
			}
			dPrice = Math.Round(dPrice * 100, 0);
			int nPrice = (int)(dPrice);
            string barcode = "MD" + Program.MyIntParse(lblCode.Text).ToString("D8") +nPrice.ToString("D6");
			lblMDBarcode.Text = barcode;
			return barcode;
		}
		private void txtMarkdownPrice_TextChanged(object sender, EventArgs e)
		{
			GenerateBarcode();
		}
		private void btnConfig_Click(object sender, EventArgs e)
		{
			string sPath = AppDomain.CurrentDomain.BaseDirectory + "markdownlabel.ini";
			Process.Start("notepad.exe", sPath);
		}
		private void btnReload_Click(object sender, EventArgs e)
		{
			Program.LoadConfig();
			Init();
			MessageBox.Show("configuration reloaded");
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /*
 *字符串换行，考虑到空格，以及完整单词的情况
 *@param inputStr 要换行的字符串
 *@param textWidth 固定的长度，超过这个长度则进行换行
 *
 */

        public List<string> listBoxWordWrap2(string inputStr, int textWidth)
        {
            List<string> list = new List<string>();
            List<string> lastList = new List<string>();
            string str = inputStr;
            //int textWidth = 64;
            if (str != "" || str != null)
            {
                int strLength = str.Length;
                if (strLength > textWidth)
                {
                    string[] listArray = str.Split(' ');//先把字符串分割成一个个单词，后面再重新连接
                    string joinStr = "";//连接起来的字符串
                    string nextStr = "";//再添加多一个元素的连接字符串
                    for (int j = 0; j < listArray.Length; j++)
                    {
                        list.Add(listArray[j]);
                        joinStr = String.Join(" ", list.ToArray());
                        //通过 当前字符串比固定长度小，但下一个字符串比固定长度大来判断换行处
                        if (joinStr.Length <= textWidth && j < listArray.Length - 1)
                        {
                            list.Add(listArray[j + 1]);
                            nextStr = String.Join(" ", list.ToArray());
                            if (nextStr.Length > textWidth)
                            {
                                lastList.Add(joinStr);
                                list.Clear();
                            }
                            else
                                list.Remove(listArray[j + 1]);
                        }
                        else if (j == listArray.Length - 1)
                        {
                            lastList.Add(joinStr.Trim());
                            list.Clear();
                        }
                    }
                }
            }
            return lastList;
        }

	}
}
