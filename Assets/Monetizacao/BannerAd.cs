using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour
{
    private BannerView bannerView;
    private int marginTop = 54; // Distância desejada do topo (em pixels) estava em 48

    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) => { });
        ShowBannerAd();
    }

    void OnDestroy()
    {
        DestroyBanner();
    }

    public void ShowBannerAd()
    {
        DestroyBanner();

        // Cria um banner adaptativo com largura completa
        AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        // Cria o banner na posição inicial (centralized horizontally, at y=0)
        bannerView = new BannerView("ca-app-pub-9227938840854475/5495266961", adaptiveSize, AdPosition.Top);

        // Configura o listener para reposicionar quando carregar
        bannerView.OnBannerAdLoaded += OnBannerLoaded;

        // Carrega o anúncio
        bannerView.LoadAd(new AdRequest());
    }

    private void OnBannerLoaded()
    {
        // Alguns dispositivos usam coordenadas em pontos (points) e não em pixels
        // Vamos tentar diferentes versões do método SetPosition

        try
        {
            // Tenta chamar SetPosition diretamente com uma coordenada Y específica
            // O primeiro parâmetro (0) é a coordenada X, mantendo centralizado horizontalmente
            // O segundo parâmetro (marginTop) é a distância do topo em pixels
            bannerView.SetPosition(0, marginTop);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao posicionar banner: " + e.Message);

            // Fallback: manter na posição padrão (topo)
            Debug.Log("Mantendo banner na posição padrão (topo)");
        }
    }

    public void DestroyBanner()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }
    }
}