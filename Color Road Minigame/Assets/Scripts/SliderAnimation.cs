using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

[RequireComponent(typeof(Slider))]
public class SliderAnimation : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Reset()
    {
        slider = GetComponent<Slider>();
    }

    private Sequence animationSequence;

    // Start is called before the first frame update
    void Start()
    {
        animationSequence = DOTween.Sequence();
        animationSequence.SetLoops(-1);
        animationSequence.PrependInterval(0.5f);
        animationSequence.Append(slider.DOValue(1f, 1f));
        animationSequence.AppendInterval(0.5f);
        animationSequence.Append(slider.DOValue(0f, 1f));
    }

    public void KillAnimation()
    {
        animationSequence.Kill();
    }
}
