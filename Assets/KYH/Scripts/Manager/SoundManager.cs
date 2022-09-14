using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /*
    private static SoundManager instacne;
    public static SoundManager Instance { get { return instacne; } }
    */

    [SerializeField] AudioSource bgmAduioSource;
    [SerializeField] AudioSource sfxAudiSource;

   // private Dictionary<string, AudioClip> bgmClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();

    private readonly string BGM_CLIP_DEFAULT_PATH = "BGM/";
    private readonly string SFX_CLIP_DEFAULT_PATH = "SFX/";

    /*
    private void Awake()
    {
        if(instacne == null)
        {
            instacne = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    */

    /// <summary>
    /// BGM �Ǵ� SFX(ȿ����) Ŭ���� ã�ƿ�
    /// </summary>
    /// <param name="path">������ ����� Ŭ�� �̸�</param>
    /// <param name="soundType">����� Ÿ�� (BGM �Ǵ� SFX)</param>
    /// <returns></returns>
    private AudioClip SearchingAudioClip(string path, Define.SoundType soundType)
    {
        AudioClip clip;
        if (soundType == Define.SoundType.BGM) // Ŭ�� Ÿ���� BGM �̸�
        {
            clip =  Mangers.Resource.GetAudioClip(BGM_CLIP_DEFAULT_PATH + path); // BGM�� ���� �̿���� �ʰ� ������ ���� �������� �ʰ� �����°� �̵��ΰ� ����
        }
        else // Ŭ�� Ÿ���� ȿ�����̸�
        {
            if(!sfxClips.TryGetValue(path, out clip)) // ȿ����(SFX)�� ���� ȣ��Ǳ� ������ ���� �����ϰ� �ҷ����� ���·� ����
            {
                clip = Mangers.Resource.GetAudioClip(SFX_CLIP_DEFAULT_PATH + path); 
                sfxClips.Add(path, clip);
            }
        }

        return clip;
    }

    /// <summary>
    /// BGM ����� ���
    /// </summary>
    /// <param name="bgmClipName">����� BGM Ŭ�� �̸�</param>
    /// <param name="bgmAudio">BGM�� ����� ����� (�⺻ �� Null)</param>
    /// <param name="vol">���� (�⺻ �� 0.2)</param>
    /// <param name="isloop">BGM �ݺ� (�⺻ �� True)</param>
    public void PlayBGMAudio(string bgmClipName, AudioSource bgmAudio = null, float vol = 0.2f, bool isloop = true)
    {
        if (bgmAudio == null) bgmAudio = bgmAduioSource;

        bgmAudio.clip = SearchingAudioClip(bgmClipName, Define.SoundType.BGM);

        if(bgmAudio.clip == null)
        {
            Debug.Log($"{bgmClipName} �� ������� ���߽��ϴ�.");
            return;
        }

        bgmAudio.volume = vol;
        bgmAudio.loop = isloop;

        bgmAudio.Play();
    }

    /// <summary>
    /// SFX ����� ���
    /// </summary>
    /// <param name="sfxClipName">����� SFX Ŭ�� �̸�</param>
    /// <param name="sfxAudio">SFX�� ����� ����� (�⺻ �� Null)</param>
    /// <param name="vol">���� (�⺻ �� 1.9)</param>
    /// <param name="isloop">BGM �ݺ� (�⺻ �� false)</param>
    public void PlaySFXAudio(string sfxClipName, AudioSource sfxAudio = null, float vol = 1.0f, bool isloop = false)
    {
        if (sfxAudio == null) sfxAudio = sfxAudiSource;

        sfxAudio.clip = SearchingAudioClip(sfxClipName, Define.SoundType.SFX);

        if (sfxAudio.clip == null)
        {
            Debug.Log($"{sfxClipName} �� ������� ���߽��ϴ�.");
            return;
        }

        sfxAudio.volume = vol;
        sfxAudio.loop = isloop;

        sfxAudio.PlayOneShot(sfxAudio.clip);
    }
}
