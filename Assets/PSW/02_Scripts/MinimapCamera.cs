using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapCamera : MonoBehaviour
{
    // 카메라 회전 속도
    public float rotateSpeed = 10f;
    // 카메라 줌 속도
    public float zoomSpeed = 10f;
    // 미니맵 카메라
    public Camera miniMapCam;
    // 줌 아웃 상태 변수
    public bool zoomInOut = false;

    void Start()
    {
        // 버튼을 클릭했을 때 줌 되게 하는 함수 호출
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Zoom);

        // miniMapCamera 
        miniMapCam = GetComponent<Camera>();
    }

    
    void Update()
    {
        Zoom();
        //Rotate();
    }

    // 줌 기능
    private void Zoom()
    {
        // 마우스 휠 줌 거리 조절
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            if (zoomInOut)
            {
                // 줌 아웃 상태에서 마우스 스크롤하면 다시 원래 크기로
                miniMapCam.fieldOfView -= distance;
            }
            else
            {
                // 마우스 스크롤로 줌 아웃
                miniMapCam.fieldOfView += distance;
            }
        }
    }

    //// 회전 기능
    //private void Rotate()
    //{
    //   // 만약에 마우스 오른쪽 버튼을 누르면
    //   if (Input.GetMouseButton(1))
    //   {
    //        // 현재 카메라의 각도를 Vector3로 반환
    //        Vector3 rot = transform.rotation.eulerAngles;
    //        // 마우스 x 위치 * 회전 스피드
    //        rot.y += Input.GetAxis("Mouse X") * rotateSpeed;
    //        // 마우스 y 위치 * 회전 스피드
    //        rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed;
    //        // Quaternion 으로 변환
    //        Quaternion q = Quaternion.Euler(rot);
    //        q.z = 0;
    //        // 자연스럽게 회전
    //        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);
    //   }
    //}

    //// 특정 콜라이더와 충돌할 때만 줌 아웃 및 회전
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("miniMapCamera"))
    //    {
    //        zoomInOut = true;
    //    }
    //}

    //// 충돌 끝났을 때 다시 줌 인 및 원래 회전
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("miniMapCamera"))
    //    {
    //        zoomInOut = false;
    //    }
    //}
}
