namespace Ex03.ConsoleUI
{
    using System;
    using Ex03.GarageLogic;
    public class Control
    {
        internal static Vehicle InsertVehicle()
        {
            Vehicle.eVehicleType typeOfVehicleChoosen = UI.GetVehicleType();
            string model = UI.GetVehicleModel();
            string licenseNumber = UI.GetLicensePlate();
            float energyPercent = UI.GetEnergyPercent();
            string wheelBrand = UI.GetWheelManufactor();
            Vehicle newVehicle = null;

            try
            {
                switch (typeOfVehicleChoosen)
                {
                    case Vehicle.eVehicleType.Truck:
                        newVehicle = createTruck(model, licenseNumber, energyPercent, wheelBrand, UI.GetCurrentAirPressure(Truck.k_MaxAirPressure));
                        break;
                    case Vehicle.eVehicleType.Car:
                        newVehicle = createCar(model, licenseNumber, energyPercent, UI.GetTypeOfEnergy(), wheelBrand, UI.GetCurrentAirPressure(Car.k_MaxAirPressure));
                        break;
                    case Vehicle.eVehicleType.Motorcycle:
                        newVehicle = createMotorcycle(model, licenseNumber, energyPercent, UI.GetTypeOfEnergy(), wheelBrand, UI.GetCurrentAirPressure(Motorcycle.k_MaxAirPressure));
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error" + Environment.NewLine);
            }

            return newVehicle;
        }

        private static Vehicle createCar(string i_Model, string i_LicenseNumber, float i_EnergyPercent, Engine.eTypeOfEngine i_EngineType, string i_WheelBrand, float i_WheelCurPressure)
        {
            Car.eNumberOfDoors numDoors = UI.GetNumOfDoors();
            Car.eColor color = UI.GetColor();
            
            return VehicleGenerator.CreateNewCar(color, numDoors, i_Model, i_LicenseNumber, i_WheelBrand, i_WheelCurPressure, i_EnergyPercent, i_EngineType);
        }

        private static Vehicle createMotorcycle(string i_Model, string i_LicenseNumber, float i_EnergyPercent, Engine.eTypeOfEngine i_TypeOfEnergy, string i_WheelBrand, float i_WheelCurPressure)
        {
            Motorcycle.eLicenseTypes typeOfLicense = UI.GetMotorcycleLicenseType();
            int motorcycleEngineVolume = UI.GetMotorcycleEngineVolume();

            return VehicleGenerator.CreateNewMotorcycle(typeOfLicense, motorcycleEngineVolume, i_Model, i_LicenseNumber, i_EnergyPercent, i_WheelBrand, i_WheelCurPressure, i_TypeOfEnergy);
        }

        private static Vehicle createTruck(string i_Model, string i_LicenseNumber, float i_EnergyPercent, string i_WheelBrand, float i_WheelCurPressure)
        {
            bool isCarryDangerousMaterial = UI.GetIsCarryDangerousMaterial();
            float cargoVolume = UI.GetVolumeOfCargo();

            return VehicleGenerator.CreateNewTruck(cargoVolume, isCarryDangerousMaterial, i_Model, i_LicenseNumber, i_WheelBrand, i_WheelCurPressure, i_EnergyPercent);
        }
    }
}
