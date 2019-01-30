namespace PrisonBreak.Scripts.Items
{
    public class AccessItem : Item
    {
        private int door;

        public AccessItem(string name, float weight, int door) : base(name, weight)
        {
            this.Door = door;
        }

        public int Door
        {
            get{return door;}
            private set{door = value;}
        }
    }
}