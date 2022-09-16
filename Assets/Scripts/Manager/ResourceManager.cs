using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{ 
    private readonly string AUDIO_CLIP_DEFAULT_PATH = "Sounds/";
    private readonly string GAME_OBJECT_DEFAULT_PATH = "Prefabs/";

    public T Load<T>(string resoucrePath) where T : Object
    {
        return Resources.Load<T>(resoucrePath);
    }

    /// <summary>
    /// ���ҽ� ������ �ִ� ����� Ŭ���� ������
    /// </summary>
    /// <param name="path">������ ����� Ŭ�� ���</param>
    /// <returns>����� Ŭ�� ��ȯ</returns>
    public AudioClip GetAudioClip (string path)
    {
        AudioClip clip = Load<AudioClip>(AUDIO_CLIP_DEFAULT_PATH + path);

        if(clip == null)
        {
            Debug.Log($"{path} ����� Ŭ���� ã�� �� �� �����ϴ�.");
            return null;
        }

        return clip;
    }

    /// <summary>
    /// ���ҽ� ������ �ִ� ���� ������Ʈ�� ������
    /// </summary>
    /// <param name="path">������ ���� ������Ʈ ���</param>
    /// <returns>���� ������Ʈ ��ȯ</returns>
    public GameObject GetPerfabGameObject(string path)
    {
        GameObject gameObject = Load<GameObject>(GAME_OBJECT_DEFAULT_PATH + path);

        if (gameObject == null)
        {
            Debug.Log($"{gameObject} ���� ������Ʈ�� ã�� �� �� �����ϴ�.");
            return null;
        }

        return gameObject;
    }
}
