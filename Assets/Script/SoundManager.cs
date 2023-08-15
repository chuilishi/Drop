using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public float globalVolume;
    [Header("敌人分裂")]
    public AudioSource dropDivisionAudioSource;
    [Header("入场音乐")]
    public AudioSource gameStartAudioSource;
    [Header("敌人死亡")]
    public AudioSource enemyDeadAudioSource;
    [Header("敌人变成Rock")]
    public AudioSource enemy2RockAudioSource;

    private List<AudioSource> _allAudioSources;
    
    private void Awake()
    {
        _allAudioSources = new List<AudioSource>();
        DontDestroyOnLoad(gameObject);
        instance = this;
        _allAudioSources.Add(dropDivisionAudioSource);
        _allAudioSources.Add(gameStartAudioSource);
        _allAudioSources.Add(enemyDeadAudioSource);
        _allAudioSources.Add(enemy2RockAudioSource);
        foreach (var audioSource in _allAudioSources)
        {
            audioSource.volume = globalVolume;
        }
    }

    private void Start()
    {
        gameStartAudioSource.Play();
    }

    public void DropDivision()
    {
        dropDivisionAudioSource.Play();
    }
    public void GameStart()
    {
        gameStartAudioSource.Play();
    }
    public void EnemyDead()
    {
        enemyDeadAudioSource.Play();
    }
    public void Enemy2Rock()
    {
        enemy2RockAudioSource.Play();
    }
    public void ChangeVolume(float volume)
    {
        globalVolume = volume;
        foreach (var a in _allAudioSources)
        {
            a.volume = globalVolume;
        }
    }
}
