using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reader
{
    public partial class Form1 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rd;
        private DataSet ds;
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            Read();

            ds = new DataSet("DataBase");
            dt = new DataTable("Nombres");
            ds.Tables.Add(dt);
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Edad", typeof(int));
            dt.Rows.Add(1,"Orion",50);
            dt.Rows.Add(2, "Vader", 55);
            dt.Rows.Add(3, "Shmenkare", 35);
            dt.Rows.Add(4, "Fett", 40);
            dt.Rows.Add(5, "Han Solo", 35);
            dt.Rows.Add(6, "Maulth", 30);

            dgvDatos.DataSource = dt;

        }

        public void Read()
        {
            string cadena = "Data Source=.;Initial Catalog=MusicListDB;Integrated Security=True";
            string sql = "SELECT * FROM Temas";
            con = new SqlConnection(cadena);
            con.Open();
            cmd = new SqlCommand(sql, con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lsvLista.Items.Add(rd[1].ToString());
            }
            rd.Close();
            con.Close();
        }

        
    }

}



