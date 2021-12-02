using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritScript : MonoBehaviour
{
    private Rigidbody2D rBody;
    public float velocity = 3.0f;
    public int auraRange = 0;
    public bool aura = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(0.97f, 2.47f, -1.2f);
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int s = GameObject.Find("GameManager").GetComponent<ManagerScript>().gameState;
        if(s==0 || s==4)
            return;
        
        rBody.velocity = new Vector2(Input.GetAxis("Horizontal") * velocity, Input.GetAxis("Vertical") * velocity);
        if(Input.GetKeyDown("space") && auraRange <= 0)
            auraRange = 256;
        
        aura = (auraRange > 0);
    }

    void FixedUpdate()
    {
        int s = GameObject.Find("GameManager").GetComponent<ManagerScript>().gameState;
        if(s==0 || s==4)
            return;
        
        if(auraRange > 0) {
            auraRange -= 12;
        }
        aura = auraRange > 0;
    }
}
