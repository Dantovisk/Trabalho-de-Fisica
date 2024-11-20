using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity; 
    [SerializeField] private float massa = 1f;
    private Vector2 velocity;       // Velocidade atual do objeto
    private ForceManager forceManager; 

    void Start()
    {
        forceManager = new ForceManager();
        velocity = initialVelocity;
    }

    void Update()
    {
        // Força gravitacional constante
        forceManager.AddForce(new Force(Vector2.down, 9.81f * massa)); // Peso: F = m * g
        Vector2 resultantForce = forceManager.GetResultantForce();

        // Para massas constantes: F = m * a -> a = F / m
        Vector2 acceleration = resultantForce / massa;
        velocity += acceleration * Time.deltaTime;

        // Conversão para Vector3 é necessária por conta do jeito que o unity lida com posição de objetos
        transform.position += (Vector3)(velocity * Time.deltaTime); 
        

        // Limpa as forças para o próximo frame
        forceManager.ClearForces();
    }
}
