using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_items : MonoBehaviour
{
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeitem", 8, Random.Range(7.0f, 12.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 60)
        {
            CancelInvoke("makeitem");
        }
        if (GameObject.Find("redstand").GetComponent<redController>().life == 0 ||
            GameObject.Find("bluestand").GetComponent<bluecontroller>().life == 0) {

            CancelInvoke("makeitem");
        
        }
    }
    void makeitem()
    {
        Instantiate(item, new Vector3(Random.Range(-8f, 8f), Random.Range(-2f, 3.5f), 0), item.transform.rotation);
    }
}
