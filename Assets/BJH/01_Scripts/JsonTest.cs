using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

// ����ü
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
        myInfo.role.Add("�л�");
        myInfo.role.Add("����");

        // myinfo�� json ���·� �����
        string json = JsonUtility.ToJson(myInfo, true);
        print(json);

        // ���� �����
        FileStream file = new FileStream(Application.dataPath + "/myinfo.txt", FileMode.Create);

        // json string �����͸� byte�迭�� ����
        byte[] bateData = Encoding.UTF8.GetBytes(json);

        // ���Ͽ� ����
        file.Write(bateData, 0, bateData.Length);

        file.Close();
    }

    private void Update()
    {
        // file �о����
        FileStream file = new FileStream(Application.dataPath + "/myInfo.txt", FileMode.Open);

        // file ũ�⸸ŭ byte �Ҵ�
        byte[] byteData = new byte[file.Length];

        // byte data�� file ���� �о����
        file.Read(byteData, 0, byteData.Length);

        // ���� �ݱ�
        file.Close();

        // byte�ϱ� string���� �ٲ���
        string jsonData = Encoding.UTF8.GetString(byteData);

        // ���ڿ��� �Ǿ��ִ� jsonData�� myInfo�� �Ľ��Ѵ�.
        myInfo = JsonUtility.FromJson<UserInfo>(jsonData);
    }
}

