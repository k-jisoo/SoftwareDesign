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
        // TODO : Enemy�� �޸� Ǯ�� (������)

        // TODO : Boss�� ���ӽ¸� UI (������)

        // TODO : Player�� ���ӿ��� UI (������)
    }
    */
    public virtual void TakeDamage(int newDamage)
    {
        hp  -= newDamage - armor;  // �����ϰ� ���ݷ� - �������� ���

        if(hp <= 0)
        {
            OnDead();
        }

        // TODO : Boss UI���� ü�� ������ ���� (������)
        // TODO : Player UI���� ü�� ������ ���� (������)
    }


}
