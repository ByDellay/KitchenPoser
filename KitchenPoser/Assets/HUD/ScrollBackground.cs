using UnityEngine;
using UnityEngine.UI;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private RawImage Image; //RawImage porque permite mudar as cordenadas UV
    [SerializeField] private float _x, _y; //Velocidade Horizontal e Vertical

    // Update is called once per frame
    void Update()
    {
        // Nova posição = posição atual + velocidade × tempo
        Image.uvRect = new Rect(Image.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, Image.uvRect.size); 
    }
}
