using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DropdownMa : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public string[] menu = new string[6] { "Profile", "Notify", "FoodMenu", "MiniMap", "Configuration", "GetOut" };
    private void Awake()
    {
        // ���� dropdown�� �ִ� ��� �ɼ��� ����
        dropdown.ClearOptions();

        // ���ο� �ɼ� ������ ���� OptionData ����
        List<TMP_Dropdown.OptionData> optionList = new List<TMP_Dropdown.OptionData>();

        //// menu �迭�� �ִ� ��� ���ڿ� �����͸� �ҷ��ͼ� optionList�� ����
        //foreach (string str in menu)
        //{
        //    optionList.Add(new TMP_Dropdown.OptionData(str));
        //}

        //// ������ ������ optionList�� dropdown�� �ɼ� ���� �߰�
        //dropdown.AddOptions(optionList);

        //// ���� dropdown�� ���õ� �ɼ��� 0������ ����
        //dropdown.value = 0;
    }

    private void OnDropdownEvent(int arg0)
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ClearOptions()
    {
        throw new NotImplementedException();
    }

    internal void AddOptions(object p)
    {
        throw new NotImplementedException();
    }

    internal class OptionData
    {
        private string v;

        public OptionData(string v)
        {
            this.v = v;
        }
    }
}
