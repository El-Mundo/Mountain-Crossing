using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTA222test : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigidbody;
    private Transform transform;
    public float MOVE_SPEED = 0.2f;
    public float SHIFT_SPEED = 0.3f;
    public float MAX_SPEED = 8f;
    public float JUMP_FORCE = -32f;
    private float hSpeed,vSpeed;
    private bool goLeft,goRight,jumping;
    private bool jumpable;
    public bool isDead;
    private bool running,runAnim;
    private bool collideWithWall;
    public bool 外挂模式 = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        this.hSpeed = 0;
        this.vSpeed = 0;
        goLeft = false;
        goRight = false;
        transform = gameObject.GetComponent<Transform>();
        jumpable = false;
        isDead = false;
        runAnim = running = false;
        collideWithWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        getControl();
        //update_animator();
    }

    void getControl()
    {
        goLeft = false;
        goRight = false;
        if(!isDead||外挂模式) {
            if(Input.GetAxisRaw("Horizontal") < -0.2f) goLeft = true;
            else if(Input.GetAxisRaw("Horizontal") > 0.2f) goRight = true;
            else {
                goLeft = false;
                goRight = false;
            }

            if((Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.Joystick1Button1))&&jumpable) jumping = true;
        }

        vSpeed = rigidbody.velocity.y;
        if(jumping) {
            vSpeed -= JUMP_FORCE;
            jumping = false;
            jumpable = false;
        }
        if(collideWithWall) hSpeed = 0;
        rigidbody.velocity = new Vector2(hSpeed, vSpeed);
    }

    void FixedUpdate()
    {
        float vlc = Input.GetAxisRaw("Horizontal");
        if(goLeft) {
            if(hSpeed>-MAX_SPEED)
                hSpeed += MOVE_SPEED * vlc;
        }else if(goRight){
            if(hSpeed<MAX_SPEED)
                hSpeed += MOVE_SPEED * vlc;
        }else{
            if(hSpeed>SHIFT_SPEED) {
                hSpeed -= SHIFT_SPEED;
            }else if(hSpeed<-SHIFT_SPEED) {
                hSpeed += SHIFT_SPEED;
            }else {
                hSpeed = 0;
            }
        }
    }

    void update_animator()
    {
        float spd = Mathf.Abs(hSpeed);
        anim.SetFloat("hSpeed",spd);
        if(spd>0.1f && running == false) running = true;
        if(spd<=0.1f) running = false;
        if(running&&!runAnim) {
            anim.Play("idle-run");
            runAnim = true;
        }
        if(!running) {
            runAnim = false;
        }
        anim.SetBool("isDead",isDead);
        /*if(hSpeed<0) transform.localScale = new Vector3(-0.8f,0.8f,1f);
        else if(hSpeed>0) transform.localScale = new Vector3(0.8f,0.8f,1f);*/
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        int layer = obj.gameObject.layer;
        switch (layer)
        {
            case 0:
                rigidbody.constraints = RigidbodyConstraints2D.None;
                if(!isDead) {
                    rigidbody.velocity = Vector2.zero;
                    rigidbody.AddForce(new Vector2(2000,-1000));
                    isDead = true;
                }
                break;
            case 9:
                jumpable = true;
                break;
            case 10:
                collideWithWall = true;
                break;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.gameObject.layer==10) {
            collideWithWall = false;
            hSpeed = 0;
        }
        else if(obj.gameObject.layer==9)
            jumpable = false;
    }
}
