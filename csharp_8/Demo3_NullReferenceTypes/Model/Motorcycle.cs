namespace Demo3_NullReferenceTypes.Model
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int weight, bool isEnvironmentFriendly = false)
            : base(weight, isEnvironmentFriendly)
        {
        }
    }
}
