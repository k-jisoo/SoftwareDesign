using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassEvent : MonoBehaviour
{
    private void OnCompleteEvent() // HourGlass Anim ���� �̺�Ʈ ȣ��
    {
        Time.timeScale = 1f;  // �ð� ���� ��ü
        PlayerCamera.Instance.ChagnePostProcessProfile(null); // Hour Glass ��ų ����Ʈ ���μ��� ȿ�� ��ü
        gameObject.SetActive(false); // ������ ��Ȱ��ȭ
    }
}
