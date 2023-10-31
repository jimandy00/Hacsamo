using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    // profileUI ������Ʈ
    public GameObject profileUI;
    // �̴ϸ� ��ũ��Ʈ
    public GameObject miniMapScript;
    // voiceUI ������Ʈ
    public GameObject voiceUI;
    // voiceUIOff ������Ʈ
    public GameObject voiceUIOff;
    // pop-Up ������Ʈ
    public GameObject popUpUI;
    // miniMap UI ������Ʈ
    public GameObject miniMapUI;
    // lunch UI ������Ʈ
    public GameObject lunchUI;
    // nofity UI ������Ʈ
    public GameObject nofityUI;


    // ������ ������ �� ���α�
    private void Start()
    {
        profileUI.SetActive(false);
        voiceUI.SetActive(false);
        popUpUI.SetActive(false);
        miniMapUI.SetActive(false);
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

    // PopUp UI �ѱ�
    public void popUp()
    {
        popUpUI.SetActive(true);
    }

    // PopUp UI ����
    public void popUpOff()
    {
        popUpUI.SetActive(false);
    }

    // miniMapUI �ѱ�
    public void miniMapUIShow()
    {
        miniMapUI.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
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

    // ��ư�� ������ voiceUIOff ��Ű�� �ϱ�
    public void voiceOff()
    {
        voiceUIOff.SetActive(true);
        voiceUI.SetActive(false);
    }

    public void voiceOn()
    {
        voiceUI.SetActive(true);
        voiceUIOff.SetActive(false);
    }

    // ����â ������
    public void OnClickOut()
    {
        Application.Quit();
    }
}
