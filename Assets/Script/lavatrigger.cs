using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavatrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            //重生function
            print("die");
        }
        else if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
