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
    // food UI ������Ʈ
    public GameObject foodUI;
    // nofity UI ������Ʈ
    public GameObject nofityUI;
    // number UI ������Ʈ
    public GameObject numberUI;
    // number UI ������Ʈ
    public GameObject numberUIOff;

    // �й� �� ���̰� �ϴ� �ؽ�Ʈ (�й� ������)
    public GameObject numberHideText;
    // �й� ���̰� �ϴ� �ؽ�Ʈ (�й� ���̱�)
    public GameObject numberShowText;



    // ������ ������ �� ���α�
    private void Start()
    {
        profileUI.SetActive(false);
        voiceUI.SetActive(false);
        popUpUI.SetActive(false);
        miniMapUI.SetActive(false);
        foodUI.SetActive(false);
        nofityUI.SetActive(false);
        numberUI.SetActive(false);
        numberShowText.SetActive(false);
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
        popUpUI.SetActive(false);
    }

    // profile UI ����
    public void profileHide()
    {
        profileUI.SetActive(false);
        popUpUI.SetActive(true);
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
        popUpUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                miniMapScript.GetComponent<MinimapCamera>().enabled = false;
                miniMapUI.SetActive(false);
                popUpUI.SetActive(true);
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

    // ��ư�� ������ voiceOnUI �ѱ�
    public void voiceOn()
    {
        voiceUI.SetActive(true);
        voiceUIOff.SetActive(false);
    }

    // lunchUI ������ �ϱ�
    public void FoodOn()
    {
        foodUI.SetActive(true);
    }

    // lunchUI ���� �ϱ�
    public void FoodOff()
    {
        foodUI.SetActive(false);
    }

    // nofityUI �ѱ�
    public void nofityUIOn()
    {
        nofityUI.SetActive(true);
        popUpUI.SetActive(false);
    }

    // nofityUI ����
    public void nofityUIOff()
    {
        nofityUI.SetActive(false);
        popUpUI.SetActive(true);
    }

    // number �й� UI ���̰� �ѱ�
    public void NumberUIOn()
    {
        numberUI.SetActive(true);
        numberUIOff.SetActive(false);
        numberShowText.SetActive(true);
        numberHideText.SetActive(false);
    }

    // number �й� UI �� ���̰� ����
    public void NumberUIOff()
    {
        numberUI.SetActive(false);
        numberUI.SetActive(true);
        numberHideText.SetActive(true);
        numberShowText.SetActive(false);
    }


    // ����â ������
    public void OnClickOut()
    {
        Application.Quit();
    }
}
