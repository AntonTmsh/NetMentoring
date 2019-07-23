using Epam.NetMentoring.Zoo.Animals;

namespace Epam.NetMentoring.Zoo
{
    public interface IAnimalReceiver
    {
        void Receive(IAnimal animal);
    }
}