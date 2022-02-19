using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private AnimatorController animatorController;

    private PlayerInput input;

    private Vector2 MoveAxis;
    
    [SerializeField]private float velocity;
    void Start()
    {
        animatorController = GetComponentInChildren<AnimatorController>();
        input = new PlayerInput();
        MoveAxis = Vector2.zero;
    }

    
    void FixedUpdate()
    {
        if(Mathf.Abs(MoveAxis.x) != Mathf.Abs(MoveAxis.y))
        transform.position+= new Vector3(MoveAxis.x, MoveAxis.y,0) * velocity * Time.fixedDeltaTime; 
    }

    public void Movement(InputAction.CallbackContext context){
        if(context.performed){
            MoveAxis = (context.ReadValue<Vector2>());
            animatorController.AnimateMovement(MoveAxis);
        }
    }
}
