
namespace Coursework
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_debug = new System.Windows.Forms.CheckBox();
            this.txt_object_w = new System.Windows.Forms.TextBox();
            this.txt_object_h = new System.Windows.Forms.TextBox();
            this.txt_object_rot = new System.Windows.Forms.TextBox();
            this.txt_object_y = new System.Windows.Forms.TextBox();
            this.txt_object_x = new System.Windows.Forms.TextBox();
            this.lbl_object_w = new System.Windows.Forms.Label();
            this.lbl_object_h = new System.Windows.Forms.Label();
            this.lbl_object_rotation = new System.Windows.Forms.Label();
            this.lbl_object_y = new System.Windows.Forms.Label();
            this.lbl_object_x = new System.Windows.Forms.Label();
            this.cb_drawedge = new System.Windows.Forms.CheckBox();
            this.btn_marker = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_layer = new System.Windows.Forms.Label();
            this.combo_layers = new System.Windows.Forms.ComboBox();
            this.btn_color2 = new System.Windows.Forms.Button();
            this.btn_color1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_edge_thickness = new System.Windows.Forms.Label();
            this.track_pen_thickness = new System.Windows.Forms.TrackBar();
            this.btn_form = new System.Windows.Forms.Button();
            this.btn_pen = new System.Windows.Forms.Button();
            this.btn_erazer = new System.Windows.Forms.Button();
            this.btn_line = new System.Windows.Forms.Button();
            this.btn_pointer = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picture_canvas = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_pen_thickness)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveasToolStripMenuItem.Text = "Save As";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.chk_debug);
            this.panel1.Controls.Add(this.txt_object_w);
            this.panel1.Controls.Add(this.txt_object_h);
            this.panel1.Controls.Add(this.txt_object_rot);
            this.panel1.Controls.Add(this.txt_object_y);
            this.panel1.Controls.Add(this.txt_object_x);
            this.panel1.Controls.Add(this.lbl_object_w);
            this.panel1.Controls.Add(this.lbl_object_h);
            this.panel1.Controls.Add(this.lbl_object_rotation);
            this.panel1.Controls.Add(this.lbl_object_y);
            this.panel1.Controls.Add(this.lbl_object_x);
            this.panel1.Controls.Add(this.cb_drawedge);
            this.panel1.Controls.Add(this.btn_marker);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbl_layer);
            this.panel1.Controls.Add(this.combo_layers);
            this.panel1.Controls.Add(this.btn_color2);
            this.panel1.Controls.Add(this.btn_color1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_edge_thickness);
            this.panel1.Controls.Add(this.track_pen_thickness);
            this.panel1.Controls.Add(this.btn_form);
            this.panel1.Controls.Add(this.btn_pen);
            this.panel1.Controls.Add(this.btn_erazer);
            this.panel1.Controls.Add(this.btn_line);
            this.panel1.Controls.Add(this.btn_pointer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(104, 604);
            this.panel1.TabIndex = 1;
            // 
            // chk_debug
            // 
            this.chk_debug.AutoSize = true;
            this.chk_debug.Location = new System.Drawing.Point(12, 584);
            this.chk_debug.Name = "chk_debug";
            this.chk_debug.Size = new System.Drawing.Size(58, 17);
            this.chk_debug.TabIndex = 36;
            this.chk_debug.Text = "Debug";
            this.chk_debug.UseVisualStyleBackColor = true;
            this.chk_debug.CheckedChanged += new System.EventHandler(this.chk_debug_CheckedChanged);
            // 
            // txt_object_w
            // 
            this.txt_object_w.Location = new System.Drawing.Point(47, 558);
            this.txt_object_w.Name = "txt_object_w";
            this.txt_object_w.Size = new System.Drawing.Size(51, 20);
            this.txt_object_w.TabIndex = 35;
            this.txt_object_w.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_object_w_KeyUp);
            // 
            // txt_object_h
            // 
            this.txt_object_h.Location = new System.Drawing.Point(47, 532);
            this.txt_object_h.Name = "txt_object_h";
            this.txt_object_h.Size = new System.Drawing.Size(51, 20);
            this.txt_object_h.TabIndex = 34;
            this.txt_object_h.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_object_h_KeyUp);
            // 
            // txt_object_rot
            // 
            this.txt_object_rot.Location = new System.Drawing.Point(47, 504);
            this.txt_object_rot.Name = "txt_object_rot";
            this.txt_object_rot.Size = new System.Drawing.Size(51, 20);
            this.txt_object_rot.TabIndex = 33;
            this.txt_object_rot.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_object_rot_KeyUp);
            // 
            // txt_object_y
            // 
            this.txt_object_y.Location = new System.Drawing.Point(47, 478);
            this.txt_object_y.Name = "txt_object_y";
            this.txt_object_y.Size = new System.Drawing.Size(51, 20);
            this.txt_object_y.TabIndex = 31;
            this.txt_object_y.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_object_y_KeyUp);
            // 
            // txt_object_x
            // 
            this.txt_object_x.Location = new System.Drawing.Point(47, 453);
            this.txt_object_x.Name = "txt_object_x";
            this.txt_object_x.Size = new System.Drawing.Size(51, 20);
            this.txt_object_x.TabIndex = 30;
            this.txt_object_x.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_object_x_KeyUp);
            // 
            // lbl_object_w
            // 
            this.lbl_object_w.AutoSize = true;
            this.lbl_object_w.Location = new System.Drawing.Point(9, 561);
            this.lbl_object_w.Name = "lbl_object_w";
            this.lbl_object_w.Size = new System.Drawing.Size(18, 13);
            this.lbl_object_w.TabIndex = 29;
            this.lbl_object_w.Text = "W";
            // 
            // lbl_object_h
            // 
            this.lbl_object_h.AutoSize = true;
            this.lbl_object_h.Location = new System.Drawing.Point(9, 532);
            this.lbl_object_h.Name = "lbl_object_h";
            this.lbl_object_h.Size = new System.Drawing.Size(15, 13);
            this.lbl_object_h.TabIndex = 28;
            this.lbl_object_h.Text = "H";
            // 
            // lbl_object_rotation
            // 
            this.lbl_object_rotation.AutoSize = true;
            this.lbl_object_rotation.Location = new System.Drawing.Point(9, 507);
            this.lbl_object_rotation.Name = "lbl_object_rotation";
            this.lbl_object_rotation.Size = new System.Drawing.Size(24, 13);
            this.lbl_object_rotation.TabIndex = 27;
            this.lbl_object_rotation.Text = "Rot";
            // 
            // lbl_object_y
            // 
            this.lbl_object_y.AutoSize = true;
            this.lbl_object_y.Location = new System.Drawing.Point(9, 481);
            this.lbl_object_y.Name = "lbl_object_y";
            this.lbl_object_y.Size = new System.Drawing.Size(14, 13);
            this.lbl_object_y.TabIndex = 25;
            this.lbl_object_y.Text = "Y";
            // 
            // lbl_object_x
            // 
            this.lbl_object_x.AutoSize = true;
            this.lbl_object_x.Location = new System.Drawing.Point(9, 456);
            this.lbl_object_x.Name = "lbl_object_x";
            this.lbl_object_x.Size = new System.Drawing.Size(14, 13);
            this.lbl_object_x.TabIndex = 24;
            this.lbl_object_x.Text = "X";
            // 
            // cb_drawedge
            // 
            this.cb_drawedge.AutoSize = true;
            this.cb_drawedge.Location = new System.Drawing.Point(9, 268);
            this.cb_drawedge.Name = "cb_drawedge";
            this.cb_drawedge.Size = new System.Drawing.Size(79, 17);
            this.cb_drawedge.TabIndex = 23;
            this.cb_drawedge.Text = "Draw Edge";
            this.cb_drawedge.UseVisualStyleBackColor = true;
            this.cb_drawedge.CheckedChanged += new System.EventHandler(this.cb_drawedge_CheckedChanged);
            // 
            // btn_marker
            // 
            this.btn_marker.Location = new System.Drawing.Point(16, 71);
            this.btn_marker.Name = "btn_marker";
            this.btn_marker.Size = new System.Drawing.Size(71, 23);
            this.btn_marker.TabIndex = 22;
            this.btn_marker.Text = "Marker";
            this.btn_marker.UseVisualStyleBackColor = true;
            this.btn_marker.Click += new System.EventHandler(this.btn_marker_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Delete Layer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Add Layer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_layer
            // 
            this.lbl_layer.AutoSize = true;
            this.lbl_layer.Location = new System.Drawing.Point(6, 346);
            this.lbl_layer.Name = "lbl_layer";
            this.lbl_layer.Size = new System.Drawing.Size(38, 13);
            this.lbl_layer.TabIndex = 17;
            this.lbl_layer.Text = "Layers";
            // 
            // combo_layers
            // 
            this.combo_layers.FormattingEnabled = true;
            this.combo_layers.Location = new System.Drawing.Point(6, 362);
            this.combo_layers.Name = "combo_layers";
            this.combo_layers.Size = new System.Drawing.Size(93, 21);
            this.combo_layers.TabIndex = 16;
            this.combo_layers.SelectedIndexChanged += new System.EventHandler(this.combo_layers_SelectedIndexChanged);
            // 
            // btn_color2
            // 
            this.btn_color2.Location = new System.Drawing.Point(5, 320);
            this.btn_color2.Name = "btn_color2";
            this.btn_color2.Size = new System.Drawing.Size(93, 23);
            this.btn_color2.TabIndex = 15;
            this.btn_color2.Text = "Color 2";
            this.btn_color2.UseVisualStyleBackColor = true;
            this.btn_color2.Click += new System.EventHandler(this.btn_color2_Click);
            // 
            // btn_color1
            // 
            this.btn_color1.Location = new System.Drawing.Point(5, 291);
            this.btn_color1.Name = "btn_color1";
            this.btn_color1.Size = new System.Drawing.Size(93, 23);
            this.btn_color1.TabIndex = 14;
            this.btn_color1.Text = "Color 1";
            this.btn_color1.UseVisualStyleBackColor = true;
            this.btn_color1.Click += new System.EventHandler(this.btn_color1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Edge Options";
            // 
            // lbl_edge_thickness
            // 
            this.lbl_edge_thickness.AutoSize = true;
            this.lbl_edge_thickness.Location = new System.Drawing.Point(9, 184);
            this.lbl_edge_thickness.Name = "lbl_edge_thickness";
            this.lbl_edge_thickness.Size = new System.Drawing.Size(78, 13);
            this.lbl_edge_thickness.TabIndex = 12;
            this.lbl_edge_thickness.Text = "Pen Thickness";
            // 
            // track_pen_thickness
            // 
            this.track_pen_thickness.Location = new System.Drawing.Point(6, 200);
            this.track_pen_thickness.Maximum = 30;
            this.track_pen_thickness.Name = "track_pen_thickness";
            this.track_pen_thickness.Size = new System.Drawing.Size(90, 45);
            this.track_pen_thickness.TabIndex = 10;
            this.track_pen_thickness.Scroll += new System.EventHandler(this.track_pen_thickness_Scroll);
            // 
            // btn_form
            // 
            this.btn_form.Location = new System.Drawing.Point(17, 158);
            this.btn_form.Name = "btn_form";
            this.btn_form.Size = new System.Drawing.Size(71, 23);
            this.btn_form.TabIndex = 9;
            this.btn_form.Text = "Figure";
            this.btn_form.UseVisualStyleBackColor = true;
            this.btn_form.Click += new System.EventHandler(this.btn_form_Click);
            // 
            // btn_pen
            // 
            this.btn_pen.Location = new System.Drawing.Point(16, 42);
            this.btn_pen.Name = "btn_pen";
            this.btn_pen.Size = new System.Drawing.Size(71, 23);
            this.btn_pen.TabIndex = 6;
            this.btn_pen.Text = "Pen";
            this.btn_pen.UseVisualStyleBackColor = true;
            this.btn_pen.Click += new System.EventHandler(this.btn_pen_Click);
            // 
            // btn_erazer
            // 
            this.btn_erazer.Location = new System.Drawing.Point(16, 129);
            this.btn_erazer.Name = "btn_erazer";
            this.btn_erazer.Size = new System.Drawing.Size(71, 23);
            this.btn_erazer.TabIndex = 5;
            this.btn_erazer.Text = "Erazer";
            this.btn_erazer.UseVisualStyleBackColor = true;
            this.btn_erazer.Click += new System.EventHandler(this.btn_erazer_Click);
            // 
            // btn_line
            // 
            this.btn_line.Location = new System.Drawing.Point(16, 100);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(71, 23);
            this.btn_line.TabIndex = 2;
            this.btn_line.Text = "Line";
            this.btn_line.UseVisualStyleBackColor = true;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // btn_pointer
            // 
            this.btn_pointer.Location = new System.Drawing.Point(16, 13);
            this.btn_pointer.Name = "btn_pointer";
            this.btn_pointer.Size = new System.Drawing.Size(71, 23);
            this.btn_pointer.TabIndex = 1;
            this.btn_pointer.Text = "Pointer";
            this.btn_pointer.UseVisualStyleBackColor = true;
            this.btn_pointer.Click += new System.EventHandler(this.btn_pointer_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picture_canvas);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(104, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 604);
            this.panel2.TabIndex = 2;
            // 
            // picture_canvas
            // 
            this.picture_canvas.BackColor = System.Drawing.Color.Transparent;
            this.picture_canvas.Location = new System.Drawing.Point(0, 0);
            this.picture_canvas.Name = "picture_canvas";
            this.picture_canvas.Size = new System.Drawing.Size(100, 50);
            this.picture_canvas.TabIndex = 1;
            this.picture_canvas.TabStop = false;
            this.picture_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_canvas_Paint);
            this.picture_canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_canvas_MouseDown);
            this.picture_canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_canvas_MouseMove);
            this.picture_canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_canvas_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(728, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(832, 628);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Курсовая работа";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_pen_thickness)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_layer;
        private System.Windows.Forms.ComboBox combo_layers;
        private System.Windows.Forms.Button btn_color2;
        private System.Windows.Forms.Button btn_color1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_edge_thickness;
        private System.Windows.Forms.TrackBar track_pen_thickness;
        private System.Windows.Forms.Button btn_form;
        private System.Windows.Forms.Button btn_pen;
        private System.Windows.Forms.Button btn_erazer;
        private System.Windows.Forms.Button btn_line;
        private System.Windows.Forms.Button btn_pointer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.PictureBox picture_canvas;
        private System.Windows.Forms.Button btn_marker;
        private System.Windows.Forms.CheckBox cb_drawedge;
        private System.Windows.Forms.Label lbl_object_w;
        private System.Windows.Forms.Label lbl_object_h;
        private System.Windows.Forms.Label lbl_object_rotation;
        private System.Windows.Forms.Label lbl_object_y;
        private System.Windows.Forms.Label lbl_object_x;
        private System.Windows.Forms.TextBox txt_object_w;
        private System.Windows.Forms.TextBox txt_object_h;
        private System.Windows.Forms.TextBox txt_object_rot;
        private System.Windows.Forms.TextBox txt_object_y;
        private System.Windows.Forms.TextBox txt_object_x;
		private System.Windows.Forms.CheckBox chk_debug;
	}
}

