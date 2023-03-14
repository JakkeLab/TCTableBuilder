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
        public List<List<string>> strList = new List<List<string>>();

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
            if (tcCommands.getActiveProject() != null)
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
            lbStatus.Text = "Loading Values";
            List<List<string>> listSets = tcCommands.GetParamSelected(activeProj, "H-Pile번호", "파일상단(EL)", "파일하단(EL)", "토사구간", "암구간");
            strList = listSets;
            for (int i = 0; i < listSets.Count; i++)
            {
                var list = listSets[i];
                string Idx = list[0].ToString();
                string DesignedLength = list[1].ToString();
                string PileTop = list[2].ToString();
                string PileBottom = list[3].ToString();
                string ExcLength = list[4].ToString();
                string SandRange = list[5].ToString();
                string RockRange = list[6].ToString();
                string[] strs = new string[] { Idx, DesignedLength, PileTop, PileBottom, ExcLength, SandRange, RockRange };
                ListViewItem lvi = new ListViewItem(strs);
                liEstimation.Items.Add(lvi);
                pgBar.Value = (i / listSets.Count) * 100;
            }
            tbStart.Enabled = true;
            tbEnd.Enabled = true;
            btExportXls.Enabled = true;
            pgBar.Value = 0;
            lbStatus.Text = "Idle";
        }

        private void btExportXls_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Making Report";
            if (Int32.TryParse(tbStart.Text, out int a1) && Int32.TryParse(tbEnd.Text, out int a2) && a1 < a2)
            {
                int n1 = Int32.Parse(tbStart.Text);
                int n2 = Int32.Parse(tbEnd.Text);
                msExcel.ExcelTest(liEstimation.Items.Count, n1, n2, strList);
                MessageBox.Show("항타일지 작성이 완료되었습니다");
            }
            else
            {
                MessageBox.Show("시작번호와 끝번호 칸의 값이 잘못되었습니다");
            }

            lbStatus.Text = "Idle";
        }
    }
}
