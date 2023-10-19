using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject profileUI;

    public GameObject miniMapScript;

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

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                miniMapScript.GetComponent<MinimapCamera>().enabled = false;
            }

        }
    }

    // ��ư�� ������ �̴ϸ� ī�޶� �۵��ǰ� �ϱ�
    public void MinimapCam()
    {
        miniMapScript.GetComponent<MinimapCamera>().enabled = true;
    }
}