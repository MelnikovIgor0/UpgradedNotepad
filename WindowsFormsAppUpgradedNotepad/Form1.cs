using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace WindowsFormsAppUpgradedNotepad
{
    /// <summary>
    /// Класс основной формы.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Конструктор основной формы.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        //Количество еще не сохраненных файлов.
        private static int s_amountUnsaved;

        //Цветовая тема на текущий момент.
        private static bool s_currentTheme = true;
        
        /// <summary>
        /// Метод проверяет, что файл является rtf-файлом.
        /// </summary>
        /// <param name="fileName">Имя файла.</param>
        /// <returns>Истинность утверждения, что выбранный файл - rtf файл.</returns>
        private bool CheckIsFileRTF(string fileName)
        {
            try
            {
                return (fileName.Length >= 3 && fileName[fileName.Length - 3] == 'r' && 
                    fileName[fileName.Length - 2] == 't' && fileName[fileName.Length - 1] == 'f');
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Метод записывает в richtextbox текст с выбранной вкладки.
        /// </summary>
        /// <param name="page">Вкладка, с которой записывается текст.</param>
        private void SetText(TabPage page)
        {
            try
            {
                if (page is not null)
                {
                    if (CheckIsFileRTF(page.Text))
                    {
                        try
                        {
                            richTextBoxMain.Text = "";
                            richTextBoxMain.Rtf = page.Name;
                        }
                        catch (Exception)
                        {
                            if (tabControl1.SelectedTab.Text == page.Text)
                            {
                                richTextBoxMain.Text = "Damaged file";
                                richTextBoxMain.Rtf = "";
                            }
                            page.Name = "Damaged file";
                            page.Text = "Damaged file";
                        }
                    }
                    else
                    {
                        try
                        {
                            richTextBoxMain.Rtf = "";
                            richTextBoxMain.Text = page.Name;
                        }
                        catch (Exception)
                        {
                            if (tabControl1.SelectedTab.Text == page.Text)
                            {
                                richTextBoxMain.Text = "Damaged file";
                                richTextBoxMain.Rtf = "";
                            }
                            page.Name = "Damaged file";
                            page.Text = "Damaged file";
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод возвращает текст, который сейчас написан в richtextbox.
        /// </summary>
        /// <param name="convert">Логическое значение, нужно ли приводить к строке текст.</param>
        /// <returns>Строка, текст.</returns>
        private string GetText(bool convert)
        {
            try
            {
                if (tabControl1.SelectedTab is not null)
                {
                    if (CheckIsFileRTF(tabControl1.SelectedTab.Text))
                    {
                        if (convert) return richTextBoxMain.Rtf.ToString();
                        return richTextBoxMain.Rtf;
                    }
                    else
                    {
                        if (convert) return richTextBoxMain.Text.ToString();
                        return richTextBoxMain.Text;
                    }
                }
                else return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Метод показывает пользователю форму с выбором интервала автосохранения файлов, а потом сохраняет выбранный
        /// пользователем интервал автосохранения файлов в настройках.
        /// </summary>
        /// <param name="sender">Объект, от которого вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripSetSaveInterval_Click(object sender, System.EventArgs e)
        {
            try
            {
                timerAutoSave.Enabled = false;
                new FormSetAutoSaveInterval().ShowDialog();
                int saveTime = 10;
                try
                {
                    saveTime = int.Parse(System.IO.File.ReadAllText(System.IO.Path.Combine(
                        System.IO.Directory.GetCurrentDirectory(), "autosave.txt")));
                }
                catch (Exception) { }
                timerAutoSave.Interval = saveTime * 1000;
                timerAutoSave.Enabled = true;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод создаёт новую вкладку.
        /// </summary>
        /// <param name="sender">Объект, от которого вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripCreate_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count >= 64) return;
                if (tabControl1.SelectedTab is not null) tabControl1.SelectedTab.Name = GetText(false);
                s_amountUnsaved++;
                tabControl1.TabPages.Add("", "unsaved file " + s_amountUnsaved);
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                SetText(tabControl1.SelectedTab);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод запрашивает у пользователя какой файл нужно открыть, 
        /// а затем открывает файл и отображает его содержимое.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripOpen_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count >= 64) return;
                OpenFileDialog openFile = new OpenFileDialog();
                if (tabControl1.SelectedTab is not null) tabControl1.SelectedTab.Name = GetText(false);
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int indexOpened = -1;
                        for (int index = 0; index < tabControl1.TabCount; index++)
                            if (tabControl1.TabPages[index].Text == openFile.FileName)
                                indexOpened = index;
                        if (indexOpened != -1)
                        {
                            tabControl1.SelectedIndex = indexOpened;
                            SetText(tabControl1.SelectedTab);
                            return;
                        }
                        string text = System.IO.File.ReadAllText(openFile.FileName);
                        tabControl1.TabPages.Add(text, openFile.FileName);
                        tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                        SetText(tabControl1.SelectedTab);
                    }
                    catch (System.Security.SecurityException ex)
                    {
                        MessageBox.Show($"Security Exception: {ex.Message}");
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод изменяет тему (со светлой на тёмную и наоборот) и сохраняет текущую тему в настройках.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripChangeTheme_Click(object sender, System.EventArgs e)
        {
            s_currentTheme = !s_currentTheme;
            try
            {
                System.IO.File.Delete(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "theme.txt"));
                System.IO.File.WriteAllText(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),
                    "theme.txt"), s_currentTheme.ToString());
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод сохраняет все изменения, внесённые пользователем в файл.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripSave_Click(object sender, System.EventArgs e)
        {
            if (tabControl1.SelectedTab is not null)
            {
                try
                {
                    if (System.IO.File.Exists(tabControl1.SelectedTab.Text))
                    {
                        System.IO.File.WriteAllText(tabControl1.SelectedTab.Text, GetText(false));
                    }
                    else
                    {
                        SaveFileDialog saveFile = new SaveFileDialog();
                        if (saveFile.ShowDialog() == DialogResult.OK)
                        {
                            System.IO.File.WriteAllText(saveFile.FileName, GetText(false));
                            tabControl1.SelectedTab.Text = saveFile.FileName;
                        }
                    }
                }
                catch (System.Security.SecurityException ex)
                {
                    MessageBox.Show($"Security Exception: {ex.Message}");
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Метод меняет жирность выделенного фрагмента текста, при этом 
        /// остальные характеристики шрифта остаются неизменными.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripBold_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (richTextBoxMain.SelectionFont is not null)
                {
                    System.Drawing.Font currentFont = richTextBoxMain.SelectionFont;
                    System.Drawing.FontStyle newFontStyle = currentFont.Style;
                    newFontStyle ^= FontStyle.Bold;
                    richTextBoxMain.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод меняет курсивность выделенного фрагмента текста, при этом 
        /// остальные характеристики шрифта остаются неизменными.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripItalics_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (richTextBoxMain.SelectionFont is not null)
                {
                    System.Drawing.Font currentFont = richTextBoxMain.SelectionFont;
                    System.Drawing.FontStyle newFontStyle = currentFont.Style;
                    newFontStyle ^= FontStyle.Italic;
                    richTextBoxMain.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод меняет подчеркнутость выделенного фрагмента текста, при этом 
        /// остальные характеристики шрифта остаются неизменными.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripUnderlined_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (richTextBoxMain.SelectionFont is not null)
                {
                    System.Drawing.Font currentFont = richTextBoxMain.SelectionFont;
                    System.Drawing.FontStyle newFontStyle = currentFont.Style;
                    newFontStyle ^= FontStyle.Underline;
                    richTextBoxMain.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод меняет зачеркнутость выделенного фрагмента текста, при этом 
        /// остальные характеристики шрифта остаются неизменными.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripStrikeThrough_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (richTextBoxMain.SelectionFont is not null)
                {
                    System.Drawing.Font currentFont = richTextBoxMain.SelectionFont;
                    System.Drawing.FontStyle newFontStyle = currentFont.Style;
                    newFontStyle ^= FontStyle.Strikeout;
                    richTextBoxMain.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод открывает новое окно приложения с новым файлом.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripOpenNew_Click(object sender, System.EventArgs e)
        {
            try
            {
                OpenAnotherWindow();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод копирует выделенный пользователем фрагмент текста в буфер обмена.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripCopy_Click(object sender, System.EventArgs e)
        {
            try
            {
                richTextBoxMain.Copy();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод копирует выбранные пользователем фрагмент текста
        /// в буфер обмена, при этом удаляет этот фрагмент текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripCut_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (richTextBoxMain.SelectedText is not null) richTextBoxMain.Cut();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод вставляет в выбранное пользователем место richtextbox содержимое буфера 
        /// обмена, если это текст. В противном случае ничего не происходит.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripPaste_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText() && !Clipboard.ContainsAudio() && !Clipboard.ContainsImage()
                    && !Clipboard.ContainsFileDropList()) 
                    richTextBoxMain.Paste(DataFormats.GetFormat(DataFormats.Text));
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод выделяет вся содержимое richtextbox.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripAll_Click(object sender, System.EventArgs e)
        {
            try
            {
                richTextBoxMain.SelectAll();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод открывает окно выбора шрифта, предоставляет пользователю возможность выбрать шрифт, этот шрифт
        /// применяется к выбранному пользователю фрагменту текста и может быть использован 
        /// для дальнейшего написания текста.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripChangeFont_Click(object sender, System.EventArgs e)
        {
            try
            {
                FontDialog getFont = new FontDialog();
                getFont.MinSize = 6;
                getFont.AllowVerticalFonts = false;
                getFont.ShowDialog();
                richTextBoxMain.Font = getFont.Font;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод закрывает текущую активную вкладку.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void ToolStripCloseTab_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab is not null)
                {
                    if (System.IO.File.Exists(tabControl1.SelectedTab.Text))
                    {
                        if (System.IO.File.ReadAllText(tabControl1.SelectedTab.Text) != GetText(false))
                        {
                            try
                            {
                                System.IO.File.WriteAllText(tabControl1.SelectedTab.Text, GetText(false));
                            }
                            catch (Exception) { }
                        }
                    }
                    else
                    {
                        SaveFileDialog saveFile = new SaveFileDialog();
                        saveFile.FileName = tabControl1.SelectedTab.Text;
                        if (saveFile.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                System.IO.File.WriteAllText(saveFile.FileName, 
                                    tabControl1.SelectedTab.Name.ToString());
                            }
                            catch (Exception) { }
                        }
                    }
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Метод задает текст richtextbox в соответствии с новой выбранной вкладкой.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetText(tabControl1.SelectedTab);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод сохраняет текст данной вкладки при переходе на другую вкладку.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (e.TabPage is not null) e.TabPage.Name = GetText(false);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод сохраняет описок переданных имен файлов в файл openedfiles.txt, чтобы при последующем открытии
        /// приложения программа имела возможность открыть эти файлы.
        /// </summary>
        /// <param name="names">Список имён файлов, которые должны быть сохранены.</param>
        private void SaveNamesOfOpenedFiles(List<string> names)
        {
            try
            {
                StringBuilder text = new StringBuilder("");
                foreach (string name in names)
                {
                    text.Append(name);
                    text.Append(Environment.NewLine);
                }
                System.IO.File.Delete(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),
                    "openedfiles.txt"));
                System.IO.File.WriteAllText(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),
                    "openedfiles.txt"), text.ToString());
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод производит все необходимые действия при закрытии формы, а именно: производит проверку на наличие
        /// несохраненных файлов или файлов с несохраненными изменениями и предлагает пользователю сохранить их; 
        /// сохраняет все открытые на момент закрытия программы файлы для их последующего открытия 
        /// при открытии программы.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab is not null) tabControl1.SelectedTab.Name = GetText(false);
                bool unsavedFiles = false;
                foreach (TabPage page in tabControl1.TabPages)
                {
                    try
                    {
                        if (!System.IO.File.Exists(page.Text) || System.IO.File.ReadAllText(page.Text) != 
                            page.Name.ToString()) unsavedFiles = true;
                    }
                    catch (Exception) { }
                }
                if (unsavedFiles)
                {
                    switch (MessageBox.Show("Вы хотите закрыть программу, но имеются несохранённые файлы/файлы с " +
                        "несохранёнными изменениями. Сохранить файлы?", "Сохранить?", MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.No:
                            List<string> fileNames = new List<string>();
                            foreach (TabPage page in tabControl1.TabPages) fileNames.Add(page.Text);
                            SaveNamesOfOpenedFiles(fileNames);
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                        case DialogResult.Yes:
                            List<string> names = new List<string>();
                            foreach (TabPage file in tabControl1.TabPages)
                            {
                                try
                                {
                                    if (!System.IO.File.Exists(file.Text))
                                    {
                                        SaveFileDialog saveFile = new SaveFileDialog();
                                        saveFile.FileName = file.Text;
                                        if (saveFile.ShowDialog() == DialogResult.OK)
                                        {
                                            System.IO.File.WriteAllText(saveFile.FileName, file.Name.ToString());
                                            names.Add(saveFile.FileName);
                                        }
                                    }
                                    else
                                    {
                                        System.IO.File.WriteAllText(file.Text, file.Name.ToString());
                                        names.Add(file.Text);
                                    }
                                }
                                catch (Exception) { }
                                SaveNamesOfOpenedFiles(names);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    List<string> fileNames = new List<string>();
                    foreach (TabPage page in tabControl1.TabPages) fileNames.Add(page.Text);
                    SaveNamesOfOpenedFiles(fileNames);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод при каждом тике таймера проходит по всем открытым программой файлам и сохраняет их содержимое.
        /// Интервал тиков таймера задается пользователем в настройках.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void timerAutoSave_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab is not null) tabControl1.SelectedTab.Name = GetText(false);
                foreach (TabPage page in tabControl1.TabPages)
                    if (System.IO.File.Exists(page.Text))
                    {
                        try
                        {
                            System.IO.File.WriteAllText(page.Text, page.Name);
                        }
                        catch (Exception) { }
                    }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод открывает все существующие, доступные для открытия и неповрежденные файлы, 
        /// среди тех, которые были открыты на момент закрытия программы.
        /// </summary>
        private void OpenOpenedFiles()
        {
            try
            {
                if (System.IO.File.Exists(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),
                    "openedfiles.txt")))
                {
                    string[] names = System.IO.File.ReadAllLines(System.IO.Path.Combine(
                        System.IO.Directory.GetCurrentDirectory(), "openedfiles.txt"));
                    foreach (string name in names)
                    {
                        try
                        {
                            if (System.IO.File.Exists(name))
                            {
                                tabControl1.TabPages.Add(System.IO.File.ReadAllText(
                                    System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), name)), name);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                System.IO.File.Delete(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),
                    "openedfiles.txt"));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Метод делает все действия, нкобходимые при загрузке формы, а именно.
        /// 1) Добавляет новую вкладку с пустым файлом, чтобы пользователю было где работать.
        /// 2) Считывает настройки и устанавливает все в программе в соответствие с ними.
        /// 3) Открывает все существующие, доступные для чтения, неповрежденные файлы, 
        /// которые были открыты на момент закрытия программы.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count == 0)
                {
                    s_amountUnsaved++;
                    tabControl1.TabPages.Add("", "unsaved file " + s_amountUnsaved);
                    OpenOpenedFiles();
                }
                else
                {
                    SetText(tabControl1.SelectedTab);
                }
            }
            catch (Exception) { }
            int autoSaveInterval = 10;
            try
            {
                autoSaveInterval = int.Parse(System.IO.File.ReadAllText(System.IO.Path.Combine(
                    System.IO.Directory.GetCurrentDirectory(), "autosave.txt")));
            }
            catch (Exception) { }
            try
            {
                System.IO.File.Delete(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), 
                    "autosave.txt"));
                System.IO.File.WriteAllText(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),
                    "autosave.txt"), autoSaveInterval.ToString());
            }
            catch (Exception) { }
            timerAutoSave.Interval = autoSaveInterval * 1000;
            timerAutoSave.Enabled = true;
            bool theme = true;
            try
            {
                theme = bool.Parse(System.IO.File.ReadAllText(System.IO.Path.Combine(
                    System.IO.Directory.GetCurrentDirectory(), "theme.txt")));
            }
            catch (Exception) { }
            try
            {
                System.IO.File.Delete(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "theme.txt"));
                System.IO.File.WriteAllText(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(),
                    "theme.txt"), theme.ToString());
            }
            catch (Exception) { }
            s_currentTheme = theme;
        }

        /// <summary>
        /// Метод изменяет цветовую схему элементов окна по темную тему.
        /// </summary>
        private void SetDarkTheme()
        {
            try
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                richTextBoxMain.BackColor = Color.FromArgb(30, 30, 30);
                richTextBoxMain.ForeColor = Color.FromArgb(220, 220, 220);
                menuStrip1.BackColor = Color.FromArgb(30, 30, 30);
                menuStrip1.ForeColor = Color.FromArgb(220, 220, 220);
                foreach (TabPage page in tabControl1.TabPages)
                {
                    page.BackColor = Color.FromArgb(40, 40, 40);
                    page.ForeColor = Color.FromArgb(220, 220, 220);
                    page.Update();
                }
                toolStripChange.BackColor = Color.FromArgb(30, 30, 30);
                toolStripChange.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripChangeTheme.BackColor = Color.FromArgb(30, 30, 30);
                toolStripChangeTheme.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripCreate.BackColor = Color.FromArgb(30, 30, 30);
                toolStripCreate.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripFile.BackColor = Color.FromArgb(30, 30, 30);
                toolStripFile.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripFormat.BackColor = Color.FromArgb(30, 30, 30);
                toolStripFormat.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripOpen.BackColor = Color.FromArgb(30, 30, 30);
                toolStripOpen.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripSave.BackColor = Color.FromArgb(30, 30, 30);
                toolStripSave.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripSetSaveInterval.BackColor = Color.FromArgb(30, 30, 30);
                toolStripSetSaveInterval.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripSettings.BackColor = Color.FromArgb(30, 30, 30);
                toolStripSettings.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripBold.BackColor = Color.FromArgb(30, 30, 30);
                toolStripBold.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripItalics.BackColor = Color.FromArgb(30, 30, 30);
                toolStripItalics.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripStrikeThrough.BackColor = Color.FromArgb(30, 30, 30);
                toolStripStrikeThrough.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripUnderlined.BackColor = Color.FromArgb(30, 30, 30);
                toolStripUnderlined.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripAll.BackColor = Color.FromArgb(40, 40, 40);
                toolStripAll.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripCopy.BackColor = Color.FromArgb(40, 40, 40);
                toolStripCopy.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripCut.BackColor = Color.FromArgb(40, 40, 40);
                toolStripCut.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripPaste.BackColor = Color.FromArgb(40, 40, 40);
                toolStripPaste.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripBold2.BackColor = Color.FromArgb(40, 40, 40);
                toolStripBold2.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripItalics2.BackColor = Color.FromArgb(40, 40, 40);
                toolStripItalics2.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripStrikeThrough2.BackColor = Color.FromArgb(40, 40, 40);
                toolStripStrikeThrough2.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripUnderlined2.BackColor = Color.FromArgb(40, 40, 40);
                toolStripUnderlined2.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripChangeFont.BackColor = Color.FromArgb(40, 40, 40);
                toolStripChangeFont.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripCopy2.BackColor = Color.FromArgb(40, 40, 40);
                toolStripCopy2.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripCut2.BackColor = Color.FromArgb(40, 40, 40);
                toolStripCut2.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripSelectAll2.BackColor = Color.FromArgb(40, 40, 40);
                toolStripSelectAll2.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripPaste2.BackColor = Color.FromArgb(40, 40, 40);
                toolStripPaste2.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripCloseTab.BackColor = Color.FromArgb(40, 40, 40);
                toolStripCloseTab.ForeColor = Color.FromArgb(220, 220, 220);
                toolStripOpenNew.BackColor = Color.FromArgb(40, 40, 40);
                toolStripOpenNew.ForeColor = Color.FromArgb(220, 220, 220);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод изменяет цветовую схему элементов окна под светлую тему.
        /// </summary>
        private void SetLightTheme()
        {
            try
            {
                this.BackColor = Color.FromArgb(245, 245, 245);
                richTextBoxMain.BackColor = Color.FromArgb(255, 255, 255);
                richTextBoxMain.ForeColor = Color.FromArgb(0, 0, 0);
                menuStrip1.BackColor = Color.FromArgb(245, 245, 245);
                menuStrip1.ForeColor = Color.FromArgb(0, 0, 0);
                foreach (TabPage page in tabControl1.TabPages)
                {
                    page.BackColor = Color.FromArgb(245, 245, 245);
                    page.ForeColor = Color.FromArgb(0, 0, 0);
                    page.Update();
                }
                toolStripChange.BackColor = Color.FromArgb(245, 245, 245);
                toolStripChange.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripChangeTheme.BackColor = Color.FromArgb(245, 245, 245);
                toolStripChangeTheme.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripCreate.BackColor = Color.FromArgb(245, 245, 245);
                toolStripCreate.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripFile.BackColor = Color.FromArgb(245, 245, 245);
                toolStripFile.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripFormat.BackColor = Color.FromArgb(245, 245, 245);
                toolStripFormat.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripOpen.BackColor = Color.FromArgb(245, 245, 245);
                toolStripOpen.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripSave.BackColor = Color.FromArgb(245, 245, 245);
                toolStripSave.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripSetSaveInterval.BackColor = Color.FromArgb(245, 245, 245);
                toolStripSetSaveInterval.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripSettings.BackColor = Color.FromArgb(245, 245, 245);
                toolStripSettings.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripBold.BackColor = Color.FromArgb(245, 245, 245);
                toolStripBold.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripItalics.BackColor = Color.FromArgb(245, 245, 245);
                toolStripItalics.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripStrikeThrough.BackColor = Color.FromArgb(245, 245, 245);
                toolStripStrikeThrough.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripUnderlined.BackColor = Color.FromArgb(245, 245, 245);
                toolStripUnderlined.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripAll.BackColor = Color.FromArgb(245, 245, 245);
                toolStripAll.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripCopy.BackColor = Color.FromArgb(245, 245, 245);
                toolStripCopy.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripCut.BackColor = Color.FromArgb(245, 245, 245);
                toolStripCut.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripPaste.BackColor = Color.FromArgb(245, 245, 245);
                toolStripPaste.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripBold2.BackColor = Color.FromArgb(245, 245, 245);
                toolStripBold2.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripItalics2.BackColor = Color.FromArgb(245, 245, 245);
                toolStripItalics2.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripStrikeThrough2.BackColor = Color.FromArgb(245, 245, 245);
                toolStripStrikeThrough2.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripUnderlined2.BackColor = Color.FromArgb(245, 245, 245);
                toolStripUnderlined2.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripChangeFont.BackColor = Color.FromArgb(245, 245, 245);
                toolStripChangeFont.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripCopy2.BackColor = Color.FromArgb(245, 245, 245);
                toolStripCopy2.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripCut2.BackColor = Color.FromArgb(245, 245, 245);
                toolStripCut2.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripSelectAll2.BackColor = Color.FromArgb(245, 245, 245);
                toolStripSelectAll2.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripPaste2.BackColor = Color.FromArgb(245, 245, 245);
                toolStripPaste2.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripCloseTab.BackColor = Color.FromArgb(245, 245, 245);
                toolStripCloseTab.ForeColor = Color.FromArgb(0, 0, 0);
                toolStripOpenNew.BackColor = Color.FromArgb(245, 245, 245);
                toolStripOpenNew.ForeColor = Color.FromArgb(0, 0, 0);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// При каждом тике таймера данный метод приводит тему программы
        /// в соответствие с указанной пользователем темой.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerThemeUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!s_currentTheme && this.BackColor != Color.FromArgb(30, 30, 30)) SetDarkTheme();
                else if (s_currentTheme && this.BackColor != Color.FromArgb(245, 245, 245)) SetLightTheme();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод сохраняет содержимое всех открытых файлов.
        /// </summary>
        private void SaveAllFiles()
        {
            try
            {
                foreach (TabPage page in tabControl1.TabPages)
                {
                    try
                    {
                        if (System.IO.File.Exists(page.Text)) System.IO.File.WriteAllText(page.Text, 
                            page.Name.ToString());
                        else
                        {
                            SaveFileDialog saveFile = new SaveFileDialog();
                            if (saveFile.ShowDialog() == DialogResult.OK)
                            {
                                System.IO.File.WriteAllText(saveFile.FileName, GetText(false));
                                tabControl1.SelectedTab.Text = saveFile.FileName;
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод открывает определенный файл в новом окне данного приложения.
        /// </summary>
        private void OpenAnotherWindow()
        {
            try
            {
                Form1 anotherForm = new Form1();
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string text = System.IO.File.ReadAllText(openFile.FileName);
                        anotherForm.tabControl1.TabPages.Add(text, openFile.FileName);
                        anotherForm.tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                        anotherForm.tabControl1.TabPages[0].Text = openFile.FileName;
                        anotherForm.tabControl1.TabPages[0].Name = text;
                        anotherForm.SetText(anotherForm.tabControl1.SelectedTab);
                    }
                    catch (System.Security.SecurityException ex)
                    {
                        MessageBox.Show($"Security Exception: {ex.Message}");
                    }
                    catch (Exception) { }
                }
                anotherForm.Show();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод вызывает другие методы в соответствии с выбранной пользователем комбинацией горячих клавиш.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.O && e.Control && e.Alt) OpenAnotherWindow();
                if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control) ToolStripOpen_Click(sender, e);
                if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control) ToolStripCreate_Click(sender, e);
                if (e.KeyCode == Keys.S && e.Control && e.Alt) SaveAllFiles();
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control) ToolStripSave_Click(sender, e);
                if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control) ToolStripCloseTab_Click(sender, e);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод вызывает другие методы в соответствии с выбранной пользователем комбинацией горячих клавиш.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void richTextBoxMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.O && e.Control && e.Alt) OpenAnotherWindow();
                if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control) ToolStripOpen_Click(sender, e);
                if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control) ToolStripCreate_Click(sender, e);
                if (e.KeyCode == Keys.S && e.Control && e.Alt) SaveAllFiles();
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control) ToolStripSave_Click(sender, e);
                if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control) ToolStripCloseTab_Click(sender, e);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод вызывает другие методы в соответствии с выбранной пользователем комбинацией горячих клавиш.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void menuStrip1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.O && e.Control && e.Alt) OpenAnotherWindow();
                if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control) ToolStripOpen_Click(sender, e);
                if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control) ToolStripCreate_Click(sender, e);
                if (e.KeyCode == Keys.S && e.Control && e.Alt) SaveAllFiles();
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control) ToolStripSave_Click(sender, e);
                if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control) ToolStripCloseTab_Click(sender, e);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод вызывает другие методы в соответствии с выбранной пользователем комбинацией горячих клавиш.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.O && e.Control && e.Alt) OpenAnotherWindow();
                if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control) ToolStripOpen_Click(sender, e);
                if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control) ToolStripCreate_Click(sender, e);
                if (e.KeyCode == Keys.S && e.Control && e.Alt) SaveAllFiles();
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control) ToolStripSave_Click(sender, e);
                if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control) ToolStripCloseTab_Click(sender, e);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Метод вызывает другие методы в соответствии с выбранной пользователем комбинацией горячих клавиш.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void richTextBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip.Show(this.Location.X + e.X, this.Location.Y + e.Y);
                }
            }
            catch (Exception) { }
        }
    }
}
