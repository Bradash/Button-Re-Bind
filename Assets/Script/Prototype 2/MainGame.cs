using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    public float battleMeter;
    public Slider battleMeterSlider;
    public float pressAmount;
    public PlayerInput playerInput; //Grab Input
    public GameObject Win;
    public bool isInputOn;
    public TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        battleMeter = 0.5f;
        isInputOn = true;
    }
    public void player1Button(InputAction.CallbackContext ctx) //Allow CallbackContext to call this function
    {
        if (isInputOn)
        {
            if (ctx.started)
            {
                battleMeter = battleMeter + (1f / pressAmount);
                Debug.Log("Player1");
            }
        }
    }
    public void player2Button(InputAction.CallbackContext ctx) //Allow CallbackContext to call this function
    {
        if (isInputOn)
        {
            if (ctx.started)
        {
            battleMeter = battleMeter - (1f / pressAmount);
            Debug.Log("Player2");
        }
        }
    }

    private void Update()
    {
        battleMeterSlider.value = battleMeter;
        if (battleMeter >= 1f)
        {
            Win.SetActive(true);
            Time.timeScale = 0f;
            isInputOn = false;
            textMeshProUGUI.text = "Player 1 Win";
        }
        if (battleMeter <= 0f)
        {
            Win.SetActive(true);
            Time.timeScale = 0f;
            isInputOn = false;
            textMeshProUGUI.text = "Player 2 Win";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
