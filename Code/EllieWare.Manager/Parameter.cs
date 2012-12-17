
namespace EllieWare.Manager
{
  public class Parameter : IParameter
  {
    public string DisplayName { get; set; }
    public object ParameterValue { get; set; }
    public string Summary
    {
      get
      {
        // TODO   support other data types ie number, array of string aka object
        // TODO   use CultureInfo.InvariantCulture for numbers
        return DisplayName + " --> " + ParameterValue;
      }
    }

    public Parameter(string name, object value)
    {
      DisplayName = name;
      ParameterValue = value;
    }
  }
}
