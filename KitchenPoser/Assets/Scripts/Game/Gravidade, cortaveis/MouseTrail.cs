using UnityEngine;

public class MouseTrail : MonoBehaviour
{

    //ParticleSystem ps;
    TrailRenderer Trail;
    /*// Poder cortar
    public bool CanCut = true;*/


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
    }
}
