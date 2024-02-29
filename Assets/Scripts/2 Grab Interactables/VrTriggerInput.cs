using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class VRTriggerInput : MonoBehaviour
{
    public InputActionReference triggerActionReference;
    public XRRayInteractor rayInteractor; // Ray Interactor 참조

    private void OnEnable()
    {
        triggerActionReference.action.performed += OnTriggerPressed;
        triggerActionReference.action.canceled += OnTriggerReleased; // 트리거 버튼이 놓여졌을 때의 이벤트
    }

    private void OnDisable()
    {
        triggerActionReference.action.performed -= OnTriggerPressed;
        triggerActionReference.action.canceled -= OnTriggerReleased;
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true; // Ray Interactor 활성화
        Debug.Log("Trigger pressed");
    }

    private void OnTriggerReleased(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger released");
        rayInteractor.enabled = false; // Ray Interactor 비활성화
    }
}