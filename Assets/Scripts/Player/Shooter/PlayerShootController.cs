﻿using ComBlitz.Player.Data;
using UnityEngine;

namespace ComBlitz.Player.Shooter
{
    [RequireComponent(typeof(Animator))]
    public class PlayerShootController : MonoBehaviour
    {
        public GameObject bullet;
        public float bulletLaunchVelocity;
        public Transform bulletLaunchPoint;
        public GameObject bulletAudioPrefab;

        private Animator playerAnimator;
        private bool stopShooting;

        // Use this for initialization
        private void Start()
        {
            playerAnimator = GetComponent<Animator>();
            stopShooting = false;
        }

        // Update is called once per frame
        private void Update() => PlayerShoot();

        public void ActivateShooting() => stopShooting = false;

        public void DeActivateShooting() => stopShooting = true;

        private void PlayerShoot()
        {
            if (stopShooting)
                return;

            playerAnimator.SetBool(PlayerConstantData.PlayerShootAnimParam, Input.GetMouseButton(0));
        }

        private void ShootBullet()
        {
            GameObject bulletInstance = Instantiate(bullet, bulletLaunchPoint.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody>().velocity = bulletLaunchVelocity * transform.forward;

            GameObject bulletAudioInstance = Instantiate(bulletAudioPrefab, transform.position, Quaternion.identity);
            bulletAudioInstance.transform.SetParent(gameObject.transform);
            Destroy(bulletAudioInstance, 0.6f);
        }
    }
}