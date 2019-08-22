using System;
using PhoneNumbers;

namespace Crosshelper.Helpers
{
    public class PhoneNumberValidator
    {
        public PhoneNumberValidator()
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                string telephoneNumber = "03336323900";
                string countryCode = "PK";
                PhoneNumber phoneNumber = phoneUtil.Parse(telephoneNumber, countryCode);

                bool isMobile = false;
                bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber); // returns true for valid number    

                // returns trueor false w.r.t phone number region  
                bool isValidRegion = phoneUtil.IsValidNumberForRegion(phoneNumber, countryCode);

                string region = phoneUtil.GetRegionCodeForNumber(phoneNumber); // GB, US , PK    

                var numberType = phoneUtil.GetNumberType(phoneNumber); // Produces Mobile , FIXED_LINE    

                string phoneNumberType = numberType.ToString();

                if (!string.IsNullOrEmpty(phoneNumberType) && phoneNumberType == "MOBILE")
                {
                    isMobile = true;
                }

                var originalNumber = phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164); // Produces "+923336323997"    

                var data = new ValidatePhoneNumberModel

                {
                    FormattedNumber = originalNumber,
                    IsMobile = isMobile,
                    IsValidNumber = isValidNumber,
                    IsValidNumberForRegion = isValidRegion,
                    Region = region
                };

                returnResult = new GenericResponse<ValidatePhoneNumberModel>()
                {
                    Data = data,
                    StatusCode = HttpStatusCode.OK,
                    StatusMessage = "Success"
                };

            }
            catch (NumberParseException ex)
            {

                String errorMessage = "NumberParseException was thrown: " + ex.Message.ToString();


                returnResult = new GenericResponse<ValidatePhoneNumberModel>()
                {
                    Message = errorMessage,
                    StatusCode = HttpStatusCode.BadRequest,
                    StatusMessage = "Failed"
                };
            }
        }
    }
}
