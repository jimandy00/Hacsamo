using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasicGridItem : MonoBehaviour
{
    [SerializeField] Text txtTitle;
    [SerializeField] Image thumbNail;

    public ListItem listitem;

    DelegateParam _returncb;

    // Start is called before the first frame update

    public void Show(ListItem listItem)
    {

        
        this.listitem = listItem;

        txtTitle.text = listItem.title;

        thumbNail.sprite = listItem.thumb;

    }
    
}