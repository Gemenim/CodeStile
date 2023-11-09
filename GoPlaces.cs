using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Transform _goals;

    private Transform[] _arrayGoals;
    private int _indexGoals;

    private void Start()
    {
        _arrayGoals = new Transform[_goals.childCount];

        for (int index = 0; index < _goals.childCount; index++)
            _arrayGoals[index] = _goals.GetChild(index).GetComponent<Transform>();
    }

    private void Update()
    {
        var pointByNumberInArray = _arrayGoals[_indexGoals];
        transform.position = Vector3.MoveTowards(transform.position, pointByNumberInArray.position, _duration * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position) SelectNextGoal();
    }

    public Vector3 SelectNextGoal()
    {
        _indexGoals++;

        if (_indexGoals == _arrayGoals.Length)
            _indexGoals = 0;

        Vector3 thisPointVector = _arrayGoals[_indexGoals].transform.position;
        transform.forward = thisPointVector - transform.position;
        return thisPointVector;
    }
}