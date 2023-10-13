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
    // ��û�� ���� URL ����

    // UnityWebRequest ����

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

        // ��û�� ����
        // UnityWebRequest ����
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        // ��û�� ����
        yield return webRequest.SendWebRequest();

        // ��û�� �Ϸ�Ǿ����� Ȯ��
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // ���� �ؽ�Ʈ ���
            Debug.Log("Response: " + webRequest.downloadHandler.text);

            LoginResponse response = JsonUtility.FromJson<LoginResponse>(webRequest.downloadHandler.text);
            // ������ȭ�� �����Ϳ� ����
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
            // ���� �޽��� ���
            Debug.LogError("Error: " + webRequest.error);
        }
    }


    public void LoginSuccess()
    {
        // �� �ε带 �񵿱�� ����
        loadOperation = SceneManager.LoadSceneAsync("AvartarSelect");
        loadOperation.allowSceneActivation = false;

        logins[0].transform.parent.gameObject.SetActive(false);
        loading.SetActive(true);


        // �ε� ����� ������Ʈ
        StartCoroutine(UpdateLoadingScreen());

    }


    //��й�ȣ �ǳ� �����ִ� �ڵ�
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
            float progress = Mathf.Clamp01(loadOperation.progress / 0.9f); // 0.9f�� ������ �ε� ������� 0-1 ���̷� ����ȭ

            // Percentage �ؽ�Ʈ ������Ʈ
            loadingText.text = "�ε� ��... " + (int)(progress * 100) + "%";

            if (progress >= 1f)
            {
                // �ε��� �Ϸ�Ǹ� ���� Ȱ��ȭ
                loadOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // ���� ���õ� InputField ã��
            TMP_InputField currentInputField = null;
            foreach (var inputField in logins)
            {
                if (inputField.isFocused)
                {
                    currentInputField = inputField;
                    break;
                }
            }

            // ���� ���õ� InputField�� �ִٸ�
            if (currentInputField != null)
            {
                // ���� InputField ã��
                int currentIndex = System.Array.IndexOf(logins, currentInputField);
                if (currentIndex >= 0)
                {
                    int nextIndex = (currentIndex + 1) % logins.Length;

                    // ���� InputField�� ��Ŀ�� �̵�
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