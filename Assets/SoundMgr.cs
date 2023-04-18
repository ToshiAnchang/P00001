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
            //AudioSource ������Ʈ �����ϱ�
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    //���� �����ϱ�
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

    //���� ������ ��������
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

    //������� ���� AudioSource ������Ʈ ��������
    AudioSource GetAudioSource()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].isPlaying)
                continue;
            return audioSources[i];
        }
        return audioSources[0]; //��� AudioSource ������Ʈ ������̸� [0]��° AudioSource ��ȯ
    }
}

public enum SFXType //���� ����
{
    monster_die, gold_get
}


[System.Serializable]
public class SoundData //���� ���� ������
{
    public SFXType sfxType;
    public AudioClip audioClip;
    public float volume;
    public bool loop;
    public bool playOnAwake;
}