using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName;
    public int[] npcId;

    public QuestData(string name, int[] npc) //����ü ���� for �Ű����� ������ 
    {
        questName = name;
        npcId = npc;
    }
    }



