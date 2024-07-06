using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode right = KeyCode.D;
    public Vector2 InputVector => inputVector;
    private Vector2 inputVector;


    private float xInput;
    private float yInput;

    //“ü—Í‚É‘Î‚µ‚Ä‚Ìˆ—
    public void HandleInput()
    {
        //debug—p
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(1);

        xInput = 0;
        yInput = 0;

        /*
        if (Input.GetKey(forward))
        {
            zInput++;
        }

        if (Input.GetKey(back))
        {
            zInput--;
        }
        */
        if (Input.GetKey(left))
        {
            xInput--;
        }

        if (Input.GetKey(right))
        {
            xInput++;
        }


        inputVector = new Vector2(xInput, yInput);

    }

    private void Update()
    {
        HandleInput();
    }
}
