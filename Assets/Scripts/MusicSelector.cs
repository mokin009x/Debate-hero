﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MusicSelector : MonoBehaviour
{

    public GameObject startScreen;
    public GameObject songSelectScreen;
    public GameObject currentSongNotes;
    public AudioClip selectedSong;
    public bool gameStarted;
    private AudioSource source;
    Result result;
    
    // Start is called before the first frame update
    private void Awake()
    {
        gameStarted = false;
        selectedSong = null;
    }

    void Start()
    {
        result = Result.instance;
        startScreen = GameObject.Find("Canvas").transform.GetChild(8).gameObject;
        songSelectScreen = GameObject.Find("Canvas").transform.GetChild(9).gameObject;
        songSelectScreen.SetActive(false);
        source = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        songSelectScreen.SetActive(true);
    }

    public void SelectSong(AudioClip _song)//button
    {
        selectedSong = _song;
        songSelectScreen.SetActive(false);
    }

    public void ActivateSong(GameObject _notes)// button
    {
        _notes.SetActive(true);
        StartCoroutine(SongDelay(_notes));
        StartCoroutine(EndSong(selectedSong));
    }

   

    IEnumerator SongDelay(GameObject _notes)
    {
        _notes.SetActive(true);
        yield return new WaitForSeconds(5f);
        source.PlayOneShot(selectedSong);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted != true)
        {
            if (Input.anyKey)
            {
                StartGame();
                gameStarted = true;
            }
        }
    }

    IEnumerator EndSong(AudioClip clippy)
    {
        yield return new WaitForSeconds(clippy.length + 5);
        result.Compare();
    }
}
