using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class gamemanager : MonoBehaviour
{
    public Text score_1p;
    public Text score_2p;

    public Text text_red_bacon;
    public Text text_red_cheese;
    public Text text_red_meat;
    public Text text_red_egg;
    public Text text_red_lettuce;
    public Text text_red_tomato;
    public Text text_red_onion;

    public Text text_blue_bacon;
    public Text text_blue_cheese;
    public Text text_blue_meat;
    public Text text_blue_egg;
    public Text text_blue_lettuce;
    public Text text_blue_tomato;
    public Text text_blue_onion;

    public GameObject[] score;
    public GameObject top;
    public GameObject[] board;
    public GameObject[] situation;

    float blue_score;
    float red_score;

    bool gamestop ;

    int blue_meat;
    int blue_cheese;
    int blue_bacon;
    int blue_egg;
    int blue_tomato;
    int blue_lettuce;
    int blue_onion;

    int red_meat;
    int red_cheese;
    int red_bacon;
    int red_egg;
    int red_tomato;
    int red_lettuce;
    int red_onion;


    // Start is called before the first frame update
    void Start()
    {
        gamestop = false;
        blue_score = 0;
        red_score = 0;
        blue_meat = 0;
        blue_cheese = 0;
        blue_bacon = 0;
        blue_egg = 0;
        blue_tomato = 0;
        blue_lettuce = 0;
        blue_onion = 0;

        red_meat = 0;
        red_cheese = 0;
        red_bacon = 0;
        red_egg = 0;
        red_tomato = 0;
        red_lettuce = 0;
        red_onion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 60)
        {
            Gameover();
            this.enabled = false; //stop update
        }
    }

    public void redadd_score(int n)
    {
        red_score += n;
        score_1p.text = "Score\n" + red_score;
    }

    public void blueadd_score(int n)
    {
        blue_score += n;
        score_2p.text = "Score\n" + blue_score;
    }


    public void red_caculate(string ingredient)
    {
 
        switch (ingredient)
        {
            case "bacon":
                Instantiate(score[0], new Vector3(8.5f, 2, 1), score[0].transform.rotation);
                red_bacon++;
                break;
            case "meat":
                Instantiate(score[1], new Vector3(8.5f, 2, 1), score[1].transform.rotation);
                red_meat++;
                break;
            case "cheese":
                Instantiate(score[2], new Vector3(8.5f, 2, 1), score[2].transform.rotation);
                red_cheese++;
                break;
            case "egg":
                Instantiate(score[3], new Vector3(8.5f, 2, 1), score[3].transform.rotation);
                red_egg++;
                break;
            case "lettuce":
                Instantiate(score[4], new Vector3(8.5f, 2, 1), score[4].transform.rotation);
                red_lettuce++;
                break;
            case "tomato":
                Instantiate(score[5], new Vector3(8.5f, 2, 1), score[5].transform.rotation);
                red_tomato++;
                break;
            case "onion":
                Instantiate(score[6], new Vector3(8.5f, 2, 1), score[6].transform.rotation);
                red_onion++;
                break;

        }
 
    }
    public void blue_caculate(string ingredient)
    {

        switch (ingredient)
        {
            case "bacon":
                Instantiate(score[0], new Vector3(-8.5f, 2, 1), score[0].transform.rotation);
                blue_bacon++;
                break;
            case "meat":
                Instantiate(score[1], new Vector3(-8.5f, 2, 1), score[1].transform.rotation);
                blue_meat++;
                break;
            case "cheese":
                Instantiate(score[2], new Vector3(-8.5f, 2, 1), score[2].transform.rotation);
                blue_cheese++;
                break;
            case "egg":
                Instantiate(score[3], new Vector3(-8.5f, 2, 1), score[3].transform.rotation);
                blue_egg++;
                break;
            case "lettuce":
                Instantiate(score[4], new Vector3(-8.5f, 2, 1), score[4].transform.rotation);
                blue_lettuce++;
                break;
            case "tomato":
                Instantiate(score[5], new Vector3(-8.5f, 2, 1), score[5].transform.rotation);
                blue_tomato++;
                break;
            case "onion":
                Instantiate(score[6], new Vector3(-8.5f, 2, 1), score[6].transform.rotation);
                blue_onion++;
                break;

        }

    }
    public void Gameover()
    {
        stop();
        Instantiate(top, new Vector3(8.5f, 2, 1), top.transform.rotation);
        Instantiate(top, new Vector3(-8.5f, 2, 1), top.transform.rotation);
        if (GameObject.Find("redstand").GetComponent<redController>().life == 0)
        {
            blue_win();
            
            this.enabled = false; //stop update
        }
        else if (GameObject.Find("bluestand").GetComponent<bluecontroller>().life == 0)
        {
            red_win();
            this.enabled = false; //stop update
        }
        else
        {
            Instantiate(board[0],new Vector3(0,0,0), board[0].transform.rotation);
            Instantiate(board[1],new Vector3(-4,0,0), board[1].transform.rotation);

            text_red_bacon.text = red_bacon.ToString();
            text_red_cheese.text = red_cheese.ToString();
            text_red_meat.text = red_meat.ToString();
            text_red_egg.text = red_egg.ToString();
            text_red_lettuce.text = red_lettuce.ToString();
            text_red_tomato.text = red_tomato.ToString();
            text_red_onion.text = red_onion.ToString();

            text_blue_bacon.text = blue_bacon.ToString();
            text_blue_cheese.text = blue_cheese.ToString();
            text_blue_meat.text = blue_meat.ToString();
            text_blue_egg.text = blue_egg.ToString();
            text_blue_lettuce.text = blue_lettuce.ToString();
            text_blue_tomato.text = blue_tomato.ToString();
            text_blue_onion.text = blue_onion.ToString();

      
            /*if ( (red_lettuce+red_onion+red_tomato)*2 < red_meat + red_cheese + red_bacon)
            {
                red_score *= 0.6f;
            }
            else if ( (blue_lettuce + blue_onion + blue_tomato) *2 < blue_meat + blue_cheese + blue_bacon)
            {
                blue_score *= 0.6f;
            }
            */

            if (blue_score > red_score)
            {
                blue_win();
                this.enabled = false; //stop update
            }
            else if( red_score > blue_score)
            {
                red_win();
                this.enabled = false; //stop update

            }
            else
            {
                tie();
                this.enabled = false; //stop update
            }

        }
    }

    void red_win()
    {
        if (GameObject.Find("bluestand").GetComponent<bluecontroller>().life == 0)
        {
            Instantiate(situation[0], new Vector3(0, 0, 0), situation[0].transform.rotation);
        }
        else
        Instantiate(situation[0], new Vector3(4.5f, 0, 0), situation[0].transform.rotation);
    }
    void blue_win()
    {
        if (GameObject.Find("redstand").GetComponent<redController>().life == 0)
        {
            Instantiate(situation[1], new Vector3(0, 0, 0), situation[1].transform.rotation);
        }
        else
            Instantiate(situation[1], new Vector3(4.5f, 0, 0), situation[1].transform.rotation);
    }
    void tie()
    {
        Instantiate(situation[2], new Vector3(4, 0, 0), situation[2].transform.rotation);
    }
    public bool stop() {
        gamestop = true;
        return gamestop;
    }
}
