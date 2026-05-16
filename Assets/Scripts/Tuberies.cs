using UnityEngine;

public class Tuberies : MonoBehaviour
{
    public Transform tuboSuperior;
    public Transform tuboInferior;
    public float velocidadMovimiento = 5f;
    public float huecoTubos = 3f;

    private float limiteIzquierdo;

    private void Start()
    {
        limiteIzquierdo = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        tuboSuperior.position += Vector3.up * huecoTubos / 2;
        tuboInferior.position += Vector3.down * huecoTubos / 2;
    }

    private void Update()
    {
        float velocidadActual = velocidadMovimiento * Main.Instancia.multiplicadorVelocidad;
        transform.position += velocidadActual * Time.deltaTime * Vector3.left;

        if (transform.position.x < limiteIzquierdo)
        {
            Destroy(gameObject);
        }
    }
}