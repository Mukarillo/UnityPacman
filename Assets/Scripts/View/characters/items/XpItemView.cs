using PacEngine;
using PacEngine.characters;
using UnityEngine;

namespace Assets.Scripts.View.characters.items
{
    public class XpItemView:AbstractCharacterView
    {
        
        [SerializeField] private Animator currentAnimator;
        protected override void Awake()
        {
            animator = currentAnimator;
            animatorSpeed = animator.speed;
        }

        public override void LinkEngineCharacter(AbstractCharacter engineCharacter)
        {
            base.LinkEngineCharacter(engineCharacter);
            PacmanEngine.OnDropItem += SpawnItem;
        }

        private void SpawnItem()
        {
            Debug.LogWarning("[View] Spawn Item");
            gameObject.SetActive(true);
        }
    }
}
