using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;
    public float speed;
    public Keyboard keyboard;
    public GameObject mouseSprite;
    public Vector2 initPos;
    public string posicao;
    public AudioSource audio2;
    public AudioSource audio;
    
    Vector2 move;
    // Start is called before the first frame update
    void Awake()
    {
        
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
        Debug.Log(move);

    }

    private void FixedUpdate()
    {
        body.velocity = move*Mathf.Round(speed);
        PosicaoInicial();
    }

    void PosicaoInicial() {
        if (posicao == "Cima") {
            initPos = Vector2.up;
        } else if (posicao == "Baixo") {
            initPos = Vector2.down;
        }
        else if (posicao == "Esquerda")
        {
            initPos = Vector2.left;
        }
        else if (posicao == "Direita")
        {
            initPos = Vector2.right;
        }
    }

    void UpdateSprite() {
        if (move==Vector2.up)
        {
            mouseSprite.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
        }

        if (move == Vector2.down)
        {
            mouseSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (move == Vector2.left)
        {
            mouseSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }

        if (move == Vector2.right)
        {
            mouseSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }

    }

    public void Iniciar() {
        Debug.Log("Iniciou");
        
        move = initPos;
    }

    public void MoverEsquerda() {
        Debug.Log("Esquerda");
        if (move==Vector2.up) {
            move = Vector2.left;
        }else if (move == Vector2.right)
        {
            move = Vector2.up;
        }
        else if (move == Vector2.left)
        {
            move = Vector2.down;
        }
        else if (move == Vector2.down)
        {
            move = Vector2.right;
        }
    }

    public void Punicao() {
        Debug.Log("Punição");
        audio2.Play();
        if (move == Vector2.right) {
            move = Vector2.left;
        } else if (move == Vector2.up) {
            move = Vector2.down;
        } else if (move==Vector2.left) {
            move = Vector2.right;
        }
        else if (move == Vector2.down)
        {
            move = Vector2.up;
        }
    }

    public void ReforcoNegativo() {
        audio.Play();
        
        Debug.Log("Reforço");
        for (int i=0;i<5;i++) {
            move = new Vector2((Random.Range(-2,2)), (Random.Range(-2, 2)));
            mouseSprite.transform.rotation = Quaternion.Euler(0,0,Random.rotation.z);
        }
        
    }

    public void ReforcoPositivo()
    {
        Debug.Log("Reforço");

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
}
