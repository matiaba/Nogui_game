using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(PlayerInventory))]

public class PlayerInventoryDisplay : MonoBehaviour
{
    public PickupUI[] slots = new PickupUI[1];
    public void OnChangePaperTotal(int paperTotal)
    {
        int numInventorySlots = slots.Length;
        for(int i = 0; i < numInventorySlots; i++)
        {
            PickupUI slot = slots[i];
            if (i < paperTotal)
                slot.DisplayColorIcon();
            else
                slot.DisplayEmpty();
        }
    }
}
