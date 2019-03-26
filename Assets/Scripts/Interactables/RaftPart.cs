namespace PrisonBreak.Scripts.Interactables
{
    using PrisonBreak.Scripts.Interfaces;
    using PrisonBreak.Scripts.Items;
    using PrisonBreak.Scripts.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RaftPart : InteractionObject, IInteractable
    {
        [SerializeField]
        private string _requiredName;

        [SerializeField]
        private UIController _uIController;

        [SerializeField]
        private GameObject _spotlightHint;

        public void Action()
        {
            CheckObject();
        }

        private void CheckObject()
        {
            if (_id == -1 || Inventory.Instance.HasKey(_id))
            {
                List<Item> items = Inventory.Instance.InvenoryItems;

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i] is AccessItem)
                    {
                        AccessItem it = (AccessItem)items[i];
                        if (it.Door == _id)
                        {
                            PlaceRaftPart(it);
                        }
                    }
                }
            }
        }

        private void PlaceRaftPart(AccessItem it)
        {
            PickUp pickup = _uIController.GameObjectsInInventory[_requiredName];
            _uIController.RemoveItemFromInventory(it);
            pickup.gameObject.transform.parent = gameObject.transform;
            pickup.gameObject.transform.localPosition = Vector3.zero;
            pickup.gameObject.transform.localRotation = Quaternion.identity;
            Destroy(pickup.gameObject.GetComponent<Rigidbody>());
            Destroy(pickup.gameObject.GetComponent<Access>());
            _spotlightHint.SetActive(false);
            Raft.Instance.PartCompleted();
        }
    }
}