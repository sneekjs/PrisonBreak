namespace PrisonBreak.Scripts.Interactables
{
    using PrisonBreak.Scripts.Interfaces;
    using PrisonBreak.Scripts.Items;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private int _id;

        [SerializeField]
        private bool _open = false;

        private void Update()                                                                                           //maak een var voor open en dicht rotation
        {
            if (_open && transform.rotation.eulerAngles.y > 0)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 1);
            }
            else if (!_open && transform.rotation.eulerAngles.y < 90)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0), 1);
            }
        }

        public void Open()
        {
            if (_id == -1 || Inventory.Instance.HasKey(_id))
            {
                _open = !_open;
            }
        }

        public void Action()
        {
            Open();
        }
    }
}