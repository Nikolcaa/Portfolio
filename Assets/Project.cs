using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Project : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Animator _anim;

    private void Start()
    {
        _anim.enabled = false;
        FadeInAnim();
    }

    private void FadeInAnim()
    {
        Vector2 cachedSize = _rectTransform.sizeDelta;
        _rectTransform.sizeDelta = Vector3.zero;
        _rectTransform.DOSizeDelta(cachedSize, 1)
            .SetDelay(2.45f)
            .SetEase(Ease.InOutQuad)
            .OnComplete(() =>
            {
                _anim.enabled = true;
            });
    }
}
