/**
 * Autogenerated by Thrift Compiler (0.9.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;


#if !SILVERLIGHT
[Serializable]
#endif
public partial class DNHObject : TBase
{
  private int _id;
  private ObjectType _type;
  private int _x;
  private int _y;
  private int _z;

  public int Id
  {
    get
    {
      return _id;
    }
    set
    {
      __isset.id = true;
      this._id = value;
    }
  }

  /// <summary>
  /// 
  /// <seealso cref="ObjectType"/>
  /// </summary>
  public ObjectType Type
  {
    get
    {
      return _type;
    }
    set
    {
      __isset.type = true;
      this._type = value;
    }
  }

  public int X
  {
    get
    {
      return _x;
    }
    set
    {
      __isset.x = true;
      this._x = value;
    }
  }

  public int Y
  {
    get
    {
      return _y;
    }
    set
    {
      __isset.y = true;
      this._y = value;
    }
  }

  public int Z
  {
    get
    {
      return _z;
    }
    set
    {
      __isset.z = true;
      this._z = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool id;
    public bool type;
    public bool x;
    public bool y;
    public bool z;
  }

  public DNHObject() {
  }

  public void Read (TProtocol iprot)
  {
    TField field;
    iprot.ReadStructBegin();
    while (true)
    {
      field = iprot.ReadFieldBegin();
      if (field.Type == TType.Stop) { 
        break;
      }
      switch (field.ID)
      {
        case 1:
          if (field.Type == TType.I32) {
            Id = iprot.ReadI32();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        case 2:
          if (field.Type == TType.I32) {
            Type = (ObjectType)iprot.ReadI32();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        case 3:
          if (field.Type == TType.I32) {
            X = iprot.ReadI32();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        case 4:
          if (field.Type == TType.I32) {
            Y = iprot.ReadI32();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        case 5:
          if (field.Type == TType.I32) {
            Z = iprot.ReadI32();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        default: 
          TProtocolUtil.Skip(iprot, field.Type);
          break;
      }
      iprot.ReadFieldEnd();
    }
    iprot.ReadStructEnd();
  }

  public void Write(TProtocol oprot) {
    TStruct struc = new TStruct("DNHObject");
    oprot.WriteStructBegin(struc);
    TField field = new TField();
    if (__isset.id) {
      field.Name = "id";
      field.Type = TType.I32;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32(Id);
      oprot.WriteFieldEnd();
    }
    if (__isset.type) {
      field.Name = "type";
      field.Type = TType.I32;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32((int)Type);
      oprot.WriteFieldEnd();
    }
    if (__isset.x) {
      field.Name = "x";
      field.Type = TType.I32;
      field.ID = 3;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32(X);
      oprot.WriteFieldEnd();
    }
    if (__isset.y) {
      field.Name = "y";
      field.Type = TType.I32;
      field.ID = 4;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32(Y);
      oprot.WriteFieldEnd();
    }
    if (__isset.z) {
      field.Name = "z";
      field.Type = TType.I32;
      field.ID = 5;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32(Z);
      oprot.WriteFieldEnd();
    }
    oprot.WriteFieldStop();
    oprot.WriteStructEnd();
  }

  public override string ToString() {
    StringBuilder sb = new StringBuilder("DNHObject(");
    sb.Append("Id: ");
    sb.Append(Id);
    sb.Append(",Type: ");
    sb.Append(Type);
    sb.Append(",X: ");
    sb.Append(X);
    sb.Append(",Y: ");
    sb.Append(Y);
    sb.Append(",Z: ");
    sb.Append(Z);
    sb.Append(")");
    return sb.ToString();
  }

}

