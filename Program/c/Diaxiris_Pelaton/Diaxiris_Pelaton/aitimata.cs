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
    public partial class aitimata : Form
    {
        

        String selectedPelatisID = "";

        int first = 0;
        MySqlCommandBuilder updateCommand;
        MySqlDataAdapter aitimataAdapter,pelatesFillAdapter;
        MySqlCommand aitimataShowCommand,pelatesFillCommand,submitAitimaCommand;
        public static MySqlCommand checkForCompletionCommand;
        public String proodos;
        DataSet aitimataDs,pelatesDs;

        public aitimata()
        {
           
            InitializeComponent();
           
        }

        private void aitimata_Load(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                fillAitimata(dataGridView1);
            }
        }

        private void fillAitimata(DataGridView dg)
        {
            try
            {
                aitimataShowCommand = login.connection.CreateCommand();

                aitimataShowCommand.CommandText = "select * from aitimata";
                aitimataAdapter = new MySqlDataAdapter(aitimataShowCommand);
                aitimataDs = new DataSet();
                aitimataDs.AcceptChanges();
                aitimataAdapter.Fill(aitimataDs, "Aitimata");
                dg.DataSource = aitimataDs.Tables[0].DefaultView;
            }
            catch (MySqlException exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void aitimata_Leave(object sender, EventArgs e)
        {

        }

        private void aitimata_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void getPelates()
        {

            pelatesFillCommand = login.connection.CreateCommand();
            pelatesFillCommand.CommandText = "select * from pelates";

            pelatesFillAdapter = new MySqlDataAdapter(pelatesFillCommand);

            pelatesDs = new DataSet();
            pelatesFillAdapter.Fill(pelatesDs);

            int pelatesCount = pelatesDs.Tables[0].Rows.Count;

            for (int i = 0; i < pelatesCount; i++)
            {

                comboBox1.Items.Add(pelatesDs.Tables[0].Rows[i][1] + " " + pelatesDs.Tables[0].Rows[i][2]);
            }
            comboBox1.SelectedIndex = 0;

                selectedPelatisID = pelatesDs.Tables[0].Rows[0][0].ToString();
       
        
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                fillAitimata(dataGridView1);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                getPelates();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                fillAitimata(dataGridView4);
            }
            else
            {

                fillAitimata(dataGridView5);
                if (first == 0) { 
                DataGridViewCheckBoxColumn diagrafiBox = new DataGridViewCheckBoxColumn();
                diagrafiBox.HeaderText = "Diagrafi";
                diagrafiBox.FalseValue = "0";
                diagrafiBox.TrueValue = "1";
                dataGridView5.Columns.Insert(0, diagrafiBox);
                first = 1;
            }
            }
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            
            
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPelatisID = pelatesDs.Tables[0].Rows[comboBox1.SelectedIndex][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                submitAitimaCommand = login.connection.CreateCommand();
                submitAitimaCommand.CommandText = "INSERT INTO aitimata(ait_id, p_id, Titlos, Proodos, Sxolia, Hmerominia_Ypovolis, Hmerominia_Ekplirosis) VALUES (NULL,@pid,@titlos,1,@sxolia,@hmerominia,NULL)";
                submitAitimaCommand.Parameters.AddWithValue("@pid", selectedPelatisID);
                submitAitimaCommand.Parameters.AddWithValue("@titlos", System.Text.Encoding.UTF8.GetBytes(textBox1.Text.ToString()));
                submitAitimaCommand.Parameters.AddWithValue("@sxolia", System.Text.Encoding.UTF8.GetBytes(textBox4.Text.ToString()));
                submitAitimaCommand.Parameters.AddWithValue("@hmerominia", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
                

                submitAitimaCommand.ExecuteNonQuery();
                clearAitimataForm();

                
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show(sqlEx.ToString());
            }
        }

        private void clearAitimataForm()
        {
            textBox1.Text = "";
            textBox4.Text = "";
            dateTimePicker1.ResetText();
            comboBox1.Items.Clear();
            getPelates();

        }

        private void dataGridView4_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
           


   
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dataGridView5.Rows[e.RowIndex].Cells[0].Value) == false)
                {
                    dataGridView5.Rows[e.RowIndex].Cells[0].Value = 1;
                    dataGridView5.RefreshEdit();
                }
                else
                {
                    dataGridView5.Rows[e.RowIndex].Cells[0].Value = 0;
                    dataGridView5.RefreshEdit();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        public void searchFunction(DataGridView dg1, TextBox txt)
        {
           
            try
            {
                dg1.ClearSelection();
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

        

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            searchFunction(dataGridView1, textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            searchFunction(dataGridView4, textBox3);
        }

     

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView5.RefreshEdit();
            dataGridView5.Refresh();
            dataGridView5.ClearSelection();
            int deleteCount = 0;
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    deleteCount++;
                }
            }

            DialogResult dialogResult = MessageBox.Show("Πρόκειται να διαγραφούν " + deleteCount.ToString() + " εγγραφές.Είστε σίγουροι ότι θέλετε να συνεχίσετε;", "Διαγραφή εγγραφών", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dataGridView5.Rows[i].Cells[0].Value))
                    {
                        MySqlCommand delete = login.connection.CreateCommand();
                        delete.CommandText = "DELETE FROM aitimata WHERE ait_id=@id";
                        delete.Parameters.AddWithValue("@id", dataGridView5.Rows[i].Cells[1].Value.ToString());
                        delete.ExecuteNonQuery();
                        
                    }
                }
                fillAitimata(dataGridView5);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            dataGridView5.RefreshEdit();
            dataGridView5.Refresh();
            dataGridView5.ClearSelection();
        }

        public static void checkForCompletion()
        {
            checkForCompletionCommand = login.connection.CreateCommand();
            checkForCompletionCommand.CommandText = "UPDATE aitimata set  Hmerominia_Ekplirosis =CURDATE()  where Proodos=3";
            checkForCompletionCommand.ExecuteNonQuery();
            Thread.Sleep(10000);

            
        }

        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* aitimataDs.GetChanges();
             MySqlCommandBuilder updateCommand = new MySqlCommandBuilder(aitimataAdapter);
             aitimataAdapter.Update(aitimataDs, "Aitimata");
             dataGridView4.Refresh();
             */

           
        }

        private void dataGridView4_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {

                    if (dataGridView4.Rows[i].Cells[3].Value.ToString() != "")
                    {
                        if (Convert.ToInt16(dataGridView4.Rows[i].Cells[3].Value.ToString()) >= 0 && Convert.ToInt16(dataGridView4.Rows[i].Cells[3].Value.ToString()) <= 3)
                        {
                            if (Convert.ToInt16(dataGridView4.Rows[i].Cells[7].Value.ToString()) >= 0 && Convert.ToInt16(dataGridView4.Rows[i].Cells[7].Value.ToString()) <= 1)
                            {
                                if (Convert.ToInt16(dataGridView4.Rows[i].Cells[8].Value.ToString()) >= 0 && Convert.ToInt16(dataGridView4.Rows[i].Cells[8].Value.ToString()) <= 1)
                                {
                                    MySqlCommand update = login.connection.CreateCommand();
                                    update.CommandText = "update aitimata set Titlos=@titlos,Sxolia=@sxolia,proodos=@proodos,eidopoihsh=@eidopoihsh,apotelesma=@apotelesma where ait_id=@id";
                                    update.Parameters.AddWithValue("@proodos", dataGridView4.Rows[i].Cells[3].Value.ToString());
                                    update.Parameters.AddWithValue("@sxolia", System.Text.Encoding.UTF8.GetBytes(dataGridView4.Rows[i].Cells[4].Value.ToString()));
                                    update.Parameters.AddWithValue("@titlos", System.Text.Encoding.UTF8.GetBytes(dataGridView4.Rows[i].Cells[2].Value.ToString()));
                                    update.Parameters.AddWithValue("@id", dataGridView4.Rows[i].Cells[0].Value.ToString());
                                    update.Parameters.AddWithValue("@eidopoihsh", dataGridView4.Rows[i].Cells[7].Value.ToString());
                                    update.Parameters.AddWithValue("@apotelesma", dataGridView4.Rows[i].Cells[8].Value.ToString());
                                    update.ExecuteNonQuery();
                                   
                                }
                                else
                                {
                                    MessageBox.Show("Παρακαλώ δώστε τιμές από 0 εως 1 για ολοκλήρωση.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Error);


                                }
                            }
                            else
                            {
                                MessageBox.Show("Παρακαλώ δώστε τιμές από 0 1 για ειδοποίηση.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            }
                        }
                        else
                        {
                            MessageBox.Show("Παρακαλώ δώστε τιμές από 0 εως 3 για πρόοδο και 0 εως 1 για ολοκλήρωση και ειδοποίηση.", "Προσοχή", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }



                    }
                }
            }
            catch (Exception exp)
            {
                Console.Write(e.ToString());
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }

        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            proodos = dataGridView4.CurrentCell.Value.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;

                MySqlCommand selectPelatis = login.connection.CreateCommand();
                selectPelatis.CommandText = "select Onoma,Epitheto from pelates WHERE p_id=@id";
                selectPelatis.Parameters.AddWithValue("@id", dataGridView1.Rows[index].Cells[1].Value.ToString());

                MySqlDataAdapter pelatisAdapter = new MySqlDataAdapter(selectPelatis);

                DataSet pelatisDs = new DataSet();
                pelatisAdapter.Fill(pelatisDs);
                MessageBox.Show(pelatisDs.Tables[0].Rows[0][0].ToString() + " " + pelatisDs.Tables[0].Rows[0][1].ToString());
            }
            catch (Exception exc)
            {
                //  MessageBox.Show(exc.ToString());
            }
            
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView4.SelectedRows[0].Index;

                MySqlCommand selectPelatis = login.connection.CreateCommand();
                selectPelatis.CommandText = "select Onoma,Epitheto from pelates WHERE p_id=@id";
                selectPelatis.Parameters.AddWithValue("@id", dataGridView4.Rows[index].Cells[1].Value.ToString());

                MySqlDataAdapter pelatisAdapter = new MySqlDataAdapter(selectPelatis);

                DataSet pelatisDs = new DataSet();
                pelatisAdapter.Fill(pelatisDs);
                MessageBox.Show(pelatisDs.Tables[0].Rows[0][0].ToString() + " " + pelatisDs.Tables[0].Rows[0][1].ToString());
            }
            catch (Exception exc)
            {
                //  MessageBox.Show(exc.ToString());
            }
            
        }

        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView5.SelectedRows[0].Index;

                MySqlCommand selectPelatis = login.connection.CreateCommand();
                selectPelatis.CommandText = "select Onoma,Epitheto from pelates WHERE p_id=@id";
                selectPelatis.Parameters.AddWithValue("@id", dataGridView5.Rows[index].Cells[2].Value.ToString());

                MySqlDataAdapter pelatisAdapter = new MySqlDataAdapter(selectPelatis);

                DataSet pelatisDs = new DataSet();
                pelatisAdapter.Fill(pelatisDs);
                MessageBox.Show(pelatisDs.Tables[0].Rows[0][0].ToString() + " " + pelatisDs.Tables[0].Rows[0][1].ToString());
            }
            catch (Exception exc)
            {
                //  MessageBox.Show(exc.ToString());
            }
            
        }

    }
}
