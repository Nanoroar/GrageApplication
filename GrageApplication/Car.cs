namespace GrageApplication
{
    public class Car :Vehicle
    {
        public Car (string regnr,int parkingNumber, string color, VehicleTypes Type, int numofpassengers, int numofwheels, bool withcabriolet) :
            base(regnr,parkingNumber, color, Type, numofpassengers, numofwheels, withcabriolet)
        {

        }

        //public override string ToString()
        //{
        //    return $"{Type.ToString()} {regNr} {color} parking number {parkingNumber}";
        //}
    }
}