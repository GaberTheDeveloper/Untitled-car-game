using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [Header("Driving")]
    [SerializeField] private float maxSpeed = 40f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float friction = 0.98f;
    private float velocity = 0f;

    [Header("Turning")]
    [SerializeField] private float maxRotation = 10f;
    [SerializeField] private float turnSpeed = 12f;
    private float rotation = 0f;

    [Header("Boost")]
    [SerializeField] private float boostMultiplier = 1.5f;
    [SerializeField] private float boostDuration = 2f;
    [SerializeField] private float boostCooldown = 5f;
    private bool isBoosting = false;
    private float boostTimer = 0f;
    private float boostCooldownTimer = 0f;


    private void Update()
    {
        MoveCar();
        TurnCar();
    }

    private void MoveCar()
    {
        // First increase or decrease velocity
        if (Input.GetKey(KeyCode.W))
        {
            velocity -= acceleration;
            if (velocity <= maxSpeed) velocity = -maxSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity += acceleration;
            if (velocity >= maxSpeed) velocity = maxSpeed;
        }
        else
        {
            // Apply some friction to slow the car down when no input
            velocity *= friction;
        }

        HandleBoost();

        // Then move the car equal to velocity
        transform.Translate(Vector3.forward * Time.deltaTime * velocity);
    }

    private void HandleBoost()
    {
        if (isBoosting)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0f)
            {
                isBoosting = false;
                boostCooldownTimer = boostCooldown; // Start cooldown
            }
        }
        else
        {
            if (boostCooldownTimer > 0f)
            {
                boostCooldownTimer -= Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftShift) && boostCooldownTimer <= 0f)
            {
                isBoosting = true;
                boostTimer = boostDuration;
            }
        }

        if (isBoosting)
        {
            velocity *= boostMultiplier;
        }
    }

    private void TurnCar()
    {
        // Reset rotation each frame
        rotation = 0f;

        // Increase or decrease rotation based on input
        if (Input.GetKey(KeyCode.D))
        {
            rotation -= turnSpeed * (velocity / maxSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rotation += turnSpeed * (velocity / maxSpeed);
        }

        // Rotate the car equal to rotation, applying Time.deltaTime
        transform.Rotate(0, rotation * Time.deltaTime * maxRotation, 0);
    }
}
