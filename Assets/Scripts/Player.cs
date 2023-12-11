using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float lineLength;
    [SerializeField] float offset;
    [SerializeField] bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //movimiento
        GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * Input.GetAxisRaw("Horizontal"), GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetAxisRaw("Horizontal") == 1) GetComponent<SpriteRenderer>().flipX = false;
        if (Input.GetAxisRaw("Horizontal") == -1) GetComponent<SpriteRenderer>().flipX = true;
       //salto
        if (Input.GetButtonDown("Fire1") && !isJumping)  
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //linea debajo de muñeco
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - offset);
        Vector2 target = new Vector2 (transform.position.x, transform.position.y - offset - lineLength);
        Debug.DrawLine(origin, target, Color.black);
        //Raycast linea
        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.down, lineLength);
        //Detectar colision Raycast
        if (raycast.collider == null) isJumping = true;
        else isJumping = false;


    }
}
