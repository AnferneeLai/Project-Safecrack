using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongData : MonoBehaviour
{
    public SongData(AudioClip _clip, string _name, int _bpm, int _sig) {
        clip = _clip;
        songName = _name;
        bpm = _bpm;
        sig = _sig;
    }
    public AudioClip clip;
    public string songName;
    public int bpm;
    public int sig;
    public int highscore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(songName + "highscore")) {
            highscore = PlayerPrefs.GetInt(songName + "highscore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
