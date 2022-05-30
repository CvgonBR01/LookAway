using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PotButton : MonoBehaviour, IPointerDownHandler
{
    //refer�ncia do c�digo do player
    private PlayerControl PlayerC;

    void Start()
    {
        //pega o script de controle do jogador
        if (PlayerControl.Instance != null) PlayerC = PlayerControl.Instance;
        else print("PlayerControl Instance not found.");
    }

    //quando o jogador toca no bot�o
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerC.PotDown();
    }
}
