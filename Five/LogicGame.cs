using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Five
{
    /// <summary>
    /// Логика игры
    /// </summary>
    public class LogicGame
    {
        Panel mainPanel; //Главная форма
        private int size; //Размер поля
        private int sizeButtom = 90; //Размер кнопки
        private Button[,] buttons;
        List<int> mix = new List<int>(); //Предназначен для сортировки значений
        int[] sortButtonNumber; //Предназначен для сортированные значений

        /// <summary>
        /// Логика игры
        /// </summary>
        /// <param name="form">форма</param>
        /// <param name="sizeField">размер поля</param>
        public LogicGame(Panel panel, int sizeField)
        {
            mainPanel = panel;
            size = sizeField;
            buttons = new Button[size, size];
            setSizePanel();
            SetButton();
        }

        /// <summary>
        /// Утстнавливает размер панели
        /// </summary>
        private void setSizePanel()
        {
            mainPanel.Size = new Size(sizeButtom * size, sizeButtom * size);
        }

        /// <summary>
        /// Устанавливает кнопки на поле
        /// </summary>
        private void SetButton()
        {
            int num = 1;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(sizeButtom, sizeButtom);
                    button.Location = new Point(j * sizeButtom, i * sizeButtom);
                    button.Click += buttonClick;
                    if (i != size - 1 || j != size - 1) button.Text = num++.ToString();
                    buttons[i, j] = button;
                    mainPanel.Controls.Add(button);
                }
            MixButton();
        }

        /// <summary>
        /// Перемешивает цифры на кнопках
        /// </summary>
        private void MixButton()
        {
            AddTextButton();
            Random R = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    int randomIndexButton = R.Next(0, mix.Count);
                    buttons[i, j].Text = mix[randomIndexButton].ToString();
                    mix.RemoveAt(randomIndexButton);
                    if (mix.Count == 0) break;
                }
        }

        /// <summary>
        /// Добавляет в лист mix все значения с кнопок
        /// </summary>
        private void AddTextButton()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (buttons[i, j].Text != "")
                        mix.Add(int.Parse(buttons[i, j].Text));
            sortButtonNumber = mix.ToArray();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку
        /// </summary>
        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != "")
                for (int x = 0; x < size; x++)
                    for (int y = 0; y < size; y++)
                        if (buttons[x, y] == button)
                            CheckNeighbours(x, y);
        }

        /// <summary>
        /// Проверяет соседнюю клетку на пустоту
        /// </summary>
        /// <param name="xB">кординаты данной клетки по x</param>
        /// <param name="yB">кординаты данной клетки по y</param>
        private void CheckNeighbours(int xB, int yB)
        {
            for (int x = xB - 1; x <= xB + 1; x++)
                for (int y = yB - 1; y <= yB + 1; y++)
                    if (x >= 0 && x < size && y >= 0 && y < size && (xB == x || yB == y))
                        if (buttons[x, y].Text == "")
                        {
                            buttons[x, y].Text = buttons[xB, yB].Text;
                            buttons[xB, yB].Text = "";
                        }
            CheckWin();
        }

        /// <summary>
        /// Проверка на выигрыш
        /// </summary>
        private void CheckWin()
        {
            int num = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (buttons[i, j].Text != "")
                        if (int.Parse(buttons[i, j].Text) == sortButtonNumber[num])
                            if (++num == sortButtonNumber.Length)
                                MessageBox.Show("Ты выиграл");
        }
    }
}
