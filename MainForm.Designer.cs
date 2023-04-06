namespace PPVC_Drawing
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_createDrawing = new System.Windows.Forms.Button();
            this.btn_setAssembly = new System.Windows.Forms.Button();
            this.cbo_castUnitDrawingTemplate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_drawingName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_title1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_title2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_title3 = new System.Windows.Forms.TextBox();
            this.cb_createDrawing = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_createDrawing
            // 
            this.btn_createDrawing.Location = new System.Drawing.Point(298, 112);
            this.btn_createDrawing.Name = "btn_createDrawing";
            this.btn_createDrawing.Size = new System.Drawing.Size(103, 46);
            this.btn_createDrawing.TabIndex = 0;
            this.btn_createDrawing.Text = "Create Drawing";
            this.btn_createDrawing.UseVisualStyleBackColor = true;
            this.btn_createDrawing.Click += new System.EventHandler(this.btn_createDrawing_Click);
            // 
            // btn_setAssembly
            // 
            this.btn_setAssembly.Location = new System.Drawing.Point(298, 24);
            this.btn_setAssembly.Name = "btn_setAssembly";
            this.btn_setAssembly.Size = new System.Drawing.Size(103, 47);
            this.btn_setAssembly.TabIndex = 1;
            this.btn_setAssembly.Text = "Set Assembly";
            this.btn_setAssembly.UseVisualStyleBackColor = true;
            this.btn_setAssembly.Click += new System.EventHandler(this.btn_setAssembly_Click);
            // 
            // cbo_castUnitDrawingTemplate
            // 
            this.cbo_castUnitDrawingTemplate.FormattingEnabled = true;
            this.cbo_castUnitDrawingTemplate.Location = new System.Drawing.Point(15, 25);
            this.cbo_castUnitDrawingTemplate.Name = "cbo_castUnitDrawingTemplate";
            this.cbo_castUnitDrawingTemplate.Size = new System.Drawing.Size(229, 21);
            this.cbo_castUnitDrawingTemplate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cast Unit Drawing Template";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Drawing Name";
            // 
            // tb_drawingName
            // 
            this.tb_drawingName.Location = new System.Drawing.Point(15, 74);
            this.tb_drawingName.Name = "tb_drawingName";
            this.tb_drawingName.Size = new System.Drawing.Size(229, 20);
            this.tb_drawingName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Title 1";
            // 
            // tb_title1
            // 
            this.tb_title1.Location = new System.Drawing.Point(15, 124);
            this.tb_title1.Name = "tb_title1";
            this.tb_title1.Size = new System.Drawing.Size(229, 20);
            this.tb_title1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Title 2";
            // 
            // tb_title2
            // 
            this.tb_title2.Location = new System.Drawing.Point(15, 175);
            this.tb_title2.Name = "tb_title2";
            this.tb_title2.Size = new System.Drawing.Size(229, 20);
            this.tb_title2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Title 3";
            // 
            // tb_title3
            // 
            this.tb_title3.Location = new System.Drawing.Point(15, 225);
            this.tb_title3.Name = "tb_title3";
            this.tb_title3.Size = new System.Drawing.Size(229, 20);
            this.tb_title3.TabIndex = 6;
            // 
            // cb_createDrawing
            // 
            this.cb_createDrawing.AutoSize = true;
            this.cb_createDrawing.Checked = true;
            this.cb_createDrawing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_createDrawing.Cursor = System.Windows.Forms.Cursors.Default;
            this.cb_createDrawing.Location = new System.Drawing.Point(298, 89);
            this.cb_createDrawing.Name = "cb_createDrawing";
            this.cb_createDrawing.Size = new System.Drawing.Size(92, 17);
            this.cb_createDrawing.TabIndex = 7;
            this.cb_createDrawing.Text = "open Drawing";
            this.cb_createDrawing.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 378);
            this.Controls.Add(this.cb_createDrawing);
            this.Controls.Add(this.tb_title3);
            this.Controls.Add(this.tb_title2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_title1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_drawingName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_castUnitDrawingTemplate);
            this.Controls.Add(this.btn_setAssembly);
            this.Controls.Add(this.btn_createDrawing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_createDrawing;
        private System.Windows.Forms.Button btn_setAssembly;
        private System.Windows.Forms.ComboBox cbo_castUnitDrawingTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_drawingName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_title1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_title2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_title3;
        private System.Windows.Forms.CheckBox cb_createDrawing;
    }
}

