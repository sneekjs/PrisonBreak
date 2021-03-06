﻿namespace PrisonBreak.Scripts.Interactables
{
    using PrisonBreak.Scripts.Interfaces;
    using PrisonBreak.Scripts.Items;
    using PrisonBreak.Scripts.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class PickUp : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private float _weight;

        protected float Weight
        {
            get{return _weight;}
            set{_weight = value;}
        }

        protected string Name
        {
            get{return _name;}
            set{_name = value;}
        }

        private void Start()
        {
            UIController.Instance.GameObjectsInInventory.Add(_name, this);
        }

        public virtual void Action()
        {
            if (Inventory.Instance.AddItem(CreateItem()))
            {
                gameObject.SetActive(false);
            }
        }

        protected abstract Item CreateItem();
    }
}