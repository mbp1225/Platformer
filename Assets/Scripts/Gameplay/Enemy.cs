using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        Analytics.CustomEvent("Enemy Killed");
        Destroy(gameObject);
    }
}
