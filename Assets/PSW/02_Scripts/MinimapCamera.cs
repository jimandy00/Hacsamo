using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapCamera : MonoBehaviour
{
    // ī�޶� ȸ�� �ӵ�
    public float rotateSpeed = 10f;
    // ī�޶� �� �ӵ�
    public float zoomSpeed = 10f;
    // �̴ϸ� ī�޶�
    public Camera miniMapCam;
    // �� �ƿ� ���� ����
    public bool zoomInOut = false;

    void Start()
    {
        // ��ư�� Ŭ������ �� �� �ǰ� �ϴ� �Լ� ȣ��
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

    // �� ���
    private void Zoom()
    {
        // ���콺 �� �� �Ÿ� ����
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            if (zoomInOut)
            {
                // �� �ƿ� ���¿��� ���콺 ��ũ���ϸ� �ٽ� ���� ũ���
                miniMapCam.fieldOfView -= distance;
            }
            else
            {
                // ���콺 ��ũ�ѷ� �� �ƿ�
                miniMapCam.fieldOfView += distance;
            }
        }
    }

    //// ȸ�� ���
    //private void Rotate()
    //{
    //   // ���࿡ ���콺 ������ ��ư�� ������
    //   if (Input.GetMouseButton(1))
    //   {
    //        // ���� ī�޶��� ������ Vector3�� ��ȯ
    //        Vector3 rot = transform.rotation.eulerAngles;
    //        // ���콺 x ��ġ * ȸ�� ���ǵ�
    //        rot.y += Input.GetAxis("Mouse X") * rotateSpeed;
    //        // ���콺 y ��ġ * ȸ�� ���ǵ�
    //        rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed;
    //        // Quaternion ���� ��ȯ
    //        Quaternion q = Quaternion.Euler(rot);
    //        q.z = 0;
    //        // �ڿ������� ȸ��
    //        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);
    //   }
    //}

    //// Ư�� �ݶ��̴��� �浹�� ���� �� �ƿ� �� ȸ��
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("miniMapCamera"))
    //    {
    //        zoomInOut = true;
    //    }
    //}

    //// �浹 ������ �� �ٽ� �� �� �� ���� ȸ��
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("miniMapCamera"))
    //    {
    //        zoomInOut = false;
    //    }
    //}
}
