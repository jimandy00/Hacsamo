using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject profileUI;

    // ������ ������ �� ���α�
    private void Start()
    {
        profileUI.SetActive(false);
    }

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

    // profile UI �ѱ�
    public void profileShow()
    {
        profileUI.SetActive(true);
    }

    // profile UI ����
    public void profileHide() 
    { 
        profileUI.SetActive(false);
    }
}