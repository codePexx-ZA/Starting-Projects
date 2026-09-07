using System;

namespace PatientDrill
{
    public class Patient
    {
        private string _fullName;

        public Patient(string fullname)
        {
            _fullName = fullname;
        }

        public string GetFullName()
        {
            return _fullName;
        }

        public void SetFullName(string newName)
        {
            _fullName = newName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var patient = new Patient("Liam");
            string name = patient.GetFullName();
            Console.WriteLine(name);

            patient.SetFullName("Liam Smith");
            Console.WriteLine(patient.GetFullName());
        }
    }
}
