using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text easyTalk;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;



    public void Action(GameObject scanOb)
    {

        //isAction = true;  �׼��� ���� ������ enter�� �ѹ� �� ������ �״�� ������. 
        scanObject = scanOb;
        ObjData A/*�����̳� ����ó�� �̿�*/ = scanObject.GetComponent<ObjData>();
        Talk(A.id, A.isNPC);
        talkPanel.SetActive(isAction); //true or fasle 

    }



    void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex); //�ش��ϴ� ���ڿ��� ���´�. 

        if (talkData == null) { isAction = false; talkIndex = 0;  return; } // �̾߱Ⱑ �� ������, �� �ε����� �� ���ư��� ��ȭâ ������, ���� ����. 


        if (isAction) //é�ͺ� ���� ���θ��� id���� 
        {
            easyTalk.text = talkData;
        }

        else 
        {
            easyTalk.text = talkData;
        }
        isAction = true;
        talkIndex++; 
    }
}



/*  public void Action(GameObject scanOb) {

if(isAction) //��ȭâ ������
        {
           isAction = false;
        }

        else //��ȭâ �˾�
        {
            //isAction = true;  �׼��� ���� ������ enter�� �ѹ� �� ������ �״�� ������. 
            scanObject = scanOb;
            ObjData A/*�����̳� ����ó�� �̿�* = scanObject.GetComponent<ObjData>();
Talk(A.id, A.isNPC);
        }

        talkPanel.SetActive(isAction); //true or fasle 

    }*/