using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HttpManager : MonoBehaviour
{
    public string[] urls; // URL을 저장할 배열
    public Button[] buttons; // 버튼 오브젝트 배열

    void Start()
    {
        // 각 버튼에 대한 클릭 이벤트 핸들러를 설정
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OpenLink(index));
        }
    }

    public void OpenLink(int index)
    {
        if (index >= 0 && index < urls.Length)
        {
            Application.OpenURL(urls[index]);
        }
    }
}
