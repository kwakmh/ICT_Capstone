using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrSliderControll : MonoBehaviour
{
    public LayerMask sliderHandleLayer; // 슬라이더 핸들 레이어

    void Update()
    {
        RaycastHit hit;
        // 컨트롤러의 현재 위치와 방향에서 레이를 발사
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, sliderHandleLayer))
        {
            // 레이가 슬라이더 핸들에 맞았다면
            if (hit.collider != null)
            {
                Debug.Log("Slider Handle Hit!");
            }
        }
    }
}