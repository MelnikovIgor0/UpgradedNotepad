using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppUpgradedNotepad
{
    /// <summary>
    /// Класс формы, которая предоставляет пользователю возможность изменять интервал автосохранения файлов.
    /// </summary>
    public partial class FormSetAutoSaveInterval : Form
    {
        /// <summary>
        /// Констркутор формы.
        /// </summary>
        public FormSetAutoSaveInterval()
        {
            InitializeComponent();
        }

        //Можно ли закрывать текущую форму (можно только при нажатии на одну из кнопок).
        private bool canClose = false;

        /// <summary>
        /// Метод переводит число (значение trackbar) в количество секнуд (это нужно для того, чтобы обеспечить
        /// экспоненциальное распределение значений секунд на trackbar), так как маленькие значения выбираются
        /// чаще, чем большие и на маленьких значениях точность важнее.
        /// </summary>
        /// <param name="value">Число, которое переводится в секунды.</param>
        /// <returns></returns>
        private int ConvertToSeconds(int value)
        {
            return (int)(86400 * Math.Exp((double)(value) / 10000) / Math.E);
        }

        /// <summary>
        /// Метод изменяет текст label в соответствии с текущим значением trackbar.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void trackBarTime_ValueChanged(object sender, EventArgs e)
        {
            labelInterval.Text = $"сохранение раз в {ConvertToSeconds(trackBarTime.Value)} секунд";
        }

        /// <summary>
        /// Метод не дает закрыть форму, если ее пытаются закрыть любым способом, кроме нажатия на одну из кнопок.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void FormSetAutoSaveInterval_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose) e.Cancel = true;
        }

        /// <summary>
        /// При нажатии на кнопку созранить настройки данный метод записывает интервал
        /// автосохранения в специальный файл и закрывает данное окно.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "autosave.txt"));
                System.IO.File.WriteAllText(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), 
                    "autosave.txt"), ConvertToSeconds(trackBarTime.Value).ToString());
            }
            catch (Exception) { }
            canClose = true;
            this.Close();
        }

        /// <summary>
        /// Метод при нажатии на кнопку отмены закрывает данное окно.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            canClose = true;
            this.Close();
        }

        /// <summary>
        /// Метод при загрузке формы устанавливает начальное положение trackbar в соответствии с установленным на
        /// данный момент интервалом автосохранения и устанваливает соответствующий текст на label.
        /// </summary>
        /// <param name="sender">Объект, от которого было вызвано событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void FormSetAutoSaveInterval_Load(object sender, EventArgs e)
        {
            int time = 10;
            try
            {
                time = int.Parse(System.IO.File.ReadAllText(System.IO.Path.Combine(
                    System.IO.Directory.GetCurrentDirectory(), "autosave.txt")));
            }
            catch (Exception) { }
            int value = -80000;
            for (int possibleValue = -80000; possibleValue <= 10000; possibleValue++)
                if (ConvertToSeconds(possibleValue) == time)
                {
                    value = possibleValue;
                    break;
                }
            trackBarTime.Value = value;
            labelInterval.Text = $"сохранение раз в {ConvertToSeconds(value)} секунд";
        }
    }
}
