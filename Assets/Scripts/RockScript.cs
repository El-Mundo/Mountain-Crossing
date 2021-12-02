using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        rBody.velocity = new Vector2(3.0f, -20.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float f = rBody.velocity.y; 
        rBody.velocity = new Vector2(3.0f, f);
    }
}
