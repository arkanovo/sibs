using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour {

	public GameObject Player;
	public GameObject Enemy;
	public float CurrDamage;
	public float damage = 1f;
	void Awake()
	{
		CurrDamage = damage;
	}
	void OnTriggerStay2D(Collider2D wall)
	{
		Debug.Log(wall.tag);
		if(wall.CompareTag("Wall")&&(Player.transform.position.y>Enemy.transform.position.y))
		{
			Rigidbody2D rb = Enemy.GetComponent<Rigidbody2D>();
			rb.AddForce(new Vector2(0f,400f));
		}
	}
	IEnumerator WaitFor(int sec)
	{	
		CurrDamage = 0f;
		yield return new WaitForSeconds(sec);	
		CurrDamage = damage;	
	}
	void OnTriggerEnter2D(Collider2D Player)
	{
		if(Player.CompareTag("Player"))
		{
			CharContr CC = Player.GetComponent<CharContr>();
			CC.DamageGet(CurrDamage);
			StartCoroutine(WaitFor(1));
			Debug.Log(CC.hp);
		}
	}
}
