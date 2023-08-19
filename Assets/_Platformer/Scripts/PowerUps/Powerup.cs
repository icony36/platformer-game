using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PowerupType
{
    HealthUp,
    AttackUp,
    SpeedUp,
    JumpUp
};

public class Powerup : MonoBehaviour
{
    [SerializeField] private PlayerData playerData; //reference to player data
    [SerializeField] private GameObject buffPrefab;

    [SerializeField] private float value;

    [SerializeField] PowerupType powerupType = new PowerupType();

    [SerializeField] private GameObject jumpUpImage;
    [SerializeField] private GameObject attackUpImage;
    [SerializeField] private GameObject speedUpImage;

    private void Start()
    {
        attackUpImage.gameObject.SetActive(false);
        speedUpImage.gameObject.SetActive(false);
        jumpUpImage.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(powerupType.Equals(PowerupType.HealthUp))
            {
                if(playerData.currentHealth + value > playerData.maxHealth) 
                    playerData.currentHealth = playerData.maxHealth;
                else
                    playerData.currentHealth += (int)value;
            }
            else if(powerupType.Equals(PowerupType.AttackUp))
            {
                playerData.attackDamage += (int)value;

                attackUpImage.gameObject.SetActive(true);
            }
            else if (powerupType.Equals(PowerupType.SpeedUp))
            {
                playerData.baseMoveSpeed += value;
                playerData.currentMoveSpeed += value;

                speedUpImage.gameObject.SetActive(true);
            }
            else if (powerupType.Equals(PowerupType.JumpUp))
            {
                playerData.maxJumps += (int)value;

                jumpUpImage.gameObject.SetActive(true);
            }

            // play vfx
            // play sfx

            Destroy(gameObject);
        }
    }
}
