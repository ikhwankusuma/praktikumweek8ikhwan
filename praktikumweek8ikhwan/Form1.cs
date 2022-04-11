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

namespace praktikumweek8ikhwan
{
    public partial class praktikumweek8 : Form
    {
        public praktikumweek8()
        {
            InitializeComponent();
        }
        public static string sqlconnection = ("server=localhost;uid=root;pwd=;database=premier_league");
        public MySqlConnection sqlconnect = new MySqlConnection(sqlconnection);
        public MySqlCommand sqlcomend;
        public MySqlDataAdapter sqladapter;
        public string sqlquery;
        private void praktikumweek8_Load(object sender, EventArgs e)
        {
            try 
            {
                sqlconnect.Open();
                DataTable team = new DataTable();
                sqlquery = "Select team_name, team_id from team";
                sqlcomend = new MySqlCommand(sqlquery, sqlconnect);
                sqladapter = new MySqlDataAdapter(sqlcomend);
                sqladapter.Fill(team);
                cbtimhome.DataSource = team;
                cbtimhome.DisplayMember = "team_name";
                cbtimhome.ValueMember = "team_id";
                cbtimaway.DataSource = team;
                cbtimaway.DisplayMember = "team_name";
                cbtimaway.ValueMember = "team_id";
                
            }
            catch (Exception ex)
            { 
            MessageBox.Show(ex.Message);
            }
       

        }

        private void cbtimhome_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable team = new DataTable();
                sqlquery = "SELECT manager_name as `manager` FROM team T,manager M WHERE T.manager_id = M.manager_id and T.team_id = '" + cbtimhome.SelectedValue.ToString() + "'"
    ;
                sqlcomend = new MySqlCommand(sqlquery, sqlconnect);
                sqladapter = new MySqlDataAdapter(sqlcomend);
                sqladapter.Fill(team);
                lbnamemanagerhome.Text = team.Rows[0]["manager"].ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void cbtimaway_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable team = new DataTable();
            sqlquery = "SELECT manager_name as `manageraway` FROM team T,manager M WHERE T.manager_id = M.manager_id and T.team_id = '" + cbtimaway.SelectedValue.ToString() + "'"
;
            sqlcomend = new MySqlCommand(sqlquery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcomend);
            sqladapter.Fill(team);
            lbnamamanageraway.Text = team.Rows[0]["manageraway"].ToString();
        }
    }
}
