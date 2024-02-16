namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if(Vehicles.Count != Capacity) Vehicles.Add(vehicle);
        }

        public bool RemoveVehicle(string vin)
        {
            foreach(Vehicle vehicle in Vehicles)
            {
                if(vehicle.VIN == vin) return Vehicles.Remove(vehicle);
            }
            return false;
        }

        public int GetCount()
        {
            return Vehicles.Count();
        }

        public Vehicle GetLowestMileage()
        {
            foreach(Vehicle vehicle in Vehicles)
            {
                if(vehicle.Mileage == Vehicles.Min(v => v.Mileage)) return vehicle;
            }
            return new Vehicle("", 0, "");
        }

        public string Report()
        {
            string result = "Vehicles in the preparatory:";
            foreach(Vehicle vehicle in Vehicles) result += $"\n{vehicle}";
            return result;
        }
    }
}
