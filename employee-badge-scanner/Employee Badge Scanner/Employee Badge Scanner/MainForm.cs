using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using readercomm;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SqlClient;

namespace Employee_Badge_Scanner
{
    public partial class MainForm : Form
    {
        public static string longNames = "CARDNO,LNAME,FNAME,DESCRP\n";
        public SqlConnection conn = new SqlConnection();
        public bool dbConnected = false;
        public static string dbServer = "";
        public static string dbUser = "";
        public static string dbPassword = "";
        private bool CurrentlyLogging;
        public static string csvPath = Directory.GetCurrentDirectory() + "..\\..\\..\\Badge List.csv";
        public static string settingsPath = Directory.GetCurrentDirectory()   + "..\\..\\..\\settings.txt";
        public static string logPath = Directory.GetCurrentDirectory() + "..\\..\\..\\Logs\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        public static StreamReader sr = new StreamReader(File.OpenRead(csvPath));
        public static List<string> list = new List<string>();
        public static int cardValue;
        public static string nameValue;
        public static string status;
        public const short PRXDEVTYP_USB = 0;
        private System.Timers.Timer LengthTimer;
        private int ElapsedSeconds;
        public MainForm()
        {
            InitializeComponent();
            Load_From_INI();
            pcproxlib.setLibPath();
            lblLoggingBegin.Text = "";
            CurrentlyLogging = false;
            lblLoggingStatusOutput.Text = "NOT LOGGING";
            lblLoggingStatusOutput.BackColor = Color.Red;
            lblLoggingLengthOutput.Text = "";

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "..\\..\\..\\Logs")) {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "..\\..\\..\\Logs");
            }

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var values = line.Split(',');
                foreach (var item in values)
                {
                    if (item != "")
                    {
                        list.Add(item);
                    }
                }
            }
            sr.Close();
        }
        public void makeFile(string FileName)
        {
            if (File.Exists(FileName) == false)
                File.Create(FileName);
        }
        public string[] readOptions(string optionsFile)
        {
            var options = File.ReadAllText(optionsFile);
            string[] optionsSplit = options.Split('\n');
            string[] optionsParameters = new string[optionsSplit.Length];
            for (var i = 0; i <= optionsSplit.Length - 1; i++)
                optionsParameters[i] = optionsSplit[i].Trim();
            return optionsParameters;
        }
        public string SearchArray(string[] aStringArray, string sSearchString)
        {
            string sReturn = "";
            if (aStringArray[0] != "")
            {
                for (int i = aStringArray.GetLowerBound(0); i <= aStringArray.GetUpperBound(0); i++)
                {
                        if (aStringArray[i].IndexOf(sSearchString) == 0)
                        {
                            sReturn = aStringArray[i].Replace(sSearchString, "");
                            break;
                        }
                }
            }
            return sReturn;
        }

        public void Load_From_INI()
        {
            makeFile(settingsPath);
            try
            {
                string[] arrOptions = readOptions(settingsPath);
                dbServer = SearchArray(arrOptions, "Server=");
                dbUser = SearchArray(arrOptions, "User=");
                dbPassword = SearchArray(arrOptions, "Password=");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void Store_INI_Values()
        {
            try
            {
                {
                    var optionsWrite = "Server=" + dbServer + Environment.NewLine + "User=" + dbUser + Environment.NewLine + "Password=" + dbPassword;
                    File.WriteAllText(settingsPath, optionsWrite);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void DB_Connect()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ("Data Source=" + dbServer + ";User ID=" + dbUser + "; Password=" + dbPassword);
                conn.Open();
                dbConnected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void DB_Close()
        {
            try
            {
                dbConnected = false;
                conn.Close();
                conn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnStartStopLogging_Click(object sender, EventArgs e)
        {
            if (CurrentlyLogging)
            {
                CurrentlyLogging = false;
                lblLoggingStatusOutput.Text = "NOT LOGGING";
                lblLoggingStatusOutput.BackColor = Color.Red;
                btnStartStopLogging.Text = "Start Logging";
                lblLoggingBegin.Text = "";
                lblLoggingLengthOutput.Text = "";
                if (LengthTimer.Enabled)
                {
                    LengthTimer.Stop();
                    LengthTimer.Dispose();
                    LengthTimer = null;
                    ElapsedSeconds = 0;
                }
            }
            else
            {
                CurrentlyLogging = true;
                lblLoggingStatusOutput.Text = "LOGGING";
                lblLoggingStatusOutput.BackColor = Color.Green;
                btnStartStopLogging.Text = "Stop Logging";
                lblLoggingBegin.Text = DateTime.Now.ToString("yyyy-MMM-dd hh:mm:ss tt");
                LengthTimer = new System.Timers.Timer(1000);
                LengthTimer.Elapsed += LengthTimer_Elapsed;
                ElapsedSeconds = 0;
                LengthTimer.Start();
            }
        }

        private void LengthTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ElapsedSeconds++;
            this.Invoke(new MethodInvoker(delegate ()
            {
                lblLoggingLengthOutput.Text = Math.Floor((decimal)ElapsedSeconds / (60 * 60)).ToString() + " Hours, " + (Math.Floor((decimal)ElapsedSeconds / (60) % 60).ToString()) + " Minutes, " +
                                            (ElapsedSeconds % 60).ToString() + " Seconds";
            }));
            

        }
        
        public static void getActiveID()
        {
            pcproxlib.SetDevTypeSrch(PRXDEVTYP_USB);
            int rc = pcproxlib.usbConnect();
            Thread.Sleep(250);
            if (rc == 1)
            {
                IntPtr result1 = Marshal.AllocHGlobal(32 * sizeof(int));
                byte[] arr = new byte[32];
                int nBits = pcproxlib.GetActiveID32(result1, 32);
                if (nBits == 0)
                {
                    return;
                }
                int Bytes = (nBits + 7) / 8;
                if (Bytes < 8)
                {
                    Bytes = 8;
                }
                Marshal.Copy(result1, arr, 0, 32);
                String cardData = "";
                for (int i = 0; i < Bytes; i++)
                {
                    String data = String.Format("{0:X2} ", arr[i]);
                    cardData = data + cardData;
                }
                cardData = cardData.Substring(11, 13).Replace(" ", "");
                cardValue = int.Parse(cardData, System.Globalization.NumberStyles.HexNumber);
                if (list.Contains(cardValue.ToString()))
                {
                    nameValue = list[list.IndexOf(cardValue.ToString()) + 2] + " " + list[list.IndexOf(cardValue.ToString()) + 1];
                    status = list[list.IndexOf(cardValue.ToString()) + 3];
                }
                else
                {
                    nameValue = "Employee Does Not Exist";
                    status = " - - DNE - - ";
                }
                Marshal.FreeHGlobal(result1);
            }
            else
            {
                Console.WriteLine("\n Reader Not Connected");
            }
        }

    private delegate void AppendTextBoxDelegate(ListBox lst, TextBox txt, TextBox txt2, TextBox txt3, string str, string str2, string str3);
    private static void AppendTextBox(ListBox lst, TextBox txt, TextBox txt2, TextBox txt3, string str, string str2, string str3) {
            if (lst.Items.Count >= 100)
            {
                lst.Items.Clear();
            }
            txt.Text = str;
            txt2.Text = str2;
            txt3.Text = str3;
            if (str3 == "Active")
            {
                txt3.ForeColor = Color.Green;
            }
            else
            {
                txt3.ForeColor = Color.Red;
            }
            if (!lst.Items.Contains("Employee Name: " + str2 + " - Employee ID: " + str + " - Status: " + status + "\n") && str != "0")
            {
                lst.Items.Add("Employee Name: " + str2 + " - Employee ID: " + str + " - Status: " + status + "\n");
                if (!File.Exists(logPath))
                {
                    File.Create(logPath);
                }
                if (str2 == "Employee Does Not Exist")
                {
                    return;
                }
                else
                {
                    File.AppendAllText(logPath, DateTime.Now + " - Employee Name: " + str2 + "\t- Employee ID: " + str + " - Status: " + status + "\n");
                }
            }
    }

        private void tmrCardScan_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentlyLogging == true)
                {
                    getActiveID();
                    AppendTextBoxDelegate chngr = new AppendTextBoxDelegate(AppendTextBox);
                    chngr(this.listHistory, this.txtScannedValue, this.txtEmployeeName, this.txtStatus, cardValue.ToString(), nameValue, status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand();
            List<string> updated = new List<string>();
            databaseConnection dc = new databaseConnection();
            if (dbServer == "")
            {
                dc.Show();
            }
            if (!dc.Visible)
            {
                try
                {
                    DB_Connect();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT BADGE_C.CARDNO, BADGE.LNAME, BADGE.FNAME, CARDSTATUS.DESCRP FROM COMPW.PWNT.dbo.BADGE INNER JOIN COMPW.PWNT.dbo.BADGE_C on BADGE.ID = BADGE_C.ID INNER JOIN COMPW.PWNT.dbo.CARDSTATUS on BADGE_C.STAT_COD = CARDSTATUS.STATUS ORDER BY BADGE.LNAME, BADGE.FNAME, BADGE_C.CARDNO";
                    comm.Connection = conn;
                    list.Clear();
                    using (SqlDataReader oReader = comm.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            list.Add(oReader["CARDNO"].ToString());
                            list.Add(oReader["LNAME"].ToString());
                            list.Add(oReader["FNAME"].ToString());
                            list.Add(oReader["DESCRP"].ToString());
                            longNames = longNames + oReader["CARDNO"].ToString() + "," + oReader["LNAME"].ToString() + "," + oReader["FNAME"].ToString() + "," + oReader["DESCRP"].ToString() + "\n";
                        }
                    }
                    File.WriteAllText(csvPath, "");
                    File.WriteAllText(csvPath, longNames);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
