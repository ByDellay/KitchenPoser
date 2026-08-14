using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public float Duration;
    public AnimationCurve Curve;

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
            Vector3 ShakeOffset = (Vector3)Random.insideUnitCircle * Curve.Evaluate((CurrentTime / Duration));
            transform.position = OriginalPos + ShakeOffset;

            CurrentTime += Time.deltaTime;
            yield return null;
        }

        transform.position = OriginalPos;
    }
}// agora faz isso!
