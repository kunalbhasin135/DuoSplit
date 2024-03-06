using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadzone = (float)-6.6;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime * 0.001f;
        moveSpeed += speed;
        transform.position = transform.position + (moveSpeed * Vector3.left) * Time.deltaTime;

        if(transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
       
    }
}