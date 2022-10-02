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
        
        move = Vector2.right;
    }

    public void MoverEsquerda() {
        Debug.Log("Esquerda");
        move = Vector2.up;
    }

    public void Punicao() {
        Debug.Log("Punição");
        if (move == Vector2.right) {
            move = Vector2.left;
        } else if (move == Vector2.up) {
            move = Vector2.down;
        } 
    }

    public void Reforco() {
        Debug.Log("Reforço");
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
}
