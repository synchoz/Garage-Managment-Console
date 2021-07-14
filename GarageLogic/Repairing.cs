using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Repairing
    {
        private readonly string r_Name;
        private readonly string r_Phone;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_Vehiclestatus;

        public Repairing(string i_OwnerName, string i_Phone, Vehicle i_Vehicle)
        {
            this.r_Name = i_OwnerName;
            this.r_Phone = i_Phone;
            this.m_Vehicle = i_Vehicle;
            this.m_Vehiclestatus = eVehicleStatus.InRepair;
        }

        public enum eVehicleStatus
        {
            InRepair = 1, Fixed, Paid
        }

        public string OwnerName
        {
            get
            {
                return this.r_Name;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return this.r_Phone;
            }
        }

        public eVehicleStatus Vehiclestatus
        {
            get
            {
                return this.m_Vehiclestatus;
            }

            set
            {
                this.m_Vehiclestatus = value;
            }
        }

        public Vehicle VehicleInRepair
        {
            get
            {
                return this.m_Vehicle;
            }

            set
            {
                this.m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string repairingInfo;
            repairingInfo = string.Format(
@"
Owner name: {0}
Owner phone: {1}
Vehicle status: {2}{3}",
this.OwnerName,
this.OwnerPhoneNumber,
this.Vehiclestatus.ToString(),
Environment.NewLine);
            str.Append(repairingInfo);
            str.Append(this.VehicleInRepair.ToString());

            return str.ToString();
        }
    }
}
