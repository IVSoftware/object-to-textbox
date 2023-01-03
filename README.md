Your simple question is **how to display details from an object to a TextBox**.

I see in your code that you've done a good job of overriding the `ToString` method. In a sense, you answered your own question because that's what it takes!

But let's try and boil all that code into a [minimal reproducible example](https://stackoverflow.com/help/minimal-reproducible-example) that will include data binding as Jimi so rightly recommended. The bare bones of our bindable class has this override:

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
        .
        .
        .
    }

Next, write the main form code to display details from an object to a TextBox.

[![show from button][1]][1]

One salient point is that `ToString()` can just be called on `object` because it's [virtual](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual).

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
        }
    }
***

Your question also states **I have a ListBox called `aircraftList`...**. 

[![form with listbox][2]][2]

When a listbox is bound to `BindingList<AircraftDetails>` you can specify the `DisplayMember` property. So now add code to the main form's `Load` event to set this up:

    public partial class MainForm : Form
    {
        .
        .
        .
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


  [1]: https://i.stack.imgur.com/6F065.png
  [2]: https://i.stack.imgur.com/XS1ZY.png