using UnityEngine;
using TMPro; // Importar o namespace do TextMesh Pro

public class PhysicsUI : MonoBehaviour
{
    [SerializeField] private PhysicsObject targetObject; // O objeto que será monitorado
    [SerializeField] private TMP_Text heightText;        // Texto para exibir a altura
    [SerializeField] private TMP_Text velocityText;      // Texto para exibir a velocidade
    [SerializeField] private TMP_Text angleText;         // Texto para exibir o ângulo

    private Vector2 groundPosition; // Posição inicial do objeto (nível do chão)

    void Start()
    {
        // Define a posição inicial do objeto como a referência para a altura
        if (targetObject != null)
            groundPosition = targetObject.transform.position;
    }

    void Update()
    {
        if (targetObject == null) return;

        // Altura do objeto em relação ao chão
        float height = targetObject.transform.position.y - groundPosition.y;

        // Velocidade atual
        Vector2 velocity = targetObject.velocity; // Supondo que PhysicsObject tenha uma propriedade pública para a velocidade
        float speed = velocity.magnitude;

        // Ângulo em relação ao eixo horizontal
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        // Atualiza os textos na UI
        heightText.text = $"Altura: {height:F2} m";
        velocityText.text = $"Velocidade: {speed:F2} m/s";
        angleText.text = $"Ângulo: {angle:F2}°";
    }
}
