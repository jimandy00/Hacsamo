using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviourPun
{
    public GameObject spawnPoint;

    private bool stopPlayer;

    public static GameManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.SerializationRate = 60;

        // 나의 플레이어 생성
        PhotonNetwork.Instantiate("Character", spawnPoint.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 클릭했을 때
        // 마우스 클릭시 해당 위치에 UI가 있으면
        // 마우스 포인터 비활성화
        //if(Input.GetMouseButtonDown(0))
        //{
        //    if (EventSystem.current.IsPointerOverGameObject())
        //    {
        //        Cursor.visible = false;
        //    }
        //}

        //// esc를 누르면
        //// 포인터 활성화
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.visible = true;
        //}
        
    }

}
