using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public GameObject panel_inventory;
    public static GameManager gameManager;
    public GameObject music;
    int inventory_slots;

    void Start()
    {
        panel_inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventory_slots = panel_inventory.transform.childCount;
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            carry_scripts();
        }
	}

    void carry_scripts()
    {
        int activos = 0;
        int inactivos = 0;
        for(int i = 0; i < inventory_slots; i++)
        {
            if (panel_inventory.transform.GetChild(i).gameObject.activeSelf)
                activos += 1;
            else
                inactivos += 1;
        }

        if (activos == inventory_slots)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            gameManager.menu_ganar.SetActive(true);
        }

        else
            Debug.Log("Al jugador le falta recoger scripts");
    }
}
