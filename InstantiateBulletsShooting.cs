using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShotsFired : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _Bullet;
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
            var newBullet = Instantiate(_Bullet, transform.position + firingDirection, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = firingDirection;
            newBullet.GetComponent<Rigidbody>().velocity = firingDirection * _speed;

            yield return new WaitForSeconds(_rateOfFire);
        }
    }
}