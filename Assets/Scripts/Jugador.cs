using UnityEngine;

public class Jugador : MonoBehaviour
{
    public Sprite[] texturasPajaro;
    public float fuerzaSalto = 5f;
    public float fuerzaGravedad = -9.81f;
    public float inclinacion = 5f;

    private SpriteRenderer renderizadorImagen;
    private Vector3 vectorMovimiento;
    private int indiceTextura;

    private void Awake()
    {
        renderizadorImagen = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimarPajaro), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 posicionInicial = transform.position;
        posicionInicial.y = 0f;
        transform.position = posicionInicial;
        vectorMovimiento = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            vectorMovimiento = Vector3.up * fuerzaSalto;
        }

        vectorMovimiento.y += fuerzaGravedad * Time.deltaTime;
        transform.position += vectorMovimiento * Time.deltaTime;

        Vector3 rotacion = transform.eulerAngles;
        rotacion.z = vectorMovimiento.y * inclinacion;
        transform.eulerAngles = rotacion;
    }

    private void AnimarPajaro()
    {
        indiceTextura++;

        if (indiceTextura >= texturasPajaro.Length)
        {
            indiceTextura = 0;
        }

        if (indiceTextura < texturasPajaro.Length && indiceTextura >= 0)
        {
            renderizadorImagen.sprite = texturasPajaro[indiceTextura];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Main.Instancia.TerminarJuego();
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            Main.Instancia.SumarPunto();
        }
    }
}