using System.Text.RegularExpressions;

namespace Fornecedores.Application.Helpers
{
    public static class ValidadorEmail
    {
        public static bool VerifiaSeEmailEValido(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                var regex = new Regex(emailPattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
