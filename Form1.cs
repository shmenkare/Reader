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
        private DataColumn id;
        private DataColumn name;
        private DataColumn age;

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            Read();

            ds = new DataSet("DataBase");
            dt = new DataTable("Nombres");
            
            id = new DataColumn("Id", typeof(int));
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
           
            name = new DataColumn("Nombre", typeof(string));
            age = new DataColumn("Edad",typeof(int));
            
            dt.Columns.AddRange(new DataColumn[] { id, name, age });
            dt.PrimaryKey = new DataColumn[] { id };
            
            ds.Tables.Add(dt);
            
            dt.Rows.Add(null,"Orion",50);
            dt.Rows.Add(null,"Vader", 55);
            dt.Rows.Add(null,"Shmenkare", 35);
            dt.Rows.Add(null,"Fett", 40);
            dt.Rows.Add(null,"Han Solo", 35);
            dt.Rows.Add(null,"Maulth", 30);
            dt.Rows.Add(null, "Acvar", 65);

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



