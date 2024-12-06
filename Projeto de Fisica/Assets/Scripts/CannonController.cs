using TMPro;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float minAngle = 0f;  // �ngulo m�nimo permitido
    [SerializeField] private float maxAngle = 90f; // �ngulo m�ximo permitido
    public TMP_Text textoAngulo;

    public float velocidadeAngulo = 1f;

    void Update()
    {
        float angleChange = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            angleChange = 1f * velocidadeAngulo; // Aumenta o ângulo
        }
        else if (Input.GetKey(KeyCode.D))
        {
            angleChange = -1f * velocidadeAngulo; // Diminui o ângulo
        }

        if (angleChange != 0f)
        {
            // Calcula o novo ângulo
            float newAngle = Mathf.Clamp(transform.eulerAngles.z + angleChange, minAngle, maxAngle);

            // Define a rotação do canhão
            transform.rotation = Quaternion.Euler(0, 0, newAngle);

            // Atualiza o texto do ângulo
            textoAngulo.text = "Ângulo: " + GetCannonAngle() + "°";
        }
    }

    public float GetCannonAngle()
    {
        // Retorna o �ngulo atual do canh�o (em graus)
        float angle = transform.eulerAngles.z;
        if (angle > 180) angle -= 360; // Converte para intervalo [-180, 180]
        return Mathf.Clamp(angle, minAngle, maxAngle);
    }
}
