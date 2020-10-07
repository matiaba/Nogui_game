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
        
        set_scene_game();
        pause_game();
        
    }

    public void ExitGame()
    {
        Application.Quit();
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
            SceneManager.LoadScene(1);
            
    }

    private void set_scene_game()
    {
        if (game_start && SceneManager.GetActiveScene().buildIndex != 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canvas.SetActive(false);
            game_start = false;
        }
    }

    private void pause_game()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && canvas.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Confined;
            canvas.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Escape) && canvas.activeSelf == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                canvas.SetActive(false);
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
    }

    public void restart_game()
    {
        var scene_index = SceneManager.GetActiveScene().buildIndex;
        Cursor.lockState = CursorLockMode.Locked;
        canvas.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(scene_index);
    }

}