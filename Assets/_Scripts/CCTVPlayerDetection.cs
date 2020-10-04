using UnityEngine;

public class CCTVPlayerDetection : MonoBehaviour {
    private GameObject player;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject == player)
        {
            Vector3 relPlayerPos = player.transform.position - transform.position;
            RaycastHit hit;
            if(Physics.Raycast(transform.position, relPlayerPos, out hit))
            {
                if(hit.collider.gameObject == player)
                {
                    Debug.Log("Player ha sido visto");
                }
            }
        }
    }

}