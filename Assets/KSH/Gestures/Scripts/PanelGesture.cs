using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGesture : MonoBehaviour
{
    [SerializeField] PanelAllGestures panelAllGestures;


       
    
    public void Show() 
    {
        gameObject.SetActive(true);

        GestureManager.AddPanel(gameObject,OnClickExit);

    }




    public void OnClickEdit() 
    {
        panelAllGestures.Show(gameObject);

        //RectTransform myRectTransform = gameObject.GetComponent<RectTransform>();

        //myRectTransform.anchoredPosition = new Vector2(-960,600);
    }


    public void OnClickExit()
    {
        GestureManager.RemovePanel(gameObject);

        gameObject.SetActive(false);
    }
}
