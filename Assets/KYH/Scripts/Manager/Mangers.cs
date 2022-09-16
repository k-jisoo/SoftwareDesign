using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mangers : MonoBehaviour
{
    private static Mangers instance;
    public static Mangers Instance { get { return instance; } }

    private ResourceManager resource = new ResourceManager(); // ��üȭ ����
    public static ResourceManager Resource { get { return Instance.resource; } }

    private SoundManager sound;
    public static SoundManager Sound { get { return Instance.sound; } }

    private ButtonManager button;
    public static ButtonManager Button { get { return Instance.button; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        sound = GetComponentInChildren<SoundManager>();
        button = GetComponentInChildren<ButtonManager>();
    }
}
