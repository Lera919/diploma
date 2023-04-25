using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class LeprConf : IConf
    {
        private const int _maxHealth = 10;
        private const int _speed = 10;
        private const int _maxAttemps = 10;
        private const int _recoveryTime = 10;
        private const int _shotForce = 10;
        private const float _armor = 10;
        private const int _bonusDuration = 10;

        public int MaxHealth => _maxHealth;

        public int Speed => _speed;

        public int MaxAttempts => _maxAttemps;

        public int RecoveryTime => _recoveryTime;

        public int ShotForce => _shotForce;

        public float Armor => _armor;

        public int BonusDuration => _bonusDuration;
    }
}
