using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerating : MonoBehaviour
{
    private static Object rocks;
    public int spawnInterval = 60;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        rocks = Resources.Load("Rock");
        time = -30;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.Find("GameManager").GetComponent<ManagerScript>().gameState != 1)
            return;
        
        time++;
        if(spawnInterval==0) {
            return;
        }else if(time==spawnInterval) {
            Object.Instantiate(rocks);
            time = 0;
        }
    }
}
