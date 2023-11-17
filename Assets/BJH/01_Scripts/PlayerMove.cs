using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

// wasd키로 플레이어를 움직인다.
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

    // 중력
    float gravity = -9.8f;
    private Vector3 velocity;

    public Animator animator;


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

        isMoving = h != 0f || v != 0f;

        // 움직이지 않으면
        if (!isMoving)
        {
            speed = 0f;
        }
        // 움직이면
        if (isMoving)
        {
            // 걸을 때
            speed = 5f;
        }

        animator.SetFloat("PlayerMove", speed);

        // dir
        Vector3 dir = new Vector3(h, 0, v).normalized;

        cc.Move(dir * speed * Time.deltaTime);

        // 중력 적용
        velocity.y += gravity * Time.deltaTime;

        // 수직 이동
        //cc.Move(velocity * Time.deltaTime);

        cam.transform.position = transform.position + offset;
        cam.transform.rotation = Quaternion.Euler(x, y, z);




    }
}
