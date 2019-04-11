using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{

    public GameObject blue;
    public GameObject red;

    private PPText player1;
    private PPText2 player2;
    public int playerBlueScore;
    public int playerRedScore;
    public static Result instance;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player1 = PPText.instance;
        player2 = PPText2.instance;
        blue = GameObject.Find("Blue Wins");
        blue.SetActive(false);
        red = GameObject.Find("Red Wins");
        red.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Compare()
    {
        playerBlueScore = player1.FinalScore();
        playerRedScore = player2.FinalScore();
        if (playerBlueScore > playerRedScore)
        {
            blue.SetActive(true);
        }
        else if (playerRedScore > playerBlueScore)
        {
            red.SetActive(true);
        }
    }
}
