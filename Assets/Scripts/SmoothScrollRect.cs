using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Version of <see cref="ScrollRect"/> that supports smooth scrolling.
/// </summary>
public class SmoothScrollRect : ScrollRect
{
    public bool SmoothScrolling { get; set; } = true;
    public float SmoothScrollTime { get; set; } = 0.5f;

    public static event Action OnScrollEvent;

    public override void OnScroll(PointerEventData data)
    {
        if (!IsActive())
            return;

        if (SmoothScrolling)
        {
            Vector2 positionBefore = normalizedPosition;
            this.DOKill(complete: true);
            base.OnScroll(data);
            Vector2 positionAfter = normalizedPosition;

            normalizedPosition = positionBefore;
            this.DONormalizedPos(positionAfter, SmoothScrollTime)
                .SetUpdate(UpdateType.Fixed);
        }
        else
        {
            base.OnScroll(data);
        }

        OnScrollEvent?.Invoke();
    }

    public override void OnBeginDrag(PointerEventData eventData) { }
    public override void OnDrag(PointerEventData eventData) { }
    public override void OnEndDrag(PointerEventData eventData) { }
}