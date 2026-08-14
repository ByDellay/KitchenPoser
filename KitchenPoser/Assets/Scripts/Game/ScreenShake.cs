using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public float Duration;
    public AnimationCurve Curve;
    [SerializeField] private int Vel = 20;

    public void DoScreenShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float CurrentTime = 0;
        Vector3 OriginalPos = transform.position;

        while (CurrentTime < Duration)
        {
            Vector3 ShakeOffset = (Vector3)Random.insideUnitCircle * Curve.Evaluate(0.00000000001f);
            transform.position = OriginalPos + ShakeOffset;

            CurrentTime += Time.deltaTime;
            for (int i = 0; i < Vel; i ++)
            {
                yield return null;
            } 
        }

        transform.position = OriginalPos;
    }
}// agora faz isso!
