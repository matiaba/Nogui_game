using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenu : MonoBehaviour
{
    public GameObject canvas_menu;
    // Start is called before the first frame update
    void Start()
    {
        canvas_menu = GameObject.FindGameObjectWithTag("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            Time.timeScale = 0;
            canvas_menu.SetActive(true);
        }
    }
}
