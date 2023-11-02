using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class AniController : MonoBehaviourPun
{

    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    // 카메라
    public Transform cam;

    // charactor controller
    public CharacterController cc;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {


        // 캐릭터 컨트롤러
        cc = GetComponent<CharacterController>();


        animator = characterBody.GetComponent<Animator>();

        // 내가 생성한 플레이어 일때만 카메라 활성화하기
        if (photonView.IsMine)
        {
            cam.gameObject.SetActive(true);
        }

    }


    // Update is called once per frame
    void Update()
    {
        // 내가 생성한 플레이어가 아니면 update()를 탈출
        if (photonView.IsMine == false)
        {
            return;
        }

        LookAround();
        MoveCharacter();
        GestureCharacter();
    }


    private void MoveCharacter()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        animator.SetBool("isMove", isMove);

        if (isMove) 
        {
            animator.SetBool("isSitting", false);
            animator.SetBool("isRest", false);
            animator.SetBool("isDonTouch", false);
            animator.SetBool("isDance", false);
            animator.SetBool("isClapping", false);

            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            characterBody.forward = moveDir;
            transform.position += 2f * Time.deltaTime * moveDir;

        }

        if (Input.GetKey(KeyCode.Keypad1))
        {
            isMove = false;
            animator.SetBool("isSitting", true);
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            isMove = false;
            animator.SetBool("isRest", true);
        }

        if (Input.GetKey(KeyCode.Keypad3))
        {
            isMove = false;
            animator.SetBool("isDonTouch", true);
        }

        if (Input.GetKey(KeyCode.Keypad4))
        {
            isMove = false;
            animator.SetBool("isDance", true);
        }

        if (Input.GetKey(KeyCode.Keypad5))
        {
            isMove = false;
            animator.SetBool("isClapping", true);
        }

        //Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized, Color.red);
    }

    private void GestureCharacter()
    {

        if (Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("hello");
        }

    }


    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        
        float x = camAngle.x - mouseDelta.y;

        if (x < 180f) 
        {
            x = Mathf.Clamp(x, -1f, 70f);   
        }

        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
}
