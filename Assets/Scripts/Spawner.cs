using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Tuberies moldeTubo;
    public float ritmoGeneracion = 1f;
    public float alturaMinima = -1f;
    public float alturaMaxima = 2f;
    public float espacioHueco = 3f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(GenerarTubo), ritmoGeneracion, ritmoGeneracion);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(GenerarTubo));
    }

    private void GenerarTubo()
    {
        Tuberies tubosNuevos = Instantiate(moldeTubo, transform.position, Quaternion.identity);
        tubosNuevos.transform.position += Vector3.up * Random.Range(alturaMinima, alturaMaxima);
        tubosNuevos.huecoTubos = espacioHueco;
    }
}