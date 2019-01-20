using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

	private Image hpBar;
	public GameObject EnemyHP;
	EnemyScript Enemy;
	void Start()
	{
		hpBar = GetComponent<Image>();
		Enemy = EnemyHP.GetComponent<EnemyScript>();
	}
	void Update()
	{
		hpBar.fillAmount = Enemy.hp / Enemy.maxHp;
	}
}
