using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Repairing> m_VehicleList = new Dictionary<string, Repairing>(); 

        public Dictionary<string, Repairing> VehicleList
        {
            get
            {
                return this.m_VehicleList;
            }

            set
            {
                this.m_VehicleList = value;
            }
        }

        public string VehicleAlreadyInGarage(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            string message;

            if (this.VehicleList.ContainsKey(i_Vehicle.LicenseNumber) != true)
            {
                this.VehicleList.Add(i_Vehicle.LicenseNumber, new Repairing(i_OwnerName, i_OwnerPhone, i_Vehicle));
                message = Environment.NewLine + "The vehicle has just been added to the garage" + Environment.NewLine;
            }
            else
            {
                this.ChangeStatus(i_Vehicle.LicenseNumber, Repairing.eVehicleStatus.InRepair);
                message = Environment.NewLine + "The vehicle is already inside the garage and now it is being repaired" + Environment.NewLine;
            }

            return message;
        }

        public List<string> VehiclesInGarage()
        {
            List<string> vehicleList = new List<string>();
            foreach (KeyValuePair<string, Repairing> vehicle in this.VehicleList)
            {
                vehicleList.Add(vehicle.Key);
            }

            return vehicleList;
        }

        public void ChangeStatus(string i_LicenseNumber, Repairing.eVehicleStatus i_Status)
        {
            if (this.isVehicleExists(i_LicenseNumber) == true)
            {
                this.VehicleList[i_LicenseNumber].Vehiclestatus = i_Status;
            }
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            if (this.isVehicleExists(i_LicenseNumber) == true)
            {
                foreach (Wheel wheel in this.VehicleList[i_LicenseNumber].VehicleInRepair.Wheels)
                {
                    wheel.Inflating(wheel.MaxAirPressure - wheel.CurrentAirPressure);
                }
            }
        }

        public List<string> VehiclesInGarageByFilter(Repairing.eVehicleStatus i_Status)
        {
            List<string> vehicleList = new List<string>();
            foreach (KeyValuePair<string, Repairing> vehicle in VehicleList)
            {
                if (i_Status == vehicle.Value.Vehiclestatus)
                {
                    vehicleList.Add(vehicle.Key);
                }
            }

            return vehicleList;
        }

        public void RefuelTankVehicle(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType, float i_AmountToFill)
        {
            if (this.isVehicleExists(i_LicenseNumber) == true)
            {
                if (this.VehicleList[i_LicenseNumber].VehicleInRepair.VehicleEnergyDetails is FuelEngine)
                {
                    ((FuelEngine)this.VehicleList[i_LicenseNumber].VehicleInRepair.VehicleEnergyDetails).RefuelingVehicle(i_AmountToFill, i_FuelType);
                    ((Vehicle)this.VehicleList[i_LicenseNumber].VehicleInRepair).UpdateLeftPercent();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void RechargeBatteryVehicle(string i_LicenseNumber, float i_TimeToCharge)
        {
            if (this.isVehicleExists(i_LicenseNumber) == true)
            {
                if (this.VehicleList[i_LicenseNumber].VehicleInRepair.VehicleEnergyDetails is ElectricEngine)
                {
                    ((ElectricEngine)this.VehicleList[i_LicenseNumber].VehicleInRepair.VehicleEnergyDetails).RechargBattery(i_TimeToCharge);
                    ((Vehicle)this.VehicleList[i_LicenseNumber].VehicleInRepair).UpdateLeftPercent();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public bool IsGarageEmpty()
        {
            bool empty = false;

            if (this.m_VehicleList.Count == 0) 
            {
                empty = true;
            }

            return empty;
        }

        private bool isVehicleExists(string i_LicenseNumber)
        {
            bool exists = true;

            if (this.VehicleList.ContainsKey(i_LicenseNumber) != true)
            {
                throw new ArgumentException();
            }

            return exists;
        }

        public string GetVehicleDetails(string i_LicenseNumber)
        {
            string details = null;

            if (this.isVehicleExists(i_LicenseNumber) == true)
            {
                details = this.VehicleList[i_LicenseNumber].ToString();
            }

            return details;
        }
    }
}
