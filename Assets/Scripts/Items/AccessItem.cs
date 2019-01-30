namespace PrisonBreak.Scripts.Items
{
    public class AccessItem : Item
    {
        private int door;

        public AccessItem(string name, float weight, int door) : base(name, weight)
        {
            this.door = door;
        }
    }
}