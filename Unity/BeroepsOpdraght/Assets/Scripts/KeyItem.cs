using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
<<<<<<< HEAD
            VariableCounts.KeyCount -= 1;
=======
            VariableCounts.KeyCount += 2;
>>>>>>> db90669e353e2fb89c5439f76e86ac111287b57a
            Destroy(gameObject);
        }
    }
}
