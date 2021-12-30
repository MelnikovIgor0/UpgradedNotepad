
namespace WindowsFormsAppUpgradedNotepad
{
    partial class FormSetAutoSaveInterval
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
            this.trackBarTime = new System.Windows.Forms.TrackBar();
            this.labelInterval = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarTime
            // 
            this.trackBarTime.Location = new System.Drawing.Point(12, 12);
            this.trackBarTime.Maximum = 10000;
            this.trackBarTime.Minimum = -80000;
            this.trackBarTime.Name = "trackBarTime";
            this.trackBarTime.Size = new System.Drawing.Size(421, 56);
            this.trackBarTime.TabIndex = 0;
            this.trackBarTime.Value = -80000;
            this.trackBarTime.ValueChanged += new System.EventHandler(this.trackBarTime_ValueChanged);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInterval.Location = new System.Drawing.Point(12, 42);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(373, 38);
            this.labelInterval.TabIndex = 1;
            this.labelInterval.Text = "сохранение раз в 10 секунд";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 84);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(171, 42);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить настройки";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(262, 84);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(171, 42);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormSetAutoSaveInterval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 141);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.trackBarTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(485, 188);
            this.MinimumSize = new System.Drawing.Size(463, 188);
            this.Name = "FormSetAutoSaveInterval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки автосохранения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetAutoSaveInterval_FormClosing);
            this.Load += new System.EventHandler(this.FormSetAutoSaveInterval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarTime;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}