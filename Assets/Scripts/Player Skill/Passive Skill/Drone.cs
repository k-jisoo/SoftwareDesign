using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Drone : PassiveSkill
{
    private LineRenderer droneBulletLine;
    private Light2D droneMuzzleFlash;

    private Coroutine droneAttackCheck;
    private Coroutine droneRotateCheck;
    private bool isDroneStop = false;

    private readonly float DRONE_MOVE_SPEED = 50f;      // ��� �̵� �ӵ� (��� ��)
    private readonly float DRONE_RETARGET_TIME = 1f;     // ��� Ÿ�� ���� �ð�(��� ��)
    private readonly float DRONE_BULLET_LINE_DURATION = 0.1f;   // ��� ���� ����Ʈ ���� �ð�(��� ��)

    private WaitForSeconds droneBulletLineDuration; // ��� ���� ����Ʈ ���ӽð�
    private WaitForSeconds droneRetargetDelay;     // ��� Ÿ�� ���� ������

    private float lastTime = 0f;        // ��� ������ ��� �ð�
    private float skillDelayTime = 5f;  // ��� ���� ���ð� (��Ÿ��)  [ �ʱ� ��Ÿ�� = 5�� ���� ]
    public float SkillDelayTime { get { return skillDelayTime; } set { skillDelayTime = value; } }

    private float circleR = 3f; //������
    private float deg; //����

    private void Start()
    {
        droneBulletLineDuration = new WaitForSeconds(DRONE_BULLET_LINE_DURATION); // ĳ��
        droneRetargetDelay = new WaitForSeconds(DRONE_RETARGET_TIME);             // ĳ��

        droneBulletLine = GetComponent<LineRenderer>();
        droneMuzzleFlash = GetComponent<Light2D>(); 
        droneBulletLine.enabled = false; // ���η����� ������Ʈ ��Ȱ��ȭ 
    }

    private void Update()  // ��� ��� ���� Ȯ��
    {
        if(!isDroneStop && Time.time >= lastTime + skillDelayTime) // ������ ���� �ð� + ���� ��Ÿ��
        {
            lastTime = Time.time;
            droneAttackCheck = StartCoroutine(DroneAttack());
        }
    }

    public override void OnActive()
    {
        DroneSkillActive();
    }

    private void DroneSkillActive() // ��� �̵� ���� Ȯ��
    {
        if (droneAttackCheck == null && droneRotateCheck == null)
        {
            isDroneStop = false;
            droneRotateCheck = StartCoroutine(DroneAroundRotate(playerObject.transform));
            
        }
    }

    /// <summary>
    /// ��� ȸ�� �ڷ�ƾ
    /// </summary>
    /// <param name="target">ȸ��Ȱ �������� �� ������Ʈ</param>
    /// <returns></returns>
    IEnumerator DroneAroundRotate(Transform target)
    {
        while (!isDroneStop)
        {
            // �ҽ� ���� : https://sharp2studio.tistory.com/4?category=884092 //
            deg += Time.deltaTime * DRONE_MOVE_SPEED;
            if (deg < 360)
            {
                var rad = Mathf.Deg2Rad * (deg);
                var x = circleR * Mathf.Sin(rad);
                var y = circleR * Mathf.Cos(rad);
                transform.position = target.position + new Vector3(x, y);
                transform.rotation = Quaternion.Euler(0, 0, deg); //����� �ٶ󺸰� ���� ����
            }
            else
            {
                deg = 0;
            }
            yield return null;
        }

        droneRotateCheck = null;
       // Debug.Log("��� ȸ�� ����");
    }


    IEnumerator DroneAttack()
    {
      //  Debug.Log("���� ����");
        Collider2D[] enemyCollider = Physics2D.OverlapCircleAll(playerObject.transform.position, 10f, enemyLayer); // �÷��̾� ���� 10������ ���� Ž��

        if (enemyCollider.Length > 0) // �� �迭�� 0���� ������
        {
          //  droneRetargetDelay = new WaitForSeconds(DRONE_RETARGET_TIME);  TODO : ��� Ÿ�ٺ��� �ð�����. (���׷��̵忡�� ��� �� �ϳ�)

            for (int i=0; i< enemyCollider.Length; i++)
            {
                if (enemyCollider[i] != null)
                {
                    Enemy enemy = enemyCollider[i].GetComponent<Enemy>();
                    StartCoroutine(DroneBulletEffect(enemy.transform.position));
                    enemy.TakeDamage(damage);

                    lastTime += DRONE_RETARGET_TIME;   // ���� ��Ÿ�ӿ� Ÿ�Ϻ��� �ð����� �߰�
                    yield return droneRetargetDelay;
                }
            }
        }
        droneAttackCheck = null;
    }

    /// <summary>
    /// ��� ���� ����Ʈ
    /// </summary>
    /// <param name="enemyPosition">���� ��� ��ġ</param>
    /// <returns>droneBulletLineDuration ��ŭ ��ٸ� �� ���� ������ ����</returns>
    IEnumerator DroneBulletEffect(Vector2 enemyPosition)
    {
        droneBulletLine.SetPosition(0, transform.position); // ���� ������ ���� ��ġ
        droneBulletLine.SetPosition(1, enemyPosition);      // ���� ������ ���� ��ġ

        droneMuzzleFlash.enabled = true; // 2D Light ������Ʈ Ȱ��ȭ
        droneBulletLine.enabled = true;  // ���� ������ ������Ʈ Ȱ��ȭ

        yield return droneBulletLineDuration;

        droneBulletLine.enabled = false; // ���� ������ ������Ʈ ��Ȱ��ȭ
        droneMuzzleFlash.enabled = false; // 2D Light ������Ʈ ��Ȱ��ȭ
    }
}
