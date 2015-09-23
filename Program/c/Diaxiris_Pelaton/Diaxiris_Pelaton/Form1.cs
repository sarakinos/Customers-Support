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
using System.Threading;


namespace Diaxiris_Pelaton
{
    public partial class Form1 : Form
    {
        public login loginForm = new login();
       
        public int loginStatus = 0;

        public Thread checkForCompletionThread;

        public Form1()
        {
             InitializeComponent();
             checkForCompletionThread = new Thread(aitimata.checkForCompletion);
             checkForCompletionThread.Start();
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Διαχείρηση Πελατών";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Διαχείρηση Ραντεβού";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Διαχείρηση Αιτημάτων";
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }
        private void button5_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Προβολή Εορτολογίου";
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }
        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Πρόσθετες Λειτουργίες";
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }
        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Έξοδος";
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (login.connection.State == ConnectionState.Open)
            {
                //Login Check
               if (loginForm.ShowDialog(this) == DialogResult.Cancel)
                {
                    loginStatus = loginForm.successLogin;
                }
            }
            if (loginStatus == 0)  //Change that to 0 to operate properly
            {
                Application.Exit();                
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            settings settingsForm = new settings();
            settingsForm.ShowDialog();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            form_pelates pelatesForm = new form_pelates();
            pelatesForm.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.connection.Close();
            checkForCompletionThread.Abort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            aitimata aitimataForm = new aitimata();
            aitimataForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            eortologio eortologioForm = new eortologio();
            eortologioForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rantevou ratnevouForm = new rantevou();
            ratnevouForm.ShowDialog();
        }
    }
}
