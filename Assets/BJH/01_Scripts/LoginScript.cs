using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Net;
using UnityEditor.PackageManager.Requests;

public class LoginScript : MonoBehaviour
{
    // 요청을 보낼 URL 생성

    // UnityWebRequest 생성

    public TMP_InputField[] logins;
    public GameObject loading;

    private void Start()
    {
        logins[1].onSubmit.AddListener(delegate { TryLogin(); });
    }


    public void TryLogin()
    {
        if (logins[0].text == "" || logins[1].text == "")
        {
            Debug.LogError("input anything");
            return;
        }

        StartCoroutine(SendRequest(logins[0].text, logins[1].text));
    }



    public IEnumerator SendRequest(string email, string password)
    {
        string url = "http://api.metaone.world:8090/api/user/login?email=" + email + "&user_password=" + password;

        Debug.LogError(url);

        // 요청을 보냄
        // UnityWebRequest 생성
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        // 요청을 보냄
        yield return webRequest.SendWebRequest();

        // 요청이 완료되었는지 확인
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // 응답 텍스트 출력
            Debug.Log("Response: " + webRequest.downloadHandler.text);

            LoginResponse response = JsonUtility.FromJson<LoginResponse>(webRequest.downloadHandler.text);
            // 역직렬화된 데이터에 접근
            Debug.Log("Result: " + response.result);
            Debug.Log("Message: " + response.msg);
            Debug.Log("Security Token: " + response.data.security_token);
            Debug.Log("Nickname: " + response.data.nickname);
            Debug.Log("Connect IP: " + response.data.connect_ip);
            Debug.Log("User Index: " + response.data.user_idx);


            if (response.msg != "Login Failed.")
            {
                LoginSuccess();
            }
        }
        else
        {
            // 오류 메시지 출력
            Debug.LogError("Error: " + webRequest.error);
        }
    }


    public void LoginSuccess()
    {
        // 씬 로드를 비동기로 시작
        loadOperation = SceneManager.LoadSceneAsync("AvartarSelect");
        loadOperation.allowSceneActivation = false;

        logins[0].transform.parent.gameObject.SetActive(false);
        loading.SetActive(true);


        // 로딩 진행률 업데이트
        StartCoroutine(UpdateLoadingScreen());

    }


    //비밀번호 판넬 보여주는 코드
    public GameObject createAccountobj;
    public void GoCreateAccount()
    {
        gameObject.SetActive(false);
        createAccountobj.SetActive(true);
    }




    public TMP_Text loadingText;

    private AsyncOperation loadOperation;


    private IEnumerator UpdateLoadingScreen()
    {
        while (!loadOperation.isDone)
        {
            float progress = Mathf.Clamp01(loadOperation.progress / 0.9f); // 0.9f로 나누어 로딩 진행률을 0-1 사이로 정규화

            // Percentage 텍스트 업데이트
            loadingText.text = "로딩 중... " + (int)(progress * 100) + "%";

            if (progress >= 1f)
            {
                // 로딩이 완료되면 씬을 활성화
                loadOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // 현재 선택된 InputField 찾기
            TMP_InputField currentInputField = null;
            foreach (var inputField in logins)
            {
                if (inputField.isFocused)
                {
                    currentInputField = inputField;
                    break;
                }
            }

            // 현재 선택된 InputField가 있다면
            if (currentInputField != null)
            {
                // 다음 InputField 찾기
                int currentIndex = System.Array.IndexOf(logins, currentInputField);
                if (currentIndex >= 0)
                {
                    int nextIndex = (currentIndex + 1) % logins.Length;

                    // 다음 InputField로 포커스 이동
                    logins[nextIndex].Select();
                }
            }
        }
    }

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