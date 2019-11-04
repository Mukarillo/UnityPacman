using PacEngine.characters;
using DG.Tweening;

public class PacmanView : AbstractCharacterView
{
    private const string ANIMATOR_DIE = "Die";
    private const string ANIMATOR_WALK = "Walk";

    private Pacman EnginePacmanCharacter => (Pacman)EngineCharacter;

    public override void LinkEngineCharacter(AbstractCharacter engineCharacter)
    {
        base.LinkEngineCharacter(engineCharacter);
        EnginePacmanCharacter.OnDie += Die;
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
