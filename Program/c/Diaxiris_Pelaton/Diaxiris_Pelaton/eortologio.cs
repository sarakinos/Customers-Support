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
    public partial class eortologio : Form
    {

        MySqlDataAdapter getEortiAdapter, getPelatesPouGiortazounAdapter;
        MySqlCommand showEortiCommand, showPelatesPouGiortazounCommand;
        DataSet todayDataset, pelatesPouGiortazounDataset;

        public eortologio()
        {
            InitializeComponent();
            todayDataset = new DataSet();
            pelatesPouGiortazounDataset = new DataSet();
            getTodayEorti();
            getPelates();

        }
        private void getTodayEorti()
        {
            try
            {

                showEortiCommand = login.connection.CreateCommand();

                showEortiCommand.CommandText = "select * from days where day='" + dateTimePicker1.Value.Day + "' and month='" + dateTimePicker1.Value.Month + "'";
                getEortiAdapter = new MySqlDataAdapter(showEortiCommand);
                todayDataset.Clear();
                getEortiAdapter.Fill(todayDataset, "Eorti Simera");

                if (todayDataset.Tables[0].Rows.Count > 0)
                {
                    label2.Text = todayDataset.Tables[0].Rows[0][2].ToString();
                }
                else label2.Text = "Δεν υπάρχει γιορτή για σήμερα";
            }
            catch (MySqlException exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            getTodayEorti();
            getPelates();
        }

        private void eortologio_Load(object sender, EventArgs e)
        {

        }

        private void getPelates()
        {

            String giorti = label2.Text;
            String[] name = giorti.Split(',');
            String finalName = label2.Text;
            finalName = finalName.Replace(" ", "");

            showPelatesPouGiortazounCommand = login.connection.CreateCommand();
            showPelatesPouGiortazounCommand.CommandText = "select * from pelates where FIND_IN_SET(Onoma, @giorti)";
            showPelatesPouGiortazounCommand.Parameters.AddWithValue("@giorti", System.Text.Encoding.UTF8.GetBytes(finalName));
            getPelatesPouGiortazounAdapter = new MySqlDataAdapter(showPelatesPouGiortazounCommand);
            pelatesPouGiortazounDataset = new DataSet();
            getPelatesPouGiortazounAdapter.Fill(pelatesPouGiortazounDataset);
            dataGridView1.DataSource = pelatesPouGiortazounDataset.Tables[0].DefaultView;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 1)
            {
                MessageBox.Show("Δεν υπάρχουν πελάτες που γιορτάζουν σήμερα", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MailMessage message = new MailMessage();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (Convert.ToString(dr.Cells[13].Value) != "")
                    {
                        // MessageBox.Show(Convert.ToString(dr.Cells[13].Value));
                        message.To.Add(new MailAddress(Convert.ToString(dr.Cells[13].Value)));
                    }
                }
                message.Subject = settings.mailThema;
                message.Body = settings.mailKeimeno;

                emailForm.getSettings();
                message.From = new MailAddress(emailForm.mailFrom);
                emailForm.sendMail(message, emailForm.mailHost, emailForm.mailUser, emailForm.mailPass);
            }
        }
    }
}
