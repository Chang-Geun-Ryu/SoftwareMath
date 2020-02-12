using System;
namespace Lab6
{
    public class Item
    {
        public EType Type
        {
            get;
        }
        public double Weight
        {
            get;
        }
        public double Volume
        {
            get;
        }
        public bool IsToxicWaste
        {
            get;
        }

        public Item(EType type, double weight, double volume, bool bToxicWaste)
        {
            Type = type;
            Weight = weight;
            Volume = volume;
            IsToxicWaste = bToxicWaste;
        }
    }
}
