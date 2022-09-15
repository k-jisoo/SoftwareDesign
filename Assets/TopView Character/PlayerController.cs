using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x;
    float y;

    public float speed;
    Camera cam;

    Rigidbody2D rb;
    Animator animator;
    Vector3 offsetZ = new Vector3(0, 0, -1);
    Vector2 lastDir = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

      //  lastDir.x = x;
      //  lastDir.y = y;

        animator.SetFloat("X", x);
        animator.SetFloat("Y", y);

        cam.transform.position = this.transform.position + offsetZ;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x, y) * speed;


        if (rb.velocity == Vector2.zero)
        {
            animator.SetBool("isMove", false);
            return;
        }
        else
        {
            animator.SetBool("isMove", true);
        }

        // X > 0  크면 오른쪽 (East)
        // X < 0 작으면 왼쪽 (West)
        // Y > 0 크면 위쪽 (North)
        // Y < 0 작으면 아래쪽 (South)

        animator.SetFloat("LastX", x);
        animator.SetFloat("LastY", y);
    }
}
