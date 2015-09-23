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

namespace Diaxiris_Pelaton
{
    public partial class login : Form
    {

        public static String dbHost = "localhost";
        public static String dbUser = "root";
        public static String dbPass = "";
        public static String db = "paroxi_ypiresion";
        public int successLogin = 0;
        String connectionString = "Server=" + dbHost + ";Database=" + db + ";Uid=" + dbUser + ";Pwd=" + dbPass + ";convert zero datetime=True";
        public static MySqlConnection connection;
        public login()
        {
            InitializeComponent();
            makeConnection();
        }

        private void login_Load(object sender, EventArgs e)
        {
           
        }
       

        private void checkLogin()
        {
            

            MySqlCommand command;
            command = connection.CreateCommand();
            command.CommandText = "select * from usersp where username=@Uname and password=@Pass";
            command.Parameters.AddWithValue("@Uname", textBox1.Text.Trim());
            command.Parameters.AddWithValue("@Pass", textBox2.Text.Trim());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            if (ds.Tables[0].DefaultView.Count > 0)
            {

                successLogin = 1;
               
            }
            else
            {
                MessageBox.Show("Invalid Username/Password","Login Failed");
            }
      
        }

        public void makeConnection()
        {
            try
            {

                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkLogin();
           // connection.Close();
            this.Close();
        }
    }
}
