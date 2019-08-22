namespace Crosshelper.Models
{
    public class PhoneNumberCheckViewModel
    {
        private string _countryCodeSelected;

        public string CountryCodeSelected
        {
            get => _countryCodeSelected;
            set => _countryCodeSelected = value.ToUpperInvariant();
        }

        public string PhoneNumberRaw { get; set; }

        public bool Valid { get; set; }

        public bool HasExtension { get; set; }

        // Optionally, add more fields here for returning data to the user.
    }
}