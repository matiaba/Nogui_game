using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public GameObject canvas;
    int canvas_children;
    public GameObject firstActiveGameObject;
    GameObject menuActive;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Menu");
        canvas_children = canvas.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i < canvas_children; i++)
        {
        //     if(canvas.transform.GetChild(i).gameObject.activeSelf == true)
        //     {
        //         firstActiveGameObject = canvas.transform.GetChild(i).gameObject;
        //     }

            int menu_count = canvas.transform.GetChild(i).gameObject.transform.childCount;
            if(canvas.transform.GetChild(i).gameObject.activeSelf == true)
            {
                Debug.Log(firstActiveGameObject = GameObject.FindWithTag("Button"));
                firstActiveGameObject = GameObject.FindWithTag("Button");
                EventSystem.current.GetComponent<EventSystem>().firstSelectedGameObject = firstActiveGameObject;

                // menuActive = canvas.transform.GetChild(i).gameObject;
                // for (int u=0; u < menu_count; u++)
                // {
                //     if (menuActive.transform.GetChild(u).gameObject.activeSelf == true)
                    // Debug.Log(menuActive.transform.GetChild(u).gameObject);
                // }
            }


        }

    }

}
