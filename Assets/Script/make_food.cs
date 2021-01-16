using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_food : MonoBehaviour
{
    public GameObject[] food;
    //public Transform[] Point;
    public float InsTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makefood", InsTime, InsTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 60)
        {
            CancelInvoke("makefood");
        }
        if (GameObject.Find("redstand").GetComponent<redController>().life == 0 ||
            GameObject.Find("bluestand").GetComponent<bluecontroller>().life == 0)
        {

            CancelInvoke("makefood");

        }
    }
    void makefood()
    {
        int Random_Food = Random.Range(0, food.Length);

        Instantiate(food[Random_Food], new Vector3(Random.Range(-7.5f, 7.5f), 7, 0), food[Random_Food].transform.rotation);
    }
}
