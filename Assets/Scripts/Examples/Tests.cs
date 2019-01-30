﻿namespace PrisonBreak.Scripts.Example
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using PrisonBreak.Scripts.Items;

    public class Tests : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            BonusItem bonus = new BonusItem(name: "bonus1", weight: 2, points: 100);
            AccessItem access = new AccessItem(name: "key1", weight: 2, door: 1);
            BonusItem anvil = new BonusItem(name: "bonus1", weight: 20, points: 100);

            Debug.Log(message: "Adding bonus success" + Inventory.Instance.AddItem(bonus));
            Debug.Log(message: "Adding key succes" + Inventory.Instance.AddItem(access));
            Debug.Log(message: "Adding anvil succes" + Inventory.Instance.AddItem(anvil));
            Debug.Log(message: "");
            Debug.Log(message: "INVENTORY");
            Inventory.Instance.PrintToConsole();

            Inventory.Instance.RemoveItem(bonus);
            Debug.Log(message: "INVENTORY after removing");
            Inventory.Instance.PrintToConsole();

            Inventory.Instance.RemoveItem(anvil);
            Debug.Log(message: "INVENTORY after FAKE removing");
            Inventory.Instance.PrintToConsole();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}