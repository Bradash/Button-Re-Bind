using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReBinding1 : MonoBehaviour
{
[SerializeField] private InputActionReference button = null;  //Grab Input
[SerializeField] private MainGame playerController = null; //Grab Script
    [SerializeField] private TMP_Text bindingButton = null; //Grab Button Text
    [SerializeField] private GameObject startRebindObject = null; //Grab Button
    [SerializeField] private GameObject waitingForInputObject = null; //Grab Waiting Text

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation; //Grab Rebinding Script

    public void StartRebinding()
    {
        startRebindObject.SetActive(false);
        waitingForInputObject.SetActive(true); 

        playerController.playerInput.SwitchCurrentActionMap("Rebinding"); //Hide Button, Show Waiting Text, Switch Controls

        rebindingOperation = button.action.PerformInteractiveRebinding() //Rebind Button
            .WithControlsExcluding("Mouse") //No Mouse Input
            .OnMatchWaitForAnother(0.1f) //Wait 0.1 seconds
            .OnComplete(operation => RebindComplete()) //Call RebindComplete if Complete
            .Start(); //Launch the code
    }
    private void RebindComplete()
    {
        int bindingIndex = button.action.GetBindingIndexForControl(button.action.controls[0]);
        bindingButton.text = InputControlPath.ToHumanReadableString(
            button.action.bindings[0].effectivePath, 
            InputControlPath.HumanReadableStringOptions.OmitDevice); //change button text to rebinded button
        rebindingOperation.Dispose(); //Remove Old Bindings
        startRebindObject.SetActive(true); 
        waitingForInputObject.SetActive(false);
        playerController.playerInput.SwitchCurrentActionMap("MainGame"); //Show Button, Hide Waiting Text, Switch Controls
    }

}
