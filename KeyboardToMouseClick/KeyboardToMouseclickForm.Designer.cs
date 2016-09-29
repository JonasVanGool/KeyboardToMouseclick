using System.Windows.Forms;
namespace KeyboardToMouseClick
{
    partial class KeyboardToMouseclickForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardToMouseclickForm));
            this.btn_TeachMode = new System.Windows.Forms.Button();
            this.btn_RunMode = new System.Windows.Forms.Button();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.btn_ClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_TeachMode
            // 
            this.btn_TeachMode.Location = new System.Drawing.Point(13, 12);
            this.btn_TeachMode.Name = "btn_TeachMode";
            this.btn_TeachMode.Size = new System.Drawing.Size(144, 23);
            this.btn_TeachMode.TabIndex = 0;
            this.btn_TeachMode.TabStop = false;
            this.btn_TeachMode.Text = "Teach";
            this.btn_TeachMode.UseVisualStyleBackColor = true;
            this.btn_TeachMode.Click += new System.EventHandler(this.btn_TeachMode_Click);
            // 
            // btn_RunMode
            // 
            this.btn_RunMode.Location = new System.Drawing.Point(325, 12);
            this.btn_RunMode.Name = "btn_RunMode";
            this.btn_RunMode.Size = new System.Drawing.Size(150, 23);
            this.btn_RunMode.TabIndex = 1;
            this.btn_RunMode.TabStop = false;
            this.btn_RunMode.Text = "Run";
            this.btn_RunMode.UseVisualStyleBackColor = true;
            this.btn_RunMode.Click += new System.EventHandler(this.btn_RunMode_Click);
            // 
            // lbl_Info
            // 
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Location = new System.Drawing.Point(13, 43);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(25, 13);
            this.lbl_Info.TabIndex = 2;
            this.lbl_Info.Text = "Info";
            // 
            // btn_ClearAll
            // 
            this.btn_ClearAll.Location = new System.Drawing.Point(163, 12);
            this.btn_ClearAll.Name = "btn_ClearAll";
            this.btn_ClearAll.Size = new System.Drawing.Size(156, 23);
            this.btn_ClearAll.TabIndex = 3;
            this.btn_ClearAll.TabStop = false;
            this.btn_ClearAll.Text = "Clear All";
            this.btn_ClearAll.UseVisualStyleBackColor = true;
            this.btn_ClearAll.Click += new System.EventHandler(this.btn_ClearAll_Click);
            // 
            // KeyboardToMouseclickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 63);
            this.Controls.Add(this.btn_ClearAll);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.btn_RunMode);
            this.Controls.Add(this.btn_TeachMode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "KeyboardToMouseclickForm";
            this.Text = "Keyboard to Mouseclick";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btn_TeachMode;
        private System.Windows.Forms.Button btn_RunMode;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Button btn_ClearAll;
    }
}

