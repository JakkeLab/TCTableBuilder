using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trimble.Connect.Desktop.API;
using Trimble.Connect.Desktop.API.Models;
using Trimble.Connect.Desktop.API.Projects;

namespace TCTableBuilder
{
    public partial class Form1 : Form
    {
        TCcommands.TCcommand tcCommands = new TCcommands.TCcommand();
        public Project activeProj;
        MSExcel.MSExcelReport msExcel = new MSExcel.MSExcelReport();
        public Form1()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            tcCommands.Connect();
            btProjLoad.Enabled = true;
            lbConnect.Text = "Connected";
        }

        private void btProjLoad_Click(object sender, EventArgs e)
        {
            if(tcCommands.getActiveProject() != null)
            {
                activeProj = tcCommands.getActiveProject();
                tbProjectname.Text = activeProj.Name;
            }
            else
            {
                MessageBox.Show("Please open a project at Trimble Connect");
            }
        }

        private void btPileLoad_Click(object sender, EventArgs e)
        {
            tcCommands.SearchObjects(activeProj);
        }

        private void btGetValues_Click(object sender, EventArgs e)
        {
            liEstimation.Items.Clear();
            List<List<string>> listSets = tcCommands.GetParamSelected(activeProj, "H-Pile번호","토사구간", "암구간");
            
            for(int i = 0; i<listSets.Count;i++)
            {
                var list = listSets[i];
                string Idx = list[0].ToString();
                string SandRange = list[1].ToString();
                string RockRange = list[2].ToString();
                string[] strs = new string[] {Idx, SandRange, RockRange};
                ListViewItem lvi = new ListViewItem(strs);
                liEstimation.Items.Add(lvi);
            }
            tbStart.Enabled = true;
            tbEnd.Enabled = true;
            btExportXls.Enabled = true;
        }

        private void btExportXls_Click(object sender, EventArgs e)
        {
            msExcel.ExcelTest(liEstimation.Items.Count, 0, 0);
        }
    }
}
