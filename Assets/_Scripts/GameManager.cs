using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static GameObject canvas;
    public static GameObject musicScene;
    public static GameObject musicTitle;
    GameObject menu_principal;
    GameObject menu_perder;
    GameObject menu_control;
    GameObject menu_ganar;
    AudioSource audio_scene;
    AudioSource audio_title;
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

        if (musicScene == null)
        {
            musicScene = GameObject.Find("MusicScene");
            DontDestroyOnLoad(musicScene);
        }
        else
        {
           Destroy(musicScene.gameObject);
        }

    }

    private void Start() {
        menu_principal = canvas.transform.GetChild(4).gameObject;
        menu_perder = canvas.transform.GetChild(1).gameObject;
        menu_control = canvas.transform.GetChild(2).gameObject;
        menu_ganar = canvas.transform.GetChild(3).gameObject;
        musicTitle = GameObject.Find("TitleMusic");
        audio_title = musicTitle.GetComponent<AudioSource>();
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
        {
            SceneManager.LoadScene(1);
        }
            
            
    }

    private void set_scene_game()
    {
        if (game_start && SceneManager.GetActiveScene().buildIndex != 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canvas.SetActive(false);
            audio_scene = musicScene.GetComponent<AudioSource>();
            audio_scene.mute = false;
            game_start = false;
            
        }
    }

    private void pause_game()
    {
        if (menu_control.activeSelf == false)
        {
            if (Input.GetKeyUp(KeyCode.Escape) && canvas.activeSelf == false)
            {
                audio_scene.mute = true;
                Cursor.lockState = CursorLockMode.Confined;
                canvas.SetActive(true);
                menu_principal.transform.GetChild(1).gameObject.SetActive(false);
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Escape) && canvas.activeSelf == true)
                {
                    if (menu_principal.activeSelf == false)
                    {
                        canvas.transform.GetChild(0).gameObject.SetActive(true);
                        menu_principal.SetActive(true);
                        menu_principal.transform.GetChild(1).gameObject.SetActive(false);
                        audio_scene.mute = true;
                        musicTitle.SetActive(true);
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.Confined;
                        Time.timeScale = 0;
                    }
                    else
                    {
                        audio_scene.mute = false;
                        Cursor.lockState = CursorLockMode.Locked;
                        canvas.SetActive(false);
                        Cursor.visible = false;
                        Time.timeScale = 1;
                    }
                    
                }
            }
        }
        
    }

    public void restart_game()
    {
        var scene_index = SceneManager.GetActiveScene().buildIndex;
        Cursor.lockState = CursorLockMode.Locked;
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);
        canvas.transform.GetChild(5).gameObject.SetActive(false);
        Cursor.visible = false;
        audio_scene.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(scene_index);
    }

    public void new_level()
    {
        Time.timeScale = 1;
    }

}