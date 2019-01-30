namespace PrisonBreak.Scripts.Items {
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

        public static Inventory Instance;

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
            if (_totalWeight + item.Weight > _maxWeight)
            {
                return false;
            }
            else
            {
                _invenoryItems.Add(item);
                _totalWeight += item.Weight;
                return true;
            }
        }

        public void RemoveItem(Item item)
        {
            if (_invenoryItems.Remove(item))
            {
                _totalWeight -= item.Weight;
            }
        }

        public void PrintToConsole()
        {
            foreach (var i in _invenoryItems)
            {
                Debug.Log(i.Name + " and " + i.Weight);
            }
        }
    }
}