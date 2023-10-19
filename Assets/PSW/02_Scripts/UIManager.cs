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

    // 프로필 시작할 때 꺼두기
    private void Start()
    {
        profileUI.SetActive(false);
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

    // 게임창 나가기
    public void OnClickOut()
    {
        Application.Quit();
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

    // 버튼을 누르면 미니맵 카메라가 작동되게 하기
    public void MinimapCam()
    {
        miniMapScript.GetComponent<MinimapCamera>().enabled = true;
    }
}