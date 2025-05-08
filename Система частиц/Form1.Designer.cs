namespace Система_частиц
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            picDisplay = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tbDirection = new TrackBar();
            lblDirection = new Label();
            tbGraviton = new TrackBar();
            tbGraviton1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton1).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(12, 12);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(776, 426);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(12, 458);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(240, 56);
            tbDirection.TabIndex = 1;
            tbDirection.Scroll += tbDirection_Scroll_1;
            // 
            // lblDirection
            // 
            lblDirection.AutoSize = true;
            lblDirection.Location = new Point(258, 474);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(0, 20);
            lblDirection.TabIndex = 2;
            // 
            // tbGraviton
            // 
            tbGraviton.Location = new Point(452, 458);
            tbGraviton.Maximum = 100;
            tbGraviton.Name = "tbGraviton";
            tbGraviton.Size = new Size(130, 56);
            tbGraviton.TabIndex = 3;
            tbGraviton.Scroll += tbGraviton_Scroll;
            // 
            // tbGraviton1
            // 
            tbGraviton1.Location = new Point(643, 458);
            tbGraviton1.Maximum = 100;
            tbGraviton1.Name = "tbGraviton1";
            tbGraviton1.Size = new Size(130, 56);
            tbGraviton1.TabIndex = 4;
            tbGraviton1.Scroll += tbGraviton1_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 526);
            Controls.Add(tbGraviton1);
            Controls.Add(tbGraviton);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private Label lblDirection;
        private TrackBar tbGraviton;
        private TrackBar tbGraviton1;
    }
}
