using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Diaxiris_Pelaton
{

    public partial class emailForm : Form
    {
        private MySqlCommand pelatesShowCommand;
        private MySqlDataAdapter pelatesAdapter;
        private DataSet pelatesDs;
        public static String mailUser, mailPass, mailHost, mailFrom;
        public emailForm()
        {
            InitializeComponent();
          //  fillPelates();
        }

        private void fillPelates()
        {
            try
            {
                pelatesShowCommand = login.connection.CreateCommand();
                pelatesShowCommand.CommandText = "select * from pelates";

                pelatesAdapter = new MySqlDataAdapter(pelatesShowCommand);

                pelatesDs = new DataSet();
                pelatesAdapter.Fill(pelatesDs);

                int pelatesCount = pelatesDs.Tables[0].Rows.Count;

                for (int i = 0; i < pelatesCount; i++)
                {

                    checkedListBox1.Items.Add(pelatesDs.Tables[0].Rows[i][1] + " " + pelatesDs.Tables[0].Rows[i][2]);

                }
                if (checkedListBox1.Items.Count != 0)
                {
                    checkedListBox1.SelectedIndex = 0;
                }





            }
            catch (MySqlException exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        public static void sendMail(MailMessage message, String mailHost, String mailUser, String mailPass)
        {

            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.Host = mailHost;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(mailUser, mailPass);
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.Send(message);
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && richTextBox1.Text != "" && checkedListBox1.CheckedItems.Count>0)
            {
                MailMessage message = new MailMessage();

                foreach (int indexChecked in checkedListBox1.CheckedIndices)
                {
                    message.To.Add(new MailAddress(pelatesDs.Tables[0].Rows[indexChecked][13].ToString()));
                }
              
                message.Subject = textBox1.Text;
                message.Body = richTextBox1.Text;

                getSettings();
                message.From = new MailAddress(mailFrom);
                sendMail(message, mailHost, mailUser, mailPass);
                MessageBox.Show("Η αποστολή ολοκληρώθηκε!", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else MessageBox.Show("Συμπληρώστε Θέμα και Μήνυμα και έπειτα επιλέξτε παραλήπτες", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void getSettings()
        {
            MySqlCommand settingsCommand;
            MySqlDataAdapter settingsAdapter;
            DataSet settingsDs;

            settingsCommand = login.connection.CreateCommand();
            settingsCommand.CommandText = "select email_username,email_password,email_host,email_from from settings";
            settingsAdapter = new MySqlDataAdapter(settingsCommand);
            settingsDs = new DataSet();
            settingsAdapter.Fill(settingsDs);

            mailHost = settingsDs.Tables[0].Rows[0][2].ToString();
            mailUser = settingsDs.Tables[0].Rows[0][0].ToString();
            mailPass = settingsDs.Tables[0].Rows[0][1].ToString();
            mailFrom = settingsDs.Tables[0].Rows[0][3].ToString();
        }

        private void emailForm_Load(object sender, EventArgs e)
        {
            fillPelates();
        }

      
    }
}

