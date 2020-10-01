using UnityEngine;

public class CCTVPlayerDetection : MonoBehaviour {
    private GameObject m_player;
    //private LastPlayerSighting m_lastPlayerSighting;

    private void Awake() {
        m_player = GameObject.FindWithTag("Player");
        //m_lastPlayerSighting = GameObject.FindWithTag("GameController").GetComponent<LastPlayerSighting>;
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("vio al personaje");
    }

}