using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewBehaviourScript : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction pinchAction;

    private void OnEnable()
    {
        var actionMap = actionAsset.FindActionMap("VRInteractions");
        pinchAction = actionMap.FindAction("Pinch");

        pinchAction.Enable();
        pinchAction.performed += OnPinchPerformed;
    }

    private void OnDisable()
    {
        pinchAction.Disable();
        pinchAction.performed -= OnPinchPerformed;
    }

    private void OnPinchPerformed(InputAction.CallbackContext context)
    {
        // "Pinch" 동작이 감지됐을 때 실행할 로직
        Debug.Log("Pinch Performed");
        // 예: 오브젝트 잡기, UI 상호작용 등
    }
}
