using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public TMP_InputField[] logins; // email, password
    public GameObject loading;
    void Start()
    {
        logins[1].onSubmit.AddListener(delegate { TryLogin(); }); // 패스워드 입력했을 때 TryLogin() 실행
    }

    private void TryLogin()
    {
        if(logins[0].text == "" || logins[1].text == "" )
        {
            Debug.LogError("input email or password");
        }

        StartCoroutine(SendRequest(logins[0].text, logins[1].text));
    }

    // 유니티 단일 쓰레드 -> 멀티 쓰레드 (코루틴)
    IEnumerator SendRequest(string email, string password)
    {
        string url = "http://api.metaone.world:8090/api/user/login?email=" + email + "&user_password=" + password;

        Debug.LogError(url);

        // 요청을 보냄
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response : " + UnityWebRequest.Result.Success);

            LoginResponse response = JsonUtility.FromJson<LoginResponse>(webRequest.downloadHandler.text);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }




    [System.Serializable]
    public class LoginResponse
    {
        public string result;
        public string msg;
        public UserData data;
    }

    [System.Serializable]
    public class UserData
    {
        public string security_token;
        public string nickname;
        public string connect_ip;
        public string user_idx;
    }
}
