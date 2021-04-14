using UnityEngine;

public class TheFoots : MonoBehaviour
{
    PlayerControler playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponentInParent<PlayerControler>();
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = other.transform;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }
}
