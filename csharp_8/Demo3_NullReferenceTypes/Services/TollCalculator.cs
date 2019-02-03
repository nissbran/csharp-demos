using Demo3_NullReferenceTypes.Model;

namespace Demo3_NullReferenceTypes.Services
{
    public class TollCalculator
    {
        public decimal Calculate(Vehicle vehicle)
        {
            return vehicle.Weight > 1000 ? 50 : 20;
        }

        public decimal Calculate2(Vehicle? nullableVehicle)
        {
            if (nullableVehicle == null)
                return 0;

            return Calculate(nullableVehicle);
        }
    }
}
