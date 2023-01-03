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
                Flight = "UA2907",
                Airline = Airline.United,
                Fuel = 50000,
                OnboardBags = 237,
                CheckedBags = 500,
            };
            textBoxMultiline.Text = o.ToString();
            aircraftDetails.SelectedIndex = -1;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            aircraftDetails.DataSource = Details;
            aircraftDetails.DisplayMember = nameof(AircraftDetails.Flight);
            aircraftDetails.SelectedIndexChanged += onAircraftDetailsSelection;

            // Add a few flights
            Details.Add(new AircraftDetails
            {
                Flight = "UA6026",
                Airline = Airline.United,
                Fuel = 45250,
                OnboardBags = 155,
                CheckedBags = 97,
            });
            Details.Add(new AircraftDetails
            {
                Flight = "UA8888",
                Airline = Airline.United,
                Fuel = 27620,
                OnboardBags = 301,
                CheckedBags = 134,
            });
            Details.Add(new AircraftDetails
            {
                Flight = "WN8610",
                Airline = Airline.Southwest,
                Fuel = 200,
                OnboardBags = 5,
                CheckedBags = 614,
            });
            aircraftDetails.SelectedIndex = -1;
        }
        // Show object in textbox
        private void onAircraftDetailsSelection(object? sender, EventArgs e)
        {
            if(aircraftDetails.SelectedItem != null)
            {
                textBoxMultiline.Text = aircraftDetails.SelectedItem.ToString();
            }
        }
        BindingList<AircraftDetails> Details = new BindingList<AircraftDetails>();
    }

    // Minimal example of a class
    class AircraftDetails : INotifyPropertyChanged
    {
        public override string ToString()
        {
            List<string> builder = new List<string>();
            builder.Add($"{Airline} {Flight}");
            builder.Add($"FlightStatus: {FlightStatus}");
            builder.Add($"{Flight}");
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
        string _tailNumber = string.Empty;
        public string Flight
        {
            get => _tailNumber;
            set
            {
                if (!Equals(_tailNumber, value))
                {
                    _tailNumber = value;
                    OnPropertyChanged();
                }
            }
        }
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
        public string FlightStatus =>
            Airline.Equals(Airline.Southwest) ? "Canceled" : "OnTime";
        #endregion B I N D I N G    P R O P E R T I E S
    }
    enum Airline
    {
        Unknown,
        [Description("I'm so sorry")]
        Southwest,
        United,
    }
}