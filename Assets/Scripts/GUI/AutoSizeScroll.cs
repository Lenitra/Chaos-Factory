using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSizeScroll : MonoBehaviour
{
    void Awake(){
        // get the sum of size of all children
        float size = 0;
        foreach (RectTransform child in transform)
        {
            size += child.sizeDelta.y;
        }
        // set the size of the scroll view
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, size);
    }
}
