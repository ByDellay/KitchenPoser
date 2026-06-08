using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private RawImage Image;
    [SerializeField] private float _x, _y;

    // Update is called once per frame
    void Update()
    {
        Image.uvRect = new Rect(Image.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, Image.uvRect.size);
    }
}
