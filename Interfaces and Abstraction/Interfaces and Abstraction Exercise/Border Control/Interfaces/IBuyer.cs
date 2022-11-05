namespace Border_Control.Interfaces
{

    public interface IBuyer : IPerson
    {
        public void BuyFood();

        public int Food { get; set; }
    }
}
