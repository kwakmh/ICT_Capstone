using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RayToggleController : MonoBehaviour
{
    public XRNode inputSource;
    private LineRenderer lineRenderer;
    private bool isRayActive = false;
    private bool wasButtonPressed = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        bool isButtonPressed;
        device.TryGetFeatureValue(CommonUsages.triggerButton, out isButtonPressed);

        // 트리거 버튼이 눌렸는데 이전 상태가 눌리지 않은 상태였다면, Ray 상태를 토글한다.
        if (isButtonPressed && !wasButtonPressed)
        {
            isRayActive = !isRayActive;
        }
        wasButtonPressed = isButtonPressed; // 버튼이 눌린 상태를 업데이트한다.

        if (isRayActive)
        {
            // Ray를 활성화하고 렌더링한다.
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position + transform.forward * 10);
            }
            lineRenderer.enabled = true;
        }
        else
        {
            // Ray를 비활성화한다.
            lineRenderer.enabled = false;
        }
    }
}