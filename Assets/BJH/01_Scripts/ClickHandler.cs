using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public bool isClick = false;
    private void OnMouseDown()
    {
        isClick = !isClick;
    }
}
