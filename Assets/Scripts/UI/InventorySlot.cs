namespace PrisonBreak.Scripts.UI
{
    using PrisonBreak.Scripts.Interactables;
    using PrisonBreak.Scripts.Items;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class InventorySlot : MonoBehaviour
    {
        [SerializeField]
        private Text _textField;

        [SerializeField]
        private Image _backgroundImage;

        private Item _currentPickUp;

        public Image BackgroundImage
        {
            get { return _backgroundImage; }
            set { _backgroundImage = value; }
        }

        public Item CurrentPickUp
        {
            get { return _currentPickUp; }
            set { _currentPickUp = value; }
        }

        public Text TextField
        {
            get { return _textField; }
            set { _textField = value; }
        }
    }
}