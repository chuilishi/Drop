using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


//https://blog.csdn.net/natrick/article/details/113833700
//Singleton 单例类 便于在其他脚本直接引用该处的函数
public class SoundManager : Singleton<SoundManager>
{
    //public static SoundManager instance;

    //public float globalVolume;
    //[Header("敌人分裂")]
    //public AudioSource dropDivisionAudioSource;
    //[Header("入场音乐")]
    //public AudioSource gameStartAudioSource;
    //[Header("敌人死亡")]
    //public AudioSource enemyDeadAudioSource;
    //[Header("敌人变成Rock")]
    //public AudioSource enemy2RockAudioSource;

    //private List<AudioSource> _allAudioSources;

    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private AudioSource sfxSource;

    [SerializeField]
    private Slider sfxSlider;

    [SerializeField]
    private Slider musicSlider;

    //一个把文件名和音效文件对应起来的字典
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        //从Resources文件夹中的Audio文件夹中获取全部音效文件
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio") as AudioClip[];

        foreach (AudioClip clip in clips)
        {
            audioClips.Add(clip.name, clip);
        }
        //_allAudioSources = new List<AudioSource>();
        //DontDestroyOnLoad(gameObject);
        //instance = this;
        //_allAudioSources.Add(dropDivisionAudioSource);
        //_allAudioSources.Add(gameStartAudioSource);
        //_allAudioSources.Add(enemyDeadAudioSource);
        //_allAudioSources.Add(enemy2RockAudioSource);
        //foreach (var audioSource in _allAudioSources)
        //{
        //    audioSource.volume = globalVolume;
        //}
    }

    private void Start()
    {
        //PlaySFX("入场");

        LoadVolume();

        //给两个Slider添加一个监听：UpdateVolume();
        musicSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });

    }

    //public void DropDivision()
    //{
    //    dropDivisionAudioSource.Play();
    //}
    //public void GameStart()
    //{
    //    gameStartAudioSource.Play();
    //}
    //public void EnemyDead()
    //{
    //    enemyDeadAudioSource.Play();
    //}
    //public void Enemy2Rock()
    //{
    //    enemy2RockAudioSource.Play();
    //}
    //public void ChangeVolume(float volume)
    //{
    //    globalVolume = volume;
    //    foreach (var a in _allAudioSources)
    //    {
    //        a.volume = globalVolume;
    //    }
    //}

    public void PlaySFX(string name)
    {
        sfxSource.PlayOneShot(audioClips[name]);
    }

    public void UpdateVolume()
    {
        musicSource.volume = musicSlider.value;

        sfxSource.volume = sfxSlider.value;

        //PlayerPrefs 用于记录玩家的数据 这里记录的是音量大小
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);

    }

    public void LoadVolume()
    {
        sfxSource.volume = PlayerPrefs.GetFloat("SFX", 0.5f);

        musicSource.volume = PlayerPrefs.GetFloat("Music", 0.5f);

        musicSlider.value = musicSource.volume;

        sfxSlider.value = sfxSource.volume;
    }
}
