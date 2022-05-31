using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdFunctions : MonoBehaviour, IUnityAdsListener
{
    //id de development do jogo
    private string gameId = "4747893";
    private bool test_mode = true;

    //bot�o usado
    [SerializeField]
    private Button[] ad_btn;
    
    //id da fun��o de placement do dashboard
    public string placementId = "teste";

    private void Start()
    {
        //inicializa os ads
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, test_mode);

        if (ad_btn != null)
        {
            foreach(Button btn in ad_btn)
            {
                //para s� dar para interagir com o bot�o se tiverem an�ncios
                //btn.interactable = Advertisement.IsReady(placementId);

                btn.onClick.AddListener(RewardedAd);
            }
        }
        else print("ad_btn is null");
    }

    //inicia o ad
    private void RewardedAd()
    {
        Advertisement.Show(placementId);
    }

    public void OnUnityAdsReady(string p_id)
    {
        if(p_id == placementId)
        {
            foreach (Button btn in ad_btn)
            {
                btn.interactable = true;
            }
        }
    }

    public void OnUnityAdsDidFinish(string p_id, ShowResult showR)
    {
        if(showR == ShowResult.Finished)
        {
            //da a recompen�a
            PlayerEquipment.Instance.potions = PlayerEquipment.Instance.max_potions;
            PlayerHealth.Instance.pot_txt.text = "" + PlayerEquipment.Instance.potions;
        }
        else if(showR == ShowResult.Skipped)
        {

        }
        else if(showR == ShowResult.Failed)
        {
            print("Ad didn't finish due to an error");
        }
    }

    public void OnUnityAdsDidError(string msg)
    {
        //faz o log do erro
    }

    public void OnUnityAdsDidStart(string p_id)
    {
        //
    }
}
