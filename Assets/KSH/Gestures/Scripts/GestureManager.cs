using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public delegate void DelegateParam(object o);
public delegate void DelegateNone();


public class ListItem : ScriptableObject
{
    public string title;
    public Sprite thumb;
}

public class GestureManager : MonoBehaviour
{
    
    [SerializeField] PanelGesture panelGesture;
    [SerializeField] PanelAllGestures panelAllGestures;
    public static GestureManager Instance = null;
    public List<ListItem> gestureList = new List<ListItem>();

    private void Start()
    {
        Instance = this;

        StartCoroutine(CoInit());
    }

    IEnumerator CoInit()
    {
        yield return new WaitForSeconds(1f);

        ListItem listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Happy";
        listItem.thumb = Resources.Load<Sprite>("Gestures/BrutalToHappyWalking");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Shaking";
        listItem.thumb = Resources.Load<Sprite>("Gestures/HappyHandGesture");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Happy";
        listItem.thumb = Resources.Load<Sprite>("Gestures/BrutalToHappyWalking");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Shaking";
        listItem.thumb = Resources.Load<Sprite>("Gestures/HappyHandGesture");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Happy";
        listItem.thumb = Resources.Load<Sprite>("Gestures/BrutalToHappyWalking");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Shaking";
        listItem.thumb = Resources.Load<Sprite>("Gestures/HappyHandGesture");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Happy";
        listItem.thumb = Resources.Load<Sprite>("Gestures/BrutalToHappyWalking");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Shaking";
        listItem.thumb = Resources.Load<Sprite>("Gestures/HappyHandGesture");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Happy";
        listItem.thumb = Resources.Load<Sprite>("Gestures/BrutalToHappyWalking");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Shaking";
        listItem.thumb = Resources.Load<Sprite>("Gestures/HappyHandGesture");
        gestureList.Add(listItem);

        listItem = ScriptableObject.CreateInstance<ListItem>();
        listItem.title = "Happy";
        listItem.thumb = Resources.Load<Sprite>("Gestures/BrutalToHappyWalking");
        gestureList.Add(listItem);


    }





        public void OnGestureButtonClicked() 
    {
        Debug.Log("panelGesture show call!!");
        panelGesture.Show();
    }



    static Dictionary<GameObject, DelegateNone> panelDic = new Dictionary<GameObject, DelegateNone>();

    public static DelegateNone GetCurrentDB() 
    {
        DelegateNone cb = null;
        if (panelDic.Count > 0) 
        {
            cb = panelDic.Values.Last();
        }

        return cb;
    }


    public static void AddPanel(GameObject panelGo, DelegateNone ExitCB) 
    {
        if (panelDic.ContainsKey(panelGo)) 
        {
            return;
        
        }

        panelDic.Add(panelGo, ExitCB);
    }

    public static void RemovePanel(GameObject panelGo) 
    {
        if (panelDic.ContainsKey(panelGo)) 
        {
            GameObject go = panelDic.Keys.Last();
            if (go == panelGo) 
            {
                panelDic.Remove(panelGo);
            }
        }
    }

    public void OnClickExit() 
    {
        GestureManager.RemovePanel(gameObject);
        gameObject.SetActive(false);
    }

}
