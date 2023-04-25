namespace Assets.Scripts
{
    public interface IConf
    {
        public int Speed { get; }
        public int MaxHealth { get; }

        public int MaxAttempts { get; }

        public int RecoveryTime { get; }

        public int ShotForce { get; }

        public float Armor { get; }

        public int BonusDuration { get; }
    }
}
