namespace PrisonBreak.Scripts.Interactables
{
    using PrisonBreak.Scripts.Interfaces;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class InteractionObject : MonoBehaviour
    {
        [SerializeField]
        protected int _id;
    }
}