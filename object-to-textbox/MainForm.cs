using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace object_to_textbox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            buttonShowObjectInTextbox.Click += onButtonShowObjectInTextbox;
        }

        private void onButtonShowObjectInTextbox(object? sender, EventArgs e)
        {
            // For demonstration purposes, make an object
            object o = new AircraftDetails
            {
                Airline = Airline.United,
                Fuel = 50000,
                OnboardBags = 237,
                CheckedBags = 500,
            };
            textBoxMultiline.Text = o.ToString();
        }
    }

    // Minimal example of a class
    class AircraftDetails : INotifyPropertyChanged
    {
        public override string ToString()
        {
            List<string> builder = new List<string>();
            builder.Add($"{Airline}");
            builder.Add($"{OnboardBags} bags onboard");
            builder.Add($"{CheckedBags} bags checked");
            builder.Add($"Total bags: {TotalBags}");
            builder.Add($"Fuel onboard: {Fuel.ToString("F2")}");
            return string.Join(Environment.NewLine, builder);
        }
        #region B I N D I N G    P R O P E R T I E S

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            switch (propertyName)
            {
                case nameof(CheckedBags):
                case nameof(OnboardBags):
                    TotalBags = CheckedBags + OnboardBags;
                    break;
            }
        }

        #endregion B I N D I N G    P R O P E R T I E S
        Airline _airline = Airline.Unknown;
        public Airline Airline
        {
            get => _airline;
            set
            {
                if (!Equals(_airline, value))
                {
                    _airline = value;
                    OnPropertyChanged();
                }
            }
        }


        double _fuel = 0;
        public double Fuel
        {
            get => _fuel;
            set
            {
                if (!Equals(_fuel, value))
                {
                    _fuel = value;
                    OnPropertyChanged();
                }
            }
        }
        int _onboardBags = 0;
        public int OnboardBags
        {
            get => _onboardBags;
            set
            {
                if (!Equals(_onboardBags, value))
                {
                    _onboardBags = value;
                    OnPropertyChanged();
                }
            }
        }
        int _checkedBgs = 0;
        public int CheckedBags
        {
            get => _checkedBgs;
            set
            {
                if (!Equals(_checkedBgs, value))
                {
                    _checkedBgs = value;
                    OnPropertyChanged();
                }
            }
        }
        int _totalBags = 0;
        public int TotalBags
        {
            get => _totalBags;
            private set
            {
                if (!Equals(_totalBags, value))
                {
                    _totalBags = value;
                    OnPropertyChanged();
                }
            }
        }

    }
    enum Airline
    {
        Unknown,
        [Description("I'm so sorry")]
        Southwest,
        United,
    }
}