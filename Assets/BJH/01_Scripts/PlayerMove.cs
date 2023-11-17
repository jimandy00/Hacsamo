using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

// wasdŰ�� �÷��̾ �����δ�.
public class PlayerMove : MonoBehaviourPun
{
    public float speed = 5f;
    bool isMoving = false;

    // camera
    public Transform cam;
    public Vector3 offset;
    public float x, y, z;

    // charactor controller
    public CharacterController cc;

    // nick name
    public TMP_Text nickName;

    // �߷�
    float gravity = -9.8f;
    private Vector3 velocity;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

        // ���� ������ �÷��̾� �϶��� ī�޶� Ȱ��ȭ�ϱ�
        if (photonView.IsMine)
        {
            cam.gameObject.SetActive(true);
        }

        nickName.text = photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ������ �÷��̾ �ƴϸ� update()�� Ż��
        if (photonView.IsMine == false) 
        {
            return;        
        }

        if(Cursor.visible == false) { return; }
        
        // input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        isMoving = h != 0f || v != 0f;

        // �������� ������
        if (!isMoving)
        {
            speed = 0f;
        }
        // �����̸�
        if (isMoving)
        {
            // ���� ��
            speed = 5f;
        }

        animator.SetFloat("PlayerMove", speed);

        // dir
        Vector3 dir = new Vector3(h, 0, v).normalized;

        cc.Move(dir * speed * Time.deltaTime);

        // �߷� ����
        velocity.y += gravity * Time.deltaTime;

        // ���� �̵�
        //cc.Move(velocity * Time.deltaTime);

        cam.transform.position = transform.position + offset;
        cam.transform.rotation = Quaternion.Euler(x, y, z);




    }
}
