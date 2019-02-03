namespace Demo3_NullReferenceTypes.Model
{
    public abstract class Vehicle
    {
        public int Weight { get; }
        public bool IsEnviromentFriendly { get; }

        protected Vehicle(int weight, bool isEnvironmentFriendly = false)
        {
            Weight = weight;
            IsEnviromentFriendly = isEnvironmentFriendly;
        }
    }
}
