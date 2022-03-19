namespace BeitarGamesCalendar
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
            this.button_StartFetch = new System.Windows.Forms.Button();
            this.textBox_Pages = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_URL = new System.Windows.Forms.TextBox();
            this.button_ExportToCSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_StartFetch
            // 
            this.button_StartFetch.Location = new System.Drawing.Point(12, 184);
            this.button_StartFetch.Name = "button_StartFetch";
            this.button_StartFetch.Size = new System.Drawing.Size(199, 109);
            this.button_StartFetch.TabIndex = 35;
            this.button_StartFetch.Text = "Start Fetching";
            this.button_StartFetch.UseVisualStyleBackColor = true;
            this.button_StartFetch.Click += new System.EventHandler(this.button_StartFetch_Click);
            // 
            // textBox_Pages
            // 
            this.textBox_Pages.Location = new System.Drawing.Point(200, 96);
            this.textBox_Pages.Name = "textBox_Pages";
            this.textBox_Pages.Size = new System.Drawing.Size(51, 20);
            this.textBox_Pages.TabIndex = 32;
            this.textBox_Pages.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "# Of Pages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "URL wanted";
            // 
            // textBox_URL
            // 
            this.textBox_URL.Location = new System.Drawing.Point(12, 30);
            this.textBox_URL.Name = "textBox_URL";
            this.textBox_URL.Size = new System.Drawing.Size(335, 20);
            this.textBox_URL.TabIndex = 29;
            // 
            // button_ExportToCSV
            // 
            this.button_ExportToCSV.Location = new System.Drawing.Point(259, 211);
            this.button_ExportToCSV.Name = "button_ExportToCSV";
            this.button_ExportToCSV.Size = new System.Drawing.Size(121, 54);
            this.button_ExportToCSV.TabIndex = 28;
            this.button_ExportToCSV.Text = "Export XML to CSV";
            this.button_ExportToCSV.UseVisualStyleBackColor = true;
            this.button_ExportToCSV.Click += new System.EventHandler(this.button_ExportToCSV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_StartFetch);
            this.Controls.Add(this.textBox_Pages);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_URL);
            this.Controls.Add(this.button_ExportToCSV);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_StartFetch;
        private System.Windows.Forms.TextBox textBox_Pages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.Button button_ExportToCSV;
    }
}