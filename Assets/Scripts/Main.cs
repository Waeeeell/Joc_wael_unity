using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class Main : MonoBehaviour
{
    public static Main Instancia { get; private set; }

    [SerializeField] private Jugador jugadorPrincipal;
    [SerializeField] private Spawner generadorTubos;
    [SerializeField] private Text textoPuntos;
    [SerializeField] private GameObject botonJugar;
    [SerializeField] private GameObject pantallaFin;

    public int puntosTotales { get; private set; } = 0;

    public float multiplicadorVelocidad { get; private set; } = 1f;
    public float aumentoPorPunto = 0.05f;

    private void Awake()
    {
        if (Instancia != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instancia = this;
        }
    }

    private void OnDestroy()
    {
        if (Instancia == this)
        {
            Instancia = null;
        }
    }

    private void Start()
    {
        PausarJuego();
    }

    public void PausarJuego()
    {
        Time.timeScale = 0f;
        jugadorPrincipal.enabled = false;
    }

    public void IniciarJuego()
    {
        puntosTotales = 0;
        multiplicadorVelocidad = 1f;
        textoPuntos.text = puntosTotales.ToString();

        botonJugar.SetActive(false);
        pantallaFin.SetActive(false);

        Time.timeScale = 1f;
        jugadorPrincipal.enabled = true;

        Tuberies[] tubosViejos = FindObjectsOfType<Tuberies>();
        for (int i = 0; i < tubosViejos.Length; i++)
        {
            Destroy(tubosViejos[i].gameObject);
        }
    }

    public void TerminarJuego()
    {
        botonJugar.SetActive(true);
        pantallaFin.SetActive(true);
        PausarJuego();
    }

    public void SumarPunto()
    {
        puntosTotales++;
        textoPuntos.text = puntosTotales.ToString();
        multiplicadorVelocidad += aumentoPorPunto;
    }
}