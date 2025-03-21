using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILoginCadastro : MonoBehaviour
{
    public GameObject loginPanel; // Refer�ncia ao painel de Login
    public GameObject registerPanel; // Refer�ncia ao painel de Cadastro
    public GameObject emailInput; // Refer�ncia ao campo de Email no painel de Login
    public GameObject passwordInput; // Refer�ncia ao campo de Senha no painel de Login
    public GameObject senhaInput; // Refer�ncia ao campo de Senha no painel de Login
    public GameObject entrarPanel; // Painel com o bot�o de entrar
    public GameObject esqueciSenha; // Bot�o esqueci minha senha
    public GameObject lembreDeMimCheckbox; // Checkbox "Lembre de mim"
    public GameObject criarContaButton; // Bot�o criar conta
    public GameObject aposCadastroPanel; // Refer�ncia ao painel mostrado ap�s o cadastro
    public GameObject EntrarText;

    public TextMeshProUGUI messageText;
    public GameObject imagemCuboLauncher;

    public GameObject criarContaEntrarButton; // Bot�o que cria a conta e entra
    public GameObject updatename;
    //public Button buttonA; // Refer�ncia ao bot�o A
    //public Button buttonB; // Refer�ncia ao bot�o B



    void Start()
    {

        // Adicionando o listener ao bot�o de criar conta e entrar
        // criarContaEntrarButton.onClick.AddListener(CreateAccountAndCheckMessage);
        // criarContaEntrarButton.onClick.AddListener(CreateAccountAndEnter);
        //buttonA.onClick.AddListener(OnButtonAClicked);
        ShowLogin(); // Inicialmente, mostrar o painel de login e esconder o de cadastro
    }

    /*
    void OnButtonAClicked()
    {
        // Inicia a coroutine para clicar no bot�o B ap�s 1 segundo
        StartCoroutine(ClickButtonBAfterDelay(1.0f));
    }
    */
    IEnumerator ClickButtonBAfterDelay(float delay)
    {
        // Aguarda o tempo especificado no delay
        yield return new WaitForSeconds(delay);

        // Invoca o evento de clique do bot�o B
        //buttonB.onClick.Invoke();
        Debug.Log("Bot�o B foi clicado automaticamente ap�s 1 segundo.");
    }




    public void ShowLogin()
    {
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
        entrarPanel.SetActive(true);
        esqueciSenha.SetActive(true);
        lembreDeMimCheckbox.SetActive(true);
        criarContaButton.SetActive(true);
    }

    public void ShowRegister()
    {
        registerPanel.SetActive(true);
        entrarPanel.SetActive(false); // Esconde apenas o bot�o entrar e outros elementos espec�ficos
        esqueciSenha.SetActive(false);
        lembreDeMimCheckbox.SetActive(false);
        criarContaButton.SetActive(false); // Esconde o bot�o de criar conta
        EntrarText.SetActive(false);

    }

    public void Updatename() 
    {
        passwordInput.SetActive(false);
        emailInput.SetActive(false);
        senhaInput.SetActive(false);
        criarContaEntrarButton.SetActive(false);
        updatename.SetActive(true);
    }


    public void OnRegisterSuccess()
    {
        CloseRegister();
    }

    public void CloseRegister()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(false);
        //ShowLogin(); // Mostra novamente os elementos do login que foram escondidos
    }

    void CreateAccountAndEnter()
    {

        // Agora, desativa os pain�is conforme necess�rio
        registerPanel.SetActive(false);
        //nameUserPanel.SetActive(false); // Certifique-se de que isso ocorre ap�s a a��o do bot�o B
    }

    // M�todo chamado quando o bot�o criar conta e entrar � pressionado
    void CreateAccountAndCheckMessage()
    {
        // Simula��o de registro, sup�e-se que o registro ocorre aqui
        RegisterUser();

        // Verifica se o registro foi bem-sucedido e atualiza a UI conforme necess�rio
        if (messageText.text == "Registrado!")
        {
            imagemCuboLauncher.SetActive(false);
            Debug.Log("Imagem do cubo foi ocultada ap�s o registro.");
        }
    }

    // Simula��o de uma fun��o de registro que atualiza a mensagem de texto
    void RegisterUser()
    {
        // Aqui voc� colocaria a l�gica de registro real
        // Ap�s o registro bem-sucedido, atualiza o texto
        messageText.text = "Registrado!";
    }
}
