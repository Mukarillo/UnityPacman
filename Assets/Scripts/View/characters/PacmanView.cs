using PacEngine.characters;
using DG.Tweening;
using PacEngine;
using UnityEngine;

public class PacmanView : AbstractCharacterView
{
    private const string ANIMATOR_DIE = "Die";
    private const string ANIMATOR_WALK = "Walk";

    private Pacman EnginePacmanCharacter => (Pacman)EngineCharacter;

    [SerializeField] private SpriteRenderer spriteSkin;
    public override void LinkEngineCharacter(AbstractCharacter engineCharacter)
    {
        base.LinkEngineCharacter(engineCharacter);
        PacmanEngine.OnDie += Die;
        PacmanEngine.OnEnableSpeedMode += ChangeSkin;
        PacmanEngine.OnDisableSpeedMode += ChangeSkin;
    }

    public void ChangeSkin()
    {
        spriteSkin.color = PacmanEngine.Instance.TurboMode ? Color.red : Color.white;
    }

    protected override void ToggleVisibility(bool active)
    {
        base.ToggleVisibility(active);
        animator.ResetTrigger(ANIMATOR_DIE);
        animator.Play(ANIMATOR_WALK);
    }

    private void Die()
    {
        moveTween?.Kill();

        ResetAnimatorSpeed();
        animator.SetTrigger(ANIMATOR_DIE);
    }
}
