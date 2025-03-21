using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using TMPro;

public class AdMobManager : MonoBehaviour
{

    public questions questionsScript; // Refer�ncia ao script Questions
    public static int ad = 0;
    [SerializeField] private TextMeshProUGUI adcount;
    [SerializeField] private TextMeshProUGUI creditCount;

    public static int credit = 5;
    public GameObject obj1;
    public GameObject obj2;


    public GameObject watchAdButton; // Refer�ncia ao bot�o de assistir an�ncio como GameObject
    public GameObject watchAdButtonlife; // Refer�ncia ao bot�o de assistir an�ncio como GameObject
    public GameObject loadingText;  // GameObject para a mensagem de "Carregando an�ncio"
    public GameObject watchAdButtonAI; // Refer�ncia ao bot�o de assistir an�ncio como GameObject
    public GameObject PanelIA; // Refer�ncia ao bot�o de assistir an�ncio como GameObject
    public GameObject PanelIA2;

    private RewardedAd _rewardedAd;
    public ChatG chatScript; // Refer�ncia ao script ChatG
    public ToggleObjects toggleObjectsScript;

#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-9227938840854475/4158113453";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
    private string _adUnitId = "unused";
#endif


    public void AskAI()
    {
        if (chatScript != null)
        {
            chatScript.OnSendButtonClick2(); // Chama a fun��o para perguntar � IA
        }
        else
        {
            Debug.LogError("ChatG n�o foi encontrado!");
        }
    }

    public void AskAIAfterDelay()
    {
        StartCoroutine(WaitAndAskAI());
    }

    private IEnumerator WaitAndAskAI()
    {
        yield return new WaitForSeconds(1f); // Espera 2 segundos
        AskAI(); // Chama a fun��o AskAI ap�s o tempo de espera
    }
    void Start()
    {
        try
        {
            // Carregar o valor salvo de 'ad' do PlayerPrefs
            ad = PlayerPrefs.GetInt("adCount", 1);
            UpdateAdCountText();

            // Configurar UI inicialmente
            if (watchAdButton != null) watchAdButton.SetActive(false);
            if (loadingText != null) loadingText.SetActive(false);

            LoadRewardedAd();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro durante Start: {ex.Message}");
        }
    }

    void Update()
    {
        creditCount.text = "Digite sua mensagem aqui... (Voc� tem " + credit.ToString() + " cr�ditos restantes)";

        try
        {
            UpdateAdCountText();

            // Atualizar visibilidade dos objetos de acordo com o valor de 'ad'
            bool hasAds = ad > 0;
            obj1?.SetActive(hasAds);
            obj2?.SetActive(hasAds);

            // Exibe ou oculta o texto de carregamento e o bot�o de an�ncio
            if (_rewardedAd == null || !_rewardedAd.CanShowAd())
            {
                loadingText?.SetActive(true);
                watchAdButton?.SetActive(false);
            }
            else
            {
                loadingText?.SetActive(false);
                watchAdButton?.SetActive(true);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro durante Update: {ex.Message}");
        }
    }

    public void LoadRewardedAd()
    {
        try
        {
            // Destroi o an�ncio anterior, se houver
            if (_rewardedAd != null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }

            Debug.Log("Carregando an�ncio recompensado.");

            // Cria a requisi��o do an�ncio
            var adRequest = new AdRequest();

            RewardedAd.Load(_adUnitId, adRequest,
                (RewardedAd ad, LoadAdError error) =>
                {
                    if (error != null || ad == null)
                    {
                        Debug.LogError("Falha ao carregar o an�ncio recompensado: " + error);
                        watchAdButton?.SetActive(false);
                        watchAdButtonlife?.SetActive(false);
                        loadingText?.SetActive(false);
                        return;
                    }

                    Debug.Log("An�ncio recompensado carregado com sucesso.");
                    _rewardedAd = ad;
                    watchAdButton?.SetActive(true);
                    watchAdButtonlife?.SetActive(true);
                    loadingText?.SetActive(false);
                });
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro durante LoadRewardedAd: {ex.Message}");
        }
    }

    public void ShowRewardedAd()
    {
        try
        {
            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) =>
                {
                    try
                    {
                        questionsScript.pular();
                        Debug.Log($"An�ncio recompensado. Tipo: {reward.Type}, Quantidade: {reward.Amount}");

                        //PlayerPrefs.SetInt("adCount", ad);
                        //PlayerPrefs.Save();

                        LoadRewardedAd();
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"Erro ao processar a recompensa: {ex.Message}");
                    }
                });

                watchAdButton?.SetActive(false);
            }
            else
            {
                Debug.LogWarning("An�ncio recompensado n�o est� pronto para ser exibido.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro durante ShowRewardedAd: {ex.Message}");
        }
    }

    public void ShowRewardedAdlife()
    {
        try
        {
            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) =>
                {
                    try
                    {
                        //questionsScript.pular();
                        Debug.Log($"An�ncio recompensado. Tipo: {reward.Type}, Quantidade: {reward.Amount}");
                        questions.vidas = questions.vidas + 3;
                        questions.SalvarVidas();
                        //PlayerPrefs.SetInt("adCount", ad);
                        //PlayerPrefs.Save();

                        LoadRewardedAd();
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"Erro ao processar a recompensa: {ex.Message}");
                    }
                });

                //watchAdButtonlife?.SetActive(false);
            }
            else
            {
                Debug.LogWarning("An�ncio recompensado n�o est� pronto para ser exibido.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro durante ShowRewardedAd: {ex.Message}");
        }
    }

    public void ShowRewardedAdia()
    {
        try
        {
            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) =>
                {
                    try
                    {
                        // toggleObjectsScript.ToggleObjectsState();
                        //questionsScript.pular();
                        controleui.lai = true;
                        Debug.Log($"An�ncio recompensado. Tipo: {reward.Type}, Quantidade: {reward.Amount}");
                        AskAIAfterDelay();
                        //PanelIA.SetActive(true);
                        //PlayerPrefs.SetInt("adCount", ad);
                        //PlayerPrefs.Save();

                        LoadRewardedAd();
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"Erro ao processar a recompensa: {ex.Message}");
                    }
                });

               // watchAdButtonAI?.SetActive(false);
            }
            else
            {
                Debug.LogWarning("An�ncio recompensado n�o est� pronto para ser exibido.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro durante ShowRewardedAd: {ex.Message}");
        }
    }

    public void ShowRewardedAdia2()
    {
        try
        {
            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) =>
                {
                    try
                    {
                        //questionsScript.pular();
                        Debug.Log($"An�ncio recompensado. Tipo: {reward.Type}, Quantidade: {reward.Amount}");
                        credit = credit + 2;
                        LoadRewardedAd();
                        PanelIA2.SetActive(false);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"Erro ao processar a recompensa: {ex.Message}");
                    }
                });

              //  watchAdButtonAI?.SetActive(false);
            }
            else
            {
                Debug.LogWarning("An�ncio recompensado n�o est� pronto para ser exibido.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro durante ShowRewardedAd: {ex.Message}");
        }
    }


    public void lastone()
    {
        try
        {
            if (ad > 0)
            {
                ad -= 1;
                PlayerPrefs.SetInt("adCount", ad);
                PlayerPrefs.Save();
                UpdateAdCountText();
            }
            else
            {
                Debug.LogWarning("Nenhum an�ncio restante para consumir.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro durante lastone: {ex.Message}");
        }
    }

    public void lastcredit()
    {
        if (credit > 0)
        {
            credit = credit - 1;
        }
    }
    private void UpdateAdCountText()
    {
        try
        {
            if (adcount != null)
            {
                adcount.text = ad.ToString();
            }
            else
            {
                Debug.LogWarning("Refer�ncia ao TextMeshProUGUI adcount est� faltando.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro durante UpdateAdCountText: {ex.Message}");
        }
    }
}