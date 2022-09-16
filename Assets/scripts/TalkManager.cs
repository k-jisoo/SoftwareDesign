using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{ Dictionary<int, string[]> talkData; 
    //Ư�� ������Ʈ�� �ش��ϴ� id�� �ҷ��� ��ȭ�� ��ġ��Ű�� Ű�� ������ ���� 


    private void Awake()
    {
        talkData = new Dictionary<int, string[]>(); //���� ���� 
        GenerateData(); //�޼ҵ� �ҷ�����
                        }


    void GenerateData()
    {
        talkData.Add(1, new string[] { "...��?", "�� ���� �����ڴ� �������� ���±�." });  //�ε��� 0, �ε��� 1
        talkData.Add(2, new string[] { "���, �� ���ĳ����°�? ����ϱ�.","���� �༮���� ���� ����ġ �����Ծ�." }); 
        talkData.Add(3, new string[] {"��ġ�� �ʾҳ�? ����ִ� �ڳ� ���� ��� ���� �� �̸��� ����� ���̾�." ,"������ �決."});
        
        //ĳ���� �Ϸ� ����ֱ�. 
    }



    public string GetTalk(int id, int talkIndex)
    //������ ��ȭ ������ ��ȯ�ϴ� �Լ�. 
    {

        if (talkIndex == talkData[id].Length) //talkindex�� ��ȭ�� ���� ���� ���Ͽ� �� Ȯ��
            return null;
    else
        return talkData[id][talkIndex]; //Ű ��ȯ�� �� ��� 

        //GenaarteDate�� talkDate�� �� ���徿 return�ؼ� ��ȯ���ش�. 
    }
}
