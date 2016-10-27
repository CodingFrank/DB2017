using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SqlParam
/// </summary>
public class SqlParam
{
    public string Name;
    public object Value;
    public ParameterDirection Direction;
    public SqlParam(string name, object value)
    {
        Name = name;
        Value = value;
    }
    public SqlParam(string name, object value, ParameterDirection direction)
        : this(name, value)
    {
        Direction = direction;
    }
}