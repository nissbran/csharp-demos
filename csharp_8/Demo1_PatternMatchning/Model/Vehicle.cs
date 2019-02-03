using System;

namespace Demo1_PatternMatching.Model
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

        public string Description => this switch
        {
            Truck truck when truck.IsEnviromentFriendly => $"Enviroment friendly truck that weights {truck.Weight} kg",
            Truck truck when !truck.IsEnviromentFriendly => $"Regular truck that weights {truck.Weight} kg",
            Vehicle vehicle => $"Vehicle that weights {vehicle.Weight} kg",
            _ => string.Empty
        };







        public RegistrationState RegistrationState { get; private set; } = RegistrationState.New;

        // Tuple patterns (State machine)
        public void ChangeRegistration(RegistrationAction action)
        {
            RegistrationState = (RegistrationState, action) switch
            {
                (RegistrationState.New, RegistrationAction.Activate) => RegistrationState.Active,
                (RegistrationState.Active, RegistrationAction.Shutdown) => RegistrationState.Shutdown,
                (RegistrationState.Shutdown, RegistrationAction.Activate) => RegistrationState.Active,
                (_, RegistrationAction.Terminate) => RegistrationState.Terminated,
                _ => throw new InvalidOperationException($"Invalid state transistion {RegistrationState} -> {action}")
            };
        }
    }
}
