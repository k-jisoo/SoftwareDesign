using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : ActiveSkill
{
   [SerializeField] GameObject barrierEffectObject;

    private Animator barrierAnimator;
    public Animator BarrierAnimator { get { return barrierAnimator; } }

    private Coroutine barrierCheck = null;
    private WaitForSeconds skillDuration = new WaitForSeconds(10f);

    private void Start()
    {
        barrierAnimator = barrierEffectObject.GetComponent<Animator>();
    }
    
    public override void OnActive()
    {
        if(barrierCheck == null)
        {
            barrierCheck = StartCoroutine(BarrierSkillProcess());
        }
    }

    private void BarrierSkillActive()
    {
        barrierEffectObject.SetActive(true);
        // TODO : barrier ������Ʈ �ݶ��̴� Ȱ��ȭ
    }

    private void BarrierSkillDisable()
    {
       if(barrierCheck != null)
       {
            StopCoroutine(barrierCheck);
       }

        barrierCheck = null;
        barrierEffectObject.SetActive(false);

        // TODO : barrier ������Ʈ �ݶ��̴� ��Ȱ��ȭ
    }

    IEnumerator BarrierSkillProcess()
    {
        BarrierSkillActive();

        yield return  skillDuration;

        BarrierSkillDisable();
    }
}
