using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    int multiplier2 = 2;
    int streak2 = 0;

    public GameObject text2;

    public void AddStreak2()
    {
        streak2++;
        if (streak2 >= 24)
            multiplier2 = 4;
        else if (streak2 >= 16)
            multiplier2 = 3;
        else if (streak2 >= 8)
            multiplier2 = 2;
        else
            multiplier2 = 1;
        UpdateGUI2();
        Debug.Log(streak2);

        if (streak2 >= 5)
        {
            text2.SetActive(true);
        }
    }

    public void ResetStreak2()
    {
        streak2 = 0;
        multiplier2 = 1;
        UpdateGUI2();
    }

    void UpdateGUI2()
    {
        PlayerPrefs.SetInt("Streak2", streak2);
        PlayerPrefs.SetInt("Mult2", multiplier2);
    }

    public int GetScore2()
    {
        return 100 * multiplier2;
    }
}
