using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LeafAnimationManager : MonoBehaviour
{
    public GameObject leaf;  // The leaf image
    public float animationDuration = 1.0f;  // Duration for all animations
    public Ease easing = Ease.InOutQuad;  // Ease type for smooth animations

    // Animation configurations
    public Vector3 flyUpPosition = new Vector3(0, 300, 0);  // Fly up position
    public Vector3 swingLeftRotation = new Vector3(0, 0, 15);  // Swing left rotation
    public Vector3 swingRightRotation = new Vector3(0, 0, -15);  // Swing right rotation
    public Vector3 slideDownPosition = new Vector3(0, -300, 0);  // Slide down position
    public Vector3 jiggleStrength = new Vector3(20, 20, 0);  // Jiggle strength for shake
    public float jiggleDuration = 1.5f;  // Duration for jiggle effect

    // States to track if animations are active
    private bool isZoomedIn = false;
    private bool isFlyingUp = false;
    private bool isSwingingLeft = false;
    private bool isSwingingRight = false;
    private bool isSlidingDown = false;
    private bool isJiggling = false;

    // Zoom In/Out toggle animation
    public Vector3 zoomedInScale = new Vector3(2f, 2f, 2f);
    public void ZoomLeaf()
    {
        if (isZoomedIn)
        {
            leaf.transform.DOScale(Vector3.one, animationDuration).SetEase(easing);
            isZoomedIn = false;
        }
        else
        {
            leaf.transform.DOScale(zoomedInScale, animationDuration).SetEase(easing);
            isZoomedIn = true;
        }
    }

    // Fly up toggle animation
    public void FlyUpLeaf()
    {
        if (isFlyingUp)
        {
            leaf.transform.DOLocalMove(Vector3.zero, animationDuration).SetEase(easing);
            isFlyingUp = false;
        }
        else
        {
            leaf.transform.DOLocalMove(flyUpPosition, animationDuration).SetEase(easing);
            isFlyingUp = true;
        }
    }

    // Swing left toggle animation
    public void SwingLeftLeaf()
    {
        if (isSwingingLeft)
        {
            leaf.transform.DOLocalRotate(Vector3.zero, animationDuration, RotateMode.FastBeyond360).SetEase(easing);
            isSwingingLeft = false;
        }
        else
        {
            leaf.transform.DOLocalRotate(swingLeftRotation, animationDuration, RotateMode.FastBeyond360).SetEase(easing);
            isSwingingLeft = true;
        }
    }

    // Swing right toggle animation
    public void SwingRightLeaf()
    {
        if (isSwingingRight)
        {
            leaf.transform.DOLocalRotate(Vector3.zero, animationDuration, RotateMode.FastBeyond360).SetEase(easing);
            isSwingingRight = false;
        }
        else
        {
            leaf.transform.DOLocalRotate(swingRightRotation, animationDuration, RotateMode.FastBeyond360).SetEase(easing);
            isSwingingRight = true;
        }
    }

    // Slide down toggle animation
    public void SlideDownLeaf()
    {
        if (isSlidingDown)
        {
            leaf.transform.DOLocalMove(Vector3.zero, animationDuration).SetEase(easing);
            isSlidingDown = false;
        }
        else
        {
            leaf.transform.DOLocalMove(slideDownPosition, animationDuration).SetEase(easing);
            isSlidingDown = true;
        }
    }

    // Jiggle toggle animation
    public void JiggleLeaf()
    {
        if (isJiggling)
        {
            leaf.transform.DOKill();  // Stop the jiggle animation
            leaf.transform.DOLocalMove(Vector3.zero, animationDuration).SetEase(easing);  // Reset to original position
            isJiggling = false;
        }
        else
        {
            leaf.transform.DOShakePosition(jiggleDuration, jiggleStrength, vibrato: 10, randomness: 90).OnComplete(() => leaf.transform.DOLocalMove(Vector3.zero, animationDuration));
            leaf.transform.DOShakeRotation(jiggleDuration, jiggleStrength, vibrato: 10, randomness: 90);
            isJiggling = true;
        }
    }
}
