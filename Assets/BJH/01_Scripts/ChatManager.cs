using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

// 채팅
// Input Field에서 채팅을 작성하면
public class ChatManager : MonoBehaviourPun
{
    public InputField chatInput;

    public GameObject chatItemFactory;
    public RectTransform rtContent;

    public RectTransform rtScrollView;

    float prevContentH;


    // 채팅룸을 클릭하면 플레이어를 이동하지 못하게 하는 방법


    // Start is called before the first frame update
    void Start()
    {
        // 엔터 키를 누르면, Input Field에 있는 text 내용을 알려주는 함수 등록
        //chatInput.onSubmit.AddListener((string s) => print("OnSubmit : " + s)); // delegate
        chatInput.onSubmit.AddListener(OnSubmit); // delegate


        //// InputField의 내용이 변경될 때마다 호출해주는 함수 등록
        //chatInput.onValueChange.AddListener(OnValueChaned);

        //// InputField의 Focusing이 사라졌을 때 호출해주는 함수 등록
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



        // 닉네임을 붙여서 채팅 내용을 만든다.
        string nameChat = "<color=#" + UnityEngine.ColorUtility.ToHtmlStringRGB(Color.blue) + ">" +
            PhotonNetwork.NickName + "</color>" + " : " + s;


        // RPC 함수로 모든 사람한테 채팅 내용 전달
        photonView.RPC(nameof(AddChatRpc), RpcTarget.All, nameChat);

    }

    [PunRPC]
    void AddChatRpc(string nameChat)
    {
        // chat item을 만든다.
        var ci = Instantiate(chatItemFactory);

        // 만들어진 chat item의 부모를 content로한다.
        ci.transform.SetParent(rtContent);

        var item = ci.GetComponent<ChatItem>();
        item.SetText(nameChat);

        // chatInput값 초기화
        chatInput.text = "";
        chatInput.ActivateInputField();

        // 값이 나타나려면? 한 프레임 쉬어가기 때문에 코루틴으로 한 프레임을 양보해준다.
        StartCoroutine(AutoScrollBottom());

    }

    IEnumerator AutoScrollBottom()
    {
        yield return 0; // 한 프레임 양보

        // scroll view의 h보다 content의 h값이 크다면 (스크롤이 가능한 상태라면)
        if(rtScrollView.sizeDelta.y < rtContent.sizeDelta.y)
        {
            // 이전에 바닥에 닿아있었다면
            if(prevContentH - rtScrollView.sizeDelta.y <= rtContent.anchoredPosition.y)
            {
                // content의 y값을 재설정한다.
                rtContent.anchoredPosition = new Vector2(0, rtContent.sizeDelta.y - rtScrollView.sizeDelta.y);
            }
        }

    }


}
