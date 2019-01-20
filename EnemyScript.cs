using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public float maxHp;
	public float hp;
	public float VisionRadius = 3f;
	public GameObject PlayerGO;
	[SerializeField] private LayerMask Player;
	Rigidbody2D rb;
	public bool FacingRight = true;
	public float LWall;
	public float RWall;
	private Vector3 velocity = Vector3.zero;
	public float Speed;
	public float ReverseSpeed;
	public bool kastil_ebanii = true;
	bool isAgro = false;
	[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{		
		Move(Speed);
		if(!isAgro)
		{		
			if((transform.position.x >= RWall)&&(kastil_ebanii))
			{
				Speed *=-1;
				kastil_ebanii = false;
			}
			if((transform.position.x <= LWall)&&(!kastil_ebanii))
			{
				Speed *=-1;
				kastil_ebanii = true;
			}
		}
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, VisionRadius, Player);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject == PlayerGO)
			isAgro = true;
			Aggro();
		}
	}
	public void DamageGet(float Damage)
	{
		hp-=Damage;
		rb.AddForce(new Vector2(transform.localScale.x * -90f,0));
		if(hp<=0)
			death();
	}
	void death()
	{
		Destroy(gameObject);
	}
	public void Move(float move)
	{
		Vector3 targetVelocity = new Vector2(move ,0);
		rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, MovementSmoothing);		
		if (move > 0 && !FacingRight)
		{			
			Flip();
		}		
		else if (move < 0 && FacingRight)
		{		
			Flip();
		}
	}
	private void Flip()
	{		
		FacingRight = !FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void Aggro()
	{
		if(PlayerGO.transform.position.x<transform.position.x)
			Speed = ReverseSpeed;
		if(PlayerGO.transform.position.x>transform.position.x)
			Speed = 1;
	}
}
