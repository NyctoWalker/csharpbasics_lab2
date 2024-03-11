using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace csharpbasics_lab2
{
    public class Guess : INotifyPropertyChanged
    {
        //Блок наобходимых private данных
        private int selfNumber;
        private bool iscorrect;
        private bool isenabled;
        public static int count = 0 ;
        //public static int correctCount = 0;
        private RelayCommand guessClick;
        
        //Конструкторы
        public Guess(bool iscorrect, bool isenabled)
        {
            count++;
            this.selfNumber = count;
            
            this.iscorrect = iscorrect;
            //if (iscorrect == true) correctCount++;
            
            this.isenabled = isenabled;
        }
        //Реализация функционала в Model?
        public RelayCommand GuessClick
        {
            get
            {
                return guessClick ??
                    (guessClick = new RelayCommand(obj =>
                    {
                        this.IsEnabled = false;
                        Count--;
                        AppVM.vmlink.OverallCount =  Count;

                        //Условие победы выполнено?
                        if (this.IsCorrect == true)
                        {
                            AppVM.vmlink.History.Add($"{this.SelfNumber} - правильно! Победа!");
                            AppVM.vmlink.History.Add($"Ходов использовано: {AppVM.vmlink.Guesses.Count-Count}!");
                            for (int i = 0; i<AppVM.vmlink.Guesses.Count; i++)
                            {
                                AppVM.vmlink.Guesses[i].IsEnabled = false;
                            }
                            //CorrectCount--;
                            //AppVM.singleton.СorrectLeft--;
                        }
                        else
                            AppVM.vmlink.History.Add($"{this.SelfNumber} - неправильно :с");
                    }));
            }
        }
        //Блок геттеров и сеттеров
        public int SelfNumber
        {
            get { return this.selfNumber; }
            //set?
        }

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public bool IsCorrect
        {
            get { return this.iscorrect; }
            set
            {
                iscorrect = value;
                OnPropertyChanged("iscorrect");
            }
            }

        /*public int CorrectCount
        {
            get 
            { 
                return correctCount; 
            }
            set
            {
                correctCount = value;
                OnPropertyChanged("CorrectCount");
            }
        }*/

        public bool IsEnabled
        {
            get 
            { 
                return this.isenabled; 
            }
            set 
            {
                this.isenabled = value;
                OnPropertyChanged("IsEnabled");
                OnPropertyChanged("GuessState");
            }
        }

        public string GuessState
        {
            get
            {
                //Ненажатая кнопка с номером. Если кнопка отключена(после нажатия) и она неправильная, то минус. Если правильная, то плюс.
                return this.IsEnabled ? SelfNumber.ToString() : this.IsCorrect ? "+" : "-";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
