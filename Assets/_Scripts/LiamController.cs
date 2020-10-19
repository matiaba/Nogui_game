using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiamController : MonoBehaviour {
    public float speed;
    public Transform cameraPlayer;

    Animator anim;

    public Collider standupCollider;
    public Collider crouchCollider;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}

    private void Start() {
    }
    // Update is called once per frame
    void Update() {
        float giro = Input.GetAxis("Horizontal");
        float avance = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", avance);
        
        if (giro != 0)
        {
            transform.eulerAngles = new Vector3 (transform.eulerAngles.x, cameraPlayer.transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (Input.GetKey(KeyCode.W))
        {            
            transform.Translate(0, 0, avance * speed * Time.deltaTime);
            anim.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (anim.GetBool("isCrawling"))
            {
                standupCollider.enabled = !standupCollider.enabled;
                crouchCollider.enabled = !crouchCollider.enabled;
                anim.SetBool("isCrawling", false);
            }
            else
            {
                standupCollider.enabled = !standupCollider.enabled;
                crouchCollider.enabled = !crouchCollider.enabled;
                anim.SetBool("isCrawling", true);
            }
        }

    }
}
