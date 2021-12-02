using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anm;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        anm = gameObject.GetComponent<Animator>();
        tr = gameObject.GetComponent<Transform>();
        tr.position = new Vector3(7.153f, 1.295f, 0.0f);
        anm.Play("Indian Walk");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("GameManager").GetComponent<ManagerScript>().gameState != 1)
            return;
        
        rBody.velocity = new Vector2(-0.7f, 0.0f);

        if(tr.position.x < -9.5f) 
            gameOver();
    }

    void FixedUpdate()
    {
        if(GameObject.Find("GameManager").GetComponent<ManagerScript>().gameState != 1)
            return;
        
        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        gameOver();
    }

    void gameOver()
    {
        if(GameObject.Find("GameManager").GetComponent<ManagerScript>().gameState != 2)
            anm.Play("Indian Die");
        GameObject.Find("GameManager").GetComponent<ManagerScript>().gameState = 2;
    }

}
