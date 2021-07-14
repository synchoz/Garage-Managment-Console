namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        public static Vehicle CreateNewCar(Car.eColor i_Color, Car.eNumberOfDoors i_NumberOfDoors, string i_ModelName, string i_LicenseNum, string i_BrandName, float i_CurrentAirPressure, float i_EnergyLeftInPct, Engine.eTypeOfEngine i_VehicleEngine)
        {
            Vehicle newCar = new Car(i_Color, i_NumberOfDoors, i_ModelName, i_LicenseNum, i_BrandName, i_CurrentAirPressure, i_EnergyLeftInPct, i_VehicleEngine);

            return newCar;
        }

        public static Vehicle CreateNewTruck(float i_CargoVolume, bool i_IsDangeriousMaterial, string i_ModelName, string i_LicenseNum, string i_BrandName, float i_CurrentAirPressure, float i_EnergyLeftInPct)
        {
            Vehicle newTruck = new Truck(i_CargoVolume, i_IsDangeriousMaterial, i_ModelName, i_LicenseNum, i_BrandName, i_CurrentAirPressure, i_EnergyLeftInPct);

            return newTruck;
        }

        public static Vehicle CreateNewMotorcycle(Motorcycle.eLicenseTypes i_TypeOfLicense, int i_EngineVolume, string i_ModelName, string i_LicenseNum, float i_EnergyCurrent, string i_WheelManufactor, float i_WheelCurrentPressure, Engine.eTypeOfEngine i_TypeOfEngine)
        {
            Vehicle newMotorcycle = new Motorcycle(i_TypeOfLicense, i_EngineVolume, i_ModelName, i_LicenseNum, i_EnergyCurrent, i_WheelManufactor, i_WheelCurrentPressure, i_TypeOfEngine);

            return newMotorcycle;
        }
    }
}
