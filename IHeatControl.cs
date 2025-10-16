namespace OOP
{
    interface IHeatControl
    {
        int HeatLevel { get; set; }
        void SetHeatLevel(int level);
    }
}