﻿namespace Demo3_NullReferenceTypes.Model
{
    public class Truck : Vehicle
    {
        private const int TruckStandardWeight = 5000;

        public Truck(bool isEnvironmentFriendly = false)
            : base(TruckStandardWeight, isEnvironmentFriendly)
        {
        }
    }
}
