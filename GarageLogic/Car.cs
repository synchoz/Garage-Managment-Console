namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_AmountOfWheels = 4;
        private const float k_MaxBatteryCharge = 2.1f;
        public const float k_MaxAirPressure = 32f;
        private const float k_MaxFuelTank = 60f;
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(eColor i_Color, eNumberOfDoors i_NumberOfDoors, string i_ModelName, string i_LicenseNum, string i_BrandName, float i_CurrentAirPressure, float i_EnergyLeftInPct, Engine.eTypeOfEngine i_VehicleEngine)
            : base(i_ModelName, i_LicenseNum, i_EnergyLeftInPct)
        {
            this.m_Color = i_Color;
            this.m_NumberOfDoors = i_NumberOfDoors;

            for (int i = 0; i < k_AmountOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_BrandName, i_CurrentAirPressure, k_MaxAirPressure));
            }

            IntializeEngineType(i_VehicleEngine, i_EnergyLeftInPct);
        }

        public eColor Color
        {
            get
            {
                return this.m_Color;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return this.m_NumberOfDoors;
            }
        }

        public enum eColor
        {
            Red = 1, White, Black, Silver
        }

        public enum eNumberOfDoors
        {
            Two = 2, Three, Four, Five
        }

        public override string ToString()
        {
            string str;

            str = string.Format(
@"Vehicle Type: Car
{0}
Color: {1}
Number of Doors: {2}",
this.VehicleDetails(),
this.Color.ToString(),
this.NumberOfDoors.ToString());

            return str;
        }

        public override void IntializeEngineType(Engine.eTypeOfEngine i_EngineType, float i_EnergyLeftInPct)
        {
            if (i_EngineType == Engine.eTypeOfEngine.Fuel)
            {
                base.m_VehicleEngineType = new FuelEngine(k_MaxFuelTank, (float)(i_EnergyLeftInPct * k_MaxFuelTank / 100), FuelEngine.eFuelType.Octan96);
                base.m_TypeOfEngine = Engine.eTypeOfEngine.Fuel; 
            }
            else
            {
                base.m_VehicleEngineType = new ElectricEngine(k_MaxBatteryCharge, (float)(i_EnergyLeftInPct * k_MaxBatteryCharge / 100));
                base.m_TypeOfEngine = Engine.eTypeOfEngine.Electric;
            }
        }
    }
}
