using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupUI : MonoBehaviour
{
    public GameObject iconColor;

    private void Awake()
    {
        DisplayEmpty();
    }

    public void DisplayColorIcon()
    {
        iconColor.SetActive(true);
    }

    public void DisplayEmpty()
    {
        iconColor.SetActive(false);
    }
}
