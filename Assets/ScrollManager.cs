using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private ScrollRect _scrollRect;
    public static float ScrollValue;

    private void Start()
    {
        ScrollValue = _scrollbar.value;
    }

    public void OnScroll()
    {
        ScrollValue = _scrollbar.value;
    }

    public void ScrollTo(float value)
    {
        _scrollRect.DOVerticalNormalizedPos(value, .75f)
            .SetEase(Ease.InOutQuad);
    }
}
