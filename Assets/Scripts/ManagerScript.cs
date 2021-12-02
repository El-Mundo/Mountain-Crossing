using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ManagerScript : MonoBehaviour
{
    public int gameState = 0;
    private static SpriteRenderer spr;
    private float alpha = 1.0f;
    private static AudioSource bgm;
    private float volume;
    private static VideoPlayer guide;

    // Start is called before the first frame update
    void Start()
    {
        spr = GameObject.Find("Black Screen").GetComponent<SpriteRenderer>();
        bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
        guide = GameObject.Find("guide").GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && (gameState == 0 || gameState == 3)) {
            gameState = 4;
            volume = 1.0f;
            bgm.volume = volume;
            bgm.Play();
            guide.Play();
        }

        if(gameState == 2 && Input.GetKeyDown("space")) {
            gameState = 3;
        }
    }

    void FixedUpdate()
    {
        if(gameState == 4) {
            if(guide.time > 36.1f || Input.GetKeyDown("space")) {
                guide.Stop();
                gameState = 1;
            }
        }

        if(gameState == 1 && alpha > 0.0f) {
            alpha -= 0.05f;
            spr.color = new Color(0, 0, 0, alpha);
        }

        if(gameState == 3) {
            if(alpha < 1.0f) {
                alpha += 0.02f;
                spr.color = new Color(0, 0, 0, alpha);
                volume -= 0.05f;
                bgm.volume = volume;
            }else {
                SceneManager.LoadScene("0");
            }
        }
    }
}
