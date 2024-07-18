using System;

namespace Nutricionista.Models
{
    public class Paciente
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }

        public int CalcularEdad()
        {
            var today = DateTime.Today;
            var age = today.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > today.AddYears(-age)) age--;
            return age;
        }

        public decimal CalcularIMC()
        {
            return Peso / (Altura * Altura);
        }

        public string ObtenerCategoriaIMC()
        {
            var imc = CalcularIMC();

            if (imc < 18)
                return "Peso Bajo";
            else if (imc < 25)
                return "Peso Normal";
            else if (imc < 27)
                return "Sobrepeso";
            else if (imc < 30)
                return "Obesidad grado I";
            else if (imc < 40)
                return "Obesidad grado II";
            else
                return "Obesidad grado III";
        }

        public string ObtenerColorCategoriaIMC()
        {
            var categoria = ObtenerCategoriaIMC();

            return categoria switch
            {
                "Peso Bajo" => "yellow",
                "Peso Normal" => "green",
                "Sobrepeso" => "orange",
                "Obesidad grado I" => "red",
                "Obesidad grado II" => "darkred",
                "Obesidad grado III" => "purple",
                _ => "gray"
            };
        }
    }
}
