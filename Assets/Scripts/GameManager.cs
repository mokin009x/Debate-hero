using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int multiplier = 2;
    int streak = 0;

    int multiplier2 = 2;
    int streak2 = 0;

    public GameObject text;
    public GameObject text2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Crowd", 25);
        text = GameObject.Find("pp");
        text.SetActive(false);
        text2 = GameObject.Find("pp2");
        text2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        GetComponent<GameManager>().ResetStreak();

    }

    public void AddStreak()
    {
        PlayerPrefs.SetInt("Crowd", PlayerPrefs.GetInt("Crowd") + 1);
        streak++;
        if (streak >= 24)
            multiplier = 4;
        else if (streak >= 16)
            multiplier = 3;
        else if (streak >= 8)
            multiplier = 2;
        else
            multiplier = 1;
        UpdateGUI();
        Debug.Log(streak);

        if(streak>= 5)
        {
            text.SetActive(true);
        }
        if (streak >= 8)
        {
            text2.SetActive(true);
            text.SetActive(false);
        }
    }

    public void ResetStreak()
    {
        PlayerPrefs.SetInt("Crowd", PlayerPrefs.GetInt("Crowd") - 1);
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Mult", multiplier);
    }

    public int GetScore()
    {
        return 100 * multiplier;
    }
}
