using ID.Systems;

namespace ID.Core
{
    public interface IAmPickUp
    {
        int Value { get;  }
        void PickUp(PickUpSystem pickUpSystem);
    }
}