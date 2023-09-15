using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// wasdŰ�� �÷��̾ �����δ�.
public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        // input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // dir
        Vector3 dir = new Vector3(h, 0, v);

        // move
        transform.position += dir * speed * Time.deltaTime;

    }
}
