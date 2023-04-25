using UnityEngine;

namespace Assets.Scripts
{
    public sealed class LeprechaunPlayerCharacter : PlayerCharacter
    {
        [SerializeField] private int healthThresholdForIncrease;
        protected override void OnPlayerEat()
        {
            Score++;
            base.OnPlayerEat();
        }

        protected override void OnPlayerHurt(int damage)
        {
            Health -= damage;
            if(Health <= healthThresholdForIncrease)
            {

            }
            base.OnPlayerHurt(damage);
        }

        protected override void OnPlayerShoot()
        {
            if (Attempts <= 0) return;
            Gun.Shoot();
            Attempts--;
            base.OnPlayerShoot();
        }
    }
}
