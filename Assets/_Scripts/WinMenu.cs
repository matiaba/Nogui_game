using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public GameObject panel_inventory;
    public GameObject canvas;
    public GameObject menu_ganar;
    public GameObject menu_principal;
    public GameObject scene_music;

    AudioSource audio_scene;
    int inventory_slots;
    // Start is called before the first frame update
    void Start()
    {
        panel_inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventory_slots = panel_inventory.transform.childCount;
        canvas = GameObject.FindGameObjectWithTag("Menu");
        menu_ganar = canvas.transform.GetChild(3).gameObject;
        menu_principal = canvas.transform.GetChild(4).gameObject;
        scene_music = GameObject.Find("MusicScene");
        audio_scene = scene_music.GetComponent<AudioSource>();
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
            canvas.SetActive(true);
            menu_ganar.SetActive(true);
            menu_principal.SetActive(false);
            Time.timeScale = 0;
            audio_scene.Stop();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        else
            Debug.Log("Al jugador le falta recoger scripts");
    }
}
