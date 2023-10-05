using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

// wasdŰ�� �÷��̾ �����δ�.
public class PlayerMove : MonoBehaviourPun
{
    public float speed = 5f;

    // camera
    public Transform cam;

    // charactor controller
    public CharacterController cc;

    // nick name
    public Text nickName;

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
        print(h + ", " + v);

        // dir
        Vector3 dir = new Vector3(h, 0, v);

        // move
        transform.position += dir * speed * Time.deltaTime;

    }
}
