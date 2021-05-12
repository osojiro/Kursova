using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;//!
using System.Data.SqlClient;//!

namespace fitnes_club
{
    public partial class InsertVisitor : Form
    {
        private SqlConnection sqlConnection;

        public InsertVisitor(SqlConnection connection)
        {
            InitializeComponent();

            sqlConnection = connection;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlCommand insertVisitorCommand = new SqlCommand("INSERT INTO [Visitor] (FIO, Adres, Tel, E-mail, Active) VALUES(@FIO, @Active, @Tel, @E-mail, @Adres)", sqlConnection);

            insertVisitorCommand.Parameters.AddWithValue("FIO", textBox1);
            insertVisitorCommand.Parameters.AddWithValue("Adres", textBox2);
            insertVisitorCommand.Parameters.AddWithValue("Tel", textBox3);
            insertVisitorCommand.Parameters.AddWithValue("E-mail", textBox4);
            insertVisitorCommand.Parameters.AddWithValue("Active", true);

            try
            {
                await insertVisitorCommand.ExecuteNonQueryAsync();//не повертає значень після додавання даних

                Close();//зачиняє форму
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
