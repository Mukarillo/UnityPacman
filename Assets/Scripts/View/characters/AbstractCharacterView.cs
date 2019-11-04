using PacEngine.characters;
using PacEngine.utils;
using UnityEngine;
using DG.Tweening;

public abstract class AbstractCharacterView : MonoBehaviour
{
    private const string ANIMTOR_X_VELOCITY = "xVelocity";
    private const string ANIMTOR_Y_VELOCITY = "yVelocity";

    public AbstractCharacter EngineCharacter { get; private set; }

    protected Tween moveTween;
    protected Animator animator;
    private float animatorSpeed;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        animatorSpeed = animator.speed;
    }

    public virtual void LinkEngineCharacter(AbstractCharacter engineCharacter)
    {
        EngineCharacter = engineCharacter;
        engineCharacter.OnMove += Move;
        engineCharacter.OnTeleport += Teleport;
        engineCharacter.OnToggleVisibility += ToggleVisibility;
    }

    protected virtual void ToggleVisibility(bool active)
    {
        gameObject.SetActive(active);
    }

    public virtual void Move(Vector position)
    {
        moveTween?.Kill();

        animator.SetFloat(ANIMTOR_X_VELOCITY, EngineCharacter.HeadingDirection.x);
        animator.SetFloat(ANIMTOR_Y_VELOCITY, EngineCharacter.HeadingDirection.y);
        ResetAnimatorSpeed();
        moveTween = transform.DOLocalMove(new Vector3(position.y, position.x), EngineCharacter.TimeToTravelOneTile)
            .SetEase(Ease.Linear)
            .OnComplete( () => {
                animator.speed = 0;
                EngineCharacter.DoneViewMove();
            });
    }

    protected void ResetAnimatorSpeed()
    {
        animator.speed = animatorSpeed;
    }

    public virtual void Teleport(Vector position)
    {
        transform.localPosition = new Vector3(position.y, position.x);
        EngineCharacter.DoneViewMove();
    }
}
