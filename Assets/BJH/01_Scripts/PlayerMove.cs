using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// wasdŰ�� �÷��̾ �����δ�.
public class PlayerMove : MonoBehaviourPun
{
    public float speed = 5f;

    // camera
    public Transform cam;

    // charactor controller
    public CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

        // ���� ������ �÷��̾� �϶��� ī�޶� Ȱ��ȭ�ϱ�
        if (photonView.IsMine)
        {
            cam.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ������ �÷��̾ �ƴϸ� update()�� Ż��
        if (photonView.IsMine == false) 
        {
            return;        
        }

        // input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // dir
        Vector3 dir = new Vector3(h, 0, v);

        // move
        transform.position += dir * speed * Time.deltaTime;

    }
}
