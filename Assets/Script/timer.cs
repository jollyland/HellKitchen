using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI; //使用Unity UI程式庫。

public class timer : MonoBehaviour
{

    int time_int = 60;

    public Text time_UI;

    void Start()
    {

        InvokeRepeating("counter", 1, 1);
        if (GameObject.Find("redstand").GetComponent<redController>().life == 0 ||
            GameObject.Find("bluestand").GetComponent<bluecontroller>().life == 0)
        {

            CancelInvoke("counter");

        }
    }

    void counter()
    {

        time_int -= 1;

        time_UI.text = time_int + "";

        if (time_int == 0)
        {

            time_UI.text = "TIME\nUP";

            CancelInvoke("counter");

        }

    }

}