using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    //refer�ncia global do c�digo do personagem
    public static PlayerEquipment Instance { get; set; }

    //niveis de equipamento
    public int sword_lvl, armor_lvl, shield_lvl;
    //po��es que o jogador tem agora
    public int potions, max_potions;

    private void Awake()
    {
        //setta a refer�ncia global desse script
        if (Instance == null) Instance = this;
        //garante que s� tem um dele na cena
        else Destroy(gameObject);
    }
	
	public void SwordStats()
	{
		switch(sword_lvl)
		{
			case 0:
				PlayerControl.Instance.dmg_mod = 1f;
				break;
			
			case 1:
				PlayerControl.Instance.dmg_mod = 1.25f;
				break;
			
			case 2:
				PlayerControl.Instance.dmg_mod = 1.5f;
				break;
			
			default:
				PlayerControl.Instance.dmg_mod = 1f;
				break;
		}
	}
	
	public void ArmorStats()
	{
		switch(armor_lvl)
		{
			case 0:
				PlayerHealth.Instance.max_hp = 100;
				break;
			
			case 1:
				PlayerHealth.Instance.max_hp = 125;
				PlayerHealth.Instance.UpdateHealth(25);
				break;
			
			case 2:
				PlayerHealth.Instance.max_hp = 150;
				PlayerHealth.Instance.UpdateHealth(25);
				break;
			
			default:
				
				break;
		}
	}
	
	//stats do escudo em PlayerControl.AnimBlock()
}
