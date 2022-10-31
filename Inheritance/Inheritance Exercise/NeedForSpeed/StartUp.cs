namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(200,300);

            sportCar.Drive(20);
        }
    }
}
