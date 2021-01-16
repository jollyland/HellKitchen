using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeatk : MonoBehaviour
{
    public float knife_speed = -6; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.parent = null;
        gameObject.transform.position += new Vector3(knife_speed * Time.deltaTime, 0, 0);
        /*        if (GameObject.Find("redstand").GetComponent<redController>().dirx >= 0)
        {
            gameObject.transform.position += new Vector3(knife_speed * Time.deltaTime, 0, 0);
        }
        else
        { 
            gameObject.transform.position += new Vector3(-knife_speed * Time.deltaTime, 0, 0);
        }
  */  }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "edge")
        {
           Destroy(gameObject);
        }
    }
}
