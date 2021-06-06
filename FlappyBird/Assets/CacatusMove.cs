using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacatusMove : MonoBehaviour
{
    public float cactusSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(6f,Random.Range(-1,1.5f),0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * cactusSpeed * Time.deltaTime);
        if (transform.position.x < -6f) Destroy(this.gameObject);
    }
}
