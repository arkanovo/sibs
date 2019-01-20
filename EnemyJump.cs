using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour {

	public GameObject Player;
	public GameObject Enemy;
	void OnTriggerStay2D(Collider2D wall)
	{
		Debug.Log(wall.tag);
		if(wall.CompareTag("Wall")&&(Player.transform.position.y>Enemy.transform.position.y))
		{
			Rigidbody2D rb = Enemy.GetComponent<Rigidbody2D>();
			rb.AddForce(new Vector2(0f,400f));
		}
	}
}
