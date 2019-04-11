using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PPText2 : MonoBehaviour
{
    public string name;
    public static PPText2 instance;

    private void Awake()
    {
        instance = this;
    }

    public int FinalScore()
    {
        var scorestring = GetComponent<Text>().text = PlayerPrefs.GetInt(name).ToString();
        int test = int.Parse(scorestring);
        return test;
    }

    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(name) + "";
    }
}
