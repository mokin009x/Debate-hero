using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{

    public GameObject blue;
    public GameObject red;

    // Start is called before the first frame update
    void Start()
    {
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
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("big pp"))
        {
            blue.SetActive(true);
        }
    }
}
