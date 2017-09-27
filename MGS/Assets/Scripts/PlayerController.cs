using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveState
{
    Idle,
    Walking,
    Running,

}

/// <summary>
/// Author: Andrew Seba
/// Description:Player controller to emulate metal gear solid.
/// </summary>
public class PlayerController : MonoBehaviour {

    [Tooltip("How fast the player will move.")]
    public float moveSpeed = 5f;
    public float rotateSpeed = 0.5f;
    Vector3 joyInput;
    public GameObject playerModel;


    void Update ()
    {
        joyInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    }

    private void FixedUpdate()
    {
        if (joyInput.magnitude > 1)
            joyInput.Normalize();

        transform.position += joyInput * moveSpeed * Time.deltaTime;

        if(joyInput.magnitude != 0)
        {
            float angle = ((Mathf.Atan2(joyInput.z, joyInput.x) * Mathf.Rad2Deg) - 90);
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.down);

            playerModel.transform.rotation = Quaternion.RotateTowards(playerModel.transform.rotation, targetRotation, rotateSpeed);
        }
    }
}
