using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    private bool moving;

    private void OncollisionEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            moving = true;
            collision.GetComponent<Collider>().transform.SetParent(transform);
        }
    }

    private void OncollisionExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Collider>().transform.SetParent(null);
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
