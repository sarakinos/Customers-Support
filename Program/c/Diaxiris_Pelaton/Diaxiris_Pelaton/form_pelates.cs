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
    public partial class form_pelates : Form
    {
       

        int first = 0;

        String selectedPeriferia = "";
        String selectedPeriferiakiEnotita="";

        MySqlDataAdapter pelatesAdapter,periferiesAdapter,periferiakiEnotitaAdapter,dimoiAdapter;
        MySqlCommand pelatesShowCommand,periferiesFillCommand,periferiakiEnotitaFillCommand,dimoiFillCommand,addPelatiCommand;

        DataSet pelatesDs,periferiesDs,periferiakiEnotitaDs,dimoiDs,addPelatiDs;
        
        
        public form_pelates()
        {
            InitializeComponent();


           
           
        }

        private void form_pelates_Load(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                fillPelates(dataGridView1);
            }
        }

       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                fillPelates(dataGridView1);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                fillPeriferies();
                fillPeriferiakiEnotita();
                fillDimoi();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                fillPelates(dataGridView2);
            }
            else
            {
                fillPelates(dataGridView3);
                if (first == 0)
                {

                
                DataGridViewCheckBoxColumn diagrafiBox = new DataGridViewCheckBoxColumn();
                diagrafiBox.HeaderText = "Diagrafi";
                diagrafiBox.FalseValue = "0";
                diagrafiBox.TrueValue = "1";
                dataGridView3.Columns.Insert(0, diagrafiBox);
                    first=1;
                }
            }
        }
        private void fillPelates(DataGridView dg)
        {
            try
            {
                pelatesShowCommand = login.connection.CreateCommand();

                pelatesShowCommand.CommandText = "select * from pelates";
                pelatesAdapter = new MySqlDataAdapter(pelatesShowCommand);
                pelatesDs = new DataSet();
                pelatesAdapter.Fill(pelatesDs, "Pelates");
                dg.DataSource = pelatesDs.Tables[0].DefaultView;
            }
            catch (MySqlException exp)
            {
                MessageBox.Show(exp.ToString());
            }
           
            

        }
        private void fillPeriferies()
        {
            periferiesFillCommand = login.connection.CreateCommand();
            periferiesFillCommand.CommandText = "select * from periferies";

            periferiesAdapter = new MySqlDataAdapter(periferiesFillCommand);

            periferiesDs = new DataSet();
            periferiesAdapter.Fill(periferiesDs);

            comboBox1.DisplayMember = "onoma";
            comboBox1.ValueMember = "onoma";
            comboBox1.DataSource = periferiesDs.Tables[0];
            selectedPeriferia = periferiesDs.Tables[0].Rows[0][0].ToString();
       
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != "")
            {
                try
                {
                    selectedPeriferia = periferiesDs.Tables[0].Rows[comboBox1.SelectedIndex][0].ToString();
                    fillPeriferiakiEnotita();
                }
                catch (Exception exce)
                {  
                    Console.Write(exce.ToString());
                }
            }
        }
        private void fillPeriferiakiEnotita()
        {
            periferiakiEnotitaFillCommand = login.connection.CreateCommand();
            periferiakiEnotitaFillCommand.CommandText = "select * from periferiaki_enotita where periferia_id=@periferiaID";
            periferiakiEnotitaFillCommand.Parameters.AddWithValue("@periferiaID", selectedPeriferia);

            periferiakiEnotitaAdapter = new MySqlDataAdapter(periferiakiEnotitaFillCommand);

            periferiakiEnotitaDs = new DataSet();
            periferiakiEnotitaAdapter.Fill(periferiakiEnotitaDs);

            comboBox2.DisplayMember = "onoma";
            comboBox2.ValueMember = "onoma";
            comboBox2.DataSource = periferiakiEnotitaDs.Tables[0];

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.Trim() != "")
            {
                try
                {
                    selectedPeriferiakiEnotita = periferiakiEnotitaDs.Tables[0].Rows[comboBox2.SelectedIndex][0].ToString();
                    fillDimoi();
                }
                catch (Exception exce)
                {
                    Console.Write(exce.ToString());
                }
            }
        }

        private void fillDimoi()
        {

            dimoiFillCommand = login.connection.CreateCommand();
            dimoiFillCommand.CommandText = "select * from dimoi where periferiaki_enotita_id=@periferiakiEnotitaID";
            dimoiFillCommand.Parameters.AddWithValue("@periferiakiEnotitaID", selectedPeriferiakiEnotita);

            dimoiAdapter = new MySqlDataAdapter(dimoiFillCommand);

            dimoiDs = new DataSet();
            dimoiAdapter.Fill(dimoiDs);

            comboBox3.DisplayMember = "onoma";
            comboBox3.ValueMember = "onoma";
            comboBox3.DataSource = dimoiDs.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int64 phone, mobPhone;
            bool isNumericalPhone = Int64.TryParse(textBox5.Text, out phone);
            bool isNumericalMobPhone = Int64.TryParse(textBox6.Text, out mobPhone);
            if (isNumericalPhone && isNumericalMobPhone)
            {
                try
                {            

                    addPelatiCommand = login.connection.CreateCommand();
                    MySqlCommand setNames = login.connection.CreateCommand();
                    setNames.CommandText = "SET NAMES 'utf8'";
                    setNames.ExecuteNonQuery();
                    addPelatiCommand.CommandText = "INSERT INTO pelates (p_id,Onoma,Epitheto,Onoma_Miteras,Onoma_Patera,Hmerominia_Gennisis,Tilefono_Oikias,Kinito_Tilefono,Diefthinsi,Dimos,Periferia,Periferiaki_Enotita,Epaggelma,Email) VALUES  (NULL,@Onoma,@Epitheto,@Onoma_Miteras, @Onoma_Patera,@Hmerominia_Genisis,@Tilefono_Oikias,@Kinito_Tilefono,@Diefthinsi, @Dimos,@Periferia, @Periferiaki_Enotita, @Epaggelma, @Email)";
                    addPelatiCommand.Parameters.AddWithValue("@Onoma", System.Text.Encoding.UTF8.GetBytes(textBox1.Text));
                    addPelatiCommand.Parameters.AddWithValue("@Epitheto", System.Text.Encoding.UTF8.GetBytes(textBox2.Text));
                    addPelatiCommand.Parameters.AddWithValue("@Onoma_Miteras", System.Text.Encoding.UTF8.GetBytes(textBox3.Text));
                    addPelatiCommand.Parameters.AddWithValue("@Onoma_Patera", System.Text.Encoding.UTF8.GetBytes(textBox4.Text));
                    addPelatiCommand.Parameters.AddWithValue("@Hmerominia_Genisis", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
                    addPelatiCommand.Parameters.AddWithValue("@Tilefono_Oikias", textBox5.Text.ToString());
                    addPelatiCommand.Parameters.AddWithValue("@Kinito_Tilefono", textBox6.Text.ToString());
                    addPelatiCommand.Parameters.AddWithValue("@Diefthinsi", System.Text.Encoding.UTF8.GetBytes(textBox7.Text));
                    addPelatiCommand.Parameters.AddWithValue("@Dimos", System.Text.Encoding.UTF8.GetBytes(comboBox3.Text));
                    addPelatiCommand.Parameters.AddWithValue("@Periferia", System.Text.Encoding.UTF8.GetBytes(comboBox1.Text));
                    addPelatiCommand.Parameters.AddWithValue("@Periferiaki_Enotita", System.Text.Encoding.UTF8.GetBytes(comboBox2.Text));
                    addPelatiCommand.Parameters.AddWithValue("@Epaggelma", System.Text.Encoding.UTF8.GetBytes(textBox9.Text));
                    addPelatiCommand.Parameters.AddWithValue("@Email", textBox10.Text.ToString());
                    addPelatiCommand.ExecuteNonQuery();

                    resetPelatisFields();
                }
                catch (MySqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.ToString());
                }
            }
            else MessageBox.Show("Παρακαλώ βάλτε αριθμούς στα πεδία 'Σταθερό','Κινητό Τηλέφωνο'");
        }
        private void resetPelatisFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            dateTimePicker1.ResetText();
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           // MySqlCommandBuilder updateCommand = new MySqlCommandBuilder(pelatesAdapter);
           // pelatesAdapter.Update(pelatesDs, "Pelates");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dataGridView3.Rows[e.RowIndex].Cells[0].Value)==false)
                {
                    dataGridView3.Rows[e.RowIndex].Cells[0].Value = 1;
                }
                else
                {
                    dataGridView3.Rows[e.RowIndex].Cells[0].Value = 0;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void form_pelates_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            searchFunction(dataGridView1,textBox8);
            
        }

        public void searchFunction(DataGridView dg1,TextBox txt)
        {
            dg1.ClearSelection();
            try
            {

                dg1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach (DataGridViewRow row in dg1.Rows)
                {

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value.ToString().Equals(txt.Text.Trim().ToString()) && txt.Text != "")
                        {
                            row.Selected = true;
                        }
                        
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
           
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            //searchFunction(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // searchFunction(dataGridView1);
        }

      

       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            searchFunction(dataGridView1, textBox12);
        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {
            searchFunction(dataGridView2, textBox8);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            int deleteCount = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    deleteCount++;
                }
            }

            DialogResult dialogResult = MessageBox.Show("Πρόκειται να διαγραφούν " + deleteCount.ToString() + " εγγραφές.Είστε σίγουροι ότι θέλετε να συνεχίσετε;", "Διαγραφή εγγραφών", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView3.RefreshEdit();


                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dataGridView3.Rows[i].Cells[0].Value))
                    {                       
                        MySqlCommand delete = login.connection.CreateCommand();
                        delete.CommandText = "DELETE FROM pelates WHERE p_id=@id";
                        delete.Parameters.AddWithValue("@id", dataGridView3.Rows[i].Cells[1].Value.ToString());
                        delete.ExecuteNonQuery();
                       
                    }
                }
                fillPelates(dataGridView3);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value.ToString() != "")
                {
                   
                        MySqlCommand update = login.connection.CreateCommand();
                        update.CommandText = "UPDATE pelates SET Onoma=@onoma,Epitheto=@epitheto,Onoma_Miteras=@onomaMiteras,Onoma_Patera=@onomaPatera,Hmerominia_Gennisis=@hmGen,Tilefono_Oikias=@tilOik,Kinito_Tilefono=@kinito,Diefthinsi=@diefthinsi,Dimos=@dimos,Periferia=@periferia,Periferiaki_Enotita=@periferiakiEnotita,Epaggelma=@epaggelma,Email=@email WHERE p_id=@id";

                        update.Parameters.AddWithValue("@id", dataGridView2.Rows[i].Cells[0].Value.ToString());
                        update.Parameters.AddWithValue("@onoma", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[1].Value.ToString()));
                        update.Parameters.AddWithValue("@epitheto",System.Text.Encoding.UTF8.GetBytes (dataGridView2.Rows[i].Cells[2].Value.ToString()));
                        update.Parameters.AddWithValue("@onomaMiteras", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[3].Value.ToString()));
                        update.Parameters.AddWithValue("@onomaPatera", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[4].Value.ToString()));
                        update.Parameters.AddWithValue("@hmGen", Convert.ToDateTime(dataGridView2.Rows[i].Cells[5].Value.ToString()));
                        update.Parameters.AddWithValue("@tilOik", dataGridView2.Rows[i].Cells[6].Value.ToString());
                        update.Parameters.AddWithValue("@kinito", dataGridView2.Rows[i].Cells[7].Value.ToString());
                        update.Parameters.AddWithValue("@diefthinsi", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[8].Value.ToString()));
                        update.Parameters.AddWithValue("@dimos", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[9].Value.ToString()));
                        update.Parameters.AddWithValue("@periferia", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[10].Value.ToString()));
                        update.Parameters.AddWithValue("@periferiakiEnotita", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[11].Value.ToString()));
                        update.Parameters.AddWithValue("@epaggelma", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[12].Value.ToString()));
                        update.Parameters.AddWithValue("@email", dataGridView2.Rows[i].Cells[13].Value.ToString());
                        update.ExecuteNonQuery();
                    
                   
                }
            }
        }
       
    }
}
