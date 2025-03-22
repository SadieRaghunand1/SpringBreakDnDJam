using UnityEngine;

public class SpriteDirectionalController : MonoBehaviour
{
    [Range(0f,180f)][SerializeField] float backAngle = 65f;
    [Range(0f,180f)][SerializeField] float sideAngle = 155f;
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void LateUpdate()
    {
        Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);

        Vector2 animationDirection = new Vector2(0f, -1f);

        float angle = Mathf.Abs(signedAngle);

        

        if (angle < backAngle)
        {
            //Back
            animationDirection = new Vector2(0f, -1f);
        }
        else if (angle < sideAngle)
        {
            //Side
            //use for flipped side animation
            
            animationDirection = new Vector2(1f, 0f);

            if (signedAngle < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            

            //use for 2 different side animations
            
            /*
            if (signedAngle < 0)
            {
                animationDirection = new Vector2(-1f, 0f);
            }
            else
            {
                animationDirection = new Vector2(1f, 0f);
            }
            */
        }
        else
        {
            //Front
            animationDirection = new Vector2(0f, 1f);
        }

        animator.SetFloat("moveX", animationDirection.x);
        animator.SetFloat("moveY", animationDirection.y);
    }
}
