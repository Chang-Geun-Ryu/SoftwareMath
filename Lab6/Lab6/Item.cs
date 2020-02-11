using System;
namespace Lab6
{
    public class Item
    {
        public EType Type;
        public double Weight;
        public double Volume;
        public bool IsToxicWaste;

        public Item(EType type, double weight, double volume, bool bToxicWaste)
        {
            this.Type = type;
            this.Weight = weight;
            this.Volume = volume;
            this.IsToxicWaste = bToxicWaste;
        }
    }
}
