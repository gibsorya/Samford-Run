using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowS : MonoBehaviour
{
    public Transform Target;

    public Transform Player;

    public int Num;

    private void Update()
    {
        if (Target == null)
        {
            return;
        }
        Vector3 dir = Vector3.Normalize(Target.position - Player.position);
        transform.position = dir + Player.position;

        transform.LookAt(Target);
    }

}
