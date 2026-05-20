using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmartTextEditorSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Role? selectedRole;
        private Preset? currentPreset;
        private readonly Dictionary<string, Preset> presetMap;
        public ObservableCollection<Role> Roles { get; }
        public Role? SelectedRole
        {
            get => selectedRole;
            set
            {
                if (!Equals(selectedRole, value))
                {
                    selectedRole = value;
                    OnPropertyChanged();

                    if (value != null && presetMap.TryGetValue(value.ID, out var preset))
                    {
                        CurrentPreset = preset;
                    }
                    else
                    {
                        CurrentPreset = null;
                    }
                }
            }
        }

        public Preset? CurrentPreset
        {
            get => currentPreset;
            set
            {
                if (!Equals(currentPreset, value))
                {
                    currentPreset = value;
                    OnPropertyChanged();
                }
            }
        }

        public ViewModel()
        {
            Roles = new ObservableCollection<Role>
            {
                new Role { ID = "Role1", Text = "Maintainer of an open-source project replying to GitHub issues" },
                new Role { ID = "Role2", Text = "Employee communicating with internal team" },
                new Role { ID = "Role3", Text = "Customer support representative responding to customer queries" },
                new Role { ID = "Role4", Text = "Sales representative responding to client inquiries" }
            };

            presetMap = new Dictionary<string, Preset>
            {
                ["Role1"] = new Preset
                {
                    UserRole = "Maintainer of an open-source project replying to GitHub issues",
                    PlaceHolder = "Write your response to the GitHub issue..."
                },
                ["Role2"] = new Preset
                {
                    UserRole = "Employee communicating with internal team",
                    PlaceHolder = "Draft your message for the team..."
                },
                ["Role3"] = new Preset
                {
                    UserRole = "Customer support representative responding to customer queries",
                    PlaceHolder = "Enter your reply to the customer query..."
                },
                ["Role4"] = new Preset
                {
                    UserRole = "Sales representative responding to client inquiries",
                    PlaceHolder = "Enter your reply to the client's inquiry..."
                }
            };

            if (Roles.Count > 0)
            {
                SelectedRole = Roles[0];
            }
            else
            {
                SelectedRole = null;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}