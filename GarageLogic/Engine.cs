namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_MaxCapacity;
        private float m_CurrentCapacity;

        public Engine(float i_MaxCapacity, float i_CurrentCapacity)
        {
            this.m_MaxCapacity = i_MaxCapacity;
            this.m_CurrentCapacity = i_CurrentCapacity;
        }

        public enum eTypeOfEngine
        {
            Electric = 1, Fuel
        }

        public float CurrentCapacity
        {
            get
            {
                return this.m_CurrentCapacity;
            }

            set
            {
                this.m_CurrentCapacity = value;
            }
        }

        public float MaxCapacity
        {
            get
            {
                return this.m_MaxCapacity;
            }

            set
            {
                m_MaxCapacity = value;
            }
        }

        public abstract override string ToString();
    }
}
