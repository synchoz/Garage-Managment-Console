using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue; 
        private float m_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        public float min
        {
            get
            {
                return this.m_MinValue;
            }

            set
            {
                this.m_MinValue = value;
            }
        }

        public float max
        {
            get
            {
                return this.m_MaxValue;
            }

            set
            {
                this.m_MaxValue = value;
            }
        }
    }
}
