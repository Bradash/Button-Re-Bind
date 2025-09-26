using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;


    private void Start()
    {
        isPaused = false;
    }
    public void pauseGame()
    {
        
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        Debug.Log("pressed");

    }
}
