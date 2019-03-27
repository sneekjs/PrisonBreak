namespace PrisonBreak.Scripts.UI
{
    using PrisonBreak.Scripts.Interactables;
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
        private Dictionary<string, PickUp> _gameObjectsInInventory = new Dictionary<string, PickUp>();

        [SerializeField]
        private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

        private bool _inventoryIsOpen = false;

        private int _selectedIndex;

        public static UIController Instance;

        public Dictionary<string, PickUp> GameObjectsInInventory
        {
            get { return _gameObjectsInInventory; }
            set { _gameObjectsInInventory = value; }
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
                PickUp pickUp = GameObjectsInInventory[item.Name];
                pickUp.transform.position = Camera.main.transform.position;
                pickUp.gameObject.SetActive(true);
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