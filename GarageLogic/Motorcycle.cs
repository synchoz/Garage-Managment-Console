namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private int m_EngineVolume;
        private eLicenseTypes m_LicenseType;
        public const int k_AmountOfWheels = 2;
        public const float k_MaxBatteryCharge = 1.2f;
        public const float k_MaxAirPressure = 30f;
        public const float k_MaxFuelTank = 7f;

        public Motorcycle(eLicenseTypes i_LicenseType, int i_EngineVolume, string i_ModelName, string i_LicenseNum, float i_EnergyLeftInPct, string i_BrandName, float i_CurrentAirPressure, Engine.eTypeOfEngine i_VehicleEngine)
           : base(i_ModelName, i_LicenseNum, i_EnergyLeftInPct)
        {
            this.m_LicenseType = i_LicenseType;
            this.m_EngineVolume = i_EngineVolume;
            for (int i = 0; i < k_AmountOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_BrandName, i_CurrentAirPressure, k_MaxAirPressure));
            }

            IntializeEngineType(i_VehicleEngine, i_EnergyLeftInPct);
        }
            
        public int EngineVolume
        {
            get
            {
                return this.m_EngineVolume;
            }
        }
            
        public enum eLicenseTypes
        {
            A = 1, A1, AA, B
        }

        public eLicenseTypes LicenseType
        {
            get
            {
                return this.m_LicenseType;
            }
        }

        public override void IntializeEngineType(Engine.eTypeOfEngine i_EngineType, float i_EnergyLeftInPct)
        {
            if (i_EngineType == Engine.eTypeOfEngine.Fuel)
            {
                base.m_VehicleEngineType = new FuelEngine(k_MaxFuelTank, (float)(i_EnergyLeftInPct * k_MaxFuelTank / 100), FuelEngine.eFuelType.Octan95);
                base.m_TypeOfEngine = Engine.eTypeOfEngine.Fuel; 
            }
            else
            {
                base.m_VehicleEngineType = new ElectricEngine(k_MaxBatteryCharge, (float)(i_EnergyLeftInPct * k_MaxBatteryCharge / 100));
                base.m_TypeOfEngine = Engine.eTypeOfEngine.Electric;
            }
        }

        public override string ToString()
        {
            string str;
            str = string.Format(
@"Vehicle Type: Motorcyle
{0}
License type:{1}
Engine Volume: {2}",
this.VehicleDetails(),
this.LicenseType,
this.EngineVolume);

            return str;
        }
    }
}