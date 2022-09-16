using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSlash : ActiveSkill
{
    private readonly float DASH_DISTANCE = 7f;  // �뽬 ����
    private TrailRenderer powerSlashEffect;

    private void Start()
    {
        powerSlashEffect = GetComponentInChildren<TrailRenderer>();

        powerSlashEffect.enabled = false;
    }

    public override void OnActive()
    {

        PowerSlashSkillAttack();
    }


    private void PowerSlashSkillAttack()
    {
        AcitvePowerDashEffect();  // ����Ʈ Ȱ��ȭ

        Vector3 firstPosition = playerObject.transform.position;
        float maxDistance = DASH_DISTANCE;

        // x, y ������ ������ �̿��� �ش� �������� 10m ���󰣴�.

        RaycastHit2D hitObject = Physics2D.Raycast(transform.position, playerController.LastDir, maxDistance, wallLayer);

        if (hitObject)  // RayCast�� ���� �浹�ߴٴ� �ǹ�
        {
            maxDistance = hitObject.distance;     // �� �浹 ��ġ������ Ray�� ��� ���� �Ÿ� ����
            playerObject.transform.position = hitObject.normal; // �浹�� �� �� ������ �̵�
        }

        else
        {
            playerObject.transform.Translate(playerController.LastDir.normalized * maxDistance); // ���������� �� ���� + dashDistance ���� ��ŭ �̵�
        }


        RaycastHit2D[] enemyObject = Physics2D.RaycastAll(firstPosition, playerController.LastDir, maxDistance, enemyLayer);
        /*
        Debug.Log("��ų �浹 �Ÿ� : " + dashDistance);
        Debug.Log("�浹�� �� : " + enemyObject.Length);
        */


        if (enemyObject.Length > 0)
        {
            for (int i = 0; i < enemyObject.Length; i++)
            {
                Destroy(enemyObject[i].transform.gameObject, 0.5f);
            }
        }

        Invoke(nameof(AcitvePowerDashEffect), 1f); //  ����Ʈ ��Ȱ��ȭ
    }

    private void AcitvePowerDashEffect()
    {
        powerSlashEffect.enabled = !powerSlashEffect.enabled;
    }    
}