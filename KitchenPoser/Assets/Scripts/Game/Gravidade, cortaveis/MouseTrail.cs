using UnityEngine;

public class MouseTrail : MonoBehaviour
{

    //ParticleSystem ps;
    TrailRenderer Trail;
    /*// Poder cortar
    public bool CanCut = true;*/

    public bool onBreak = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ps = GetComponent<ParticleSystem>();
        Trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onBreak == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            transform.position = mousePos;
            Trail.emitting = Input.GetMouseButton(0);
        }
    }
}
