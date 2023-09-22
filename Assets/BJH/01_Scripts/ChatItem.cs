using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatItem : MonoBehaviour
{
    Text chatText;
    RectTransform rt;

    // Start is called before the first frame update
    void Awake()
    {
        chatText = GetComponent<Text>();
        rt = GetComponent<RectTransform>();
    }

    public void SetText(string s)
    {
        // text ����
        chatText.text = s;

        // text�� ���缭 ũ�⸦ ����
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, chatText.preferredHeight);
    }
}
