using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A)) {
            GetComponent<Rigidbody>().velocity = new Vector2(-1, 0);
        }else if(Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody>().velocity = new Vector2(1, 0);
        }
    }
}
