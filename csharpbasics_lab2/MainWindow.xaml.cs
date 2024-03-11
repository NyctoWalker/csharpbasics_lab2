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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace csharpbasics_lab2
{
/*Разработать прототип игрового приложения «Угадать число». Пользователь задает количество
  чисел, среди которых программное приложение должно загадать число.Так же пользователь
  задает, сколько чисел должна загадать система.Повторяющихся чисел быть не должно.Далее по
  нажатию на клавишу «Новая игра» динамически создается нужное количество кнопок (или
  подобных компонентов) начиная с единицы до числа, которое задал пользователь.Каждая кнопка
  должна быть подписана соответствующим числом.Кнопки выстраиваются по рядам, в каждом
  ряду не более 5 штук.Далее система, «загадывает» числа.Пользователь пытается угадать числа,
  путем нажатия на кнопки.Необходимо предусмотреть запись всех ходов(например, через
ListBox). Один раз нажатые кнопки должны заблокироваться и не быть доступными».*/
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AppVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_SourceUpdated(object sender, DataTransferEventArgs e)
        {
        }
    }
}
