namespace PrisonBreak.Scripts.Items
{
    public abstract class Item
    {
        private string name;

        private float weight;

        public Item(string name, float weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public float Weight
        {
            get{return weight;}
            private set{weight = value;}
        }

        public string Name
        {
            get{return name;}
            private set{name = value;}
        }
    }
}