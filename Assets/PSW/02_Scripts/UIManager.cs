using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    // profileUI 오브젝트
    public GameObject profileUI;
    // 미니맵 스크립트
    public GameObject miniMapScript;
    // voiceUI 오브젝트
    public GameObject voiceUI;
    // voiceUIOff 오브젝트
    public GameObject voiceUIOff;
    // pop-Up 오브젝트
    public GameObject popUpUI;
    // miniMap UI 오브젝트
    public GameObject miniMapUI;
    // lunch UI 오브젝트
    public GameObject lunchUI;
    // nofity UI 오브젝트
    public GameObject nofityUI;


    // 프로필 시작할 때 꺼두기
    private void Start()
    {
        profileUI.SetActive(false);
        voiceUI.SetActive(false);
        popUpUI.SetActive(false);
        miniMapUI.SetActive(false);
    }

    // 맵 2로 전환
    public void OnClickMap2()
    {
        // Scene MAP2 로 변경할 것
        SceneManager.LoadScene("Map2");
    }

    // 맵 1로 전환
    public void OnClickMap1()
    {
        // Scene MAP1 로 변경할 것
        SceneManager.LoadScene("Map1");
    }

    // profile UI 켜기
    public void profileShow()
    {
        profileUI.SetActive(true);
    }

    // profile UI 끄기
    public void profileHide()
    {
        profileUI.SetActive(false);
    }

    // PopUp UI 켜기
    public void popUp()
    {
        popUpUI.SetActive(true);
    }

    // PopUp UI 끄기
    public void popUpOff()
    {
        popUpUI.SetActive(false);
    }

    // miniMapUI 켜기
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

    // 버튼을 누르면 미니맵 카메라가 작동되게 하기
    public void MinimapCam()
    {
        miniMapScript.GetComponent<MinimapCamera>().enabled = true;
    }

    // 버튼을 누르면 voiceUIOff 시키게 하기
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

    // 게임창 나가기
    public void OnClickOut()
    {
        Application.Quit();
    }
}
