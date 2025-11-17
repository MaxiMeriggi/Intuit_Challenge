using System.Text.RegularExpressions;

namespace Intuit.Domain.Entities
{
    public class Client
    {
        public ulong Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string CompanyName { get; private set; }

        public string Cuit { get; private set; }

        public DateOnly BirthDate { get; private set; }

        public string Cellphone { get; private set; }

        public string Email { get; private set; }

        public DateTime? CreationDate { get; private set; }

        public DateTime? ModifiedDate { get; private set; }
        public Client()
        {
        }
        public static Client Create(string name,
                                string surname,
                                string companyName,
                                string cuit,
                                DateOnly birthDate,
                                string cellphone,
                                string email)
        {
            Validation(name, surname, companyName, cuit, birthDate, cellphone, email);

            return new Client
            {
                Name = name,
                Surname = surname,
                CompanyName = companyName,
                Cuit = cuit,
                BirthDate = birthDate,
                Cellphone = cellphone,
                Email = email,
                CreationDate = DateTime.Now,
                ModifiedDate = null
            };
        }

        public void Modify(string name,
                                string surname,
                                string companyName,
                                string cuit,
                                DateOnly birthDate,
                                string cellphone,
                                string email)
        {
            Validation(name, surname, companyName, cuit, birthDate, cellphone, email);

            Name = name;
            Surname = surname;
            CompanyName = companyName;
            Cuit = cuit;
            BirthDate = birthDate;
            Cellphone = cellphone;
            Email = email;
            ModifiedDate = DateTime.Now;
        }
        private static void Validation(string name, string surname, string companyName, string cuit, DateOnly birthDate,
                        string cellphone, string email)
        {
            ValidateName(name);
            ValidateSurname(surname);
            ValidateCuit(cuit);
            ValidateCompanyName(companyName);
            ValidateBirthDate(birthDate);
            ValidateCellphone(cellphone);
            ValidateEmail(email);
        }


        #region Validations
        private static readonly Regex EmailRegex =
            new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private static readonly Regex CuitRegex =
            new(@"^\d{2}-\d{8}-\d$", RegexOptions.Compiled);

        private static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Nombre no puede estar vacío");
            }
        }
        private static void ValidateSurname(string surname)
        {
            if (string.IsNullOrEmpty(surname))
            {
                throw new Exception("Apellido no puede estar vacío");
            }
        }
        private static void ValidateCuit(string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                throw new Exception("Cuit no puede estar vacío");
            }

            if (!CuitRegex.IsMatch(cuit))
            {
                throw new Exception("Cuit tiene formato incorrecto");
            }
        }
        private static void ValidateCompanyName(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
            {
                throw new Exception("Razón social no puede estar vacío");
            }
        }

        private static void ValidateBirthDate(DateOnly birthDate)
        {
            if (birthDate > DateOnly.FromDateTime(DateTime.Today))
                throw new Exception("La fecha de nacimiento no puede ser futura");
        }

        private static void ValidateCellphone(string cellphone)
        {
            if (string.IsNullOrEmpty(cellphone))
                throw new Exception("Celular no puede estar vacío");

        }

        private static void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("Email no puede estar vacío");

            if (!EmailRegex.IsMatch(email))
                throw new Exception("Email tiene formato incorrecto");
        }
        #endregion
    }
}
