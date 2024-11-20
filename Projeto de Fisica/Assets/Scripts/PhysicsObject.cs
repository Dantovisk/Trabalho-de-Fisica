using UnityEngine;

//Estamos considerando que 1 unidade de dist�ncia no Unity � equivalente a 1 metro
//Ent�o, ao utilizar medidas do SI, consideraremos esse detalhe para obter resultados realistas

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity; 
    [SerializeField] private float mass = 1f;
    [SerializeField] private float dragCoefficient = 0.1f; // Coeficiente de arrasto (k), utilizado para calcular a for�a viscosa
    public Vector2 velocity;       // Velocidade atual do objeto
    private ForceManager forceManager; 

    void Start()
    {
        forceManager = new ForceManager();
        velocity = initialVelocity;
    }

    void Update()
    {
        // For�a gravitacional constante
        forceManager.AddForce(new Force(Vector2.down, 9.81f * mass)); // Peso: F = m * g
        Vector2 resultantForce = forceManager.GetResultantForce();
        
        // C�lculo da for�a viscosa, proporcional � velocidade
        Vector2 viscousForce = -dragCoefficient * velocity; // F = -k * v
        forceManager.AddForce(new Force(viscousForce.normalized, viscousForce.magnitude));

        // Para massas constantes: F = m * a -> a = F / m
        Vector2 acceleration = resultantForce / mass;
        velocity += acceleration * Time.deltaTime;

        // Convers�o para Vector3 � necess�ria por conta do jeito que o unity lida com posi��o de objetos
        transform.position += (Vector3)(velocity * Time.deltaTime); 
        

        // Limpa as for�as para o pr�ximo frame
        forceManager.ClearForces();
    }
}
