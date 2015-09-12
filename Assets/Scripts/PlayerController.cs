using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public float theta;
    public float jump;
    public float gravity;

	private Animator attack;

	void Start()
	{
		attack = GetComponent<Animator> ();
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
            transform.position += transform.up * jump * Time.deltaTime;

        if(transform.position.y > 0.5f)
            transform.position -= transform.up * gravity * Time.deltaTime;

        if (transform.position.y < 0.5f)
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

		if (Input.GetKey (KeyCode.Z))
			attack.SetTrigger ("Attack");

		if (Input.GetKey (KeyCode.X))
			attack.SetTrigger ("Defend");

    }
}
