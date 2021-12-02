using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerating2 : MonoBehaviour
{
    private static Object rocks;
    public int spawnInterval = 60;
    private int time;
    private Transform playerTr;
    // Start is called before the first frame update
    void Start()
    {
        rocks = Resources.Load("Rock1");
        time = -450;
        playerTr = GameObject.Find("Indian").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.Find("GameManager").GetComponent<ManagerScript>().gameState != 1)
            return;

        time++;
        if(spawnInterval == 0) {
            return;
        }else if(time==spawnInterval) {
            Object.Instantiate(rocks);
            time = 0;
        }
    }
}
