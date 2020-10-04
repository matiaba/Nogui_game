using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GameManager.instance.HP--;
        else if (Input.GetKeyDown(KeyCode.Return))
            GameManager.instance.AddHealth();
        if (GameManager.instance.HP == 0)
            Destroy(gameObject);
    }
}
