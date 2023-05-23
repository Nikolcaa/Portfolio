using DG.Tweening;
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

    public override void OnScroll(PointerEventData data)
    {
        if (!IsActive())
            return;

        base.OnScroll(data);

        /*
        if (SmoothScrolling)
        {
            Vector2 positionBefore = normalizedPosition;
            this.DOKill(complete: true);
            base.OnScroll(data);
            Vector2 positionAfter = normalizedPosition;

            normalizedPosition = positionBefore;
            this.DONormalizedPos(positionAfter, SmoothScrollTime);
        }
        else
        {
            base.OnScroll(data);
        }
        */
    }
}