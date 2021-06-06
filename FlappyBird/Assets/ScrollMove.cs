using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMove : MonoBehaviour
{
    public float scrollSpeed;

    private float targetOffset;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        targetOffset += Time.deltaTime * scrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(targetOffset, 0);
        
    }
}
