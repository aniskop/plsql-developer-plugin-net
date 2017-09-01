namespace DemoPluginNet
{
    partial class DemoForm
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
            this.NewSqlWindowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewSqlWindowButton
            // 
            this.NewSqlWindowButton.Location = new System.Drawing.Point(12, 12);
            this.NewSqlWindowButton.Name = "NewSqlWindowButton";
            this.NewSqlWindowButton.Size = new System.Drawing.Size(260, 23);
            this.NewSqlWindowButton.TabIndex = 0;
            this.NewSqlWindowButton.Text = "Create SQL window";
            this.NewSqlWindowButton.UseVisualStyleBackColor = true;
            this.NewSqlWindowButton.Click += new System.EventHandler(this.NewSqlWindowButton_Click);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.NewSqlWindowButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DemoForm";
            this.Text = "DemoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewSqlWindowButton;
    }
}