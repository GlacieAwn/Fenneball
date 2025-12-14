using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController2D : MonoBehaviour
{
	
	public float paddleSpeed;
	
	private PlayerInputActions input;

	void Awake()
	{
		input = new PlayerInputActions();
		input.Player.Enable();
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		PaddleMovement();
	}

	private void PaddleMovement()
	{
		Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
		Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		if(gameObject.tag == "RightPaddle")
		{
			float rightPaddleMove = input.Player.RightPaddleMovement.ReadValue<float>();
			transform.Translate(0, Mathf.Clamp(rightPaddleMove * paddleSpeed * Time.deltaTime, minScreenBounds.y, maxScreenBounds.y), 0);
		}
		else if(gameObject.tag == "LeftPaddle")
        {
			float leftPaddleMove = input.Player.LeftPaddleMovement.ReadValue<float>();
			transform.Translate(0, Mathf.Clamp(leftPaddleMove * paddleSpeed * Time.deltaTime, minScreenBounds.y, maxScreenBounds.y), 0);
        }
		

		//transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, minScreenBounds.y / 1.65f, maxScreenBounds.y / 1.65f));
		transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3, 3));

		
		
	}
}
