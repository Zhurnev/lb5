using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Windows.Forms;

namespace lb5
{
    public partial class Form1 : Form
    {
        private int[] numBeds = { 4, 3, 2, 4, 2, 3, 2, 3, 4, 3, 2, 4, 2, 3, 2, 3, 4, 3, 2, 4, 2, 3, 2, 3, 4, 3, 2, 4, 2, 3 };
        private decimal[] costPerDay = { 5, 7, 10, 10, 8, 7, 9, 7, 6, 8, 9, 5, 6, 7, 8, 10, 7, 6, 8, 9, 6, 7, 9, 8, 7, 6, 8, 9, 6, 7 };

        private volatile bool stopSimulation = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void RunSimulation(Hotel hotel, TextBox hotelStatusLog)
        {
            Thread guestThread = new Thread(() =>
            {
                while (!stopSimulation)
                {
                    if (hotel.IsFull())
                    {
                        int numRooms = hotel.Rooms.Count;
                        while (hotel.GetNumOccupiedRooms() >= (int)(numRooms * 0.9))
                        {
                            Thread.Sleep(1000);
                        }
                    }

                    Random rand = new Random();
                    int numDays = rand.Next(1, 7);
                    int numPeople = rand.Next(1, 5);
                    decimal costPerDay = this.costPerDay[rand.Next(this.costPerDay.Length)];
                    Guest guest = new Guest(numDays, costPerDay, numPeople);

                    int roomIndex = hotel.FindVacantRoom(guest);

                    if (roomIndex >= 0)
                    {
                        Room room = hotel.Rooms[roomIndex];

                        room.AssignGuest(guest);
                        hotel.UpdateCashRegister(room.CostPerDay * room.Occupant.NumDays);
                        UpdateCashRegisterLabel(hotel.CashRegister);
                        UpdateHotelStatusLog(hotelStatusLog, $"Guest {guest.Id} with {guest.NumPeople} people has checked into Room {roomIndex + 1} for {guest.NumDays} days");
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
            Thread timeThread = new Thread(() =>
            {
                while (!stopSimulation)
                {
                    Thread.Sleep(3000);
                    foreach (Room room in hotel.Rooms)
                    {
                        if (room.IsOccupied)
                        {
                            room.DaysRemaining--;
                            if (room.DaysRemaining <= 0)
                            {
                                UpdateHotelStatusLog(hotelStatusLog, $"Guest {room.Occupant.Id} has checked out. Room is now vacant.");
                                room.Release();
                            }
                        }
                    }
                    SaveHotelStatusLogToJson(hotel);
                }

            });
            guestThread.Start();
            timeThread.Start();
        }

        private void SaveHotelStatusLogToJson(Hotel hotel)
        {
            try
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Hotel));
                using (FileStream fileStream = new FileStream("hotel_status_log.json", FileMode.Create))
                {
                    jsonSerializer.WriteObject(fileStream, hotel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving hotel status log to JSON file: {ex.Message}");
            }
        }

        private void UpdateHotelStatusLog(TextBox textBox, string message)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() => textBox.AppendText(message + Environment.NewLine)));
            }
            else
            {
                textBox.AppendText(message + Environment.NewLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Hotel hotel = new Hotel(numBeds, costPerDay);
            Thread simThread = new Thread(() => RunSimulation(hotel, textBox1));
            simThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopSimulation = true;
            button1.Enabled = true;
        }
        private void UpdateCashRegisterLabel(decimal cashRegisterValue)
        {
            if (cashRegisterValueLabel.InvokeRequired)
            {
                cashRegisterValueLabel.Invoke(new Action(() => cashRegisterValueLabel.Text = $"{cashRegisterValue}$"));
            }
            else
            {
                cashRegisterValueLabel.Text = $"{cashRegisterValue}$";
            }
        }

    }
}
