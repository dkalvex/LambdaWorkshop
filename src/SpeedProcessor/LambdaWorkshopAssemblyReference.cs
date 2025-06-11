using System.Reflection;
namespace LambdaWorkshop.SpeedProcessor;

public static class LambdaWorkshopAssemblyReference
{
    public static Assembly Assembly { get; } = typeof(LambdaWorkshopAssemblyReference).Assembly;
}