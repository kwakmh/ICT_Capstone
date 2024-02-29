using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class VRControllerInput : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction triggerAction;

    private void OnEnable()
    {
        var actionMap = actionAsset.FindActionMap("Vr Controls");
        triggerAction = actionMap.FindAction("Trigger");

        triggerAction.Enable();
        triggerAction.performed += OnTriggerPressed;
    }

    private void OnDisable()
    {
        triggerAction.Disable();
        triggerAction.performed -= OnTriggerPressed;
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
        // 'P' 키가 눌렸을 때 실행될 로직
        Debug.Log("Trigger pressed");
    }
}