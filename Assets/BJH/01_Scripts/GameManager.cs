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

        // ���� �÷��̾� ����
        PhotonNetwork.Instantiate("Character", spawnPoint.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 Ŭ������ ��
        // ���콺 Ŭ���� �ش� ��ġ�� UI�� ������
        // ���콺 ������ ��Ȱ��ȭ
        //if(Input.GetMouseButtonDown(0))
        //{
        //    if (EventSystem.current.IsPointerOverGameObject())
        //    {
        //        Cursor.visible = false;
        //    }
        //}

        //// esc�� ������
        //// ������ Ȱ��ȭ
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.visible = true;
        //}
        
    }

}
