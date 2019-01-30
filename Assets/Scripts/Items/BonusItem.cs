namespace PrisonBreak.Scripts.Items {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BonusItem : Item
    {
        private float points;

        public BonusItem(string name, float weight, float points) : base(name, weight)
        {
            this.points = points;
        }
    }
}