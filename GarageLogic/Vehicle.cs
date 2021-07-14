using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private readonly List<Wheel> r_Wheels;
        private float m_EnergyLeftInPercent;
        protected Engine m_VehicleEngineType;
        protected Engine.eTypeOfEngine m_TypeOfEngine;

        public Vehicle(string i_ModelName, string i_LicenseNum, float i_EnergyLeftInPct)
        {
            this.r_ModelName = i_ModelName;
            this.r_LicenseNumber = i_LicenseNum;
            this.m_EnergyLeftInPercent = i_EnergyLeftInPct;
            this.r_Wheels = new List<Wheel>();
        }

        public string ModelName
        {
            get
            {
                return this.r_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.r_LicenseNumber;
            }
        }

        internal void UpdateLeftPercent()
        {
            EnergyLeftInPercent = VehicleEnergyDetails.CurrentCapacity / VehicleEnergyDetails.MaxCapacity * 100f;
        }

        public float EnergyLeftInPercent
        {
            get
            {
                return this.m_EnergyLeftInPercent;
            }

            set
            {
                this.m_EnergyLeftInPercent = value; 
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return this.r_Wheels;
            }
        }

        public Engine VehicleEnergyDetails
        {
            get
            {
                return m_VehicleEngineType;
            }
        }
        
        public Engine.eTypeOfEngine VehicleEngineType
        {
            get
            {
                return m_TypeOfEngine;
            }
        }

        public enum eVehicleType
        {
            Car = 1, Truck, Motorcycle
        }

        public abstract void IntializeEngineType(Engine.eTypeOfEngine i_EngineType, float i_EnergyLeftInPct);

        public string VehicleDetails()
        {
            string str;
            str = string.Format(
@"Vehicle lisence Plate Number: {0}
Vehicle Model Name: {1}
Wheels details:{2}
Enery Percent left: {3}%
Type of engine:{4}
{5}",
this.LicenseNumber,
this.ModelName,
this.Wheels[0].ToString(),
this.EnergyLeftInPercent,
this.VehicleEngineType.ToString(),
this.VehicleEnergyDetails);

            return str;
        }

        public abstract override string ToString();
    }
}
