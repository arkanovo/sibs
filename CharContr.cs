using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharContr : MonoBehaviour {
	[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
	[SerializeField] private Transform GroundCheck;
	[SerializeField] private float JumpForce = 400f;
	const float GroundedRadius = .2f;
	[SerializeField] private LayerMask WhatIsGround;
	private bool Grounded;
	public bool FacingRight = true;
	private Rigidbody2D RB2D;
	public float hp;
	public float Maxhp = 10;
	private Vector3 velocity = Vector3.zero;
	private void Awake()
	{
		hp = Maxhp;
		RB2D = GetComponent<Rigidbody2D>();	
	}
	private void FixedUpdate()
	{
		Grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				Grounded = true;
		}
	}
	public void Move(float move, bool jump)
	{
		Vector3 targetVelocity = new Vector2(move * 10f, RB2D.velocity.y);
		RB2D.velocity = Vector3.SmoothDamp(RB2D.velocity, targetVelocity, ref velocity, MovementSmoothing);		
		if (move > 0 && !FacingRight)
		{			
			Flip();
		}		
		else if (move < 0 && FacingRight)
		{		
			Flip();
		}
		if (Grounded && jump)
		{	
			Grounded = false;
			RB2D.AddForce(new Vector2(0f, JumpForce));
		}
	}
	private void Flip()
	{		
		FacingRight = !FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public void DamageGet(float damage)
	{
		hp-=damage;
		if(hp<=0)
		{
			Die();
		}
	}
	IEnumerator WaitFor(int sec)
	{	
		PlayerMovement PM = this.GetComponent<PlayerMovement>();
		PM.runSpeed = 0f;
		yield return new WaitForSeconds(sec);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);		
	}
	public void Die()
	{
		StartCoroutine(WaitFor(3));
	}
}	
