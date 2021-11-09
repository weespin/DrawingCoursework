
namespace Coursework.AuxForms
{
    partial class NewFileForm
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
            this.num_height = new System.Windows.Forms.NumericUpDown();
            this.num_width = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_width)).BeginInit();
            this.SuspendLayout();
            // 
            // num_height
            // 
            this.num_height.Location = new System.Drawing.Point(56, 10);
            this.num_height.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_height.Name = "num_height";
            this.num_height.Size = new System.Drawing.Size(120, 20);
            this.num_height.TabIndex = 0;
            this.num_height.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // num_width
            // 
            this.num_width.Location = new System.Drawing.Point(56, 39);
            this.num_width.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_width.Name = "num_width";
            this.num_width.Size = new System.Drawing.Size(120, 20);
            this.num_width.TabIndex = 1;
            this.num_width.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Width";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(102, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NewFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 98);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_width);
            this.Controls.Add(this.num_height);
            this.Name = "NewFileForm";
            this.Text = "NewFileForm";
            ((System.ComponentModel.ISupportInitialize)(this.num_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.NumericUpDown num_height;
        public System.Windows.Forms.NumericUpDown num_width;
    }
}