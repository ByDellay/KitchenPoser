using UnityEngine;
using System.Collections;

public class FogaoTremida : MonoBehaviour
{
    public float Duration;
    public AnimationCurve Curve;
    public Vector3 OriginalPos;
    [SerializeField] private int Vel = 200;


    void Start()
    {    
        OriginalPos = transform.position;
    }   
    
    public void DoShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float CurrentTime = 0;

        while (CurrentTime < Duration)
        {
            Vector3 ShakeOffset = new Vector3(Random.insideUnitCircle.x * Curve.Evaluate(0.01f), 0, 0);
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

