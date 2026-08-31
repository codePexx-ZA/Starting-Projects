using System;
using System.Threading;

namespace CarCruiseContorl
{
    public class Car
    {
        public string Name { get; set; } = string.Empty;
        public int CurrentSpeed { get; set; }
        public int DesiredSpeed { get; set; }
        public bool IsBrakeApplied { get; set; }
        public int LastDrivingSpeed { get; private set; }
        public CarState State { get; private set; } = CarState.Parked;

        public void SetSpeed(int speed)
        {
            CurrentSpeed = speed;
        }

        public void SetDesiredSpeed(int speed)
        {
            DesiredSpeed = speed;
        }

        public void SetBrakeStatus(bool status)
        {
            IsBrakeApplied = status;
        }

        public void ApplyBrake()
        {
            if (State != CarState.Driving)
            {
                Console.WriteLine($"{Name} is not in driving state");
                return;
            }

            LastDrivingSpeed = CurrentSpeed;
            IsBrakeApplied = true;
            State = CarState.Braking;

            Console.WriteLine($"{Name} is now braking");
        }

        public enum CarState
        {
            Parked,
            Driving,
            Braking,
            Stopped,
        }

        public void IncreaseCruiseSpeed(int amount)
        {
            if (State != CarState.Driving || IsBrakeApplied)
            {
                Console.WriteLine($"{Name} cannot increase cruise speed right now.");
                return;
            }

            DesiredSpeed += amount;
            Console.WriteLine($"{Name}'s cruise speed is now {DesiredSpeed} km/h");
        }

        public void DecreaseCruiseSpeed(int amount)
        {
            if (State != CarState.Driving || IsBrakeApplied)
            {
                Console.WriteLine($"{Name} cannot decrease cruise speed right now.");
                return;
            }

            DesiredSpeed -= amount;

            if (DesiredSpeed < 0)
            {
                DesiredSpeed = 0;
            }

            Console.WriteLine($"{Name}'s cruise speed is now {DesiredSpeed} km/h");
        }

        public void UpdateSpeed(int speedStep)
        {
            if (State == CarState.Braking)
            {
                CurrentSpeed -= speedStep;

                if (CurrentSpeed <= 0)
                {
                    CurrentSpeed = 0;
                    // CHANGED: Keep the recorded speed accurate when the car reaches zero.
                    LastDrivingSpeed = 0;
                    State = CarState.Stopped;
                    Console.WriteLine($"{Name} has stopped");
                }
                else
                {
                    // CHANGED: Record the latest speed shown during braking so P
                    // resumes at that speed instead of the original speed.
                    LastDrivingSpeed = CurrentSpeed;
                    Console.WriteLine($"{Name} is slowing down: {CurrentSpeed} km/h");
                }

                return;
            }

            if (State != CarState.Driving || IsBrakeApplied)
            {
                return;
            }

            if (CurrentSpeed < DesiredSpeed)
            {
                CurrentSpeed += speedStep;

                if (CurrentSpeed > DesiredSpeed)
                {
                    CurrentSpeed = DesiredSpeed;
                }
            }
            else if (CurrentSpeed > DesiredSpeed)
            {
                CurrentSpeed -= speedStep;

                if (CurrentSpeed < DesiredSpeed)
                {
                    CurrentSpeed = DesiredSpeed;
                }
            }

            Console.WriteLine($"{Name} is now driving at {CurrentSpeed} km/h");
        }

        public void StartDriving()
        {
            Console.WriteLine("Enter Desired Speed: ");
            if (!int.TryParse(Console.ReadLine(), out int desiredSpeed) || desiredSpeed < 0)
            {
                Console.WriteLine("Please enter a valid non-negative speed.");
                return;
            }

            DesiredSpeed = desiredSpeed;
            CurrentSpeed = DesiredSpeed;
            IsBrakeApplied = false;
            State = CarState.Driving;
            Console.WriteLine($"{Name} is now driving at {DesiredSpeed} km/h");
        }

        public void StopDriving()
        {
            CurrentSpeed = 0;
            State = CarState.Stopped;
            Console.WriteLine($"{Name} has stopped");
        }

        public void ContinueDriving()
        {
            if (State != CarState.Braking)
            {
                Console.WriteLine($"{Name} is not currently braking.");
                return;
            }

            CurrentSpeed = LastDrivingSpeed;
            DesiredSpeed = LastDrivingSpeed;
            IsBrakeApplied = false;
            State = CarState.Driving;

            Console.WriteLine($"{Name} resumed at {CurrentSpeed} km/h");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the car: ");
            string name = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("please enter a valid name");
                return;
            }

            Car car = new Car
            {
                Name = name,
                CurrentSpeed = 0,
                DesiredSpeed = 0,
                IsBrakeApplied = false,
            };

            Console.WriteLine($"Press Enter to start driving {name}");
            Console.ReadLine();

            car.StartDriving();

            Console.WriteLine(
                "Press + to increase speed, - to decrease speed, b to apply brake, p to continue driving at last recorded speed, s to stop, q to quit"
            );
            while (
                car.State == Car.CarState.Driving ||
                car.State == Car.CarState.Braking
            )
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Add || key == ConsoleKey.OemPlus)
                    {
                        car.IncreaseCruiseSpeed(5);
                    }
                    else if (key == ConsoleKey.Subtract || key == ConsoleKey.OemMinus)
                    {
                        car.DecreaseCruiseSpeed(5);
                    }
                    else if (key == ConsoleKey.B)
                    {
                        car.ApplyBrake();
                    }
                    else if (key == ConsoleKey.P)
                    {
                        car.ContinueDriving();
                    }
                    else if (key == ConsoleKey.S)
                    {
                        car.StopDriving();
                    }
                    else if (key == ConsoleKey.Q)
                    {
                        Console.WriteLine("Quitting...");
                        return;
                    }
                }

                car.UpdateSpeed(5);
                Thread.Sleep(500);
            }
        }
    }
}
