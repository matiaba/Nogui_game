using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject canvas_menu;
    public GameObject menu_perder;
    public static GameObject musicScene;
    new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        canvas_menu = GameObject.FindGameObjectWithTag("Menu");
        menu_perder = canvas_menu.transform.GetChild(1).gameObject;
        musicScene = GameObject.Find("MusicScene");
        audio = musicScene.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            Time.timeScale = 0;
            canvas_menu.SetActive(true);
            canvas_menu.transform.GetChild(4).gameObject.SetActive(false);
            canvas_menu.transform.GetChild(1).gameObject.SetActive(true);
            audio.Stop();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

        }
    }

}
