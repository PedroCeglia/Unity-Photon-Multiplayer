using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{

    private CharacterController controller;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        // Get Moviment
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moviment = new Vector3(horizontal, 0f, vertical);
        if(moviment.magnitude != 0)
        {
            controller.Move(moviment * Time.deltaTime *speed);
        }
    }
}
