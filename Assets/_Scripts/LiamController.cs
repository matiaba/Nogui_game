using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class LiamController : MonoBehaviour {
    public float speed;
    public float turnSpeed;

    public bool isGrounded;
    Rigidbody rb;

    Animator anim;


	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update() {
        float giro = Input.GetAxis("Horizontal");
        float avance = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", avance);
        
        if (giro != 0)
        {            
            transform.Rotate(0, giro * turnSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {            
            transform.Translate(0, 0, avance * speed * Time.deltaTime);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (anim.GetBool("isCrawling"))
            {
                anim.SetBool("isCrawling", false);
            }
            else
            {
                anim.SetBool("isCrawling", true);
            }
        }

    }
}
