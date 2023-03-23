using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeScrollbar : MonoBehaviour
{
    public GameObject scrollBar;
    public Scrollbar scrollBarComponent;

    private float scrollPos = 0;
    private float[] pos;
    private float distance;
    private Button[] _arrayBtnLevel;

    private void Start()
    {
        scrollBarComponent = scrollBar.GetComponent<Scrollbar>();
        _arrayBtnLevel = GetComponentsInChildren<Button>();
        for (int i = 0; i < _arrayBtnLevel.Length; i++)
        {
            
        }
    }

    void Update()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollBarComponent.value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollBarComponent.value =
                        Mathf.Lerp(scrollBarComponent.value, pos[i], 0.1f);
                    transform.GetChild(i).localScale =
                        Vector3.Lerp(transform.GetChild(i).localScale, new Vector3(1.2f, 1.2f), 0.1f);
                    
                    for (int j = 0; j < pos.Length; j++)
                    {
                        if (j != i)
                        {
                            transform.GetChild(j).localScale =
                                Vector3.Lerp(transform.GetChild(j).localScale, new Vector3(0.86f, 0.86f), 0.1f);
                        }
                    }
                }
                
                    
            }
        }

        
        
        
    }
}
