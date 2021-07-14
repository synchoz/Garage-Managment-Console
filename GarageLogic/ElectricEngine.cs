namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine 
    {
        public ElectricEngine(float i_MaxCapacity, float i_CurrentCapacity)
            : base(i_MaxCapacity, i_CurrentCapacity)
        {
        }

        public void RechargBattery(float i_TimeForRecharge)
        {
            if (i_TimeForRecharge + (this.CurrentCapacity * 60f) <= (this.MaxCapacity * 60f) && i_TimeForRecharge > 0)
            {
                this.CurrentCapacity += i_TimeForRecharge / 60f;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.MaxCapacity - this.CurrentCapacity);
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Current amount of battery : {0} hours
Max amount of battrey : {1} hours",
this.CurrentCapacity,
this.MaxCapacity);
        }
    }
}
