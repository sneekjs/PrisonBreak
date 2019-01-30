namespace PrisonBreak.Scripts.Actors
{
    using PrisonBreak.Scripts.Interfaces;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _interactionRange = 2f;

        [SerializeField]
        private Transform _playerHead;

        private void Update()
        {
            if (Input.GetButtonDown("Action"))
            {
                Interact();
            }
            Debug.DrawRay(_playerHead.position, _playerHead.forward, Color.green);
        }

        private void Interact()
        {
            Ray r = new Ray(_playerHead.position, _playerHead.forward);
            RaycastHit hit;

            if (Physics.Raycast(r, out hit, _interactionRange))
            {
                IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
                if (i != null)
                {
                    i.Action();
                }
            }
        }
    }
}