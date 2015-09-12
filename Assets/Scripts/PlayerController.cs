using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public float theta;
    public float jump;
    public float gravity;
    private Vector3 jumpHeight;
    private bool jumping;

    void Start()
    {
        jumpHeight = transform.position;
        jumping = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -theta * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, theta * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
            transform.position -= transform.forward * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpHeight = transform.position + transform.up * jump * Time.deltaTime;
            jumping = true;
         
        }

        if (jumping)
        {
            transform.position = Vector3.Lerp(transform.position, jumpHeight, 10*Time.deltaTime);
            if (transform.position.y +1 >= jumpHeight.y)
                jumping = false;
        }
        if (!jumping)
        {
  
            if (transform.position.y > 0.5f)
                transform.position -= transform.up * gravity * Time.deltaTime;

            if (transform.position.y < 0.5f)
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }

       
    }
}
