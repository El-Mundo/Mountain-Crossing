using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour1 : MonoBehaviour
{
    private Vector2 force;
    private Rigidbody2D rBody;
    private Transform tr;
    private bool landed;
    public int ROCK_SPEED = -1;
    private static Object emitter;
    // Start is called before the first frame update
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        force = new Vector2((int)(Random.value * (-2) + ROCK_SPEED), 1);
        rBody.velocity = force;
        tr = gameObject.GetComponent<Transform>();
        landed = false;
        float r = (float)(Random.value * 0.4 + 1.0);
        tr.localScale = new Vector3(r,r,1);
        if(emitter == null)
            emitter = Resources.Load("Rock Shard Emitter");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(tr.position.y < -7) {GameObject.Destroy(gameObject);}
        if(landed) rBody.velocity -= new Vector2(1f,0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*if(other.gameObject.layer==9) {
            landed = true;
        }else */if(other.gameObject.layer==11) {
            /*bool r = GameObject.Find("Spirit").GetComponent<SpiritScript>().aura;
            if(r)*/
                GameObject.Destroy(gameObject);
                Object.Instantiate(emitter, tr.position, Quaternion.identity);
        }
    }
    
    /*void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer==9) {
            landed = false;
        }
    }*/
}
