﻿
namespace EllieWare.Manager
{
  public interface IParameter
  {
    string DisplayName { get; set; }
    object ParameterValue { get; set; }
    string Summary { get; }
  }
}