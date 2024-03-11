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
    public class AppVM : INotifyPropertyChanged
    {
        Random rand = new Random();

        private ObservableCollection<Guess> guesses { get; set; }
        private ObservableCollection<string> history { get; set; }
        public static AppVM vmlink;
        //private int correctLeft=0;
        private int overallCount = 0;
        public int OverallCount
        {
            get { return overallCount; }
            set
            {
                overallCount = value;
                OnPropertyChanged("overallCount");
            }
        }
        /*public int СorrectLeft
        {
            get { return correctLeft; }
            set
            {
                correctLeft = value;
                OnPropertyChanged("correctLeft");
            }
        }*/
        //"{Binding ggg, StringFormat='Осталось ненажатых: {0}'}"

        //Блок relay command
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        History.Clear();
                        Guesses.Clear();
                        if (OverallCount > 0 && OverallCount < 41)
                        {
                            Guess.count = 0;
                            //Guess.correctCount = 1;
                            for (int i = 0; i < OverallCount; i++)
                            {
                                Guess guess = new Guess(false, true);
                                Guesses.Insert(guess.SelfNumber - 1, guess);
                            }
                            int IsCorrect = rand.Next(1, OverallCount);
                            Guesses[IsCorrect - 1].IsCorrect = true;
                            History.Insert(0, $"Новая игра, кнопок: {OverallCount}");
                        }
                        else
                        {
                            History.Insert(0, "Некорректный старт");
                        }
                    }));
            }
        }

        public AppVM()
        {
            vmlink = this;
            history = new ObservableCollection<string>();
            guesses = new ObservableCollection<Guess>()
            {
/*              new Guess(false, true),
                new Guess(true, true),
                new Guess(true, false),
                new Guess(false, false)*/
            };
            
        }

        public ObservableCollection<Guess> Guesses
        {
            get { return this.guesses; }
        }
        public ObservableCollection<string> History
        {
            get { return this.history; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}