using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Triad triad;

        private void Calculate_Click(object sender, RoutedEventArgs? e)
        {
            bool checkValue1 = uint.TryParse(inputValue1.Text, out uint value1);
            bool checkValue2 = uint.TryParse(inputValue2.Text, out uint value2);
            bool checkValue3 = uint.TryParse(inputValue3.Text, out uint value3);

            if (!(checkValue1 && checkValue2 && checkValue3))
            {
                MessageBox.Show("Данные введены неверно!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            triad = new Triad(value1, value2, value3);
            uint res = triad.Amount();
            result.Text = res.ToString();

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            inputValue1.Text = null;
            inputValue2.Text = null;
            inputValue3.Text = null;
            inputValueA.Text = null;
            inputValueB.Text = null;
            inputValueC.Text = null;
            result.Text = null;
            triad.ClearTriad();
        }

        private void About_Program_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создать класс Triad(тройка положительных чисел). " +
                "Создать необходимые методы и свойства.Определить метод вычисления суммы чисел. " +
                "Создать перегруженные методы SetParams, для установки параметров объекта.", "О программе",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Изменить_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UInt32.TryParse(inputValueA.Text, out uint valueA);
                UInt32.TryParse(inputValueB.Text, out uint valueB);
                UInt32.TryParse(inputValueC.Text, out uint valueC);

                if (inputValueA.Text != "")
                {
                    triad.SetParams(valueA, triad.Number2, triad.Number3);
                    inputValue1.Text = inputValueA.Text;
                   
                    Calculate_Click(calculate, null);

                    inputValueA.Text = null;
                   
                }

                if (inputValueB.Text != "")
                {
                    triad.SetParams(triad.Number1, valueB, triad.Number3);
                    inputValue2.Text = inputValueB.Text;

                    Calculate_Click(calculate, null);

                    inputValueB.Text = null;

                }
                if (inputValueC.Text != "")
                {
                    triad.SetParams(triad.Number1, triad.Number2, valueC);
                    inputValue3.Text = inputValueC.Text;

                    Calculate_Click(calculate, null);

                    inputValueC.Text = null;

                }


            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Объект не был создан!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Данные должны быть больше 0", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
