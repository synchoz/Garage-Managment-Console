namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        private string m_WheelBrandName;

        public Wheel(string i_BrandName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            this.m_WheelBrandName = i_BrandName;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }

            set
            {
                this.m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return this.m_MaxAirPressure;
            }
        }

        public string WheelBrandName
        {
            get
            {
                return this.m_WheelBrandName;
            }
        }

        public void Inflating(float i_AmountOfAirToAdd)
        {
            if(this.CurrentAirPressure + i_AmountOfAirToAdd <= this.MaxAirPressure && i_AmountOfAirToAdd > 0)
            {
                this.CurrentAirPressure = this.CurrentAirPressure + i_AmountOfAirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.MaxAirPressure - this.CurrentAirPressure);
            }
        }

        public override string ToString()
        {
            string str;
            str = string.Format(
@"
    air pressure: {0}
    Brand: {1}",
this.CurrentAirPressure,
this.WheelBrandName);

            return str;
        }
    }
}
