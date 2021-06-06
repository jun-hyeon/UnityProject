using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(3.0f, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -6.0f) Destroy(this.gameObject);
    }
}
