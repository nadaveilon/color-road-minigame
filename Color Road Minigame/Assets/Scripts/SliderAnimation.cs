using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderAnimation : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Reset()
    {
        slider = GetComponent<Slider>();
    }

    private Sequence animationSequence;
    
    void Start()
    {
        // Create looping animation sequence for the slider value
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
