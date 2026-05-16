using UnityEngine;

public class velocitat : MonoBehaviour
{
    public float velocidadFondo = 1f;
    private MeshRenderer renderizadorMalla;

    private void Awake()
    {
        renderizadorMalla = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float velocidadActual = velocidadFondo * Main.Instancia.multiplicadorVelocidad;
        renderizadorMalla.material.mainTextureOffset += new Vector2(velocidadActual * Time.deltaTime, 0);
    }
}