using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;
    public MainGame game;


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
            game.isInputOn = true;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            game.isInputOn = false;
        }
        Debug.Log("pressed");

    }
}
