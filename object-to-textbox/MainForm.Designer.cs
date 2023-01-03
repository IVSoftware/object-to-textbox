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
            this.aircraftDetails = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonShowObjectInTextbox
            // 
            this.buttonShowObjectInTextbox.Location = new System.Drawing.Point(12, 19);
            this.buttonShowObjectInTextbox.Name = "buttonShowObjectInTextbox";
            this.buttonShowObjectInTextbox.Size = new System.Drawing.Size(159, 23);
            this.buttonShowObjectInTextbox.TabIndex = 0;
            this.buttonShowObjectInTextbox.Text = "Show Aircraft In Textbox";
            this.buttonShowObjectInTextbox.UseVisualStyleBackColor = true;
            // 
            // textBoxMultiline
            // 
            this.textBoxMultiline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMultiline.Location = new System.Drawing.Point(185, 20);
            this.textBoxMultiline.Multiline = true;
            this.textBoxMultiline.Name = "textBoxMultiline";
            this.textBoxMultiline.Size = new System.Drawing.Size(215, 151);
            this.textBoxMultiline.TabIndex = 1;
            // 
            // listBox1
            // 
            this.aircraftDetails.FormattingEnabled = true;
            this.aircraftDetails.ItemHeight = 15;
            this.aircraftDetails.Location = new System.Drawing.Point(12, 62);
            this.aircraftDetails.Name = "listBox1";
            this.aircraftDetails.Size = new System.Drawing.Size(159, 109);
            this.aircraftDetails.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 195);
            this.Controls.Add(this.aircraftDetails);
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
        private ListBox aircraftDetails;
    }
}