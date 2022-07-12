using System.Text.RegularExpressions;
using ems.Client.app.model;
using OtpNet;

namespace ems.Client.app.utilities
{
    public class Utils
    {
        Regex emailRegex = new Regex(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");
        Regex phoneRegex = new Regex(@"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]
                {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)");

        public void ValidateEmployeeInfo(EmployeeModel model)
        {
            if (model.Name==null||model.Name.Length <= 0)
            {
                throw new Exception("Employee Name Required");
            }
            if (model.Phone==null||!phoneRegex.IsMatch(model.Phone)||model.Phone.Length!=10)
            {
                throw new Exception("Invalid Phone Number");
            }
            if (model.Email == null ||!emailRegex.IsMatch(model.Email))
            {
                throw new Exception("Invalid Email Address");
            }
            if (model.Name == null || model.Name.Length <= 0)
            {
                throw new Exception("Employee Name Required");
            }
        }

        public static string generateOTP()
        {
            var key = KeyGeneration.GenerateRandomKey(20);
            var base32String = Base32Encoding.ToString(key);
            var base32Bytes = Base32Encoding.ToBytes(base32String);
            var totp = new Totp(base32Bytes, mode: OtpHashMode.Sha512, totpSize: 8, step: 1);
            return totp.ComputeTotp();
        }
    }
}
