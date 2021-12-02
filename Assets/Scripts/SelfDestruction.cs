using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        GameObject.Find("Boom").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time ++;
        if(time == 160) {
            GameObject.Destroy(gameObject);
        }
    }
}
