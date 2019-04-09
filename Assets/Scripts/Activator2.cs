using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator2 : MonoBehaviour
{
    public GameObject note;
    public KeyCode Key;
    bool active = false;
    public bool creatorMode;
    public GameObject n;
    Color old;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        old = sr.color;
        PlayerPrefs.SetInt("big pp", 0);
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
            if (Input.GetKeyDown(Key))
            {
                StartCoroutine(Pressed());
            }

            if (Input.GetKeyDown(Key) && active)
            {
                Destroy(note);
                AddScore();
                active = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
        {
            note = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("big pp", PlayerPrefs.GetInt("big pp") + 100);
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
