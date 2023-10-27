using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField[] logins; // email, password
    public GameObject loading;
    void Start()
    {
        loading.SetActive(false);

        logins[0].onSubmit.AddListener(delegate { TryLogin(); }); // 이메일을 입력했을 때 TryLogin() 실행
        logins[1].onSubmit.AddListener(delegate { TryLogin(); }); // 패스워드 입력했을 때 TryLogin() 실행
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TryLogin()
    {
        if(logins[0].text == "" || logins[1].text == "" )
        {
            Debug.LogError("input email or password");
            return;
        }

        print("email : " + logins[0].text + "   password : " + logins[1].text);

        StartCoroutine(SendRequest(logins[0].text, logins[1].text));
    }

    // 유니티 단일 쓰레드 -> 멀티 쓰레드 (코루틴)
    // email, password를 입력하면
    IEnumerator SendRequest(string email, string password)
    {
        string url = "http://api.metaone.world:8090/api/user/login?email=" + email + "&user_password=" + password;

        Debug.LogError(url);

        // 요청을 보냄
        // UnityWebRequest 생성
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        
        yield return webRequest.SendWebRequest();

        // 요청이 완료 되었는지 확인
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // 응답 텍스트 출력
            Debug.Log("Response : " + UnityWebRequest.Result.Success);

            LoginResponse response = JsonUtility.FromJson<LoginResponse>(webRequest.downloadHandler.text);

            if (response.result == "200")
            {
                //LoginSuccess();

                // 로딩 UI 활성화
                loading.SetActive(true);

                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    // Photon
                    // 다음 씬으로 이동
                    SimpleConnectionManager.instance.StartConnection();
                }
                else
                {
                    Debug.Log("아이디 혹은 비밀번호를 다시 확인해주세요.");
                }

            }
            else
            {
                // 로그인이 실패하면 오류 메시지를 출력
                Debug.Log("Error : " + webRequest.error);
            }
        }
    }

    private AsyncOperation loadOperation;

    public void LoginSuccess()
    {
        // 씬 로드를 비동기로 시작
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
