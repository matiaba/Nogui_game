using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static GameObject canvas = null;
    public static GameObject music = null;
    int canvas_children;
    public GameObject menu_principal;
    public GameObject menu_perder;
    public GameObject menu_control;
    public GameObject menu_ganar;
    public GameObject menu_pausa;
    public GameObject audio_escena;
    AudioSource audio_scene;

    void Awake()
    {
        if (instance == null)
        {
            //If I am the first instance, make me the Singleton
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
           Destroy(this.gameObject);
        }

        if (canvas == null)
        {
            canvas = GameObject.FindGameObjectWithTag("Menu");
            DontDestroyOnLoad(canvas);
        }
        else
        {
           Destroy(canvas.gameObject);
        }

        if (music == null)
        {
            music = GameObject.FindGameObjectWithTag("Sound");
            DontDestroyOnLoad(music);
        }
        else
        {
           Destroy(music.gameObject);
        }

    }

    private void Start() {
        menu_perder = canvas.transform.GetChild(0).gameObject;
        menu_control = canvas.transform.GetChild(1).gameObject;
        menu_ganar = canvas.transform.GetChild(2).gameObject;
        menu_principal = canvas.transform.GetChild(4).gameObject;
        menu_pausa = menu_principal.transform.GetChild(3).gameObject;
        canvas_children = canvas.transform.childCount;
        audio_escena = music.transform.GetChild(0).gameObject;
        audio_scene = audio_escena.GetComponent<AudioSource>();
    }

    void Update() {
        PauseGame();
    }

    public void LoadScene()
    {
        int level;
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            level = int.Parse(SceneManager.GetActiveScene().name);
            level += 1;
            if (level < 10)
                SceneManager.LoadScene(level);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
            
            
    }

        public void SetScene()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        DesactivateCanvasChildren();
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void PauseGame()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} 
            
            else if (Time.timeScale == 0)
            {
				Time.timeScale = 1;
				hidePaused();
			}
        }
    }

    public void showPaused()
    {
        menu_principal.SetActive(true);
        menu_principal.transform.GetChild(2).gameObject.SetActive(false);
        menu_pausa.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

	}

    public void hidePaused()
    {
        menu_principal.SetActive(false);
		menu_pausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DesactivateCanvasChildren();
        Time.timeScale = 1;
    }

    public void DesactivateCanvasChildren()
    {
        for (int i=0; i < canvas_children; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

}