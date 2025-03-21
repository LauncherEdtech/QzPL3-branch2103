using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILoginCadastro : MonoBehaviour
{
    public GameObject loginPanel; // Referência ao painel de Login
    public GameObject registerPanel; // Referência ao painel de Cadastro
    public GameObject emailInput; // Referência ao campo de Email no painel de Login
    public GameObject passwordInput; // Referência ao campo de Senha no painel de Login
    public GameObject senhaInput; // Referência ao campo de Senha no painel de Login
    public GameObject entrarPanel; // Painel com o botão de entrar
    public GameObject esqueciSenha; // Botão esqueci minha senha
    public GameObject lembreDeMimCheckbox; // Checkbox "Lembre de mim"
    public GameObject criarContaButton; // Botão criar conta
    public GameObject aposCadastroPanel; // Referência ao painel mostrado após o cadastro
    public GameObject EntrarText;

    public TextMeshProUGUI messageText;
    public GameObject imagemCuboLauncher;

    public GameObject criarContaEntrarButton; // Botão que cria a conta e entra
    public GameObject updatename;
    //public Button buttonA; // Referência ao botão A
    //public Button buttonB; // Referência ao botão B



    void Start()
    {

        // Adicionando o listener ao botão de criar conta e entrar
        // criarContaEntrarButton.onClick.AddListener(CreateAccountAndCheckMessage);
        // criarContaEntrarButton.onClick.AddListener(CreateAccountAndEnter);
        //buttonA.onClick.AddListener(OnButtonAClicked);
        ShowLogin(); // Inicialmente, mostrar o painel de login e esconder o de cadastro
    }

    /*
    void OnButtonAClicked()
    {
        // Inicia a coroutine para clicar no botão B após 1 segundo
        StartCoroutine(ClickButtonBAfterDelay(1.0f));
    }
    */
    IEnumerator ClickButtonBAfterDelay(float delay)
    {
        // Aguarda o tempo especificado no delay
        yield return new WaitForSeconds(delay);

        // Invoca o evento de clique do botão B
        //buttonB.onClick.Invoke();
        Debug.Log("Botão B foi clicado automaticamente após 1 segundo.");
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
        entrarPanel.SetActive(false); // Esconde apenas o botão entrar e outros elementos específicos
        esqueciSenha.SetActive(false);
        lembreDeMimCheckbox.SetActive(false);
        criarContaButton.SetActive(false); // Esconde o botão de criar conta
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

        // Agora, desativa os painéis conforme necessário
        registerPanel.SetActive(false);
        //nameUserPanel.SetActive(false); // Certifique-se de que isso ocorre após a ação do botão B
    }

    // Método chamado quando o botão criar conta e entrar é pressionado
    void CreateAccountAndCheckMessage()
    {
        // Simulação de registro, supõe-se que o registro ocorre aqui
        RegisterUser();

        // Verifica se o registro foi bem-sucedido e atualiza a UI conforme necessário
        if (messageText.text == "Registrado!")
        {
            imagemCuboLauncher.SetActive(false);
            Debug.Log("Imagem do cubo foi ocultada após o registro.");
        }
    }

    // Simulação de uma função de registro que atualiza a mensagem de texto
    void RegisterUser()
    {
        // Aqui você colocaria a lógica de registro real
        // Após o registro bem-sucedido, atualiza o texto
        messageText.text = "Registrado!";
    }
}
