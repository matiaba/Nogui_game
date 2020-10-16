using UnityEngine;

public class CCTVPlayerDetection : MonoBehaviour {
    private GameObject player;
    public GameManager gameManager;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    private void Start() {
        if (gameManager == null)
            {
                gameManager = FindObjectOfType<GameManager>();
            }
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
                    gameManager.menu_perder.SetActive(true);
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                }
            }
        }
    }

}