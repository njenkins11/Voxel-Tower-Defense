using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private List<AudioSource> musicList;
    [SerializeField] private float breakBetweenSongs = 30;
    [SerializeField] private List<AudioSource> ambienceList;
    [SerializeField] private float breakBetweenAmbience = 2;
    [SerializeField] private bool playMusic;
    private float currentbreak;
    private float currentAmbienceBreak;
    private int index;
    private int ambienceIndex;

    void Start()
    {
        index = 0;
        ambienceIndex = 0;
        currentbreak = breakBetweenSongs;
        playMusic = true;
    }

    void Update()
    {
        if(playMusic)
        {
            if(!checkIsPlaying(musicList[index]))
                currentbreak += Time.deltaTime;
            if(currentbreak >= breakBetweenSongs)
            {
                index++;
                index %= musicList.Count;
                musicList[index].Play();
                currentbreak = 0;
            }
        
            if(!checkIsPlaying(ambienceList[ambienceIndex]))
                currentAmbienceBreak += Time.deltaTime;
            if(currentAmbienceBreak >= breakBetweenAmbience)
            {
                ambienceIndex++;
                ambienceIndex %= ambienceList.Count;
                ambienceList[ambienceIndex].Play();
                currentAmbienceBreak = 0;
            }
        }
        else
        {
            musicList[index].Stop();
            ambienceList[ambienceIndex].Stop();
            currentbreak = breakBetweenSongs;
            currentAmbienceBreak = breakBetweenAmbience;
        }
    }

    private bool checkIsPlaying(AudioSource song)
    {
        return song.isPlaying;
    }

    public void SetPlayMusic(bool playMusic){this.playMusic = playMusic;}
    public bool GetPlayMusic(){return playMusic;}

    
}
