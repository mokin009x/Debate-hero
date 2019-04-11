using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crowd : MonoBehaviour
{
    float c;
    GameObject crowd;
    public Transform defaultPos;
    public Vector3 blueWinning;
    public Vector3 redWinning;

    // Start is called before the first frame update
    void Start()
    {
        crowd = transform.Find("crowd").gameObject;
        defaultPos = crowd.transform;
        redWinning = new Vector3(1, crowd.transform.position.y, crowd.transform.position.z);
        blueWinning = new Vector3(-1, crowd.transform.position.y, crowd.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
