namespace SwagClicker
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
            this.btnChoose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudUpdateTime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApplyUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(12, 12);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(260, 23);
            this.btnChoose.TabIndex = 0;
            this.btnChoose.Text = "Save Script";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Choose Script";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "[HOME] keyboard button sto start/stop recording";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "[PAGE UP] keyboard key to start/stop the script";
            // 
            // nudUpdateTime
            // 
            this.nudUpdateTime.Location = new System.Drawing.Point(12, 229);
            this.nudUpdateTime.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudUpdateTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUpdateTime.Name = "nudUpdateTime";
            this.nudUpdateTime.Size = new System.Drawing.Size(120, 20);
            this.nudUpdateTime.TabIndex = 5;
            this.nudUpdateTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudUpdateTime.ValueChanged += new System.EventHandler(this.nudUpdateTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Recording/Playback update time in milliseconds";
            // 
            // btnApplyUpdate
            // 
            this.btnApplyUpdate.Location = new System.Drawing.Point(139, 225);
            this.btnApplyUpdate.Name = "btnApplyUpdate";
            this.btnApplyUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnApplyUpdate.TabIndex = 7;
            this.btnApplyUpdate.Text = "Apply";
            this.btnApplyUpdate.UseVisualStyleBackColor = true;
            this.btnApplyUpdate.Click += new System.EventHandler(this.btnApplyUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnApplyUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudUpdateTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnChoose);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudUpdateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApplyUpdate;
    }
}

