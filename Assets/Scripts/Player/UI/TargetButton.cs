using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetButton : MonoBehaviour, IPointerDownHandler
{
    //refer�ncia global do c�digo do bot�o
    public static TargetButton Instance { get; set; }

    //refer�ncia do c�digo do camera Lock
    private CamLock CL;

    void Awake()
    {
        //setta a refer�ncia global desse script
        if (Instance == null) Instance = this;
        //garante que s� tem um dele na cena
        else Destroy(gameObject);
    }

    void Start()
    {
        //pega o script de camera lock
        if (CamLock.Instance != null) CL = CamLock.Instance;
        else print("CamLock Instance not found.");
    }

    //quando o jogador toca no bot�o
    public void OnPointerDown(PointerEventData eventData)
    {
        CL.NextTarget();
    }
}