using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller;
	public float gravity = -9.8f;
    public float speed = 4f;
	private float temp_speed = 12f;
	private float run_speed = 24f;

	Vector3 velocity;

	public Animator playerAnim;
	public Rigidbody playerRigid;

	private bool walking;

	/// groundcheck variables
	public Transform groundCheck;
	public float groundDistance = 0.2f;
	public LayerMask groundMask;
	private bool isgrounded;

    private void Start()
    {
        
    }
    void Update()
    {
		isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if(isgrounded && velocity.y < 0)
        {
			velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
		z = Mathf.Clamp01(z);


		Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.W))
		{
			playerAnim.SetTrigger("walk");
			playerAnim.ResetTrigger("idle");
			walking = true;

		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			playerAnim.ResetTrigger("walk");
			playerAnim.SetTrigger("idle");
			walking = false;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			playerAnim.SetTrigger("walkback");
			playerAnim.ResetTrigger("idle");
			//steps1.SetActive(true);
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			playerAnim.ResetTrigger("walkback");
			playerAnim.SetTrigger("idle");
			//steps1.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			playerAnim.ResetTrigger("idle");
			playerAnim.SetTrigger("turn_right");
			transform.Rotate(0, -2f * Time.deltaTime, 0);
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			playerAnim.ResetTrigger("turn_right");
			playerAnim.SetTrigger("idle");
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			playerAnim.ResetTrigger("idle");
			playerAnim.SetTrigger("turn_left");
			transform.Rotate(0, 2f * Time.deltaTime, 0);
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			playerAnim.ResetTrigger("turn_left");
			playerAnim.SetTrigger("idle");
		}


		if (walking == true)
		{
			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				speed =  run_speed;
				playerAnim.SetTrigger("run");
				playerAnim.ResetTrigger("walk");
			}
			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				speed = temp_speed;
				playerAnim.ResetTrigger("run");
				playerAnim.SetTrigger("walk");
			}
		}

	}
}
