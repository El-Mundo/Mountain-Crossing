using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corriel : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rBody;
    public float chSpeed = 2;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inp = Input.GetAxisRaw("Horizontal");
        if(inp!=0) {
            anim.Play("Corriel-Walk");
            rBody.velocity += new Vector2(chSpeed*inp*Time.deltaTime,0);
            Debug.Log(rBody.velocity.x);
        }else {
            rBody.velocity = new Vector2(0,0);
        }
    }
}
