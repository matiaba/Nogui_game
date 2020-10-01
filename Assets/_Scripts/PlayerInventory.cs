using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerInventoryDisplay playerInventoryDisplay;
    private int totalPapers = 0;

    private void Awake()
    {
        playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
    }

    void Start()
    {
        playerInventoryDisplay.OnChangePaperTotal(totalPapers);
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Paper"))
        {
            totalPapers++;
            playerInventoryDisplay.OnChangePaperTotal(totalPapers);
            Destroy(hit.gameObject);
        }
    }
}
