using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
using System.Data.SqlClient;
using Npgsql;
using System.Diagnostics;
using System.ComponentModel;
namespace QBaseClient
{
    public partial class Form1 : Form
    {
        const string algorithmsPath = "algorithms/";
        const string determinantsPath = "determinants/";
        const string ticksAction = "/ticks/";
        const string processorsAction = "/processors/";
        const string dimensionsAction = "/dimensions/";
        const string commonCompareAction = "algorithms{0}comparecommon";
        const string incrementCompareAction = "algorithms{0}compareincrement";

        const string ticksResString = "При прочих равных условиях алгоритм {0} выполнится быстрее, чем алгоритм {1}.";
        const string ticksResEqString = "При прочиз равных условиях алгоритмы {0} и {1} выполнятся за одинаковое время.";
        const string processorsResString = "Алгоритм {0} потребует большего количества процессоров, чем алгоритм {1}.";
        const string processorsResEqString = "Алгоритмы {0} и {1} потребуют одинакового количества процессоров.";

        //Dictionary<int, Algorithm> alg;

        //SqlDataAdapter adapter_al;
        DataTable dt_al = new DataTable();
        //Строка подключения к бд
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "QbaseKvp";
        private static string Password = "123";
        private static string Port = "5432";

        string connectionString = String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
        //string connectionString = @"Data Source=DESKTOP-TDL137K\KVP;Initial Catalog=QbaseKvp;Persist Security Info=True;User ID=sa;Password=123";
        //string sql_al = "SELECT * FROM Algorithms";
        DataTable dt1 = new DataTable();
        DataTable dt = new DataTable();
        //SqlDataAdapter adapter6;
        DataTable dt6 = new DataTable();
        //SqlDataAdapter adapter1;
        //SqlDataAdapter adapter;
        //SqlDataAdapter adapter3;
        //SqlDataAdapter adapter4;
        
        //SqlDataAdapter adapter7;
        //SqlDataAdapter adapter8;
        //SqlDataAdapter adapter9;
        // string sql1 = "SELECT * FROM Complexity_characteristic";
        // string sql1 = "SELECT Complexity_characteristic.id,ID_Algorithm, name, ticks, processors,dimensions, iteration FROM Complexity_characteristic, Algorithms where Algorithms.id = Complexity_characteristic.ID_Algorithm";

        string sql1 = "SELECT \"Complexity_characteristic\".\"id\", \"ID_Algorithm\",\"Algorithms\".\"name\", ticks, processors, dimensions, iteration FROM public.\"Complexity_characteristic\", public.\"Algorithms\" where \"Algorithms\".\"id\" = \"Complexity_characteristic\".\"ID_Algorithm\" ORDER BY \"Complexity_characteristic\".\"id\"";

        //string sqlcomboBoxAlg1 = "SELECT * FROM Algorithms";
        string sqlcomboBoxAlg1 = "SELECT * FROM public.\"Algorithms\"";

        //string sql = "SELECT * FROM Determinant ";
        string sql = "SELECT * FROM public.\"Determinant\"";

        //string sql6 = "SELECT * FROM Algorithms";
        string sql6 = "SELECT * FROM public.\"Algorithms\" ORDER BY id";

        //string sqlcomboBox1 = "SELECT * FROM Algorithms";
        string sqlcomboBox1 = "SELECT * FROM public.\"Algorithms\" ORDER BY id";
        //string sqlcomboBox2 = "SELECT * FROM Algorithms";
        string sqlcomboBox2 = "SELECT * FROM public.\"Algorithms\" ORDER BY id";
        //string sqlcomboBox1 = "SELECT * FROM Algorithms";
        string sqlcomboBox3 = "SELECT * FROM public.\"Algorithms\" ORDER BY id";
        public Form1()
        {
            InitializeComponent();
            ViewGrid();
            ViewGrid2();
            ViewGrid3();
            ViewcomboBox1();
            ViewcomboBox2();
            ViewcomboBox3();
            ViewcomboBoxAlg1();
            ViewcomboBoxAlg2();
            ViewcomboBoxAlg3();
        }

        //отображение ViewcomboBoxAlg1
        void ViewcomboBoxAlg1()
        {
            //sqlServer
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    adapter7 = new SqlDataAdapter(sqlcomboBoxAlg1, connection);
            //    DataTable dt7 = new DataTable();
            //    adapter7.Fill(dt7);
            //    comboBox1.DataSource = dt7;
            //    comboBox1.DisplayMember = "name";
            //    comboBox1.ValueMember = "id";
            //}
            //postgresql
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter7 = new NpgsqlDataAdapter(sqlcomboBoxAlg1, connection);
                DataTable dt7 = new DataTable();
                adapter7.Fill(dt7);
                comboBox1.DataSource = dt7;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "id";
            }

        }
        //отображение ViewcomboBoxAlg2
        void ViewcomboBoxAlg2()
        {
            //sqlServer
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    adapter8 = new SqlDataAdapter(sqlcomboBoxAlg1, connection);
            //    DataTable dt8 = new DataTable();
            //    adapter8.Fill(dt8);
            //    comboBox4.DataSource = dt8;
            //    comboBox4.DisplayMember = "name";
            //    comboBox4.ValueMember = "id";
            //}
            //postgresql
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter8 = new NpgsqlDataAdapter(sqlcomboBoxAlg1, connection);
                DataTable dt8 = new DataTable();
                adapter8.Fill(dt8);
                comboBox4.DataSource = dt8;
                comboBox4.DisplayMember = "name";
                comboBox4.ValueMember = "id";
            }

        }
        //отображение ViewcomboBoxAlg3
        void ViewcomboBoxAlg3()
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    adapter9 = new SqlDataAdapter(sqlcomboBoxAlg1, connection);
            //    DataTable dt9 = new DataTable();
            //    adapter9.Fill(dt9);
            //    comboBox5.DataSource = dt9;
            //    comboBox5.DisplayMember = "name";
            //    comboBox5.ValueMember = "id";
            //}

            //postgresql
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter9 = new NpgsqlDataAdapter(sqlcomboBoxAlg1, connection);
                DataTable dt9 = new DataTable();
                adapter9.Fill(dt9);
                comboBox5.DataSource = dt9;
                comboBox5.DisplayMember = "name";
                comboBox5.ValueMember = "id";
            }

        }
        //вывод данных в dataGridView из таблицы алгоритмы
        void ViewGrid()
        {
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.AllowUserToAddRows = false;
            //postgresql
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter6 = new NpgsqlDataAdapter(sql6, connection);
                DataTable dt6 = new DataTable();
                adapter6.Fill(dt6);
                dataGridView3.DataSource = dt6;
                dataGridView3.Columns[0].HeaderText = "Id";
                dataGridView3.Columns[1].HeaderText = "Название";
                dataGridView3.Columns[2].HeaderText = "Описание";
                //----
                dataGridView3.Columns[0].Width = 20;
                dataGridView3.Columns[1].Width = 250;
                dataGridView3.Columns[2].Width = 350;
            }
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    adapter6 = new SqlDataAdapter(sql6, connection);
            //    DataTable dt6 = new DataTable();
            //    adapter6.Fill(dt6);
            //    dataGridView3.DataSource = dt6;
            //    dataGridView3.Columns[0].HeaderText = "Id";
            //    dataGridView3.Columns[1].HeaderText = "Название";
            //    dataGridView3.Columns[2].HeaderText = "Описание";
            //    //----
            //    dataGridView3.Columns[0].Width = 20;
            //    dataGridView3.Columns[1].Width = 250;
            //    dataGridView3.Columns[2].Width = 350;
            //}

        }
        #region k
        private void algPostButton_Click(object sender, EventArgs e)
        {
          
        }

        private void algUpdateButton_Click(object sender, EventArgs e)
        {
            
        }

        private void algDeleteButton_Click(object sender, EventArgs e)
        {
           
        }

     

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }


        private void button4_Click(object sender, EventArgs e)
        {
        }

        #endregion 

        #region comparison
        // для сравнения 
        private void compareButton_Click(object sender, EventArgs e)
        {
            
            int id1, id2;
         
            try
            {
                string value = comboBox4.Text;
                string value2 = comboBox5.Text;
                // MessageBox.Show(value);
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand id_select = new NpgsqlCommand("select id from public.\"Algorithms\" WHERE name='" + value + "'", connection);
                    id1 = Convert.ToInt32(id_select.ExecuteScalar());
                    NpgsqlCommand id_select2 = new NpgsqlCommand("select id from public.\"Algorithms\" WHERE name='" + value2 + "'", connection);
                    id2 = Convert.ToInt32(id_select2.ExecuteScalar());
                    //MessageBox.Show(id.ToString());
                }

                //int currentMyComboBoxIndex1 = comboBox4.SelectedIndex;
                //int currentMyComboBoxIndex2 = comboBox5.SelectedIndex;

                //id1 = currentMyComboBoxIndex1 + 1;
                //id2 = currentMyComboBoxIndex2 + 1;
                //id1 = int.Parse(compareAlg1ID.Text);
                //id2 = int.Parse(compareAlg2ID.Text);
            }
            catch
            {
                MessageBox.Show("IDs must be numbers.");
                return;
            }
            CommonCompare(id1, id2);
        }

        void CommonCompare(int id1, int id2)
        {
            var dict = new Dictionary<string, int>();
            dict.Add("id1", id1);
            dict.Add("id2", id2);

            var ser = new JavaScriptSerializer();
            string args = ser.Serialize(dict);
            string resticks = HttpManager.Post(string.Format(commonCompareAction, ticksAction), args);
            string resprocessors = HttpManager.Post(string.Format(commonCompareAction, processorsAction), args);
            int ticks, processors;
            try
            {
                ticks = int.Parse(resticks);
            }
            catch
            {
                MessageBox.Show(resticks);
                return;
            }
            try
            {
                processors = int.Parse(resprocessors);
            }
            catch
            {
                MessageBox.Show(resprocessors);
                return;
            }
            compareTicksResult.Text = ticks.ToString();
            compareProcessorsResult.Text = processors.ToString();

            string tRes = "", pRes = "";
            string z1 = "№1 ";
            string z2 = "№2 ";
            if (ticks > 0)
                tRes = string.Format(ticksResString, z2, z1);
            if (ticks == 0)
                tRes = string.Format(ticksResEqString, z1, z2);
            if (ticks < 0)
                tRes = string.Format(ticksResString, z1, z2);
            if (processors > 0)
                pRes = string.Format(processorsResString, z1, z2);
            if (processors == 0)
                pRes = string.Format(processorsResEqString, z1, z2);
            if (processors < 0)
                pRes = string.Format(processorsResString, z2, z1);
            //if (ticks > 0)
            //    tRes = string.Format(ticksResString, id2, id1);
            //if (ticks == 0)
            //    tRes = string.Format(ticksResEqString, id1, id2);
            //if (ticks < 0)
            //    tRes = string.Format(ticksResString, id1, id2);
            //if (processors > 0)
            //    pRes = string.Format(processorsResString, id1, id2);
            //if (processors == 0)
            //    pRes = string.Format(processorsResEqString, id1, id2);
            //if (processors < 0)
            //    pRes = string.Format(processorsResString, id2, id1);
            ticksResult.Text = tRes;
            processorsResult.Text = pRes;
        }

        void IncrementCompare(int id1, int id2)
        {

        }

        #endregion
        //кнопка добавления алгоритма
        private void button5_Click(object sender, EventArgs e)
        {
            AddAlgorithms();
            MessageBox.Show("Данные  сохранены успешно..!");
            ViewcomboBox1();
            ViewcomboBox2();
            ViewcomboBox3();
            ViewGrid();
            ViewcomboBoxAlg1();
        }
        //кнопка обновления алгоритма
        private void button3_Click(object sender, EventArgs e)
        {
            Update_Algorithms();

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox16.Clear();
            textBox17.Clear();
            ViewcomboBoxAlg1();
            ViewGrid();
        }
// кнопка удаления алгоритма
        private void button6_Click(object sender, EventArgs e)
        {
            DeleteAlgorithms();
            ViewcomboBoxAlg1();
            ViewGrid();
            textBox16.Clear();
            textBox17.Clear();

        }
        // метод удаления алгоритма
        void DeleteAlgorithms()
        {

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand cmd = new SqlCommand(@"Delete From [Algorithms] WHERE [id] = '" + textBox1.Text + "'", connection);
            //    cmd.ExecuteNonQuery();
            //}
            //postgresql
            using (var connection = new NpgsqlConnection(connectionString))
            {             
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("Delete From public.\"Algorithms\" WHERE id = '" + textBox1.Text + "'", connection);
                cmd.ExecuteNonQuery();
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }
        //метод обновления алгоритма
        void Update_Algorithms()
        {
   //         using (SqlConnection connection = new SqlConnection(connectionString))
   //         {
   //             connection.Open();
   //             SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Algorithms]
   //SET [name] = '" + textBox16.Text + "',[description] = '" + textBox17.Text + "' WHERE [id] = '" + textBox4.Text + "'", connection);
   //             cmd.ExecuteNonQuery();
   //         }
            
            //postgresql
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Algorithms\" SET name = '" + textBox16.Text + "',description = '" + textBox17.Text + "' WHERE id = '" + textBox4.Text + "'", connection);
                cmd.ExecuteNonQuery();
            }
        }
        //метод добавления алгоритма
        void AddAlgorithms()
        {
           
            if (dataGridView3.Rows.Count != 0)
            {
                //MessageBox.Show("1");
                //           using (SqlConnection connection = new SqlConnection(connectionString))
                //           {
                //               connection.Open();
                //               SqlCommand maxid1 = new SqlCommand(@"select max([id]) from [dbo].[Algorithms]", connection);                  
                //               int rows_dt2 = Convert.ToInt32(maxid1.ExecuteScalar());
                //               int rows_dt2_new = rows_dt2 + 1;
                //               SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Algorithms]
                //      ([id]
                //      ,[name]
                //      ,[description])
                //VALUES
                //      ('" + rows_dt2_new + "','" + textBox2.Text + "','" + textBox3.Text + "')", connection);
                //               cmd.ExecuteNonQuery();
                //           }
                //postgresql
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand maxid1 = new NpgsqlCommand("SELECT max(id) FROM public.\"Algorithms\"", connection);
                    int rows_dt2 = Convert.ToInt32(maxid1.ExecuteScalar());
                    int rows_dt2_new = rows_dt2 + 1;
                    NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Algorithms\" (id,name,description) VALUES ('" + rows_dt2_new + "','" + textBox2.Text + "','" + textBox3.Text + "')", connection);
                    cmd.ExecuteNonQuery();
                }
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                //MessageBox.Show("2");
                //     using (SqlConnection connection = new SqlConnection(connectionString))
                //     {
                //         connection.Open();

                //         int rows_dt2 = dataGridView3.Rows.Count;
                //         int rows_dt2_new = rows_dt2 + 1;
                //             SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Algorithms] ([id],[name],[description]) VALUES
                //('" + rows_dt2_new + "','" + textBox2.Text + "','" + textBox3.Text + "')", connection);
                //             cmd.ExecuteNonQuery();                   
                //     }
                //postgresql
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    int rows_dt2 = dataGridView3.Rows.Count;
                    int rows_dt2_new = rows_dt2 + 1;
                    NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Algorithms\" (id,name,description) VALUES ('" + rows_dt2_new + "','" + textBox2.Text + "','" + textBox3.Text + "')", connection);
                    cmd.ExecuteNonQuery();                 
                }
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }

        }

        //вывод данных в dataGridView из таблицы Complexity_characteristic
        void ViewGrid2()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            //using (SqlConnection connection1 = new SqlConnection(connectionString))
            //{

            //    connection1.Open();
            //    adapter1 = new SqlDataAdapter(sql1, connection1);
            //    DataTable dt1 = new DataTable();
            //    adapter1.Fill(dt1);
            //    dataGridView1.DataSource = dt1;
            //    dataGridView1.Columns[0].HeaderText = "Идентификатор характеристики";
            //    dataGridView1.Columns[1].HeaderText = "Идентификатор алгоритма";
            //    dataGridView1.Columns[2].HeaderText = "Название алгоритма";               
            //    dataGridView1.Columns[3].HeaderText = "Высота";
            //    dataGridView1.Columns[4].HeaderText = "Ширина";
            //    dataGridView1.Columns[5].HeaderText = "Размерность";
            //    dataGridView1.Columns[6].HeaderText = "Количетсво итераций";
            //    //----
            //    dataGridView1.Columns[0].Width = 90;
            //    dataGridView1.Columns[1].Width = 90;
            //    dataGridView1.Columns[2].Width = 130;
            //    dataGridView1.Columns[3].Width = 80;
            //    dataGridView1.Columns[4].Width = 80;
            //    dataGridView1.Columns[5].Width = 80;
            //    dataGridView1.Columns[6].Width = 80;
            //}
            //postgresql
            using (NpgsqlConnection connection1 = new NpgsqlConnection(connectionString))
            {

                connection1.Open();
                NpgsqlDataAdapter adapter1 = new NpgsqlDataAdapter(sql1, connection1);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns[0].HeaderText = "Идентификатор характеристики";
                dataGridView1.Columns[1].HeaderText = "Идентификатор алгоритма";
                dataGridView1.Columns[2].HeaderText = "Название алгоритма";
                dataGridView1.Columns[3].HeaderText = "Высота";
                dataGridView1.Columns[4].HeaderText = "Ширина";
                dataGridView1.Columns[5].HeaderText = "Размерность";
                dataGridView1.Columns[6].HeaderText = "Количетсво итераций";
                //----
                dataGridView1.Columns[0].Width = 90;
                dataGridView1.Columns[1].Width = 90;
                dataGridView1.Columns[2].Width = 130;
                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 80;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].Width = 80;
            }
        }
        //вывод данных в dataGridView из таблицы determinant
        void ViewGrid3()
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AllowUserToAddRows = false;

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    adapter = new SqlDataAdapter(sql, connection);
            //    DataTable dt = new DataTable();
            //    adapter.Fill(dt);
            //    dataGridView2.DataSource = dt;
            //    dataGridView2.Columns[0].HeaderText = "Идентификатор предстаавления";
            //    dataGridView2.Columns[1].HeaderText = "Идентификатор характеристик";
            //    dataGridView2.Columns[2].HeaderText = "Выходные данные";
            //    dataGridView2.Columns[3].HeaderText = "Логический Q-терм";
            //    dataGridView2.Columns[4].HeaderText = "Безусловный Q-терм";
            //    //---
            //    dataGridView2.Columns[0].Width = 90;
            //    dataGridView2.Columns[1].Width = 90;
            //    dataGridView2.Columns[2].Width = 70;
            //    dataGridView2.Columns[3].Width = 140;
            //    dataGridView2.Columns[4].Width = 140;
            //}
            //postgresql
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
                dataGridView2.Columns[0].HeaderText = "Идентификатор предстаавления";
                dataGridView2.Columns[1].HeaderText = "Идентификатор характеристик";
                dataGridView2.Columns[2].HeaderText = "Выходные данные";
                dataGridView2.Columns[3].HeaderText = "Логический Q-терм";
                dataGridView2.Columns[4].HeaderText = "Безусловный Q-терм";
                //---
                dataGridView2.Columns[0].Width = 90;
                dataGridView2.Columns[1].Width = 90;
                dataGridView2.Columns[2].Width = 70;
                dataGridView2.Columns[3].Width = 140;
                dataGridView2.Columns[4].Width = 140;
            }
        }

        void ViewcomboBox1()
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    adapter3 = new SqlDataAdapter(sqlcomboBox1, connection);
            //    DataTable dt3 = new DataTable();
            //    adapter3.Fill(dt3);
            //    comboBox2.DataSource = dt3;
            //    comboBox2.DisplayMember = "id";
            //    comboBox2.ValueMember = "id";
            //}
            //postgresql

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter3 = new NpgsqlDataAdapter(sqlcomboBox1, connection);
                DataTable dt3 = new DataTable();
                adapter3.Fill(dt3);
                comboBox2.DataSource = dt3;
                comboBox2.DisplayMember = "id";
                comboBox2.ValueMember = "id";
            }
        }
        void ViewcomboBox2()
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    adapter4 = new SqlDataAdapter(sqlcomboBox2, connection);
            //    DataTable dt4 = new DataTable();
            //    adapter4.Fill(dt4);
            //    comboBox3.DataSource = dt4;
            //    comboBox3.DisplayMember = "name";
            //    comboBox3.ValueMember = "name";
            //}
            //postgresql
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter4 = new NpgsqlDataAdapter(sqlcomboBox2, connection);
                DataTable dt4 = new DataTable();
                adapter4.Fill(dt4);
                comboBox3.DataSource = dt4;
                comboBox3.DisplayMember = "name";
                comboBox3.ValueMember = "name";
            }
        }
        // кнопка загрузки представления алгоритма и добаления размерности и кол итераций
        private void button7_Click(object sender, EventArgs e)
        {
            Add_Complexity_characteristic_Determinant();
            textBox7.Clear();
            textBox8.Clear();
            ViewGrid2();
            ViewGrid3();
            comboBox2.SelectedIndex = -1;          
            determTextBox.Text = "";
            dimensionsTextBox.Text = "";
        }
        void ViewcomboBox3()
        {          
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter4 = new NpgsqlDataAdapter(sqlcomboBox3, connection);
                DataTable dt4 = new DataTable();
                adapter4.Fill(dt4);
                comboBox6.DataSource = dt4;
                comboBox6.DisplayMember = "name";
                comboBox6.ValueMember = "name";
            }
        }
        void Add_Complexity_characteristic_Determinant()
        {
            int id = 0;
            
            try
            {
                //Вар 1
                //int currentMyComboBoxIndex = comboBox1.SelectedIndex;
                //id = currentMyComboBoxIndex + 1;
                //Вар 2 норм
                string value = comboBox1.Text;
               // MessageBox.Show(value);
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand id_select = new NpgsqlCommand("select id from public.\"Algorithms\" WHERE name='" + value + "'", connection);
                    id = Convert.ToInt32(id_select.ExecuteScalar());
                    //MessageBox.Show(id.ToString());
                }
                //id = int.Parse(determAlgComboBox.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("Cannot parse algorithm's ID.");
                return;
            }
            object determinant = null;
            object dimensions = null;
            var ser = new JavaScriptSerializer();
           // determinant = ser.DeserializeObject(determTextBox.Text);

            textBox14.Text = "0";
            textBox15.Text = "0";

            if (dataGridView2.Rows.Count != 0)
            {
               //MessageBox.Show("1");
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand maxid1 = new NpgsqlCommand("select max(id) from public.\"Complexity_characteristic\"", connection);
                    int rows_dt2 = Convert.ToInt32(maxid1.ExecuteScalar());
                    int rows_dt2_new = rows_dt2 + 1;

                    NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT INTO public.\"Complexity_characteristic\" (id, \"ID_Algorithm\", ticks, processors, dimensions, iteration) VALUES('" + rows_dt2_new + "','" + id + "','" + textBox14.Text + "','" + textBox15.Text + "','" + dimensionsTextBox.Text + "','" + textBox8.Text + "')", connection);
                    cmd1.ExecuteNonQuery();
                }
                // ДОБАЛЕНИЕ В ЮД ДАННЫХ
                OpenFileDialog o = new OpenFileDialog();
                o.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (o.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = File.ReadAllLines(o.FileName, Encoding.Default);
                    string[] output_data = new string[lines.Length];
                    string[] logical_Q_term = new string[lines.Length];
                    string[] unconditional_Q_term = new string[lines.Length];
                    string[] logical_Q_term_new = new string[lines.Length];
                    string[] unconditional_Q_term_new = new string[lines.Length];

                    for (int i = 0; i < lines.Length; i++)
                    {//---  
                        string substring = "=";
                        int ind = lines[i].IndexOf(substring);
                        string S3 = "@";
                        string z1 = lines[i].Remove(ind, substring.Length).Insert(ind, S3);
                        string[] ns = z1.Split(new Char[] { '@', ';' });                    
                        output_data[i] = ns[0];
                        logical_Q_term[i] = ns[1];                        
                        unconditional_Q_term[i] = ns[2];
                        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                        {
                            connection.Open();
                            NpgsqlCommand maxid1 = new NpgsqlCommand("select max(id) from public.\"Complexity_characteristic\"", connection);
                            int rows_dt2_new = Convert.ToInt32(maxid1.ExecuteScalar());

                            NpgsqlCommand maxid2 = new NpgsqlCommand("select max(id) from public.\"Determinant\"", connection);
                            int rows_dt1_new = Convert.ToInt32(maxid2.ExecuteScalar());

                            rows_dt1_new = rows_dt1_new + 1;
                            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Determinant\" (id, id_characteristic, output_data, \"logical_Qterm\", \"uncon_Qterm\") VALUES('" + rows_dt1_new + "','" + rows_dt2_new + "','" + output_data[i] + "','" + logical_Q_term[i] + "','" + unconditional_Q_term[i] + "')", connection);
                            cmd.ExecuteNonQuery();
                        }
                       
                        string strproveerka = logical_Q_term[i];
                        if (strproveerka == " ")
                        {
                            //MessageBox.Show("1 шт");
                            logical_Q_term_new[i] = " ";
                            //MessageBox.Show(logical_Q_term_new[i]);
                            unconditional_Q_term_new[i] = unconditional_Q_term[i];
                            //MessageBox.Show(unconditional_Q_term_new[i]);
                        }
                        else
                        {
                            logical_Q_term_new[i] = logical_Q_term[i];
                            //MessageBox.Show(logical_Q_term_new[i]);
                            unconditional_Q_term_new[i] = unconditional_Q_term[i];
                            //MessageBox.Show(unconditional_Q_term_new[i]);
                            //qdeterminantz[i] = logical_Q_term[i]+";"+unconditional_Q_term[i];
                        }
                    }

                    string strproveerka2 = logical_Q_term_new[0];
                    string f_sim = unconditional_Q_term_new[0][0].ToString();
                    if (f_sim =="{")
                    {
                    }
                    else
                    {
                        for (int i = 0; i < unconditional_Q_term_new.Length; i++)
                        {
                            unconditional_Q_term_new[i] = '"' + unconditional_Q_term_new[i] + '"';
                        }
                    }

                    if (strproveerka2 == " ")
                    {
                        // если logical_Q_term_new =" "
                        string[] qdeterminantz_itog = unconditional_Q_term_new;
                        string singleString = String.Join(",", qdeterminantz_itog);
                        string itog = "[" + singleString + "]";
                        string z1z = itog.Replace(";", ",");
                        string strojson = "{\"Determinant\":" + z1z + ",\"Dimensions\":" + dimensionsTextBox.Text + "}";
                        //--2
                        string writePath1 = @"C:\vkr_temp\json.json";
                        // сохранение в файл
                        using (StreamWriter sw = new StreamWriter(writePath1, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(strojson);
                            sw.Close();
                        }
                        string json1 = "[{\"op\":\" != \",\"fO\":\"A(1, 1)\",\"sO\":\"0\"}]";
                        determinant = ser.DeserializeObject(json1);
                        dimensions = ser.DeserializeObject(dimensionsTextBox.Text);
                        var obj = new QDeterminant(determinant, dimensions);
                        ser.Serialize(obj);
                        string res = HttpManager.Post(algorithmsPath + id.ToString(), ser.Serialize(obj));
                        try
                        {
                            int.Parse(res);
                        }
                        catch
                        {
                            MessageBox.Show(res);
                            return;
                        }
                    }
                    else
                    {
                        // если logical_Q_term_new !=" "
                        //MessageBox.Show("удаление дубликотов 2 ");
                        string[] logical_Q_term_new_res = logical_Q_term_new.Distinct().ToArray();
                        string[] qdeterminantz_itog = logical_Q_term_new_res.Union(unconditional_Q_term_new).ToArray();
                        string singleString = String.Join(",", qdeterminantz_itog);
                        string itog = "[" + singleString + "]";
                        //MessageBox.Show(itog);
                        string z1z = itog.Replace(";", ",");
                        string strojson = "{\"Determinant\":" + z1z + ",\"Dimensions\":" + dimensionsTextBox.Text + "}";
                        //--2
                        string writePath1 = @"C:\vkr_temp\json.json";
                        // сохранение в файл
                        using (StreamWriter sw = new StreamWriter(writePath1, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(strojson);
                            sw.Close();
                        }
                        string json1 = "[{\"op\":\" != \",\"fO\":\"A(1, 1)\",\"sO\":\"0\"}]";
                        determinant = ser.DeserializeObject(json1);
                        dimensions = ser.DeserializeObject(dimensionsTextBox.Text);
                        var obj = new QDeterminant(determinant, dimensions);
                        ser.Serialize(obj);
                        string res = HttpManager.Post(algorithmsPath + id.ToString(), ser.Serialize(obj));
                        try
                        {
                            int.Parse(res);
                        }
                        catch
                        {
                            MessageBox.Show(res);
                            return;
                        }
                    }                   
                    MessageBox.Show("Данные  добавлены и сохранены успешно..!");
                }
                determTextBox.Text = "";
                dimensionsTextBox.Text = "";
            }
            else
            {
               // MessageBox.Show("2");
                int rows_dt2 = dataGridView2.Rows.Count;
                int rows_dt2_new = rows_dt2 + 1;
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT INTO public.\"Complexity_characteristic\" (id, \"ID_Algorithm\", ticks, processors, dimensions, iteration) VALUES ('" + rows_dt2_new + "','" + id + "','" + textBox14.Text + "','" + textBox15.Text + "','" + dimensionsTextBox.Text + "','" + textBox8.Text + "')", connection);
                    cmd1.ExecuteNonQuery();
                }
                // ДОБАЛЕНИЕ В ЮД ДАННЫХ
                int rows_dt1 = dataGridView1.Rows.Count;
                int rows_dt1_new = rows_dt1;
                OpenFileDialog o = new OpenFileDialog();
                o.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (o.ShowDialog() == DialogResult.OK)
                {
                    string[] lines = File.ReadAllLines(o.FileName, Encoding.Default);
                    string[] output_data = new string[lines.Length];
                    string[] logical_Q_term = new string[lines.Length];
                    string[] unconditional_Q_term = new string[lines.Length];
                    string[] logical_Q_term_new = new string[lines.Length];
                    string[] unconditional_Q_term_new = new string[lines.Length];
                    for (int i = 0; i < lines.Length; i++)
                    {//---  
                        string substring = "=";
                        int ind = lines[i].IndexOf(substring);
                        string S3 = "@";
                        string z1 = lines[i].Remove(ind, substring.Length).Insert(ind, S3);
                        string[] ns = z1.Split(new Char[] { '@', ';' });                        
                        output_data[i] = ns[0];
                        logical_Q_term[i] = ns[1];
                        unconditional_Q_term[i] = ns[2];
                        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                        {
                            rows_dt1_new = rows_dt1_new + 1;
                            connection.Open();
                            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Determinant\" (id, id_characteristic, output_data, \"logical_Qterm\", \"uncon_Qterm\") VALUES ('" + rows_dt1_new + "','" + rows_dt2_new + "','" + output_data[i] + "','" + logical_Q_term[i] + "','" + unconditional_Q_term[i] + "')", connection);
                            cmd.ExecuteNonQuery();
                        }

                        string strproveerka = logical_Q_term[i];
                        if (strproveerka == " ")
                        {
                            //MessageBox.Show("1 шт");
                            logical_Q_term_new[i] = " ";
                            //MessageBox.Show(logical_Q_term_new[i]);
                            unconditional_Q_term_new[i] = unconditional_Q_term[i];
                            //MessageBox.Show(unconditional_Q_term_new[i]);
                        }
                        else
                        {
                            logical_Q_term_new[i] = logical_Q_term[i];
                            //MessageBox.Show(logical_Q_term_new[i]);
                            unconditional_Q_term_new[i] = unconditional_Q_term[i];
                            //MessageBox.Show(unconditional_Q_term_new[i]);
                            //qdeterminantz[i] = logical_Q_term[i]+";"+unconditional_Q_term[i];
                        }
                    }
                    string strproveerka2 = logical_Q_term_new[0];
                    string f_sim = unconditional_Q_term_new[0][0].ToString();
                    if (f_sim == "{")
                    {
                    }
                    else
                    {
                        for (int i = 0; i < unconditional_Q_term_new.Length; i++)
                        {
                            unconditional_Q_term_new[i] = '"' + unconditional_Q_term_new[i] + '"';
                        }
                    }

                    if (strproveerka2 == " ")
                    {
                        // если logical_Q_term_new =" "
                        string[] qdeterminantz_itog = unconditional_Q_term_new;
                        string singleString = String.Join(",", qdeterminantz_itog);
                        string itog = "[" + singleString + "]";
                        string z1z = itog.Replace(";", ",");
                        string strojson = "{\"Determinant\":" + z1z + ",\"Dimensions\":" + dimensionsTextBox.Text + "}";
                        //--2
                        string writePath1 = @"C:\vkr_temp\json.json";
                        // сохранение в файл
                        using (StreamWriter sw = new StreamWriter(writePath1, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(strojson);
                            sw.Close();
                        }
                        string json1 = "[{\"op\":\" != \",\"fO\":\"A(1, 1)\",\"sO\":\"0\"}]";
                        determinant = ser.DeserializeObject(json1);
                        dimensions = ser.DeserializeObject(dimensionsTextBox.Text);
                        var obj = new QDeterminant(determinant, dimensions);
                        ser.Serialize(obj);
                        string res = HttpManager.Post(algorithmsPath + id.ToString(), ser.Serialize(obj));
                        try
                        {
                            int.Parse(res);
                        }
                        catch
                        {
                            MessageBox.Show(res);
                            return;
                        }
                    }
                    else
                    {
                        // если logical_Q_term_new !=" "
                        //MessageBox.Show("удаление дубликотов 2 ");
                        string[] logical_Q_term_new_res = logical_Q_term_new.Distinct().ToArray();
                        string[] qdeterminantz_itog = logical_Q_term_new_res.Union(unconditional_Q_term_new).ToArray();
                        string singleString = String.Join(",", qdeterminantz_itog);
                        string itog = "[" + singleString + "]";
                        //MessageBox.Show(itog);
                        string z1z = itog.Replace(";", ",");
                        string strojson = "{\"Determinant\":" + z1z + ",\"Dimensions\":" + dimensionsTextBox.Text + "}";
                        //--2
                        string writePath1 = @"C:\vkr_temp\json.json";
                        // сохранение в файл
                        using (StreamWriter sw = new StreamWriter(writePath1, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(strojson);
                            sw.Close();
                        }
                        string json1 = "[{\"op\":\" != \",\"fO\":\"A(1, 1)\",\"sO\":\"0\"}]";
                        determinant = ser.DeserializeObject(json1);
                        dimensions = ser.DeserializeObject(dimensionsTextBox.Text);
                        var obj = new QDeterminant(determinant, dimensions);
                        ser.Serialize(obj);
                        string res = HttpManager.Post(algorithmsPath + id.ToString(), ser.Serialize(obj));
                        try
                        {
                            int.Parse(res);
                        }
                        catch
                        {
                            MessageBox.Show(res);
                            return;
                        }
                    }


                    MessageBox.Show("Данные  добавлены и сохранены успешно..!");
                }
                determTextBox.Text = "";
                dimensionsTextBox.Text = "";
            }
        }
        // кнопка удаления из таб Complexity_characteristic
        private void button8_Click(object sender, EventArgs e)
        {
            DeleteDeterminant_Complexity_characteristic();
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            ViewGrid2();
            ViewGrid3();
            textBox6.Text = "";
        }
        void DeleteDeterminant_Complexity_characteristic()
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand cmd = new SqlCommand(@"Delete From [Determinant] WHERE [id_characteristic] = '" + textBox6.Text + "'", connection);
            //    cmd.ExecuteNonQuery();
            //    SqlCommand cmd1 = new SqlCommand(@"Delete From [Complexity_characteristic] WHERE [id] = '" + textBox6.Text + "'", connection);
            //    cmd1.ExecuteNonQuery();
            //    //SqlCommand cmd2 = new SqlCommand(@"Delete From [Determinants] WHERE [id] = '" + textBox6.Text + "'", connection);
            //    //cmd2.ExecuteNonQuery();                
            //}
            //postgresql
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("Delete From public.\"Determinant\" WHERE id_characteristic = '" + textBox6.Text + "'", connection);
                cmd.ExecuteNonQuery();
                NpgsqlCommand cmd1 = new NpgsqlCommand("Delete From public.\"Complexity_characteristic\" WHERE id = '" + textBox6.Text + "'", connection);
                cmd1.ExecuteNonQuery();
                //SqlCommand cmd2 = new SqlCommand(@"Delete From [Determinants] WHERE [id] = '" + textBox6.Text + "'", connection);
                //cmd2.ExecuteNonQuery();                
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Update_Complexity_characteristic();
            textBox5.Clear();
            comboBox3.SelectedIndex = -1;
            textBox11.Clear();
            textBox12.Clear();
        }
        void Update_Complexity_characteristic()
        {
            int currentMyComboBoxIndex = comboBox3.SelectedIndex;
            int idcomboBox3 = currentMyComboBoxIndex + 1;

            //         using (SqlConnection connection = new SqlConnection(connectionString))
            //         {
            //             connection.Open();
            //             SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Complexity_characteristic]
            //SET [ID_Algorithm] = '" + idcomboBox3 + "',[dimensions] = '" + textBox11.Text + "',[iteration] = '" + textBox12.Text + "' WHERE [id] = '" + textBox5.Text + "'", connection);
            //             cmd.ExecuteNonQuery();

            ////             SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[Determinants]
            ////SET [algorithm] = '" + idcomboBox3 + "',[dimensions] = '" + textBox11.Text  + "' WHERE [id] = '" + textBox5.Text + "'", connection);
            ////             cmd1.ExecuteNonQuery();
            //         }
            //postgresql
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Complexity_characteristic\" SET \"ID_Algorithm\" = '" + idcomboBox3 + "',dimensions = '" + textBox11.Text + "',iteration = '" + textBox12.Text + "' WHERE id = '" + textBox5.Text + "'", connection);
                cmd.ExecuteNonQuery();

                //             SqlCommand cmd1 = new SqlCommand(@"UPDATE [dbo].[Determinants]
                //SET [algorithm] = '" + idcomboBox3 + "',[dimensions] = '" + textBox11.Text  + "' WHERE [id] = '" + textBox5.Text + "'", connection);
                //             cmd1.ExecuteNonQuery();
            }
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            ViewGrid2();
            ViewGrid3();
        }

   

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int z = dataGridView1.SelectedRows[0].Index;
            textBox5.Text = dataGridView1.Rows[z].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.Rows[z].Cells[0].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[z].Cells[2].Value.ToString();
            textBox11.Text = dataGridView1.Rows[z].Cells[5].Value.ToString();
            textBox12.Text = dataGridView1.Rows[z].Cells[6].Value.ToString();
        }

        private void compareAlg1ID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void compareAlg2ID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void algTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
           
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = dataGridView3.SelectedRows[0].Index;
            textBox4.Text = dataGridView3.Rows[n].Cells[0].Value.ToString();
            textBox1.Text = dataGridView3.Rows[n].Cells[0].Value.ToString();
            textBox16.Text = dataGridView3.Rows[n].Cells[1].Value.ToString();
            textBox17.Text = dataGridView3.Rows[n].Cells[2].Value.ToString();
        }
         
                   
                   
        public List<string> zList(string name,int id_alg)
        {
            List<string> list = new List<string>();
            list.Clear();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            //"select max(id) from public.\"Complexity_characteristic\""
            string query = "SELECT " +name+ " from public.\"Complexity_characteristic\" WHERE \"ID_Algorithm\" = " + id_alg+ " ORDER BY " + name;
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
            }
            connection.Close();
            return list;
        }

        public List<int> zList2(string name, int id_alg)
        {
            List<int> list = new List<int>();
            list.Clear();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            //"select max(id) from public.\"Complexity_characteristic\""
            string query = "SELECT " + name + " from public.\"Complexity_characteristic\" WHERE \"ID_Algorithm\" = " + id_alg + " ORDER BY " + name;
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(reader.GetInt32(0));
                }
            }
            connection.Close();
            return list;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                //Вар 1
                //int currentMyComboBoxIndex = comboBox6.SelectedIndex;
                //id = currentMyComboBoxIndex + 1;
                string value = comboBox6.Text;
                //MessageBox.Show(value);
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand id_select = new NpgsqlCommand("select id from public.\"Algorithms\" WHERE name='" + value + "'", connection);
                    id = Convert.ToInt32(id_select.ExecuteScalar());
                    //MessageBox.Show(id.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Cannot parse algorithm's ID.");
                return;
            }
            //MessageBox.Show(id.ToString());
            List<string> list_dimentions = new List<string>();
            list_dimentions = zList("dimensions", id);
            string str_dimentions = string.Join(",", new List<string>(list_dimentions).ToArray());
            //MessageBox.Show("1 " + str_dimentions);
            //--------------------------------------------
            List<int> list_iterations = new List<int>();
            list_iterations = zList2("iteration", id);
            string str_iterations = string.Join(",", new List<int>(list_iterations).ToArray());
           //MessageBox.Show("2 " + str_iterations);
            //--------------------------------------------
            List<int> list_processors = new List<int>();
            list_processors = zList2("processors", id);
            string str_processors = string.Join(",", new List<int>(list_processors).ToArray());
            //MessageBox.Show("3 "+str_processors);
            //--------------------------------------------
            List<int> list_ticks = new List<int>();
            list_ticks = zList2("ticks", id);
            string str_ticks = string.Join(",", new List<int>(list_ticks).ToArray());
            //MessageBox.Show("3 " + str_ticks);


            string str_dimentions_new = "dimentions: ["+str_dimentions+"]";
            string str_iterations_new = "iterations: [" + str_iterations + "]";
            string str_processors_new = "processors: [" + str_processors + "]";
            string str_ticks_new = "ticks: [" + str_ticks + "]";

            string writePath1 = @"C:\vkr_temp\Approximation.yaml";
            using (StreamWriter sw = new StreamWriter(writePath1, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(str_dimentions_new);
                sw.WriteLine(str_iterations_new);
                sw.WriteLine(str_processors_new);
                sw.WriteLine(str_ticks_new);
                sw.Close();
            }
            listBox1.Items.Clear();
            listBox1.Items.Add(str_dimentions_new);
            listBox1.Items.Add(str_iterations_new);
            listBox1.Items.Add(str_processors_new);
            listBox1.Items.Add(str_ticks_new);
            listBox1.HorizontalScrollbar = true; // Горизонтальный скролл
            listBox1.ScrollAlwaysVisible = true; // Вертикальный скролл
            MessageBox.Show("Файл создан");           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            run_cmd();
            string readPath = @"C:\vkr_temp\res.txt";
            StreamReader reader = new StreamReader(readPath);
            string res = reader.ReadToEnd();
            reader.Close();
            string[] res_ap = res.Split(',',':');
            listBox2.Items.Add("Функция высоты:");
            listBox2.Items.Add(res_ap[3].Trim(new Char[] {'}'}));
            listBox2.Items.Add("Функция ширины:");
            listBox2.Items.Add(res_ap[1]);
            listBox2.HorizontalScrollbar = true; // Горизонтальный скролл
            listBox2.ScrollAlwaysVisible = true; // Вертикальный скролл
            MessageBox.Show("Выполнено");
        }
        private void run_cmd()
        {           
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python39_64\python.exe";
            var script = @"C:\vkr_temp\Approximation-master\Approximation\main.py";
            psi.Arguments=$"\"{script}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var errors = "";
            using(var process = Process.Start(psi))
            {
                errors=process.StandardError.ReadToEnd();
            }

        }
    }
}
