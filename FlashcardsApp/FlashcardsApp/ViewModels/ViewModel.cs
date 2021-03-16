using System.ComponentModel;
using Xamarin.Forms;

namespace FlashcardsApp.ViewModels
{
    // base viewmodel class for all viewmodels, implements GUI awarness of changes in properties and
    // taking the Navigation dependency of xamarin.forms off of the other viewmodels class
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
