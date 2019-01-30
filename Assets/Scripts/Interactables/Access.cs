namespace PrisonBreak.Scripts.Interactables
{
    using PrisonBreak.Scripts.Items;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Access : PickUp
    {
        [SerializeField]
        private int _doorId;

        protected override Item CreateItem()
        {
            return new AccessItem(Name, Weight, _doorId);
        }
    }
}