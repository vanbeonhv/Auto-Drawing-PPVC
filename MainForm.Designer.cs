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
            this.btn_getModel = new System.Windows.Forms.Button();
            this.btn_setAssembly = new System.Windows.Forms.Button();
            this.cbo_castUnitDrawingTemplate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_getModel
            // 
            this.btn_getModel.Location = new System.Drawing.Point(225, 202);
            this.btn_getModel.Name = "btn_getModel";
            this.btn_getModel.Size = new System.Drawing.Size(122, 46);
            this.btn_getModel.TabIndex = 0;
            this.btn_getModel.Text = "Pick Model";
            this.btn_getModel.UseVisualStyleBackColor = true;
            this.btn_getModel.Click += new System.EventHandler(this.btn_getModel_Click);
            // 
            // btn_setAssembly
            // 
            this.btn_setAssembly.Location = new System.Drawing.Point(96, 201);
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
            this.cbo_castUnitDrawingTemplate.Location = new System.Drawing.Point(12, 34);
            this.cbo_castUnitDrawingTemplate.Name = "cbo_castUnitDrawingTemplate";
            this.cbo_castUnitDrawingTemplate.Size = new System.Drawing.Size(139, 21);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 298);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_castUnitDrawingTemplate);
            this.Controls.Add(this.btn_setAssembly);
            this.Controls.Add(this.btn_getModel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_getModel;
        private System.Windows.Forms.Button btn_setAssembly;
        private System.Windows.Forms.ComboBox cbo_castUnitDrawingTemplate;
        private System.Windows.Forms.Label label1;
    }
}

