using Medical;
using System;

namespace Medical
{
    public class HospitalDemo
    {
        private Hospital hospital = new Hospital();

        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            while (true)
            {
                Console.WriteLine("\nОберіть дію:");
                Console.WriteLine("1. Додати лікаря");
                Console.WriteLine("2. Реєструвати пацієнта");
                Console.WriteLine("3. Створити палату");
                Console.WriteLine("4. Госпіталізувати пацієнта");
                Console.WriteLine("5. Додати медичний запис");
                Console.WriteLine("6. Переглянути історію пацієнта");
                Console.WriteLine("7. Переглянути статистику лікарні");
                Console.WriteLine("0. Вихід");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddDoctor(); break;
                    case "2": RegisterPatient(); break;
                    case "3": CreateRoom(); break;
                    case "4": HospitalizePatient(); break;
                    case "5": AddMedicalRecord(); break;
                    case "6": ShowPatientHistory(); break;
                    case "7": ShowStatistics(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір!"); break;
                }
            }
        }

        private void AddDoctor()
        {
            Console.Write("ID лікаря: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Ім'я лікаря: ");
            string name = Console.ReadLine();
            Console.Write("Спеціалізація: ");
            string spec = Console.ReadLine();

            hospital.AddDoctor(new Doctor(id, name, spec));
        }

        private void RegisterPatient()
        {
            Console.Write("ID пацієнта: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Ім'я пацієнта: ");
            string name = Console.ReadLine();
            Console.Write("Вік: ");
            int age = int.Parse(Console.ReadLine());

            hospital.RegisterPatient(new Patient(id, name, age));
        }

        private void CreateRoom()
        {
            Console.Write("Номер палати: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Місткість: ");
            int capacity = int.Parse(Console.ReadLine());

            hospital.CreateRoom(new HospitalRoom(number, capacity));
        }

        private void HospitalizePatient()
        {
            Console.Write("ID пацієнта: ");
            int pid = int.Parse(Console.ReadLine());
            Console.Write("Номер палати: ");
            int roomNumber = int.Parse(Console.ReadLine());

            hospital.HospitalizePatient(pid, roomNumber);
        }

        private void AddMedicalRecord()
        {
            Console.Write("ID пацієнта: ");
            int pid = int.Parse(Console.ReadLine());
            var patient = hospital.Patients.Find(p => p.Id == pid);
            if (patient == null)
            {
                Console.WriteLine("Пацієнт не знайдений!");
                return;
            }

            Console.Write("ID лікаря: ");
            int did = int.Parse(Console.ReadLine());
            var doctor = hospital.Doctors.Find(d => d.Id == did);
            if (doctor == null)
            {
                Console.WriteLine("Лікар не знайдений!");
                return;
            }

            Console.Write("Опис медичного запису: ");
            string desc = Console.ReadLine();

            hospital.AddMedicalRecord(new MedicalRecord(patient, doctor, DateTime.Now, desc));
        }

        private void ShowPatientHistory()
        {
            Console.Write("ID пацієнта: ");
            int pid = int.Parse(Console.ReadLine());

            var history = hospital.GetPatientHistory(pid);
            if (history.Count == 0)
            {
                Console.WriteLine("Історія пацієнта порожня.");
                return;
            }

            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }
        }

        private void ShowStatistics()
        {
            Console.WriteLine(hospital.GetStatistics());
        }
    }
}
