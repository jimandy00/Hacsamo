using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject profileUI;

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
}