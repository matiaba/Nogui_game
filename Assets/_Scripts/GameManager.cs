using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Canvas canvas;
    public int HP = 3;

    void Awake()
    {
        if (instance == null)
        {
            //If I am the first instance, make me the Singleton
            instance = this;
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(canvas);
        }
        else
        {
           Destroy(this.gameObject);
        }
    }

    public void AddHealth()
    {
        HP++;
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
}