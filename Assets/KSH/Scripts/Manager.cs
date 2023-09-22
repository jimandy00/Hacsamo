using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager s_instance;    //���ϼ��� �����Ѵ�
    public static Manager Instance { get { init(); return s_instance; } }    //������ �Ŵ����� ������ �´�


    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void init() 
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("Manager");
            if (go == null)
            {
                go = new GameObject { name = "Manager" };
                go.AddComponent<Manager>();

            }

            DontDestroyOnLoad(go);

            s_instance = go.GetComponent<Manager>();
        }
    
    }
}
