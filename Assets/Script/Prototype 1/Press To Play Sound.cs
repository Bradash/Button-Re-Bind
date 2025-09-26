using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressToPlaySound : MonoBehaviour
{
    public AudioSource audioSource; //Grab Audio
    public PlayerInput playerInput; //Grab Input
public void pressButton(InputAction.CallbackContext ctx) //Allow CallbackContext to call this function
    {
        if(ctx.started) audioSource.Play(); //Play Audio
    }
}
