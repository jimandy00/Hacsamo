using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // ��2�� ��ȯ
   public void OnClickMap2()
   {
        // Scene MAP2 �� ������ ��
        SceneManager.LoadScene("Map2");
   }

    public void OnClickOut()
    {
        // ����â ������
        Application.Quit();
    }
}
