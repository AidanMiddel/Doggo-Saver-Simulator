using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int keys;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && VariableCounts.KeyCount > keys)
        {
            VariableCounts.KeyCount--;
            Destroy(gameObject);
        }
    }
}
