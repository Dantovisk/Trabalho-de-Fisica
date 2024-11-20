using UnityEngine;
using TMPro; // Importar o namespace do TextMesh Pro

public class PhysicsUI : MonoBehaviour
{
    [SerializeField] private PhysicsObject targetObject; // O objeto que ser� monitorado
    [SerializeField] private TMP_Text heightText;        // Texto para exibir a altura
    [SerializeField] private TMP_Text velocityText;      // Texto para exibir a velocidade
    [SerializeField] private TMP_Text angleText;         // Texto para exibir o �ngulo

    private Vector2 groundPosition; // Posi��o inicial do objeto (n�vel do ch�o)

    void Start()
    {
        // Define a posi��o inicial do objeto como a refer�ncia para a altura
        if (targetObject != null)
            groundPosition = targetObject.transform.position;
    }

    void Update()
    {
        if (targetObject == null) return;

        // Altura do objeto em rela��o ao ch�o
        float height = targetObject.transform.position.y - groundPosition.y;

        // Velocidade atual
        Vector2 velocity = targetObject.velocity; // Supondo que PhysicsObject tenha uma propriedade p�blica para a velocidade
        float speed = velocity.magnitude;

        // �ngulo em rela��o ao eixo horizontal
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        // Atualiza os textos na UI
        heightText.text = $"Altura: {height:F2} m";
        velocityText.text = $"Velocidade: {speed:F2} m/s";
        angleText.text = $"�ngulo: {angle:F2}�";
    }
}
