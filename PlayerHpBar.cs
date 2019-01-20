using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour {

	private Image hpBar;
	CharContr Player;
	public GameObject PlayerOBJ;
	void Start()
	{
		hpBar = GetComponent<Image>();
		Player = PlayerOBJ.GetComponent<CharContr>();
	}
	void Update()
	{
		hpBar.fillAmount = Player.hp / Player.Maxhp;
	}
}
