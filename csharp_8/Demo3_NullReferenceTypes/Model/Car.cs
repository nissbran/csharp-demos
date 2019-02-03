namespace Demo3_NullReferenceTypes.Model
{
    public class Car : Vehicle
    {
        public Car(int weight, bool isEnvironmentFriendly = false)
            : base(weight, isEnvironmentFriendly)
        {
        }
    }
}
