using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace fitnes_club
{
    public partial class UpdateVisitor : Form
    {
        private SqlConnection sqlConnection = null;
        private int VisitorId;

        public UpdateVisitor(SqlConnection connection, int VisitorId)
        {
            InitializeComponent();

            sqlConnection = connection;

            this.VisitorId = VisitorId;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlCommand updateVisitorcommand = new SqlCommand("UPDATE [Visitor] SET [FIO] = @FIO, [Adres] = @Adres, [Tel] = @Tel, [E-mail] = @E-mail, [Active] = @Active WHERE [VisitorId] = @VisitorId", sqlConnection);

            updateVisitorcommand.Parameters.AddWithValue("VisitorId", VisitorId);
            updateVisitorcommand.Parameters.AddWithValue("FIO", textBox1.Text);
            updateVisitorcommand.Parameters.AddWithValue("Adres", textBox2.Text);
            updateVisitorcommand.Parameters.AddWithValue("Tel", textBox3.Text);
            updateVisitorcommand.Parameters.AddWithValue("E-mail", textBox4.Text);
            updateVisitorcommand.Parameters.AddWithValue("Active", checkBox1.Checked);

            try
            {
                await updateVisitorcommand.ExecuteNonQueryAsync();

                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UpdateVisitor_Load(object sender, EventArgs e)
        {
            SqlCommand getVisitorInfoCommand = new SqlCommand("SELECT [FIO], [Adres], [Tel], [E-mail], [Active] FROM [Visitor] WHERE [VisitorId] = @VisitorId", sqlConnection);

            getVisitorInfoCommand.Parameters.AddWithValue("VisitorId", VisitorId);

            SqlDataReader sqlReader = null;

            try
            {
                sqlReader = await getVisitorInfoCommand.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    textBox1.Text = Convert.ToString(sqlReader["FIO"]);
                    textBox2.Text = Convert.ToString(sqlReader["Adres"]);
                    textBox3.Text = Convert.ToString(sqlReader["Tel"]);
                    textBox4.Text = Convert.ToString(sqlReader["E-mail"]);
                    checkBox1.Checked = Convert.ToBoolean(sqlReader["Active"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                { sqlReader.Close(); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
