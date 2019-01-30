namespace PrisonBreak.Scripts.Interactables
{
    using System.Collections;
    using System.Collections.Generic;
    using PrisonBreak.Scripts.Items;
    using UnityEngine;

    public class Bonus : PickUp
    { 
        [SerializeField]
        private float _points;

        protected override Item CreateItem()
        {
            return new BonusItem(Name, Weight, _points);
        }
    }
}