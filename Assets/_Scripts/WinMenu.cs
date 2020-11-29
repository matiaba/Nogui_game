using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject panel_inventory;
    public static GameManager gameManager;
    int inventory_slots;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        panel_inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventory_slots = panel_inventory.transform.childCount;
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
            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                gameManager.menu_ganar.SetActive(true);
                gameManager.menu_ganar.transform.GetChild(2).gameObject.SetActive(false);
            }
            else{
                gameManager.menu_ganar.SetActive(true);
            }
        }

        else
            Debug.Log("Al jugador le falta recoger scripts");
    }
}
