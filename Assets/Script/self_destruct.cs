using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_destruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("self_d", 4.0f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
         //   Destroy(gameObject);
        }
    }
*/
    void self_d()
    {
        Destroy(gameObject);
    }
}
