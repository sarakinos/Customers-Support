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
     
    public partial class rantevou : Form
    {
        private int first = 0;
        public MySqlCommand pelatesFillCommand, aitimataFillCommand;
        public MySqlDataAdapter pelatesAdapter,aitimataAdapter;
        public DataSet pelatesDs,aitimataDs;
        public String selectedPelatisId,selectedAitimaId;
        public rantevou()
        {
            InitializeComponent();
            fillRantevou(dataGridView1);

            comboBox3.Items.Add("Χαμηλή");
            comboBox3.Items.Add("Μεσαία");
            comboBox3.Items.Add("Υψηλή");

            comboBox3.SelectedIndex = 0;
        }

        public void searchFunction(DataGridView dg1, TextBox txt)
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
        public void fillRantevou(DataGridView dg){
            MySqlCommand fillCommand = login.connection.CreateCommand();
            fillCommand.CommandText = "select * from rantevou";           
            DataSet rantevouDs = new DataSet();
            MySqlDataAdapter rantevouAdapter = new MySqlDataAdapter(fillCommand);
            rantevouAdapter.Fill(rantevouDs);
            dg.DataSource = rantevouDs.Tables[0].DefaultView;
        }

        private void fillPelates()
        {

             pelatesFillCommand = login.connection.CreateCommand();
            pelatesFillCommand.CommandText = "select * from pelates";


             pelatesAdapter = new MySqlDataAdapter(pelatesFillCommand);

             pelatesDs = new DataSet();
            pelatesAdapter.Fill(pelatesDs);

            int pelatesCount = pelatesDs.Tables[0].Rows.Count;

            for (int i = 0; i < pelatesCount; i++)
            {

                comboBox1.Items.Add(pelatesDs.Tables[0].Rows[i][1] + " " + pelatesDs.Tables[0].Rows[i][2]);
            }
            if (comboBox1.Items.Count != 0)
            {
                comboBox1.SelectedIndex = 0;
                selectedPelatisId = pelatesDs.Tables[0].Rows[0][0].ToString();
            }

        }

        public void fillAitimata()
        {
            aitimataFillCommand = login.connection.CreateCommand();
            aitimataFillCommand.CommandText = "select * from aitimata";


            aitimataAdapter = new MySqlDataAdapter(aitimataFillCommand);

            aitimataDs = new DataSet();
            aitimataAdapter.Fill(aitimataDs);

            int aitimataCount = aitimataDs.Tables[0].Rows.Count;

            for (int i = 0; i < aitimataCount; i++)
            {

                comboBox2.Items.Add(aitimataDs.Tables[0].Rows[i][2]);
            }
            if (comboBox2.Items.Count != 0)
            {
                comboBox2.SelectedIndex = 0;
                selectedAitimaId = aitimataDs.Tables[0].Rows[0][0].ToString();
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                fillRantevou(dataGridView1);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                fillPelates();
                fillAitimata();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                fillRantevou(dataGridView2);
            }
            else
            {
                fillRantevou(dataGridView3);
                if (first == 0)
                {


                    DataGridViewCheckBoxColumn diagrafiBox = new DataGridViewCheckBoxColumn();
                    diagrafiBox.HeaderText = "Diagrafi";
                    diagrafiBox.FalseValue = "0";
                    diagrafiBox.TrueValue = "1";
                    dataGridView3.Columns.Insert(0, diagrafiBox);
                    first = 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                MySqlCommand addRantevou = login.connection.CreateCommand();
                MySqlCommand setNames = login.connection.CreateCommand();
                setNames.CommandText = "SET NAMES 'utf8'";
                setNames.ExecuteNonQuery();

                addRantevou.CommandText = "INSERT INTO rantevou(rant_id, p_id, ait_id, Thema, Hmerominia, Krisimotita, Sxolia) VALUES (NULL, @pId, @aitId, @thema, @hmerominia, @krisimotita, @sxolia)";
                addRantevou.Parameters.AddWithValue("@pId",selectedPelatisId);
                addRantevou.Parameters.AddWithValue("@aitId", selectedAitimaId);
                addRantevou.Parameters.AddWithValue("@thema", System.Text.Encoding.UTF8.GetBytes(textBox1.Text));
                addRantevou.Parameters.AddWithValue("@hmerominia", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
                addRantevou.Parameters.AddWithValue("@krisimotita", comboBox3.SelectedIndex+1);
                addRantevou.Parameters.AddWithValue("@sxolia", System.Text.Encoding.UTF8.GetBytes(richTextBox1.Text));

                addRantevou.ExecuteNonQuery();
                resetFields();
            }
        }
        private void resetFields()
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            richTextBox1.Text = "";
            textBox1.Text = "";
            dateTimePicker1.ResetText();
            

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            searchFunction(dataGridView2,textBox2);
        }

        private void dataGridView2_CellValidated_1(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value.ToString() != "")
                {

                    MySqlCommand update = login.connection.CreateCommand();
                    update.CommandText = "UPDATE rantevou SET p_id=@pId,ait_id=@aitId,Thema=@thema,Hmerominia=@hm,Krisimotita=@krisimotita,Sxolia=@sxolia WHERE rant_id=@rantId";

                    update.Parameters.AddWithValue("@pId", dataGridView2.Rows[i].Cells[1].Value.ToString());
                    update.Parameters.AddWithValue("@rantId", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[0].Value.ToString()));
                    update.Parameters.AddWithValue("@aitId", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[2].Value.ToString()));
                    update.Parameters.AddWithValue("@thema", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[3].Value.ToString()));
                    update.Parameters.AddWithValue("@krisimotita", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[5].Value.ToString()));
                    update.Parameters.AddWithValue("@hm", Convert.ToDateTime(dataGridView2.Rows[i].Cells[4].Value.ToString()));
                    update.Parameters.AddWithValue("@sxolia", System.Text.Encoding.UTF8.GetBytes(dataGridView2.Rows[i].Cells[6].Value.ToString()));
                    
                    update.ExecuteNonQuery();
                    
                    dataGridView1.Refresh();

                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            searchFunction(dataGridView3, textBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int deleteCount = 0;
            List<Int32> deleteValues= new List<Int32>();
            try {
               
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                if (dataGridView3.Rows[i].Cells[0].Value=="1")
                {
                    deleteCount++;
                    deleteValues.Add(Convert.ToInt32( dataGridView3.Rows[i].Cells[1].Value.ToString()));
                }
            }
                }
        catch(Exception exp){
        
        }
                

            DialogResult dialogResult = MessageBox.Show("Πρόκειται να διαγραφούν " + deleteCount.ToString() + " εγγραφές.Είστε σίγουροι ότι θέλετε να συνεχίσετε;", "Διαγραφή εγγραφών", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView3.RefreshEdit();
                

                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    if (dataGridView3.Rows[i].Cells[0].Value=="1" )
                    {
                        MySqlCommand delete = login.connection.CreateCommand();
                        delete.CommandText = "DELETE FROM rantevou WHERE rant_id=@id";
                        delete.Parameters.AddWithValue("@id", dataGridView3.Rows[i].Cells[1].Value.ToString());
                        delete.ExecuteNonQuery();
                       // dataGridView3.Rows.RemoveAt(dataGridView3.Rows[i].Index);
                      
                    }
                   
                }

                fillRantevou(dataGridView3);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
            
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

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView2.SelectedRows[0].Index;

                MySqlCommand selectPelatis = login.connection.CreateCommand();
                selectPelatis.CommandText = "select Onoma,Epitheto from pelates WHERE p_id=@id";
                selectPelatis.Parameters.AddWithValue("@id", dataGridView2.Rows[index].Cells[1].Value.ToString());

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

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView3.SelectedRows[0].Index;

                MySqlCommand selectPelatis = login.connection.CreateCommand();
                selectPelatis.CommandText = "select Onoma,Epitheto from pelates WHERE p_id=@id";
                selectPelatis.Parameters.AddWithValue("@id", dataGridView3.Rows[index].Cells[2].Value.ToString());

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            searchFunction(dataGridView1, textBox4);
        }
    }

     

}
