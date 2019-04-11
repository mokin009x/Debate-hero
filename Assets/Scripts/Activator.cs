using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject note;
    public KeyCode Key;
    bool active = false;
    public bool creatorMode;
    public GameObject n, gm;
    Color old;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>(); 
    }

    void Start()
    {
        gm=GameObject.Find("GameManager");
        old = sr.color;
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (creatorMode)
        {
            if (Input.GetKeyDown(Key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(Key)){
                StartCoroutine(Pressed());
            }

            if (Input.GetKeyDown(Key) && active)
            {
                Destroy(note);
                gm.GetComponent<GameManager>().AddStreak();
                AddScore();
                active = false;
            }
            else if (Input.GetKeyDown(Key) && !active)
            {
                gm.GetComponent<GameManager>().ResetStreak();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "WinNote")
        {
            //GetComponent<Result>().Compare();
        }
            if (col.gameObject.tag == "Note")
        {
            note = col.gameObject;
            active = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
        //gm.GetComponent<GameManager>().ResetStreak();
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager>().GetScore());
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
