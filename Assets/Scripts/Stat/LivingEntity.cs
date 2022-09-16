using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class LivingEntity : MonoBehaviour
{
    [SerializeField] BasicStat basicStat;

    private int hp;
    private int maxHp;
    private float moveSpeed;
    private int armor;
    private int defaultAttackDamage;

    public int Hp { get; set; }
    public int MaxHp { get; set; }
    public float MoveSpeed { get { return moveSpeed; } }
    public float Armor { get; set; }
    public int DefaultAttackDamage { get; set; }

    protected void Init()
    {
        hp = basicStat.Hp;
        maxHp = hp;
        moveSpeed = basicStat.MoveSpeed;
        armor = basicStat.Armor;
        defaultAttackDamage = basicStat.defaultAttackDamage;
    }

    protected abstract void OnDead();
    /*
    {
        // TODO : Enemy는 메모리 풀링 (재정의)

        // TODO : Boss는 게임승리 UI (재정의)

        // TODO : Player는 게임오버 UI (재정의)
    }
    */
    public virtual void TakeDamage(int newDamage)
    {
        hp  -= newDamage - armor;  // 간단하게 공격력 - 방어력으로 계산

        if(hp <= 0)
        {
            OnDead();
        }

        // TODO : Boss UI에서 체력 게이지 변경 (재정의)
        // TODO : Player UI에서 체력 게이지 변경 (재정의)
    }


}
