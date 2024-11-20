using UnityEngine;

//Estamos considerando que 1 unidade de distância no Unity é equivalente a 1 metro
//Então, ao utilizar medidas do SI, consideraremos esse detalhe para obter resultados realistas

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity; 
    [SerializeField] private float mass = 1f;
    [SerializeField] private float dragCoefficient = 0.1f; // Coeficiente de arrasto (k), utilizado para calcular a força viscosa
    public Vector2 velocity;       // Velocidade atual do objeto
    private ForceManager forceManager; 

    void Start()
    {
        forceManager = new ForceManager();
        velocity = initialVelocity;
    }

    void Update()
    {
        // Força gravitacional constante
        forceManager.AddForce(new Force(Vector2.down, 9.81f * mass)); // Peso: F = m * g
        Vector2 resultantForce = forceManager.GetResultantForce();
        
        // Cálculo da força viscosa, proporcional à velocidade
        Vector2 viscousForce = -dragCoefficient * velocity; // F = -k * v
        forceManager.AddForce(new Force(viscousForce.normalized, viscousForce.magnitude));

        // Para massas constantes: F = m * a -> a = F / m
        Vector2 acceleration = resultantForce / mass;
        velocity += acceleration * Time.deltaTime;

        // Conversão para Vector3 é necessária por conta do jeito que o unity lida com posição de objetos
        transform.position += (Vector3)(velocity * Time.deltaTime); 
        

        // Limpa as forças para o próximo frame
        forceManager.ClearForces();
    }
}
