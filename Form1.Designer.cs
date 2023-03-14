namespace TCTableBuilder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConnect = new System.Windows.Forms.Button();
            this.lbConnect = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.liEstimation = new System.Windows.Forms.ListView();
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btExportXls = new System.Windows.Forms.Button();
            this.lbExportXls = new System.Windows.Forms.Label();
            this.lbLoadPiles = new System.Windows.Forms.Label();
            this.btPileLoad = new System.Windows.Forms.Button();
            this.tbProjectname = new System.Windows.Forms.TextBox();
            this.btProjLoad = new System.Windows.Forms.Button();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.tbEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbGetValues = new System.Windows.Forms.Label();
            this.btGetValues = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.lbStatusHeader = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(14, 15);
            this.btConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(102, 29);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "트림블 연결";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // lbConnect
            // 
            this.lbConnect.AutoSize = true;
            this.lbConnect.Location = new System.Drawing.Point(177, 21);
            this.lbConnect.Name = "lbConnect";
            this.lbConnect.Size = new System.Drawing.Size(97, 15);
            this.lbConnect.TabIndex = 1;
            this.lbConnect.Text = "Disconnected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status :";
            // 
            // liEstimation
            // 
            this.liEstimation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col7,
            this.col8});
            this.liEstimation.HideSelection = false;
            this.liEstimation.Location = new System.Drawing.Point(17, 95);
            this.liEstimation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.liEstimation.Name = "liEstimation";
            this.liEstimation.Size = new System.Drawing.Size(678, 374);
            this.liEstimation.TabIndex = 3;
            this.liEstimation.UseCompatibleStateImageBehavior = false;
            this.liEstimation.View = System.Windows.Forms.View.Details;
            // 
            // col1
            // 
            this.col1.Text = "파일번호";
            // 
            // col2
            // 
            this.col2.Text = "설계 천공심도";
            this.col2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col2.Width = 100;
            // 
            // col3
            // 
            this.col3.Text = "파일상단";
            this.col3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col3.Width = 80;
            // 
            // col4
            // 
            this.col4.Text = "파일하단";
            this.col4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col4.Width = 80;
            // 
            // col5
            // 
            this.col5.Text = "천공심도";
            this.col5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col5.Width = 80;
            // 
            // col7
            // 
            this.col7.Text = "토사구간";
            this.col7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col7.Width = 80;
            // 
            // col8
            // 
            this.col8.Text = "암구간";
            this.col8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col8.Width = 80;
            // 
            // btExportXls
            // 
            this.btExportXls.Enabled = false;
            this.btExportXls.Location = new System.Drawing.Point(134, 570);
            this.btExportXls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btExportXls.Name = "btExportXls";
            this.btExportXls.Size = new System.Drawing.Size(86, 29);
            this.btExportXls.TabIndex = 4;
            this.btExportXls.Text = "출력";
            this.btExportXls.UseVisualStyleBackColor = true;
            this.btExportXls.Click += new System.EventHandler(this.btExportXls_Click);
            // 
            // lbExportXls
            // 
            this.lbExportXls.AutoSize = true;
            this.lbExportXls.Location = new System.Drawing.Point(131, 551);
            this.lbExportXls.Name = "lbExportXls";
            this.lbExportXls.Size = new System.Drawing.Size(102, 15);
            this.lbExportXls.TabIndex = 5;
            this.lbExportXls.Text = "항타일지 출력";
            // 
            // lbLoadPiles
            // 
            this.lbLoadPiles.AutoSize = true;
            this.lbLoadPiles.Location = new System.Drawing.Point(14, 488);
            this.lbLoadPiles.Name = "lbLoadPiles";
            this.lbLoadPiles.Size = new System.Drawing.Size(96, 15);
            this.lbLoadPiles.TabIndex = 7;
            this.lbLoadPiles.Text = "Pile 불러오기";
            // 
            // btPileLoad
            // 
            this.btPileLoad.Location = new System.Drawing.Point(14, 506);
            this.btPileLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btPileLoad.Name = "btPileLoad";
            this.btPileLoad.Size = new System.Drawing.Size(86, 29);
            this.btPileLoad.TabIndex = 6;
            this.btPileLoad.Text = "파일 로드";
            this.btPileLoad.UseVisualStyleBackColor = true;
            this.btPileLoad.Click += new System.EventHandler(this.btPileLoad_Click);
            // 
            // tbProjectname
            // 
            this.tbProjectname.Location = new System.Drawing.Point(122, 56);
            this.tbProjectname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbProjectname.Name = "tbProjectname";
            this.tbProjectname.ReadOnly = true;
            this.tbProjectname.Size = new System.Drawing.Size(211, 25);
            this.tbProjectname.TabIndex = 9;
            // 
            // btProjLoad
            // 
            this.btProjLoad.Enabled = false;
            this.btProjLoad.Location = new System.Drawing.Point(14, 58);
            this.btProjLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btProjLoad.Name = "btProjLoad";
            this.btProjLoad.Size = new System.Drawing.Size(102, 29);
            this.btProjLoad.TabIndex = 10;
            this.btProjLoad.Text = "프로젝트 로드";
            this.btProjLoad.UseVisualStyleBackColor = true;
            this.btProjLoad.Click += new System.EventHandler(this.btProjLoad_Click);
            // 
            // tbStart
            // 
            this.tbStart.Enabled = false;
            this.tbStart.Location = new System.Drawing.Point(134, 509);
            this.tbStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(85, 25);
            this.tbStart.TabIndex = 11;
            // 
            // tbEnd
            // 
            this.tbEnd.Enabled = false;
            this.tbEnd.Location = new System.Drawing.Point(248, 509);
            this.tbEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(85, 25);
            this.tbEnd.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "시작번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "끝번호";
            // 
            // lbGetValues
            // 
            this.lbGetValues.AutoSize = true;
            this.lbGetValues.Location = new System.Drawing.Point(14, 551);
            this.lbGetValues.Name = "lbGetValues";
            this.lbGetValues.Size = new System.Drawing.Size(87, 15);
            this.lbGetValues.TabIndex = 16;
            this.lbGetValues.Text = "값 불러오기";
            // 
            // btGetValues
            // 
            this.btGetValues.Location = new System.Drawing.Point(14, 570);
            this.btGetValues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btGetValues.Name = "btGetValues";
            this.btGetValues.Size = new System.Drawing.Size(86, 29);
            this.btGetValues.TabIndex = 15;
            this.btGetValues.Text = "값 로드";
            this.btGetValues.UseVisualStyleBackColor = true;
            this.btGetValues.Click += new System.EventHandler(this.btGetValues_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pgBar
            // 
            this.pgBar.Location = new System.Drawing.Point(248, 619);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(444, 23);
            this.pgBar.TabIndex = 18;
            // 
            // lbStatusHeader
            // 
            this.lbStatusHeader.AutoSize = true;
            this.lbStatusHeader.Location = new System.Drawing.Point(14, 623);
            this.lbStatusHeader.Name = "lbStatusHeader";
            this.lbStatusHeader.Size = new System.Drawing.Size(64, 15);
            this.lbStatusHeader.TabIndex = 19;
            this.lbStatusHeader.Text = "Status : ";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(71, 623);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(29, 15);
            this.lbStatus.TabIndex = 20;
            this.lbStatus.Text = "Idle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 641);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbStatusHeader);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbGetValues);
            this.Controls.Add(this.btGetValues);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEnd);
            this.Controls.Add(this.tbStart);
            this.Controls.Add(this.btProjLoad);
            this.Controls.Add(this.tbProjectname);
            this.Controls.Add(this.lbLoadPiles);
            this.Controls.Add(this.btPileLoad);
            this.Controls.Add(this.lbExportXls);
            this.Controls.Add(this.btExportXls);
            this.Controls.Add(this.liEstimation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbConnect);
            this.Controls.Add(this.btConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "항타일지 출력";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Label lbConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView liEstimation;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col7;
        private System.Windows.Forms.ColumnHeader col8;
        private System.Windows.Forms.Button btExportXls;
        private System.Windows.Forms.Label lbExportXls;
        private System.Windows.Forms.Label lbLoadPiles;
        private System.Windows.Forms.Button btPileLoad;
        private System.Windows.Forms.TextBox tbProjectname;
        private System.Windows.Forms.Button btProjLoad;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.TextBox tbEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbGetValues;
        private System.Windows.Forms.Button btGetValues;
        private System.Windows.Forms.ColumnHeader col2;
        private System.Windows.Forms.ColumnHeader col3;
        private System.Windows.Forms.ColumnHeader col4;
        private System.Windows.Forms.ColumnHeader col5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ProgressBar pgBar;
        private System.Windows.Forms.Label lbStatusHeader;
        private System.Windows.Forms.Label lbStatus;
    }
}

