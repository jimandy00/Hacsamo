using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggedSlot : MonoBehaviour
{
    static public DraggedSlot instance;
    public DraggAbleUI dragSlot;

    [SerializeField]
    private Image imageItem;

    void Start()
    {
        instance = this;
        DragSetImage(imageItem);
    }

    public void DragSetImage(Image _itemImage)
    {
        this.GetComponent<Image>().sprite = imageItem.sprite;
        Debug.Log("imaged set");
        //imageItem.sprite = _itemImage.sprite;
        SetColor(1);
    }

    public void SetColor(float _alpha)
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }
}
