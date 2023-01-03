namespace object_to_textbox
{
    partial class MainForm
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
            this.buttonShowObjectInTextbox = new System.Windows.Forms.Button();
            this.textBoxMultiline = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.buttonShowObjectInTextbox.Location = new System.Drawing.Point(12, 31);
            this.buttonShowObjectInTextbox.Name = "button1";
            this.buttonShowObjectInTextbox.Size = new System.Drawing.Size(159, 23);
            this.buttonShowObjectInTextbox.TabIndex = 0;
            this.buttonShowObjectInTextbox.Text = "Show Aircraft In Textbox";
            this.buttonShowObjectInTextbox.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBoxMultiline.Location = new System.Drawing.Point(226, 27);
            this.textBoxMultiline.Multiline = true;
            this.textBoxMultiline.Name = "textBox1";
            this.textBoxMultiline.Size = new System.Drawing.Size(235, 217);
            this.textBoxMultiline.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.textBoxMultiline);
            this.Controls.Add(this.buttonShowObjectInTextbox);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonShowObjectInTextbox;
        private TextBox textBoxMultiline;
    }
}