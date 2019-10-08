using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    //score for all the enemies the player hits
    private Text text;

    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.Tackled == false)
        {
            text.text = score.ToString();

        }
        else
        {
            text.text = ("Tackled!");
        }
    }
}
