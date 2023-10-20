using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SimpleConnectionManager : MonoBehaviourPunCallbacks
{
    public static SimpleConnectionManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Photon ȯ�漳���� ������� ���� �õ�
        //PhotonNetwork.ConnectUsingSettings();
    }

    public void StartConnection()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster(); // �θ� ���� ���� �� ���� ����
        print(nameof(OnConnectedToMaster));

        // master scene�� ����������
        // �κ� ����
        JoinLobby();
    }

    void JoinLobby()
    {
        // �г��� ����
        // ����� ���Ƿ� ����
        PhotonNetwork.NickName = "����Park";

        // �⺻ �κ� ����
        PhotonNetwork.JoinLobby();
    }

    // �κ����� �Ϸ�
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(nameof(OnJoinedLobby));

        // �� ���� or �� ����
        RoomOptions roomOptions = new RoomOptions();
        PhotonNetwork.JoinOrCreateRoom("Hacsamo", roomOptions, TypedLobby.Default);

    }

    // �� ���� �Ϸ�
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print(nameof(OnCreatedRoom));
    }

    // �� ���� ����
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print(nameof(OnCreateRoomFailed));
    }

    // �� ���� �Ϸ�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print(nameof(OnJoinedRoom));

        // Game Scene���� �̵�
        PhotonNetwork.LoadLevel(1); // build setting ���� 1�� ������ �̵�
    }
}
