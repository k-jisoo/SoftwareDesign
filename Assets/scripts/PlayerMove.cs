using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    public GameManager_YJ manager; 
    public float Speed;
  
    Rigidbody2D rigid;
    float h;
    float v;
    Vector3 dirVec;
    GameObject scanObject;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0: Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump")&&scanObject != null ) { manager.Action(scanObject); }
        // Debug.Log("이것은" + scanObject.name);
        //scan Object 



    }
    void FixedUpdate()
    {

        rigid.velocity = new Vector2(h, v) * Speed;
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHIt = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("object")); //해당레이어의물체만스캔

        if (rayHIt.collider != null)
            scanObject = rayHIt.collider.gameObject; //레이케스트 된 obj를 변수로 저장하여 활용 
        else
            scanObject = null;

    }

}
