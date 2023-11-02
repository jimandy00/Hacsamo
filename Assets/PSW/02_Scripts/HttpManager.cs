using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HttpManager : MonoBehaviour
{
    public string[] urls; // URL�� ������ �迭
    public Button[] buttons; // ��ư ������Ʈ �迭

    void Start()
    {
        // �� ��ư�� ���� Ŭ�� �̺�Ʈ �ڵ鷯�� ����
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
