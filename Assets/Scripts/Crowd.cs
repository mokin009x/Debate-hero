using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd : MonoBehaviour
{
    float c;
    GameObject crowd;

    // Start is called before the first frame update
    void Start()
    {
        crowd = transform.Find("crowd").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        c = PlayerPrefs.GetInt("Crowd");

        crowd.transform.localPosition = new Vector3(0, (c - 25) / 25, 0);
    }
}
