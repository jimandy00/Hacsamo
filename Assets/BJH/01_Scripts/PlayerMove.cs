using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

// wasd키로 플레이어를 움직인다.
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

        // 내가 생성한 플레이어 일때만 카메라 활성화하기
        if (photonView.IsMine)
        {
            cam.gameObject.SetActive(true);
        }

        nickName.text = photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        // 내가 생성한 플레이어가 아니면 update()를 탈출
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
