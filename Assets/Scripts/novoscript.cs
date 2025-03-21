using UnityEngine;

public class novoscript : MonoBehaviour
{
    public float forcaDoPulo = 10f;

    void Update()
    {
        // Verifica se a tecla de espa�o foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Aplica uma for�a vertical para simular o pulo
            GetComponent<Rigidbody>().AddForce(Vector3.up * forcaDoPulo, ForceMode.Impulse);
        }
    }
}
