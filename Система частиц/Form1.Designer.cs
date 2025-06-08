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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbSpeed = new TrackBar();
            label5 = new Label();
            colorDialog1 = new ColorDialog();
            btnChooseColor = new Button();
            pause = new Button();
            checkBox1 = new CheckBox();
            trackBar1 = new TrackBar();
            label6 = new Label();
            trackBar2 = new TrackBar();
            label7 = new Label();
            checkBox2 = new CheckBox();
            button1 = new Button();
            checkBox3 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(12, 12);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(776, 733);
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
            tbDirection.Location = new Point(803, 113);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(232, 56);
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
            tbGraviton.Location = new Point(832, 196);
            tbGraviton.Maximum = 100;
            tbGraviton.Name = "tbGraviton";
            tbGraviton.Size = new Size(181, 56);
            tbGraviton.TabIndex = 3;
            tbGraviton.Scroll += tbGraviton_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift Condensed", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(884, 12);
            label1.Name = "label1";
            label1.Size = new Size(83, 41);
            label1.TabIndex = 5;
            label1.Text = "Меню";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(880, 89);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 6;
            label2.Text = "Направление";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(868, 172);
            label3.Name = "label3";
            label3.Size = new Size(110, 21);
            label3.TabIndex = 7;
            label3.Text = "Размер гравитона";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(803, 53);
            label4.Name = "label4";
            label4.Size = new Size(194, 20);
            label4.TabIndex = 8;
            label4.Text = "Общее количество частиц:";
            label4.Click += label4_Click;
            // 
            // tbSpeed
            // 
            tbSpeed.Location = new Point(803, 275);
            tbSpeed.Maximum = 100;
            tbSpeed.Name = "tbSpeed";
            tbSpeed.Size = new Size(232, 56);
            tbSpeed.TabIndex = 10;
            tbSpeed.Scroll += tbSpeed_Scroll;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(884, 251);
            label5.Name = "label5";
            label5.Size = new Size(60, 21);
            label5.TabIndex = 11;
            label5.Text = "Скорость";
            // 
            // btnChooseColor
            // 
            btnChooseColor.Location = new Point(810, 490);
            btnChooseColor.Name = "btnChooseColor";
            btnChooseColor.Size = new Size(225, 29);
            btnChooseColor.TabIndex = 12;
            btnChooseColor.Text = "Изменение цвета гравитона";
            btnChooseColor.UseVisualStyleBackColor = true;
            btnChooseColor.Click += btnChooseColor_Click;
            // 
            // pause
            // 
            pause.Location = new Point(384, 751);
            pause.Name = "pause";
            pause.Size = new Size(94, 29);
            pause.TabIndex = 13;
            pause.Text = "Пауза";
            pause.UseVisualStyleBackColor = true;
            pause.Click += pause_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(866, 537);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(123, 24);
            checkBox1.TabIndex = 15;
            checkBox1.Text = "Черная дыра";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(810, 346);
            trackBar1.Maximum = 360;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(225, 56);
            trackBar1.TabIndex = 16;
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bahnschrift Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(866, 322);
            label6.Name = "label6";
            label6.Size = new Size(101, 21);
            label6.TabIndex = 17;
            label6.Text = "Распределение";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(839, 428);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(165, 56);
            trackBar2.TabIndex = 18;
            trackBar2.Value = 2;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bahnschrift Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(877, 404);
            label7.Name = "label7";
            label7.Size = new Size(90, 21);
            label7.TabIndex = 19;
            label7.Text = "Время жизни: ";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(810, 567);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(248, 24);
            checkBox2.TabIndex = 20;
            checkBox2.Text = "Точки перекрашивания частиц";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(874, 597);
            button1.Name = "button1";
            button1.Size = new Size(139, 29);
            button1.TabIndex = 21;
            button1.Text = "Поменять цвет";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(868, 648);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(129, 24);
            checkBox3.TabIndex = 22;
            checkBox3.Text = "Антигравитон";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 792);
            Controls.Add(checkBox3);
            Controls.Add(button1);
            Controls.Add(checkBox2);
            Controls.Add(label7);
            Controls.Add(trackBar2);
            Controls.Add(label6);
            Controls.Add(trackBar1);
            Controls.Add(checkBox1);
            Controls.Add(pause);
            Controls.Add(btnChooseColor);
            Controls.Add(label5);
            Controls.Add(tbSpeed);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbGraviton);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Система частиц";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private Label lblDirection;
        private TrackBar tbGraviton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TrackBar tbSpeed;
        private Label label5;
        private ColorDialog colorDialog1;
        private Button btnChooseColor;
        private Button pause;
        private CheckBox checkBox1;
        private TrackBar trackBar1;
        private Label label6;
        private TrackBar trackBar2;
        private Label label7;
        private CheckBox checkBox2;
        private Button button1;
        private CheckBox checkBox3;
    }
}
