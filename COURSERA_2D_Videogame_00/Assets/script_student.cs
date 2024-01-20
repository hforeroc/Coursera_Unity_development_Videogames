using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class control_student : MonoBehaviour 
{
    public float vel = 1f;
    public int symbol = -1;
    private BoxCollider bxCol_right_wall;
    private BoxCollider bxCol_left_wall;

    float _horizontal = 0;
    public float speed = 1f;
    public Rigidbody _RigidBody;
    public Animator _Animator;

    // Start is called before the first frame update
    void Start()
    {
        _RigidBody = GetComponent<Rigidbody> ();

        // Obtener la referencia al BoxCollider del objeto "invisibleleftwall"
        GameObject student_idle_left_wall = GameObject.Find("student_idle_left_wall");
        GameObject student_idle_right_wall = GameObject.Find("student_idle_right_wall");

        // Verificar si se encontró el objeto "invisibleleftwall"
        if (student_idle_left_wall != null | student_idle_left_wall != null)
        {
            // Obtener la referencia al BoxCollider
            bxCol_left_wall = student_idle_left_wall.GetComponent<BoxCollider>();
            bxCol_right_wall = student_idle_right_wall.GetComponent<BoxCollider>();

            // Inicializacion del collider Izquierdo
            bxCol_left_wall.enabled = true;

            // Verificar si se encontró el BoxCollider
            if (bxCol_left_wall == null | bxCol_right_wall == null)
            {
                Debug.LogError("No se encontraron los BoxCollider para Idle de Student.");
            }
        }
        else
        {
            Debug.LogError("No se encontraron los BoxCollider para Idle de Student.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vel_x = new Vector2 (vel, _RigidBody.velocity.y);
        _RigidBody.velocity = vel_x;
        _Animator.SetFloat("Anim_Speed", Mathf.Abs(vel_x.x));
    }

    private void OnTriggerEnter(Collider other)
    { 
        Flip();
        symbol = symbol * -1;
    }
    void Flip()
    {

        if (symbol == -1) 
        {
            bxCol_left_wall.enabled = false;
            bxCol_right_wall.enabled = true;
        }
        else if (symbol == 1) 
        {
            bxCol_right_wall.enabled = false;
            bxCol_left_wall.enabled = true;
        }

        Vector3 localScale = transform.localScale;
        localScale.x *= symbol;
        vel *= symbol;
    }
}
