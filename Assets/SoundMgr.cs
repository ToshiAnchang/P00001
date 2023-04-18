using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    private static SoundMgr instance;
    public static SoundMgr Instance
    {
        get { return instance; }
    }

    [SerializeField] SoundData[] soundDatas;
    [SerializeField] AudioSource[] audioSources;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        audioSources = new AudioSource[10];
        for (int i = 0; i < 10; i++)
        {
            //AudioSource 컴포넌트 생성하기
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    //사운드 실행하기
    public void PlaySound(SFXType _sType)
    {
        SoundData _sData = GetSoundData(_sType);
        if (_sData == null)
            return;

        AudioSource _aSource = GetAudioSource();

        _aSource.clip = _sData.audioClip;
        _aSource.volume = _sData.volume;
        _aSource.loop = _sData.loop;
        _aSource.playOnAwake = _sData.playOnAwake;

        _aSource.Play();
    }

    //사운드 데이터 가져오기
    SoundData GetSoundData(SFXType _sType)
    {
        for (int i = 0; i < soundDatas.Length; i++)
        {
            if (soundDatas[i].sfxType.Equals(_sType))
            {
                return soundDatas[i];
            }
        }
        return null;
    }

    //사용하지 않은 AudioSource 컴포넌트 가져오기
    AudioSource GetAudioSource()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].isPlaying)
                continue;
            return audioSources[i];
        }
        return audioSources[0]; //모든 AudioSource 컴포넌트 사용중이면 [0]번째 AudioSource 반환
    }
}

public enum SFXType //사운드 종류
{
    monster_die, gold_get
}


[System.Serializable]
public class SoundData //사운드 관련 데이터
{
    public SFXType sfxType;
    public AudioClip audioClip;
    public float volume;
    public bool loop;
    public bool playOnAwake;
}