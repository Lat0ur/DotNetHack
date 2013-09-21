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

public partial class DNHPushService {
  /// <summary>
  /// Description: Service for pushing back information
  /// </summary>
  public interface Iface {
    DNHActionResult Callback(DNHPacket packet);
    #if SILVERLIGHT
    IAsyncResult Begin_Callback(AsyncCallback callback, object state, DNHPacket packet);
    DNHActionResult End_Callback(IAsyncResult asyncResult);
    #endif
  }

  /// <summary>
  /// Description: Service for pushing back information
  /// </summary>
  public class Client : Iface {
    public Client(TProtocol prot) : this(prot, prot)
    {
    }

    public Client(TProtocol iprot, TProtocol oprot)
    {
      iprot_ = iprot;
      oprot_ = oprot;
    }

    protected TProtocol iprot_;
    protected TProtocol oprot_;
    protected int seqid_;

    public TProtocol InputProtocol
    {
      get { return iprot_; }
    }
    public TProtocol OutputProtocol
    {
      get { return oprot_; }
    }


    
    #if SILVERLIGHT
    public IAsyncResult Begin_Callback(AsyncCallback callback, object state, DNHPacket packet)
    {
      return send_Callback(callback, state, packet);
    }

    public DNHActionResult End_Callback(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_Callback();
    }

    #endif

    public DNHActionResult Callback(DNHPacket packet)
    {
      #if !SILVERLIGHT
      send_Callback(packet);
      return recv_Callback();

      #else
      var asyncResult = Begin_Callback(null, null, packet);
      return End_Callback(asyncResult);

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_Callback(AsyncCallback callback, object state, DNHPacket packet)
    #else
    public void send_Callback(DNHPacket packet)
    #endif
    {
      oprot_.WriteMessageBegin(new TMessage("Callback", TMessageType.Call, seqid_));
      Callback_args args = new Callback_args();
      args.Packet = packet;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      #if SILVERLIGHT
      return oprot_.Transport.BeginFlush(callback, state);
      #else
      oprot_.Transport.Flush();
      #endif
    }

    public DNHActionResult recv_Callback()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      Callback_result result = new Callback_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.success) {
        return result.Success;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "Callback failed: unknown result");
    }

  }
  public class Processor : TProcessor {
    public Processor(Iface iface)
    {
      iface_ = iface;
      processMap_["Callback"] = Callback_Process;
    }

    protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
    private Iface iface_;
    protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

    public bool Process(TProtocol iprot, TProtocol oprot)
    {
      try
      {
        TMessage msg = iprot.ReadMessageBegin();
        ProcessFunction fn;
        processMap_.TryGetValue(msg.Name, out fn);
        if (fn == null) {
          TProtocolUtil.Skip(iprot, TType.Struct);
          iprot.ReadMessageEnd();
          TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
          oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
          x.Write(oprot);
          oprot.WriteMessageEnd();
          oprot.Transport.Flush();
          return true;
        }
        fn(msg.SeqID, iprot, oprot);
      }
      catch (IOException)
      {
        return false;
      }
      return true;
    }

    public void Callback_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      Callback_args args = new Callback_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      Callback_result result = new Callback_result();
      result.Success = iface_.Callback(args.Packet);
      oprot.WriteMessageBegin(new TMessage("Callback", TMessageType.Reply, seqid)); 
      result.Write(oprot);
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Callback_args : TBase
  {
    private DNHPacket _packet;

    public DNHPacket Packet
    {
      get
      {
        return _packet;
      }
      set
      {
        __isset.packet = true;
        this._packet = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool packet;
    }

    public Callback_args() {
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
            if (field.Type == TType.Struct) {
              Packet = new DNHPacket();
              Packet.Read(iprot);
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
      TStruct struc = new TStruct("Callback_args");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Packet != null && __isset.packet) {
        field.Name = "packet";
        field.Type = TType.Struct;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        Packet.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Callback_args(");
      sb.Append("Packet: ");
      sb.Append(Packet== null ? "<null>" : Packet.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Callback_result : TBase
  {
    private DNHActionResult _success;

    public DNHActionResult Success
    {
      get
      {
        return _success;
      }
      set
      {
        __isset.success = true;
        this._success = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool success;
    }

    public Callback_result() {
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
          case 0:
            if (field.Type == TType.Struct) {
              Success = new DNHActionResult();
              Success.Read(iprot);
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
      TStruct struc = new TStruct("Callback_result");
      oprot.WriteStructBegin(struc);
      TField field = new TField();

      if (this.__isset.success) {
        if (Success != null) {
          field.Name = "Success";
          field.Type = TType.Struct;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          Success.Write(oprot);
          oprot.WriteFieldEnd();
        }
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Callback_result(");
      sb.Append("Success: ");
      sb.Append(Success== null ? "<null>" : Success.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}
