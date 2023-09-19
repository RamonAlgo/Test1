using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_1 : MonoBehaviour
{
    public float velocity = 0.5f;
    public GameObject bala;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener la posición máxima en el eje Y de la pantalla en coordenadas del mundo
        maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.y += velocity * Time.deltaTime;
        transform.position = novaPos;
        
        if (novaPos.y > maxY)
        {
            Destroy(gameObject); // Destruye la bala si supera el límite superior
        }
    }
}
