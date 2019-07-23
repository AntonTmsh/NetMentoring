using Epam.NetMentoring.Zoo.Animals;

namespace Epam.NetMentoring.Zoo
{
    public interface IAnimalStatusTracker
    {
        void IsInHunger(IAnimal animal);
        void Died(IAnimal animal);
    }
}