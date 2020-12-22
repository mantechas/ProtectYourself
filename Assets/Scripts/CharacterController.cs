using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Transform Character;
    private bool RotateLeft = false;
    private bool RotateRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RotateLeft)
        {
            Character.Rotate(new Vector3(0, 0, 3));
        }
        else if(RotateRight)
        {
            Character.Rotate(new Vector3(0, 0, -3));
        }
    }

    public void RotateLeftEntered()
    {
        RotateLeft = true;
    }

    public void RotateRightEntered()
    {
        RotateRight = true;
    }

    public void RotateLeftLeft()
    {
        RotateLeft = false;
    }

    public void RotateRightLeft()
    {
        RotateRight = false;
    }
}
