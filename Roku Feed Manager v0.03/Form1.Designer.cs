namespace Roku_Feed_Manager_v0._03
{
    partial class FRMmain
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
            BTNGo = new Button();
            TXToutput = new TextBox();
            SuspendLayout();
            // 
            // BTNGo
            // 
            BTNGo.Location = new Point(3, 3);
            BTNGo.Name = "BTNGo";
            BTNGo.Size = new Size(188, 58);
            BTNGo.TabIndex = 0;
            BTNGo.Text = "&Go";
            BTNGo.UseVisualStyleBackColor = true;
            // 
            // TXToutput
            // 
            TXToutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TXToutput.Location = new Point(12, 68);
            TXToutput.Multiline = true;
            TXToutput.Name = "TXToutput";
            TXToutput.ScrollBars = ScrollBars.Both;
            TXToutput.Size = new Size(2032, 775);
            TXToutput.TabIndex = 1;
            // 
            // FRMmain
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2054, 855);
            Controls.Add(TXToutput);
            Controls.Add(BTNGo);
            Name = "FRMmain";
            Text = "Roku Feed Manager v0.03";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTNGo;
        private TextBox TXToutput;
    }
}
