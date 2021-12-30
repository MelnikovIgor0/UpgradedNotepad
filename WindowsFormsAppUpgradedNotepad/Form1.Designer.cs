
namespace WindowsFormsAppUpgradedNotepad
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCloseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripOpenNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripChange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCopy2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCut2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPaste2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSelectAll2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBold = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItalics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUnderlined = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStrikeThrough = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripChangeFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSetSaveInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripChangeTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.timerAutoSave = new System.Windows.Forms.Timer(this.components);
            this.timerThemeUpdate = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBold2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripItalics2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUnderlined2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStrikeThrough2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFile,
            this.toolStripChange,
            this.toolStripFormat,
            this.toolStripSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.menuStrip1_KeyDown);
            // 
            // toolStripFile
            // 
            this.toolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpen,
            this.toolStripCreate,
            this.toolStripSave,
            this.toolStripCloseTab,
            this.toolStripOpenNew});
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Size = new System.Drawing.Size(59, 24);
            this.toolStripFile.Text = "Файл";
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.ShortcutKeyDisplayString = "ctrl+o";
            this.toolStripOpen.Size = new System.Drawing.Size(341, 26);
            this.toolStripOpen.Text = "Открыть";
            this.toolStripOpen.Click += new System.EventHandler(this.ToolStripOpen_Click);
            // 
            // toolStripCreate
            // 
            this.toolStripCreate.Name = "toolStripCreate";
            this.toolStripCreate.ShortcutKeyDisplayString = "ctrl+n";
            this.toolStripCreate.Size = new System.Drawing.Size(341, 26);
            this.toolStripCreate.Text = "Создать";
            this.toolStripCreate.Click += new System.EventHandler(this.ToolStripCreate_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.ShortcutKeyDisplayString = "ctrl+s";
            this.toolStripSave.Size = new System.Drawing.Size(341, 26);
            this.toolStripSave.Text = "Сохранить";
            this.toolStripSave.Click += new System.EventHandler(this.ToolStripSave_Click);
            // 
            // toolStripCloseTab
            // 
            this.toolStripCloseTab.Name = "toolStripCloseTab";
            this.toolStripCloseTab.ShortcutKeyDisplayString = "ctrl+e";
            this.toolStripCloseTab.Size = new System.Drawing.Size(341, 26);
            this.toolStripCloseTab.Text = "Закрыть текущую вкладку";
            this.toolStripCloseTab.Click += new System.EventHandler(this.ToolStripCloseTab_Click);
            // 
            // toolStripOpenNew
            // 
            this.toolStripOpenNew.Name = "toolStripOpenNew";
            this.toolStripOpenNew.ShortcutKeyDisplayString = "ctrl + alt + o";
            this.toolStripOpenNew.Size = new System.Drawing.Size(341, 26);
            this.toolStripOpenNew.Text = "Открыть в новом окне";
            this.toolStripOpenNew.Click += new System.EventHandler(this.ToolStripOpenNew_Click);
            // 
            // toolStripChange
            // 
            this.toolStripChange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCopy2,
            this.toolStripCut2,
            this.toolStripPaste2,
            this.toolStripSelectAll2});
            this.toolStripChange.Name = "toolStripChange";
            this.toolStripChange.Size = new System.Drawing.Size(74, 24);
            this.toolStripChange.Text = "Правка";
            // 
            // toolStripCopy2
            // 
            this.toolStripCopy2.Name = "toolStripCopy2";
            this.toolStripCopy2.Size = new System.Drawing.Size(179, 26);
            this.toolStripCopy2.Text = "Копировать";
            this.toolStripCopy2.Click += new System.EventHandler(this.ToolStripCopy_Click);
            // 
            // toolStripCut2
            // 
            this.toolStripCut2.Name = "toolStripCut2";
            this.toolStripCut2.Size = new System.Drawing.Size(179, 26);
            this.toolStripCut2.Text = "Вырезать";
            this.toolStripCut2.Click += new System.EventHandler(this.ToolStripCut_Click);
            // 
            // toolStripPaste2
            // 
            this.toolStripPaste2.Name = "toolStripPaste2";
            this.toolStripPaste2.Size = new System.Drawing.Size(179, 26);
            this.toolStripPaste2.Text = "Вставить";
            this.toolStripPaste2.Click += new System.EventHandler(this.ToolStripPaste_Click);
            // 
            // toolStripSelectAll2
            // 
            this.toolStripSelectAll2.Name = "toolStripSelectAll2";
            this.toolStripSelectAll2.Size = new System.Drawing.Size(179, 26);
            this.toolStripSelectAll2.Text = "Выбрать всё";
            this.toolStripSelectAll2.Click += new System.EventHandler(this.ToolStripAll_Click);
            // 
            // toolStripFormat
            // 
            this.toolStripFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBold,
            this.toolStripItalics,
            this.toolStripUnderlined,
            this.toolStripStrikeThrough,
            this.toolStripChangeFont});
            this.toolStripFormat.Name = "toolStripFormat";
            this.toolStripFormat.Size = new System.Drawing.Size(77, 24);
            this.toolStripFormat.Text = "Формат";
            // 
            // toolStripBold
            // 
            this.toolStripBold.Name = "toolStripBold";
            this.toolStripBold.Size = new System.Drawing.Size(194, 26);
            this.toolStripBold.Text = "Жирный";
            this.toolStripBold.Click += new System.EventHandler(this.ToolStripBold_Click);
            // 
            // toolStripItalics
            // 
            this.toolStripItalics.Name = "toolStripItalics";
            this.toolStripItalics.Size = new System.Drawing.Size(194, 26);
            this.toolStripItalics.Text = "Курсив";
            this.toolStripItalics.Click += new System.EventHandler(this.ToolStripItalics_Click);
            // 
            // toolStripUnderlined
            // 
            this.toolStripUnderlined.Name = "toolStripUnderlined";
            this.toolStripUnderlined.Size = new System.Drawing.Size(194, 26);
            this.toolStripUnderlined.Text = "Подчёркнутый";
            this.toolStripUnderlined.Click += new System.EventHandler(this.ToolStripUnderlined_Click);
            // 
            // toolStripStrikeThrough
            // 
            this.toolStripStrikeThrough.Name = "toolStripStrikeThrough";
            this.toolStripStrikeThrough.Size = new System.Drawing.Size(194, 26);
            this.toolStripStrikeThrough.Text = "Зачёркнутый";
            this.toolStripStrikeThrough.Click += new System.EventHandler(this.ToolStripStrikeThrough_Click);
            // 
            // toolStripChangeFont
            // 
            this.toolStripChangeFont.Name = "toolStripChangeFont";
            this.toolStripChangeFont.Size = new System.Drawing.Size(194, 26);
            this.toolStripChangeFont.Text = "Шрифт";
            this.toolStripChangeFont.Click += new System.EventHandler(this.ToolStripChangeFont_Click);
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSetSaveInterval,
            this.toolStripChangeTheme});
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(98, 24);
            this.toolStripSettings.Text = "Настройки";
            // 
            // toolStripSetSaveInterval
            // 
            this.toolStripSetSaveInterval.Name = "toolStripSetSaveInterval";
            this.toolStripSetSaveInterval.Size = new System.Drawing.Size(264, 26);
            this.toolStripSetSaveInterval.Text = "Частота автосохранения";
            this.toolStripSetSaveInterval.Click += new System.EventHandler(this.ToolStripSetSaveInterval_Click);
            // 
            // toolStripChangeTheme
            // 
            this.toolStripChangeTheme.Name = "toolStripChangeTheme";
            this.toolStripChangeTheme.Size = new System.Drawing.Size(264, 26);
            this.toolStripChangeTheme.Text = "Сменить тему";
            this.toolStripChangeTheme.Click += new System.EventHandler(this.ToolStripChangeTheme_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(707, 31);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Deselecting);
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMain.Location = new System.Drawing.Point(0, 59);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.ShortcutsEnabled = false;
            this.richTextBoxMain.Size = new System.Drawing.Size(707, 328);
            this.richTextBoxMain.TabIndex = 2;
            this.richTextBoxMain.Text = "";
            this.richTextBoxMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxMain_KeyDown);
            this.richTextBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBoxMain_MouseUp);
            // 
            // timerAutoSave
            // 
            this.timerAutoSave.Tick += new System.EventHandler(this.timerAutoSave_Tick);
            // 
            // timerThemeUpdate
            // 
            this.timerThemeUpdate.Enabled = true;
            this.timerThemeUpdate.Tick += new System.EventHandler(this.timerThemeUpdate_Tick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCopy,
            this.toolStripCut,
            this.toolStripPaste,
            this.toolStripAll,
            this.toolStripBold2,
            this.toolStripItalics2,
            this.toolStripUnderlined2,
            this.toolStripStrikeThrough2});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 196);
            // 
            // toolStripCopy
            // 
            this.toolStripCopy.Name = "toolStripCopy";
            this.toolStripCopy.Size = new System.Drawing.Size(180, 24);
            this.toolStripCopy.Text = "Копировать";
            this.toolStripCopy.Click += new System.EventHandler(this.ToolStripCopy_Click);
            // 
            // toolStripCut
            // 
            this.toolStripCut.Name = "toolStripCut";
            this.toolStripCut.Size = new System.Drawing.Size(180, 24);
            this.toolStripCut.Text = "Вырезать";
            this.toolStripCut.Click += new System.EventHandler(this.ToolStripCut_Click);
            // 
            // toolStripPaste
            // 
            this.toolStripPaste.Name = "toolStripPaste";
            this.toolStripPaste.Size = new System.Drawing.Size(180, 24);
            this.toolStripPaste.Text = "Вставить";
            this.toolStripPaste.Click += new System.EventHandler(this.ToolStripPaste_Click);
            // 
            // toolStripAll
            // 
            this.toolStripAll.Name = "toolStripAll";
            this.toolStripAll.Size = new System.Drawing.Size(180, 24);
            this.toolStripAll.Text = "Выбрать всё";
            this.toolStripAll.Click += new System.EventHandler(this.ToolStripAll_Click);
            // 
            // toolStripBold2
            // 
            this.toolStripBold2.Name = "toolStripBold2";
            this.toolStripBold2.Size = new System.Drawing.Size(180, 24);
            this.toolStripBold2.Text = "Жирный";
            this.toolStripBold2.Click += new System.EventHandler(this.ToolStripBold_Click);
            // 
            // toolStripItalics2
            // 
            this.toolStripItalics2.Name = "toolStripItalics2";
            this.toolStripItalics2.Size = new System.Drawing.Size(180, 24);
            this.toolStripItalics2.Text = "Курсив";
            this.toolStripItalics2.Click += new System.EventHandler(this.ToolStripItalics_Click);
            // 
            // toolStripUnderlined2
            // 
            this.toolStripUnderlined2.Name = "toolStripUnderlined2";
            this.toolStripUnderlined2.Size = new System.Drawing.Size(180, 24);
            this.toolStripUnderlined2.Text = "Подчёркнутый";
            this.toolStripUnderlined2.Click += new System.EventHandler(this.ToolStripUnderlined_Click);
            // 
            // toolStripStrikeThrough2
            // 
            this.toolStripStrikeThrough2.Name = "toolStripStrikeThrough2";
            this.toolStripStrikeThrough2.Size = new System.Drawing.Size(180, 24);
            this.toolStripStrikeThrough2.Text = "Зачёркнутый";
            this.toolStripStrikeThrough2.Click += new System.EventHandler(this.ToolStripStrikeThrough_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 387);
            this.Controls.Add(this.richTextBoxMain);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upgraded notepad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripChange;
        private System.Windows.Forms.ToolStripMenuItem toolStripOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripCreate;
        private System.Windows.Forms.ToolStripMenuItem toolStripSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripFormat;
        private System.Windows.Forms.ToolStripMenuItem toolStripSettings;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.RichTextBox richTextBoxMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripSetSaveInterval;
        private System.Windows.Forms.Timer timerAutoSave;
        private System.Windows.Forms.Timer timerThemeUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripChangeTheme;
        private System.Windows.Forms.ToolStripMenuItem toolStripBold;
        private System.Windows.Forms.ToolStripMenuItem toolStripItalics;
        private System.Windows.Forms.ToolStripMenuItem toolStripUnderlined;
        private System.Windows.Forms.ToolStripMenuItem toolStripStrikeThrough;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripCut;
        private System.Windows.Forms.ToolStripMenuItem toolStripPaste;
        private System.Windows.Forms.ToolStripMenuItem toolStripAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripBold2;
        private System.Windows.Forms.ToolStripMenuItem toolStripItalics2;
        private System.Windows.Forms.ToolStripMenuItem toolStripUnderlined2;
        private System.Windows.Forms.ToolStripMenuItem toolStripStrikeThrough2;
        private System.Windows.Forms.ToolStripMenuItem toolStripChangeFont;
        private System.Windows.Forms.ToolStripMenuItem toolStripCopy2;
        private System.Windows.Forms.ToolStripMenuItem toolStripCut2;
        private System.Windows.Forms.ToolStripMenuItem toolStripPaste2;
        private System.Windows.Forms.ToolStripMenuItem toolStripSelectAll2;
        private System.Windows.Forms.ToolStripMenuItem toolStripCloseTab;
        private System.Windows.Forms.ToolStripMenuItem toolStripOpenNew;
    }
}

