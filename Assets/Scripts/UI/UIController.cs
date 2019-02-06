namespace PrisonBreak.Scripts.UI
{
    using PrisonBreak.Scripts.Items;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private Inventory _inventory;

        [SerializeField]
        private GameObject _inventoryDisplay;

        [SerializeField]
        private Text _weightInfo;

        [SerializeField]
        private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

        private bool _inventoryIsOpen = false;

        private int _selectedIndex;

        private List<Item> _inventoryItems = new List<Item>();

        private void Start()
        {
            _inventoryDisplay.SetActive(false);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleInventory(!_inventoryIsOpen);
            }

            if (_inventoryIsOpen)
            {                
                CheckInventoryInputs();
            }
        }

        public void AddItemToInventory(Item item)
        {
            UpdateVisualInventory();
        }

        public void RemoveItemFromInventory(Item item)
        {
            if (_inventory.InvenoryItems.Contains(item))
            {
                _inventory.RemoveItem(item);
                UpdateVisualInventory();               
            }
        }

        private void UpdateVisualInventory()
        {
            for (int i = 0; i < _inventorySlots.Count; i++)
            {
                if (_inventory.InvenoryItems.Count > i)
                {
                    _inventorySlots[i].CurrentPickUp = _inventory.InvenoryItems[i];
                    _inventorySlots[i].TextField.text = _inventory.InvenoryItems[i].Name;
                }
                else
                {
                    _inventorySlots[i].CurrentPickUp = null;
                    _inventorySlots[i].TextField.text = "";
                }
            }

            _weightInfo.text = "Weight: " + _inventory.TotalWeight + "/" + _inventory.MaxWeight;
        }

        private void ToggleInventory(bool open)
        {
            _inventoryDisplay.SetActive(open);
            _inventoryIsOpen = !_inventoryIsOpen;
            _selectedIndex = 0;
            ChangeSelection();
        }

        private void CheckInventoryInputs()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_selectedIndex == 0)
                {
                    _selectedIndex = _inventorySlots.Count - 1;
                }
                else
                {
                    _selectedIndex--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_selectedIndex == _inventorySlots.Count - 1)
                {
                    _selectedIndex = 0;
                }
                else
                {
                    _selectedIndex++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (_selectedIndex - 2 >= 0)
                {
                    _selectedIndex -= 2;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (_selectedIndex + 2 <= _inventorySlots.Count - 1)
                {
                    _selectedIndex += 2;
                }
            }
            ChangeSelection();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                RemoveItemFromInventory(_inventorySlots[_selectedIndex].CurrentPickUp);
            }
        }

        private void ChangeSelection()
        {
            for (int i = 0; i < _inventorySlots.Count; i++)
            {
                if (i == _selectedIndex)
                {
                    _inventorySlots[i].BackgroundImage.color = Color.white;
                }
                else
                {
                    _inventorySlots[i].BackgroundImage.color = Color.grey;
                }
            }
        }
    }
}