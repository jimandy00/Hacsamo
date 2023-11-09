using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

// ä��
// Input Field���� ä���� �ۼ��ϸ�
public class ChatManager : MonoBehaviourPun
{
    public InputField chatInput;

    public GameObject chatItemFactory;
    public RectTransform rtContent;

    public RectTransform rtScrollView;

    float prevContentH;


    // ä�÷��� Ŭ���ϸ� �÷��̾ �̵����� ���ϰ� �ϴ� ���


    // Start is called before the first frame update
    void Start()
    {
        // ���� Ű�� ������, Input Field�� �ִ� text ������ �˷��ִ� �Լ� ���
        //chatInput.onSubmit.AddListener((string s) => print("OnSubmit : " + s)); // delegate
        chatInput.onSubmit.AddListener(OnSubmit); // delegate


        //// InputField�� ������ ����� ������ ȣ�����ִ� �Լ� ���
        //chatInput.onValueChange.AddListener(OnValueChaned);

        //// InputField�� Focusing�� ������� �� ȣ�����ִ� �Լ� ���
        //chatInput.onEndEdit.AddListener((string s) => print("OnEndEdit : " + s));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnSubmit(string s)
    {
        prevContentH = rtContent.sizeDelta.y;

        print("Onsubmit : " + s);



        // �г����� �ٿ��� ä�� ������ �����.
        string nameChat = "<color=#" + UnityEngine.ColorUtility.ToHtmlStringRGB(Color.blue) + ">" +
            PhotonNetwork.NickName + "</color>" + " : " + s;


        // RPC �Լ��� ��� ������� ä�� ���� ����
        photonView.RPC(nameof(AddChatRpc), RpcTarget.All, nameChat);

    }

    [PunRPC]
    void AddChatRpc(string nameChat)
    {
        // chat item�� �����.
        var ci = Instantiate(chatItemFactory);

        // ������� chat item�� �θ� content���Ѵ�.
        ci.transform.SetParent(rtContent);

        var item = ci.GetComponent<ChatItem>();
        item.SetText(nameChat);

        // chatInput�� �ʱ�ȭ
        chatInput.text = "";
        chatInput.ActivateInputField();

        // ���� ��Ÿ������? �� ������ ����� ������ �ڷ�ƾ���� �� �������� �纸���ش�.
        StartCoroutine(AutoScrollBottom());

    }

    IEnumerator AutoScrollBottom()
    {
        yield return 0; // �� ������ �纸

        // scroll view�� h���� content�� h���� ũ�ٸ� (��ũ���� ������ ���¶��)
        if(rtScrollView.sizeDelta.y < rtContent.sizeDelta.y)
        {
            // ������ �ٴڿ� ����־��ٸ�
            if(prevContentH - rtScrollView.sizeDelta.y <= rtContent.anchoredPosition.y)
            {
                // content�� y���� �缳���Ѵ�.
                rtContent.anchoredPosition = new Vector2(0, rtContent.sizeDelta.y - rtScrollView.sizeDelta.y);
            }
        }

    }


}
