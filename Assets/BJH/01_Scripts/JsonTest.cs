using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

// 구조체
[System.Serializable]
public struct UserInfo
{
    public string name;
    public int age;
    public List<string> role;
}

[System.Serializable]
public struct JsonDataTest
{
    public UserInfo data;
}

public class JsonTest : MonoBehaviour
{
    public UserInfo myInfo;
    // Start is called before the first frame update
    void Start()
    {
        myInfo.name = "test";
        myInfo.age = 100;
        myInfo.role = new List<string>();
        myInfo.role.Add("학생");
        myInfo.role.Add("반장");

        // myinfo를 json 형태로 만들기
        string json = JsonUtility.ToJson(myInfo, true);
        print(json);

        // 파일 만들기
        FileStream file = new FileStream(Application.dataPath + "/myinfo.txt", FileMode.Create);

        // json string 데이터를 byte배열로 변경
        byte[] bateData = Encoding.UTF8.GetBytes(json);

        // 파일에 저장
        file.Write(bateData, 0, bateData.Length);

        file.Close();
    }

    private void Update()
    {
        // file 읽어오기
        FileStream file = new FileStream(Application.dataPath + "/myInfo.txt", FileMode.Open);

        // file 크기만큼 byte 할당
        byte[] byteData = new byte[file.Length];

        // byte data에 file 내용 읽어오기
        file.Read(byteData, 0, byteData.Length);

        // 파일 닫기
        file.Close();

        // byte니까 string으로 바꾸자
        string jsonData = Encoding.UTF8.GetString(byteData);

        // 문자열로 되어있는 jsonData를 myInfo에 파싱한다.
        myInfo = JsonUtility.FromJson<UserInfo>(jsonData);
    }
}

