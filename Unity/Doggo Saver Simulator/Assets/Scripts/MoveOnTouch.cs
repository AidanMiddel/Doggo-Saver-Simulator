using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    private bool moving;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("test");
            moving = true;
            collision.gameObject.transform.parent = transform;
            /*collision.GetComponent<Collision.game>().transform.SetParent(transform);*/
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            //collision.GetComponent<Collider>().transform.SetParent(null);
            collision.gameObject.transform.parent = (null);
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }
}
