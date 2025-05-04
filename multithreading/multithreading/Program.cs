using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace multithreading
{
    public class PassengerStop
    {
        private int waitingPassengers = 0;

        private readonly object lockObj = new object();

        public void AddPassengers(int count)
        {
            lock (lockObj)
            {
                waitingPassengers += count;
                Console.WriteLine($"На остановке {waitingPassengers} человеков");
            }
        }

        public int GetWaitingPassengers()
        {
            lock (lockObj)
            {
                return waitingPassengers;
            }
        }

        public void RemovePassengers(int count)
        {
            lock (lockObj)
            {
                waitingPassengers -= count;
                if (waitingPassengers < 0)
                    waitingPassengers = 0;
            }
        }
    }

    public class Bus
    {
        private readonly string busNumber;
        private readonly int capacity;
        private readonly AutoResetEvent newPassengersEvent;
        private readonly PassengerStop stop;
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public Bus(string busNumber, int capacity, PassengerStop stop, AutoResetEvent newPassengersEvent)
        {
            this.busNumber = busNumber;
            this.capacity = capacity;
            this.stop = stop;
            this.newPassengersEvent = newPassengersEvent;
        }

        public void Run()
        {
            while (true)
            {
                newPassengersEvent.WaitOne(); // ждём сигнал от диспетчера

                int waiting = stop.GetWaitingPassengers();
                if (waiting == 0)
                    continue;

                int boardingCount = Math.Min(capacity, waiting);

                Console.WriteLine($"\nАвтобус №{busNumber} подъехал");
               
                Barrier barrier = new Barrier(boardingCount + 1);

                for (int i = 0; i < boardingCount; i++)
                {
                    int passengerId = i + 1;
                    Task.Run(() =>
                    {
                        semaphore.Wait();
                
                        semaphore.Release();

                        barrier.SignalAndWait(); // ждёт остальных
                    });
                }

                barrier.SignalAndWait(); // автобус ждёт посадку всех

                stop.RemovePassengers(boardingCount);
                Console.WriteLine($"Автобус №{busNumber} забрал {boardingCount} человеков. Осталось {stop.GetWaitingPassengers()} на остановке\n");

                Thread.Sleep(3000); // Пауза между рейсами
            }
        }
    }

    public class Dispatcher
    {
        private readonly PassengerStop stop;
        private readonly AutoResetEvent newPassengersEvent;
        private readonly Random random = new Random();

        public Dispatcher(PassengerStop stop, AutoResetEvent newPassengersEvent)
        {
            this.stop = stop;
            this.newPassengersEvent = newPassengersEvent;
        }

        public void Run()
        {
            while (true)
            {
                int newPassengers = random.Next(1, 21);
                stop.AddPassengers(newPassengers);
                Console.WriteLine($"На остановку подошли {newPassengers} человеков");

                newPassengersEvent.Set(); // сигнал автобусу

                Thread.Sleep(random.Next(2000, 4000)); // пауза перед новыми пассажирами
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PassengerStop stop = new PassengerStop();

            AutoResetEvent newPassengersEvent = new AutoResetEvent(false);

            Dispatcher dispatcher = new Dispatcher(stop, newPassengersEvent);

            Bus bus = new Bus("150", 25, stop, newPassengersEvent);

            Task.Run(() => dispatcher.Run());

            Task.Run(() => bus.Run());

            Console.ReadLine();
        }
    }
}
