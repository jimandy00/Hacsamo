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
        // 현재 dropdown에 있는 모든 옵션을 제거
        dropdown.ClearOptions();

        // 새로운 옵션 설정을 위한 OptionData 생성
        List<TMP_Dropdown.OptionData> optionList = new List<TMP_Dropdown.OptionData>();

        //// menu 배열에 있는 모든 문자열 데이터를 불러와서 optionList에 저장
        //foreach (string str in menu)
        //{
        //    optionList.Add(new TMP_Dropdown.OptionData(str));
        //}

        //// 위에서 생성한 optionList를 dropdown의 옵션 값에 추가
        //dropdown.AddOptions(optionList);

        //// 현재 dropdown에 선택된 옵션을 0번으로 설정
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
