using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private eFuelType m_FuelType;

        public FuelEngine(float i_MaxCapacity, float i_CurrentCapacity, eFuelType i_FuelType)
            : base(i_MaxCapacity, i_CurrentCapacity)
        {
            this.m_FuelType = i_FuelType;
        }

        public enum eFuelType
        {
            Soler = 1, Octan95, Octan96, Octan98
        }

        public eFuelType FuelType
        {
            get
            {
                return this.m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }

        internal void RefuelingVehicle(float i_AmountOfFuell, eFuelType i_FuelType)
        {
            if (i_FuelType == this.FuelType)
            {
                if (this.CurrentCapacity + i_AmountOfFuell <= this.MaxCapacity && i_AmountOfFuell > 0)
                {
                    this.CurrentCapacity += i_AmountOfFuell;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, this.MaxCapacity - this.CurrentCapacity);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Current amount of fuel : {0}
Max amount of fuel : {1}
Fuel Type: {2}",
this.CurrentCapacity,
this.MaxCapacity,
this.FuelType);
        }
    }
}
