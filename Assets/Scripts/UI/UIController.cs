namespace PrisonBreak.Scripts.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _inventoryDisplay;

        [SerializeField]
        private GameObject _inventoryObject;

        private List<GameObject> _inventoryItems = new List<GameObject>();

        public void AddItemToInventory(string name)
        {
            //GameObject item = Instantiate(_inventoryObject);
            //item.transform.SetParent(_inventoryDisplay.transform);
            //item.GetComponentInChildren<Text>().text = name;
            //_inventoryItems.Add(item);
        }

        public void RemoveItemFromInventory(string name)
        {
        }
    }
}