using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShotsFired : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _rateOfFire;

    void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var firingDirection = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + firingDirection, Quaternion.identity);

            newBullet.transform.up = firingDirection;
            newBullet.velocity = firingDirection * _speed;

            yield return new WaitForSeconds(_rateOfFire);
        }
    }
}