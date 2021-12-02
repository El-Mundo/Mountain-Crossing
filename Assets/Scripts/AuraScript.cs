using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraScript : MonoBehaviour
{
    float xx, yy;
    private Transform tr2;
    private Transform tr1;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        tr1 = GameObject.Find("Spirit").GetComponent<Transform>();
        tr2 = gameObject.GetComponent<Transform>();
        xx = tr2.position.x - tr1.position.x;
        yy = tr2.position.y - tr1.position.y;
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        tr2.position = new Vector2(tr1.position.x + xx, tr1.position.y + yy);
        //spr.color = new Color(256,256,256,(float)GameObject.Find("Spirit").GetComponent<SpiritScript>().auraRange / 256);
    }
}
