using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // �� 2�� ��ȯ
   public void OnClickMap2()
   {
        // Scene MAP2 �� ������ ��
        SceneManager.LoadScene("Map2");
   }

    // �� 1�� ��ȯ
    public void OnClickMap1()
    {
        // Scene MAP1 �� ������ ��
        SceneManager.LoadScene("Map1");
    }

    // ����â ������
    public void OnClickOut()
    {
        Application.Quit();
    }
}
