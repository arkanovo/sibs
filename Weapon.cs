using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	float damage = 1f;
	public bool isHitting = true;
	public GameObject Player;
	public CharContr CC;
	public Animator anim;
	void Start()
	{
		CC = Player.GetComponent<CharContr>();

	}
	void Update()
	{	
		if(!isHitting)
		{
			if(Input.GetButtonDown("Fire1"))
			{
				anim.SetBool("Attacking",true);
			}	
		}
		if(isHitting)
			anim.SetBool("Attacking",false);
	}
	void OnTriggerEnter2D(Collider2D col)
	{		
		EnemyScript Enemy = col.GetComponent<EnemyScript>();
		if(Enemy != null)
		{
			Enemy.DamageGet(damage);
		}								
	}
}
