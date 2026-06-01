using UnityEngine;

public class MouseTrail : MonoBehaviour
{

    //ParticleSystem ps;
    TrailRenderer Trail;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ps = GetComponent<ParticleSystem>();
        Trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;
        Trail.emitting = Input.GetMouseButton(0);

        /*if (Input.GetMouseButton(0))
        {
            if (!ps.isPlaying)
            {
                ps.Play();
            }
        }
        else
        {
            if (ps.isPlaying)
            {
                ps.Stop();
            }
        }*/
    }
}
