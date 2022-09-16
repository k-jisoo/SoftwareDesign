using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HourGlass : PassiveSkill
{
    [SerializeField] GameObject hourGlassEffectObject;
    [SerializeField] VolumeProfile hourGlassProfile;

    private Animator hourGlassAnimator;
    public Animator HourGlassAnimator { get { return hourGlassAnimator; } }

    private Coroutine hourGlassCheck = null;
    private WaitForSecondsRealtime skillDuration = new WaitForSecondsRealtime(5f);

    private void Start()
    {
        hourGlassAnimator = hourGlassEffectObject.GetComponent<Animator>();
    }

    public override void OnActive()
    {
        if (hourGlassCheck == null)
        {
            hourGlassCheck = StartCoroutine(BarrierSkillProcess());
        }
    }

    private void HourGlassSkillActive()
    {
        Time.timeScale = 0f; // �ð� ���� 
        PlayerCamera.Instance.ChagnePostProcessProfile(hourGlassProfile); // Hour Glass ��ų ����Ʈ ���μ��� ȿ�� Ȱ��ȭ
        hourGlassEffectObject.SetActive(true); // Hour Glass Effect ������Ʈ Ȱ��ȭ
    }

    private void HourGlassSkillDisable()
    {
        if (hourGlassCheck != null)
        {
            StopCoroutine(hourGlassCheck);
        }

        hourGlassAnimator.SetTrigger("ComeBack"); // ���ƿ��� �ð� �ִϸ��̼� ���
        hourGlassCheck = null;
    }

    IEnumerator BarrierSkillProcess()
    {
        HourGlassSkillActive();

        yield return skillDuration;

        HourGlassSkillDisable();
    }
}
