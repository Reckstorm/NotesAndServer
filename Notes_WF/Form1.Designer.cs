namespace Notes_WF
{
    partial class Notes
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            List_pn = new Panel();
            NotesList_lb = new ListBox();
            Details_pn = new Panel();
            New_btn = new Button();
            Delete_btn = new Button();
            Save_btn = new Button();
            Date_dp = new DateTimePicker();
            Name_tb = new TextBox();
            Text_tb = new TextBox();
            List_pn.SuspendLayout();
            Details_pn.SuspendLayout();
            SuspendLayout();
            // 
            // List_pn
            // 
            List_pn.Controls.Add(NotesList_lb);
            List_pn.Location = new Point(12, 12);
            List_pn.Name = "List_pn";
            List_pn.Size = new Size(200, 426);
            List_pn.TabIndex = 0;
            // 
            // NotesList_lb
            // 
            NotesList_lb.FormattingEnabled = true;
            NotesList_lb.ItemHeight = 15;
            NotesList_lb.Location = new Point(3, 0);
            NotesList_lb.Name = "NotesList_lb";
            NotesList_lb.Size = new Size(194, 424);
            NotesList_lb.TabIndex = 0;
            NotesList_lb.SelectedIndexChanged += SetDataOnIndexChange;
            // 
            // Details_pn
            // 
            Details_pn.Controls.Add(New_btn);
            Details_pn.Controls.Add(Delete_btn);
            Details_pn.Controls.Add(Save_btn);
            Details_pn.Controls.Add(Date_dp);
            Details_pn.Controls.Add(Name_tb);
            Details_pn.Controls.Add(Text_tb);
            Details_pn.Location = new Point(218, 12);
            Details_pn.Name = "Details_pn";
            Details_pn.Size = new Size(570, 426);
            Details_pn.TabIndex = 1;
            // 
            // New_btn
            // 
            New_btn.Location = new Point(411, 32);
            New_btn.Name = "New_btn";
            New_btn.Size = new Size(75, 23);
            New_btn.TabIndex = 5;
            New_btn.Text = "New";
            New_btn.UseVisualStyleBackColor = true;
            New_btn.Click += NewClick;
            // 
            // Delete_btn
            // 
            Delete_btn.Location = new Point(3, 32);
            Delete_btn.Name = "Delete_btn";
            Delete_btn.Size = new Size(75, 23);
            Delete_btn.TabIndex = 4;
            Delete_btn.Text = "Delete";
            Delete_btn.UseVisualStyleBackColor = true;
            Delete_btn.Click += DeleteClick;
            // 
            // Save_btn
            // 
            Save_btn.Location = new Point(492, 32);
            Save_btn.Name = "Save_btn";
            Save_btn.Size = new Size(75, 23);
            Save_btn.TabIndex = 3;
            Save_btn.Text = "Save";
            Save_btn.UseVisualStyleBackColor = true;
            Save_btn.Click += SaveClick;
            // 
            // Date_dp
            // 
            Date_dp.Location = new Point(367, 3);
            Date_dp.Name = "Date_dp";
            Date_dp.Size = new Size(200, 23);
            Date_dp.TabIndex = 2;
            // 
            // Name_tb
            // 
            Name_tb.Location = new Point(3, 3);
            Name_tb.Name = "Name_tb";
            Name_tb.Size = new Size(358, 23);
            Name_tb.TabIndex = 1;
            // 
            // Text_tb
            // 
            Text_tb.Location = new Point(3, 64);
            Text_tb.Multiline = true;
            Text_tb.Name = "Text_tb";
            Text_tb.Size = new Size(564, 359);
            Text_tb.TabIndex = 0;
            // 
            // Notes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Details_pn);
            Controls.Add(List_pn);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Notes";
            Text = "Notes";
            List_pn.ResumeLayout(false);
            Details_pn.ResumeLayout(false);
            Details_pn.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel List_pn;
        private Panel Details_pn;
        private TextBox Text_tb;
        private ListBox NotesList_lb;
        private Button Delete_btn;
        private Button Save_btn;
        private DateTimePicker Date_dp;
        private TextBox Name_tb;
        private Button New_btn;
    }
}