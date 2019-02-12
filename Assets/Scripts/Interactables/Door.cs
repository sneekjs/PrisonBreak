namespace PrisonBreak.Scripts.Interactables
{
    using PrisonBreak.Scripts.Interfaces;
    using PrisonBreak.Scripts.Items;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof (HingeJoint))]
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private int _id;

        [SerializeField]
        private bool _open = false;

        [SerializeField]
        private Vector3 _openRotation;
        
        private bool _isUnlocked = false;

        private void Update()                                                                                           //maak een var voor open en dicht rotation
        {
            if (_open)
            {
                gameObject.GetComponent<HingeJoint>().axis = _openRotation;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
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