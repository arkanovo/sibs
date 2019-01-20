using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

	float damage = 1f;
	public GameObject GO;
	Rigidbody2D rb;

	void Start()
	{
		rb = GO.GetComponent<Rigidbody2D>();
	}
	void OnTriggerEnter2D(Collider2D col)
	{		
		CharContr Player = col.GetComponent<CharContr>();
		if(Player != null)
		{		

			Player.DamageGet(damage);
			rb.AddForce(new Vector2(200f,0));
		}								
	}
}
