namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDrivingDangeriousMaterial;
        private float m_CargoVolume;
        public const int k_AmountOfWheels = 16;
        public const float k_MaxAirPressure = 28f;
        public const float k_MaxFuelTank = 120f;

        public Truck(float i_CargoVolume, bool i_IsDangeriousMaterial, string i_ModelName, string i_LicenseNum, string i_BrandName, float i_CurrentAirPressure, float i_EnergyLeftInPct)
            : base(i_ModelName, i_LicenseNum, i_EnergyLeftInPct)
        {
            this.m_CargoVolume = i_CargoVolume;
            this.m_IsDrivingDangeriousMaterial = i_IsDangeriousMaterial;
            for (int i = 0; i < k_AmountOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_BrandName, i_CurrentAirPressure, k_MaxAirPressure));
            }

            IntializeEngineType(Engine.eTypeOfEngine.Fuel, i_EnergyLeftInPct);
        }

        public float MaxAirPressure
        {
            get
            {
                return k_MaxAirPressure;
            }
        }

    public bool IsDrivingDangeriousMaterial
        {
            get
            {
                return this.m_IsDrivingDangeriousMaterial;
            }
        }

        public float CargoVolume
        {
            get
            {
                return this.m_CargoVolume;
            }
        }

        public override void IntializeEngineType(Engine.eTypeOfEngine i_EngineType, float i_EnergyLeftInPct)
        {
            base.m_VehicleEngineType = new FuelEngine(k_MaxFuelTank, (float)(i_EnergyLeftInPct * k_MaxFuelTank / 100), FuelEngine.eFuelType.Soler);
            base.m_TypeOfEngine = Engine.eTypeOfEngine.Fuel;
        }

        public override string ToString()
        {
            string str;
            str = string.Format(
@"Type : Truck
{0}
Is the truck carrying Dangerious Material: {1}
Truck's cargo volume is: {2}", this.VehicleDetails(), this.IsDrivingDangeriousMaterial, this.CargoVolume);

            return str;
        }
    }
}
