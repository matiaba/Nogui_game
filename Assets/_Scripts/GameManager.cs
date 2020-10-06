using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static GameObject canvas;
    private bool game_start = true;

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

    }

    void Update() {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            set_canvas_on_load_level();
            if (Input.GetKeyUp(KeyCode.Escape) && canvas.activeSelf == false)
            {
                canvas.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Escape) && canvas.activeSelf == true)
                {
                    canvas.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }
        
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        int level;
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            level = int.Parse(SceneManager.GetActiveScene().name);
            level += 1;
            if (level < 10)
                SceneManager.LoadScene(level);
        }
        else
            SceneManager.LoadScene(1);
            
    }

    private void set_canvas_on_load_level()
    {
        if (game_start && SceneManager.GetActiveScene().name != "Menu")
        {
            canvas.SetActive(false);
            game_start = false;
        }
    }

}