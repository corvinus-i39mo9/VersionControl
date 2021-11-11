
namespace i39mo9_week08_irf
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonCar = new System.Windows.Forms.Button();
            this.buttonBall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSzinvalaszto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(1, 212);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(801, 100);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // buttonCar
            // 
            this.buttonCar.Location = new System.Drawing.Point(12, 12);
            this.buttonCar.Name = "buttonCar";
            this.buttonCar.Size = new System.Drawing.Size(75, 23);
            this.buttonCar.TabIndex = 1;
            this.buttonCar.Text = "CAR";
            this.buttonCar.UseVisualStyleBackColor = true;
            this.buttonCar.Click += new System.EventHandler(this.buttonCar_Click);
            // 
            // buttonBall
            // 
            this.buttonBall.Location = new System.Drawing.Point(12, 43);
            this.buttonBall.Name = "buttonBall";
            this.buttonBall.Size = new System.Drawing.Size(75, 23);
            this.buttonBall.TabIndex = 2;
            this.buttonBall.Text = "BALL";
            this.buttonBall.UseVisualStyleBackColor = true;
            this.buttonBall.Click += new System.EventHandler(this.buttonBall_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Coming next:";
            // 
            // buttonSzinvalaszto
            // 
            this.buttonSzinvalaszto.BackColor = System.Drawing.Color.Yellow;
            this.buttonSzinvalaszto.Location = new System.Drawing.Point(12, 100);
            this.buttonSzinvalaszto.Name = "buttonSzinvalaszto";
            this.buttonSzinvalaszto.Size = new System.Drawing.Size(75, 52);
            this.buttonSzinvalaszto.TabIndex = 4;
            this.buttonSzinvalaszto.UseVisualStyleBackColor = false;
            this.buttonSzinvalaszto.Click += new System.EventHandler(this.buttonSzinvalaszto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 311);
            this.Controls.Add(this.buttonSzinvalaszto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBall);
            this.Controls.Add(this.buttonCar);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button buttonCar;
        private System.Windows.Forms.Button buttonBall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSzinvalaszto;
    }
}

