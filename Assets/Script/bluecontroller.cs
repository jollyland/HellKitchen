using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluecontroller : MonoBehaviour
{
    public float speed = 5;
    public float jump_speed = 6;
    public int jumpCoolDown = 70;
    public GameObject weapon;
    public GameObject weapon_right;
    public GameObject life01;
    public GameObject life02;
    public GameObject life03;
    public GameObject cooldown;
    public float knifecd = 4f;

    public int life = 3;
    private Rigidbody2D rbody2D;
    private int jumpCount;
    private bool isJump;
    private float nextatk = 0.0f;
    private float boost_cd = 0.0f;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        rbody2D = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpCount = 0;
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GameObject.Find("gamemanager").GetComponent<gamemanager>().stop())
        {
            this.enabled = false;
        }
     */
        if (GameObject.Find("redstand").GetComponent<redController>().life == 0)
        {
            this.enabled = false;
        }
        if (Time.time > 60)
        {
            this.enabled = false; //stop update
        }
        //stop move
        float dirx = Input.GetAxisRaw("Horizontal_2");
        rbody2D.velocity = new Vector2(dirx * speed, rbody2D.velocity.y);



        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            isJump = true;
            jumpCount = jumpCoolDown;
            rbody2D.velocity += new Vector2(0, jump_speed);
        }

        if (jumpCount > 0)
        {
            jumpCount -= 1;
            if (jumpCount == 0)
            {
                isJump = false;
            }
        }
        if (Time.time > nextatk)
        {
            cooldown.SetActive(true);
        }
        if (Time.time > boost_cd)
        {
            speed = 5;
            jump_speed = 6;
        }
        if (life == 2)
        {
            life01.SetActive(false);
        }
        else if (life == 1)
        {
            life02.SetActive(false);
        }
        else if (life == 0)
        {
            life03.SetActive(false);
            GameObject.Find("GameManager").GetComponent<gamemanager>().Gameover();
            Destroy(gameObject);
        }
        if (dirx != 0)
        {
            anim.SetInteger("state", 1);
        }
        else if (Input.GetKey(KeyCode.Q) && Time.time >nextatk)
        {
            cd();
            nextatk = Time.time + knifecd;
            anim.SetInteger("state", 2);
            Instantiate(weapon, this.transform.position + new Vector3(-0.6f, 0, 0), weapon.transform.rotation);
        }
        else if (Input.GetKeyUp(KeyCode.E) && Time.time > nextatk)
        {
            cd();
            nextatk = Time.time + knifecd;
            anim.SetInteger("state", 2);
            Instantiate(weapon_right, this.transform.position + new Vector3(0.6f, 0, 0), weapon_right.transform.rotation);
        }
        else
        {
            anim.SetInteger("state", 0);
        }
        if (dirx * this.transform.localScale.x > 0)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "boost")
        {
            Destroy(col.gameObject);
            Boosting();
            boost_cd = Time.time + 5;
        }
        else if (col.tag == "Food")
        {
            eating(col);
            Destroy(col.gameObject);
        }
        else if (col.tag == "knife")
        {
            GetComponent<Animator>().Play("bluehurt");
            Destroy(col.gameObject);
            life--;

        }
        else if (col.tag == "edge")
        {
            life--;
            this.transform.position = new Vector3(0, 24, 0);
        }
    }
    void Boosting()
    {
        print("boosting");
        speed = 8;
        jump_speed = 9;
    }
    void cd()
    {
        cooldown.SetActive(false);
    }
    void eating(Collider2D food)
    {
        switch (food.name)
        {
            case "bacon(Clone)":
                GameObject.Find("GameManager").GetComponent<gamemanager>().blue_caculate("bacon");
                GameObject.Find("GameManager").GetComponent<gamemanager>().blueadd_score(60);
                break;
            case "cheese(Clone)":
                GameObject.Find("GameManager").GetComponent<gamemanager>().blue_caculate("cheese");
                GameObject.Find("GameManager").GetComponent<gamemanager>().blueadd_score(50);
                break;
            case "lettuce(Clone)":
                GameObject.Find("GameManager").GetComponent<gamemanager>().blue_caculate("lettuce");
                GameObject.Find("GameManager").GetComponent<gamemanager>().blueadd_score(20);
                break;
            case "egg(Clone)":
                GameObject.Find("GameManager").GetComponent<gamemanager>().blue_caculate("egg");
                GameObject.Find("GameManager").GetComponent<gamemanager>().blueadd_score(40);
                break;
            case "tomato(Clone)":
                GameObject.Find("GameManager").GetComponent<gamemanager>().blue_caculate("tomato");
                GameObject.Find("GameManager").GetComponent<gamemanager>().blueadd_score(30);
                print("tmt");
                break;
            case "meat(Clone)":
                GameObject.Find("GameManager").GetComponent<gamemanager>().blue_caculate("meat");
                GameObject.Find("GameManager").GetComponent<gamemanager>().blueadd_score(80);
                break;
            case "onion(Clone)":
                GameObject.Find("GameManager").GetComponent<gamemanager>().blue_caculate("onion");
                GameObject.Find("GameManager").GetComponent<gamemanager>().blueadd_score(30);
                break;

        }
    }
}

