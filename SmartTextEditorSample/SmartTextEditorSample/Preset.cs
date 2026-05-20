using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartTextEditorSample
{
    public class Preset : INotifyPropertyChanged
    {
        private string? userRole;

        private string? placeHolder;

        public string? UserRole
        {
            get => userRole;
            set
            {
                if (userRole != value)
                {
                    userRole = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? PlaceHolder
        {
            get => placeHolder;
            set
            {
                if (placeHolder != value)
                {
                    placeHolder = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}