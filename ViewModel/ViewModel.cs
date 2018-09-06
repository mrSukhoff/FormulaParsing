using System.ComponentModel;
using FormulaParsing.Model;


namespace Stacker.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        public string Expression
        {
           set
           {
                Model.Expression = value;
                OnPropertyChahged("Result");
            }
        }

        public string ValueOfVariable
        {
            set
            {
                double.TryParse(value, out double d);
                Model.Variable = d;
                OnPropertyChahged("Result");
            }
        }

        public string Result
        {
            get => Model.Meaninig == null ? "NA" : Model.Meaninig.ToString();
        }
        
        //Модель MVVM
        public Parser Model;

        //конструктор ---------------------------------------------------------------------------------------
        public ViewModel()
        {
            Model = new Parser();
        }

        //реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChahged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
