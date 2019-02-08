using System;

namespace Demo1_PatternMatching.Model
{
    public abstract class Vehicle
    {
        public int Weight { get; }
        public bool IsEnvironmentFriendly { get; }

        protected Vehicle(int weight, bool isEnvironmentFriendly = false)
        {
            Weight = weight;
            IsEnvironmentFriendly = isEnvironmentFriendly;
        }

        public string Description => this switch
        {
            Truck truck when truck.IsEnvironmentFriendly => $"Environment friendly truck that weights {truck.Weight} kg",
            Truck truck when !truck.IsEnvironmentFriendly => $"Regular truck that weights {truck.Weight} kg",
            Vehicle vehicle => $"Vehicle that weights {vehicle.Weight} kg",
            _ => string.Empty
        };







        public RegistrationState State { get; private set; } = RegistrationState.New;

        // Tuple patterns (State machine)
        public void ChangeRegistration(RegistrationAction action)
        {
            State = (State, action) switch
            {
                (RegistrationState.New, RegistrationAction.Activate) => RegistrationState.Active,
                (RegistrationState.Active, RegistrationAction.Shutdown) => RegistrationState.Shutdown,
                (RegistrationState.Shutdown, RegistrationAction.Activate) => RegistrationState.Active,
                (_, RegistrationAction.Terminate) => RegistrationState.Terminated,
                _ => throw new InvalidOperationException($"Invalid state transition {State} -> {action}")
            };
        }

        public string RegistrationDescription => this switch
        {
            Truck { State: RegistrationState.New, IsEnvironmentFriendly: true, Weight: var w } _ 
                => $"An new enviroment friendly truck that weights {w} kg",
            Truck { State: RegistrationState.Active, IsEnvironmentFriendly: true, Weight: var w } _
                => $"An active enviroment friendly truck that weights {w} kg",
            Truck { IsEnvironmentFriendly: false } truck => $"Regular truck that weights {truck.Weight} kg",
            _ => string.Empty
        };
    }
}
