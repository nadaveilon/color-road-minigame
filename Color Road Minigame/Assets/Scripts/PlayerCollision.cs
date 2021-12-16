using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(ParticleSystem))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ParticleSystemRenderer particleRenderer;

    private void Reset()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        particleRenderer = GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>();
    }

    public void OnColorChanged(int index, Color color)
    {
        meshRenderer.material.color = color;
        particleRenderer.material.color = color;
        BlinkWhite();
    }

    public void OnScoreChanged(string score)
    {
        BlinkWhite();
    }

    private void BlinkWhite()
    {
        var original = meshRenderer.material.color;
        var flashTween = meshRenderer.material.DOColor(Color.white, 0.2f);
        flashTween.onComplete += () => meshRenderer.material.DOColor(original, 0.2f);
    }
}
