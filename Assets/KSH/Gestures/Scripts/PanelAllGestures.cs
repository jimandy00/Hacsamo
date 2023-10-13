using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kmr.Grids;

public class PanelAllGestures : MonoBehaviour
{
    [SerializeField] BasicGridAdapter basicGridAdapter;

    GameObject preGo = null;
    
    public void Show(GameObject go)
    {
        gameObject.SetActive(true);

        GestureManager.AddPanel(gameObject, OnClickExit);

        MakeDim(true);

        if (go != null)
        {
            preGo = go;
        }

        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {

        yield return null;

        /*
        if (basicGridAdapter.Data.Count == 0)
        {
            foreach (ListItem item in GestureManager.Instance.gestureList)
            {
                var model = new MainGridItemModel();

                model.listItem = item;
               
                basicGridAdapter.Data.InsertOneAtEnd(model);
            }
        }
        */


    }


    public void OnClickExit()
    {
        GestureManager.RemovePanel(gameObject);

        //RectTransform preRectTransform = preGo.GetComponent<RectTransform>();

        //preRectTransform.anchoredPosition = new Vector2(-233, 220);

        MakeDim(false);

        gameObject.SetActive(false);
        
    }

    public void MakeDim(bool isDim)
    {
        Transform parentTransform = transform.parent;
        Image panelImage = parentTransform.GetComponent<Image>();
        

        if (isDim)
        {
            panelImage.color = new Color(128f / 255f, 128f / 255f, 128f / 255f, 0.5f);

        }

        else
        {
            panelImage.color = new Color(0f, 0f, 0f, 0f);
        }
    }

    public void OnClickButtonSearch() 
    {
        
    
    }
}
