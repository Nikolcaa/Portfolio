using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    public static float ScrollValue;

    private void Start()
    {
        ScrollValue = _scrollbar.value;
    }

    public void OnScroll()
    {
        ScrollValue = _scrollbar.value;
    }
}
