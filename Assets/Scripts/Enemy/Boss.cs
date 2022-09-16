using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private BossFSM bossFSM;

    private new void Start()
    {
        base.Start();
        bossFSM = new BossFSM(this,  BossFSM.BossState.Move);
    }

    private void Update()
    {
        bossFSM.StateUpdate();
        bossFSM.CurrentState = BossFSM.BossState.Move;

    }


    protected override sealed void OnDead()
    {
        
        // TODO : ���� UI ����
    }

    public override sealed void TakeDamage(int newDamage)
    {
        base.TakeDamage(newDamage);

        // TODO : Boss UI ü�� ������ ����
    }

    public void SkillAttack()
    {

    }

}
