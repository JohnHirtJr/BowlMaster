using UnityEngine;

public class Swiper : MonoBehaviour
{

    private Animator anim;
	void Start ()
	{

	}
	

	void Update () {
	
	}

    public void IsSwiping()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("SwipeBool", true);
    }

}
