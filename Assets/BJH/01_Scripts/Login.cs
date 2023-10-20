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

        logins[1].onSubmit.AddListener(delegate { TryLogin(); }); // �н����� �Է����� �� TryLogin() ����
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

        StartCoroutine(SendRequest(logins[0].text, logins[1].text));
    }

    // ����Ƽ ���� ������ -> ��Ƽ ������ (�ڷ�ƾ)
    // email, password�� �Է��ϸ�
    IEnumerator SendRequest(string email, string password)
    {
        string url = "http://api.metaone.world:8090/api/user/login?email=" + email + "&user_password=" + password;

        Debug.LogError(url);

        // ��û�� ����
        // UnityWebRequest ����
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        
        yield return webRequest.SendWebRequest();

        // ��û�� �Ϸ� �Ǿ����� Ȯ��
        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            // ���� �ؽ�Ʈ ���
            Debug.Log("Response : " + UnityWebRequest.Result.Success);

            LoginResponse response = JsonUtility.FromJson<LoginResponse>(webRequest.downloadHandler.text);

            if (response.msg != "Login Failed")
            {
                LoginSuccess();
            }
            else
            {
                // �α����� �����ϸ� ���� �޽����� ���
                Debug.Log("Error : " + webRequest.error);
            }
        }
    }

    private AsyncOperation loadOperation;

    public void LoginSuccess()
    {
        // �� �ε带 �񵿱�� ����
    }

    // �α��� ��ư ���� �� ȣ��Ǵ� �Լ�
    public void OnclickLoginBtn()
    {
        // �ε� UI Ȱ��ȭ
        loading.SetActive(true);

        // Photon
        // ���� ������ �̵�
        SimpleConnectionManager.instance.StartConnection();
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
