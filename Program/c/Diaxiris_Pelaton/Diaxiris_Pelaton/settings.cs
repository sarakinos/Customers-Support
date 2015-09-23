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
using System.Net.Mail;


namespace Diaxiris_Pelaton
{
    public partial class settings : Form
    {
        public emailForm email = new emailForm();

        private MySqlDataAdapter settingsAdapter;
        private MySqlCommand settingsCommand;
        private DataSet settingsDs;
        private MySqlDataAdapter settingsMinimataAdapter;
        private MySqlCommand settingsMinimataCommand;
        private DataSet settingsMinimataDs;
        private String mailUser, mailPass, mailFrom, mailHost;
        public static String mailThema, mailKeimeno, aitAporThema, aitAporKeimeno, aitEgThema, aitEgMinima;

        public settings()
        {
            InitializeComponent();
            getSettings();


                textBox11.Text = login.dbHost;
                textBox10.Text = login.dbUser;
                textBox9.Text = login.dbPass;
                textBox8.Text = login.db;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            email.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            settingsCommand.CommandText = "update settings set email_host=@host";
            settingsCommand.Parameters.AddWithValue("@host", System.Text.Encoding.UTF8.GetBytes(textBox1.Text));
            settingsCommand.ExecuteNonQuery();

            settingsCommand.CommandText = "update settings set email_username=@username";
            settingsCommand.Parameters.AddWithValue("@username", System.Text.Encoding.UTF8.GetBytes(textBox2.Text));
            settingsCommand.ExecuteNonQuery();

            settingsCommand.CommandText = "update settings set email_password=@password";
            settingsCommand.Parameters.AddWithValue("@password", System.Text.Encoding.UTF8.GetBytes(textBox3.Text));
            settingsCommand.ExecuteNonQuery();

            settingsCommand.CommandText = "update settings_minimata set eortazontesThema=@et";
            settingsCommand.Parameters.AddWithValue("@et", System.Text.Encoding.UTF8.GetBytes(textBox5.Text));
            settingsCommand.ExecuteNonQuery();

            settingsCommand.CommandText = "update settings_minimata set eortazontesMinima=@em";
            settingsCommand.Parameters.AddWithValue("@em", System.Text.Encoding.UTF8.GetBytes(richTextBox1.Text));
            settingsCommand.ExecuteNonQuery();

            settingsCommand.CommandText = "update settings_minimata set aporifthikanThema=@at";
            settingsCommand.Parameters.AddWithValue("@at", System.Text.Encoding.UTF8.GetBytes(textBox7.Text));
            settingsCommand.ExecuteNonQuery();

            settingsCommand.CommandText = "update settings_minimata set aporifthikanMinima=@am";
            settingsCommand.Parameters.AddWithValue("@am", System.Text.Encoding.UTF8.GetBytes(richTextBox3.Text));
            settingsCommand.ExecuteNonQuery();

            settingsCommand.CommandText = "update settings_minimata set oloklirothikanThema=@ot";
            settingsCommand.Parameters.AddWithValue("@ot", System.Text.Encoding.UTF8.GetBytes(textBox6.Text));
            settingsCommand.ExecuteNonQuery();

            settingsCommand.CommandText = "update settings_minimata set oloklirothikanMinima=@om";
            settingsCommand.Parameters.AddWithValue("@om", System.Text.Encoding.UTF8.GetBytes(richTextBox2.Text));
            settingsCommand.ExecuteNonQuery();

          
            getSettings();
        }

        private void settings_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void getSettings()
        {
            settingsCommand = login.connection.CreateCommand();
            settingsCommand.CommandText = "select email_username,email_password,email_host,email_from from settings";
            settingsAdapter = new MySqlDataAdapter(settingsCommand);
            settingsDs = new DataSet();
            settingsAdapter.Fill(settingsDs);

            textBox1.Text = settingsDs.Tables[0].Rows[0][2].ToString();
            textBox2.Text = settingsDs.Tables[0].Rows[0][0].ToString();
            textBox3.Text = settingsDs.Tables[0].Rows[0][1].ToString();
            textBox4.Text = settingsDs.Tables[0].Rows[0][3].ToString();

            settingsMinimataCommand = login.connection.CreateCommand();
            settingsMinimataCommand.CommandText = "SELECT * FROM settings_minimata";
            settingsMinimataAdapter = new MySqlDataAdapter(settingsMinimataCommand);
            settingsMinimataDs = new DataSet();
            settingsMinimataAdapter.Fill(settingsMinimataDs);

            textBox5.Text = settingsMinimataDs.Tables[0].Rows[0][1].ToString();
            richTextBox1.Text = settingsMinimataDs.Tables[0].Rows[0][2].ToString();

            textBox6.Text = settingsMinimataDs.Tables[0].Rows[0][3].ToString();
            richTextBox2.Text = settingsMinimataDs.Tables[0].Rows[0][4].ToString();

            textBox7.Text = settingsMinimataDs.Tables[0].Rows[0][5].ToString();
            richTextBox3.Text = settingsMinimataDs.Tables[0].Rows[0][6].ToString();

            mailThema = settingsMinimataDs.Tables[0].Rows[0][1].ToString();
            mailKeimeno = settingsMinimataDs.Tables[0].Rows[0][2].ToString();
            aitAporThema = settingsMinimataDs.Tables[0].Rows[0][3].ToString();
            aitAporKeimeno = settingsMinimataDs.Tables[0].Rows[0][4].ToString();
            aitEgThema = settingsMinimataDs.Tables[0].Rows[0][5].ToString();
            aitEgMinima = settingsMinimataDs.Tables[0].Rows[0][6].ToString();

        }

        private void settings_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void settings_Load(object sender, EventArgs e)
        {
            getSettings();
            tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand aitimataGiaEmail = login.connection.CreateCommand();
            aitimataGiaEmail.CommandText = "SELECT aitimata.p_id FROM aitimata LEFT OUTER JOIN pelates ON aitimata.p_id=pelates.p_id where eidopoihsh=1 and apotelesma=1";
            MySqlDataAdapter aitimataGiaEmailAdapter = new MySqlDataAdapter(aitimataGiaEmail);
            DataSet aitimataDs = new DataSet();
            aitimataGiaEmailAdapter.Fill(aitimataDs);

            for (int i = 0; i < aitimataDs.Tables[0].Rows.Count; i++)
            {
                MySqlCommand mailCommand = login.connection.CreateCommand();
                mailCommand.CommandText = "select email from pelates where p_id=@id";
                mailCommand.Parameters.AddWithValue("@id", aitimataDs.Tables[0].Rows[i][0]);
                MySqlDataAdapter mailAdapter = new MySqlDataAdapter(mailCommand);
                DataSet mailDs = new DataSet();
                mailAdapter.Fill(mailDs);
               
                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(mailDs.Tables[0].Rows[0][0].ToString()));
                message.Subject = settings.aitEgThema;
                message.Body = settings.aitEgMinima;
                getSettings();
                mailHost = settingsDs.Tables[0].Rows[0][2].ToString();
                mailUser = settingsDs.Tables[0].Rows[0][0].ToString();
                mailPass = settingsDs.Tables[0].Rows[0][1].ToString();
                mailFrom = settingsDs.Tables[0].Rows[0][3].ToString();
                message.From = new MailAddress(mailFrom);
                sendMail(message, mailHost, mailUser, mailPass);
                MessageBox.Show("Η αποστολή ολοκληρώθηκε!", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand aitimataGiaEmail = login.connection.CreateCommand();
            aitimataGiaEmail.CommandText = "SELECT aitimata.p_id FROM aitimata LEFT OUTER JOIN pelates ON aitimata.p_id=pelates.p_id where eidopoihsh=1 and apotelesma=0";
            MySqlDataAdapter aitimataGiaEmailAdapter = new MySqlDataAdapter(aitimataGiaEmail);
            DataSet aitimataDs = new DataSet();
            aitimataGiaEmailAdapter.Fill(aitimataDs);

            for (int i = 0; i < aitimataDs.Tables[0].Rows.Count; i++)
            {
                MySqlCommand mailCommand = login.connection.CreateCommand();
                mailCommand.CommandText = "select email from pelates where p_id=@id";
                mailCommand.Parameters.AddWithValue("@id", aitimataDs.Tables[0].Rows[i][0]);
                MySqlDataAdapter mailAdapter = new MySqlDataAdapter(mailCommand);
                DataSet mailDs = new DataSet();
                mailAdapter.Fill(mailDs);

                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(mailDs.Tables[0].Rows[0][0].ToString()));
                message.Subject = settings.aitAporThema;
                message.Body = settings.aitAporKeimeno;
                getSettings();
                mailHost = settingsDs.Tables[0].Rows[0][2].ToString();
                mailUser = settingsDs.Tables[0].Rows[0][0].ToString();
                mailPass = settingsDs.Tables[0].Rows[0][1].ToString();
                mailFrom = settingsDs.Tables[0].Rows[0][3].ToString();
                message.From = new MailAddress(mailFrom);
                sendMail(message, mailHost, mailUser, mailPass);
                MessageBox.Show("Η αποστολή ολοκληρώθηκε!", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
    
     
    }
}
        
    
}
