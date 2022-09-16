using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierEvent : MonoBehaviour
{

    Barrier barrier;

    private void Awake()
    {
        barrier = GetComponentInParent<Barrier>();
    }

    private void OnCompleteEvent() // Barrier Anim ���� �̺�Ʈ ȣ��
    {
        barrier.BarrierAnimator.SetTrigger("OnAcitveBarrier");
    }
}

