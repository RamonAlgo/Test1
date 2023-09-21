using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class operacions : MonoBehaviour
{
    public GameObject num;
    private float _vel;

    private int _valoroperacions;

    public Sprite[] _spritesoperacions = new Sprite[5];
    // Start is called before the first frame update
    void Start()
    {
        _vel = 2;

        System.Random aleatori = new System.Random();
        _valoroperacions = aleatori.Next(0, 10);//Aleatori ebtre 0 i 9
        // Accedim al component Sptite Render i dins d'aquest, a l'atribut Sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = _spritesoperacions[_valoroperacions];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.y = novaPos.y - _vel * Time.deltaTime;
        transform.position = novaPos;

        DestrueixSiSurtFora();
    }

    private void DestrueixSiSurtFora()
    {

        if (transform.position.y <= -3)
        {
            Destroy(gameObject);
        }
    }
}
