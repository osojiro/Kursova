using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Потрібна для підключення до БД

namespace fitnes_club
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ignis\Desktop\TyrAgent\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync(); //відчиняємо базу даних

            SqlDataReader sqlReader = null;

            SqlCommand ActivityCommand = new SqlCommand("SELECT * FROM [Tyr]", sqlConnection);
            try
            {
                sqlReader = await ActivityCommand.ExecuteReaderAsync();
                //await усюди потрібен для того щоб програма виконувалася одночасно
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(
                             Convert.ToString(sqlReader["ActivityId"]) +
                       ". Страна: " + Convert.ToString(sqlReader["Strana"]) +
                       ". Город: " + Convert.ToString(sqlReader["Gorod"]) +
                       ". Отель: " + Convert.ToString(sqlReader["Otel"]) +
                       ". Тип тура: " + Convert.ToString(sqlReader["Type"]) +
                       ". Питание: " + Convert.ToString(sqlReader["Pitanie"]) +
                       ". Цена: " + Convert.ToString(sqlReader["Cena"])
                        );
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            SqlCommand TreinerCommand = new SqlCommand("SELECT * FROM [Visitor]", sqlConnection);
            try
            {
                sqlReader = await TreinerCommand.ExecuteReaderAsync();
                //await усюди потрібен для того щоб програма виконувалася одночасно
                while (await sqlReader.ReadAsync())
                {
                    listBox2.Items.Add(
                       "Клиент: " + Convert.ToString(sqlReader["VisitorId"]) +
                       ". ФИО: " + Convert.ToString(sqlReader["Fio"]) +
                       ". Адрес: " + Convert.ToString(sqlReader["Adres"]) +
                       ". Телефон: " + Convert.ToString(sqlReader["Tel"]) +
                       ". E-mail: " + Convert.ToString(sqlReader["E-mail"]) +
                       ". Active: " + Convert.ToString(sqlReader["Active"])
                        );
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            SqlCommand VisitorCommand = new SqlCommand("SELECT * FROM [Otel]", sqlConnection);
            try
            {
                sqlReader = await VisitorCommand.ExecuteReaderAsync();
                //await усюди потрібен для того щоб програма виконувалася одночасно
                while (await sqlReader.ReadAsync())
                {
                    listBox3.Items.Add(
                       "Отель: " + Convert.ToString(sqlReader["OtelId"]) +
                       ". Страна: " + Convert.ToString(sqlReader["Strana"]) +
                       ". Город: " + Convert.ToString(sqlReader["Gorod"]) +
                       ". Название: " + Convert.ToString(sqlReader["Nazvanie"]) +
                       ". Класс: " + Convert.ToString(sqlReader["Class"]) 
                        );
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close(); //зачиняє з'єдання з БД
        }


        private async void button4_Click(object sender, EventArgs e)
        {//оновлення листів
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            SqlDataReader sqlReader = null;

            SqlCommand ActivityCommand = new SqlCommand("SELECT * FROM [Tyr]", sqlConnection);
            try
            {
                sqlReader = await ActivityCommand.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(
                                  Convert.ToString(sqlReader["ActivityId"]) +
                       ". Страна: " + Convert.ToString(sqlReader["Strana"]) +
                       ". Город: " + Convert.ToString(sqlReader["Gorod"]) +
                       ". Отель: " + Convert.ToString(sqlReader["Otel"]) +
                       ". Тип тура: " + Convert.ToString(sqlReader["Type"]) +
                       ". Питание: " + Convert.ToString(sqlReader["Pitanie"]) +
                       ". Цена: " + Convert.ToString(sqlReader["Cena"])
                        );
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            SqlCommand TreinerCommand = new SqlCommand("SELECT * FROM [Otel]", sqlConnection);
            try
            {
                sqlReader = await TreinerCommand.ExecuteReaderAsync();
                //await усюди потрібен для того щоб програма виконувалася одночасно
                while (await sqlReader.ReadAsync())
                {                                        
                        listBox3.Items.Add(
                       "Отель: " + Convert.ToString(sqlReader["OtelId"]) +
                       ". Страна: " + Convert.ToString(sqlReader["Strana"]) +
                       ". Город: " + Convert.ToString(sqlReader["Gorod"]) +
                       ". Название: " + Convert.ToString(sqlReader["Nazvanie"]) +
                       ". Класс: " + Convert.ToString(sqlReader["Class"])
                        );
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            SqlCommand VisitorCommand = new SqlCommand("SELECT * FROM [Visitor]", sqlConnection);
            try
            {
                sqlReader = await VisitorCommand.ExecuteReaderAsync();
                //await усюди потрібен для того щоб програма виконувалася одночасно
                while (await sqlReader.ReadAsync())
                {
                    listBox2.Items.Add(
                        "Клиент: " + Convert.ToString(sqlReader["VisitorId"]) +
                        ". ФИО:: " + Convert.ToString(sqlReader["Fio"]) +
                        ". Адрес: " + Convert.ToString(sqlReader["Adres"]) +
                        ". Телефон: " + Convert.ToString(sqlReader["Tel"]) +
                        ". E-mail: " + Convert.ToString(sqlReader["E-mail"]) +
                        ". Active: " + Convert.ToString(sqlReader["Active"])
                         );
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//встановлення
            if (tabControl1.SelectedTab == tabPage2)
            {
                InsertVisitor insertVisitor = new InsertVisitor(sqlConnection);
                insertVisitor.Show();
            }
            //Так само і для інших insert
            else if (tabControl1.SelectedTab == tabPage1) { }
            else if (tabControl1.SelectedTab == tabPage3) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {//Змінити
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (listBox2.SelectedIndex > 0)
                {
                    UpdateVisitor updateVisitor = new UpdateVisitor(sqlConnection, listBox2.SelectedIndices[0] + 1);
                    updateVisitor.Show();
                }
                else
                {
                    MessageBox.Show("Вы не выделили строки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tabControl1.SelectedTab == tabPage1) { }
            else if (tabControl1.SelectedTab == tabPage3) { }

        }

        private async void button2_Click(object sender, EventArgs e)
        {//Видалити

            if (tabControl1.SelectedTab == tabPage2)
            {
                if (listBox2.SelectedIndex > 0)
                {
                    DialogResult result = MessageBox.Show("Вы правда хотите удалить?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    switch (result)
                    {
                        case DialogResult.OK:
                            SqlCommand deleteVisitorcommand = new SqlCommand("DELETE FROM [Visitor] WHERE [VisitorId] = @VisitorId", sqlConnection);
                            deleteVisitorcommand.Parameters.AddWithValue("VisitorId", Convert.ToInt32(listBox2.SelectedIndices[0] + 1));

                            try
                            {
                                await deleteVisitorcommand.ExecuteNonQueryAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            listBox2.Items.Clear();
                            MessageBox.Show("Вы изменили данные, нажмите 'Обновить'", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выделили строки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tabControl1.SelectedTab == tabPage1) { }
            else if (tabControl1.SelectedTab == tabPage3) { }
        }
    }
}
