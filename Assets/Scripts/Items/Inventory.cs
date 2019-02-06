namespace PrisonBreak.Scripts.Items {
    using PrisonBreak.Scripts.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private List<Item> _invenoryItems = new List<Item>();

        [SerializeField]
        private float _totalWeight;

        [SerializeField]
        private float _maxWeight = 10f;

        [SerializeField]
        private UIController _uIController;

        public static Inventory Instance;

        public List<Item> InvenoryItems
        {
            get { return _invenoryItems; }
            set { _invenoryItems = value; }
        }

        public float TotalWeight
        {
            get { return _totalWeight; }
            set { _totalWeight = value; }
        }

        public float MaxWeight
        {
            get { return _maxWeight; }
            set { _maxWeight = value; }
        }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public bool AddItem(Item item)
        {
            if (TotalWeight + item.Weight > MaxWeight)
            {
                return false;
            }
            else
            {
                InvenoryItems.Add(item);
                TotalWeight += item.Weight;
                _uIController.AddItemToInventory(item);
                return true;
            }
        }

        public void RemoveItem(Item item)
        {
            if (InvenoryItems.Remove(item))
            {
                TotalWeight -= item.Weight;
            }
        }

        public bool HasKey(int id)
        {
            for (int i = 0; i < InvenoryItems.Count; i++)
            {
                if (InvenoryItems[i] is AccessItem)
                {
                    AccessItem it = (AccessItem)InvenoryItems[i];
                    if (it.Door == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void PrintToConsole()
        {
            foreach (var i in InvenoryItems)
            {
                Debug.Log(i.Name + " and " + i.Weight);
            }
        }
    }
}