using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureveGlow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mRenderer;
    [SerializeField] private AnimationCurve mPulseCurve;
    private float mTimer = 0;
    private float mMaxTime;

    private void Start()
    {
        mMaxTime = mPulseCurve.keys[mPulseCurve.keys.Length - 1].time;
    }

    void Update()
    {
        mTimer += Time.deltaTime;
        if (mTimer > mMaxTime)
            mTimer = 0;

        var c = mRenderer.color;
        c.a = mPulseCurve.Evaluate(mTimer);
        mRenderer.color = c;
    }
}
