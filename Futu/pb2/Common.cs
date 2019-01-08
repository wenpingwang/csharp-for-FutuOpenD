// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: Common.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace Common {

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public static partial class Common {

    #region Extension registration
    public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
    }
    #endregion
    #region Static variables
    internal static pbd::MessageDescriptor internal__static_Common_PacketID__Descriptor;
    internal static pb::FieldAccess.FieldAccessorTable<global::Common.PacketID, global::Common.PacketID.Builder> internal__static_Common_PacketID__FieldAccessorTable;
    #endregion
    #region Descriptor
    public static pbd::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbd::FileDescriptor descriptor;

    static Common() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxDb21tb24ucHJvdG8SBkNvbW1vbiIsCghQYWNrZXRJRBIOCgZjb25uSUQY", 
            "ASACKAQSEAoIc2VyaWFsTm8YAiACKA0qdwoHUmV0VHlwZRITCg9SZXRUeXBl", 
            "X1N1Y2NlZWQQABIbCg5SZXRUeXBlX0ZhaWxlZBD///////////8BEhwKD1Jl", 
            "dFR5cGVfVGltZU91dBCc//////////8BEhwKD1JldFR5cGVfVW5rbm93bhDw", 
          "/P////////8B"));
      pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
        descriptor = root;
        internal__static_Common_PacketID__Descriptor = Descriptor.MessageTypes[0];
        internal__static_Common_PacketID__FieldAccessorTable = 
            new pb::FieldAccess.FieldAccessorTable<global::Common.PacketID, global::Common.PacketID.Builder>(internal__static_Common_PacketID__Descriptor,
                new string[] { "ConnID", "SerialNo", });
        pb::ExtensionRegistry registry = pb::ExtensionRegistry.CreateInstance();
        RegisterAllExtensions(registry);
        return registry;
      };
      pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
          new pbd::FileDescriptor[] {
          }, assigner);
    }
    #endregion

  }
  #region Enums
  public enum RetType {
    RetType_Succeed = 0,
    RetType_Failed = -1,
    RetType_TimeOut = -100,
    RetType_Unknown = -400,
  }

  #endregion

  #region Messages
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class PacketID : pb::GeneratedMessage<PacketID, PacketID.Builder> {
    private PacketID() { }
    private static readonly PacketID defaultInstance = new PacketID().MakeReadOnly();
    private static readonly string[] _packetIDFieldNames = new string[] { "connID", "serialNo" };
    private static readonly uint[] _packetIDFieldTags = new uint[] { 8, 16 };
    public static PacketID DefaultInstance {
      get { return defaultInstance; }
    }

    public override PacketID DefaultInstanceForType {
      get { return DefaultInstance; }
    }

    protected override PacketID ThisMessage {
      get { return this; }
    }

    public static pbd::MessageDescriptor Descriptor {
      get { return global::Common.Common.internal__static_Common_PacketID__Descriptor; }
    }

    protected override pb::FieldAccess.FieldAccessorTable<PacketID, PacketID.Builder> InternalFieldAccessors {
      get { return global::Common.Common.internal__static_Common_PacketID__FieldAccessorTable; }
    }

    public const int ConnIDFieldNumber = 1;
    private bool hasConnID;
    private ulong connID_;
    public bool HasConnID {
      get { return hasConnID; }
    }
    public ulong ConnID {
      get { return connID_; }
    }

    public const int SerialNoFieldNumber = 2;
    private bool hasSerialNo;
    private uint serialNo_;
    public bool HasSerialNo {
      get { return hasSerialNo; }
    }
    public uint SerialNo {
      get { return serialNo_; }
    }

    public override bool IsInitialized {
      get {
        if (!hasConnID) return false;
        if (!hasSerialNo) return false;
        return true;
      }
    }

    public override void WriteTo(pb::ICodedOutputStream output) {
      CalcSerializedSize();
      string[] field_names = _packetIDFieldNames;
      if (hasConnID) {
        output.WriteUInt64(1, field_names[0], ConnID);
      }
      if (hasSerialNo) {
        output.WriteUInt32(2, field_names[1], SerialNo);
      }
      UnknownFields.WriteTo(output);
    }

    private int memoizedSerializedSize = -1;
    public override int SerializedSize {
      get {
        int size = memoizedSerializedSize;
        if (size != -1) return size;
        return CalcSerializedSize();
      }
    }

    private int CalcSerializedSize() {
      int size = memoizedSerializedSize;
      if (size != -1) return size;

      size = 0;
      if (hasConnID) {
        size += pb::CodedOutputStream.ComputeUInt64Size(1, ConnID);
      }
      if (hasSerialNo) {
        size += pb::CodedOutputStream.ComputeUInt32Size(2, SerialNo);
      }
      size += UnknownFields.SerializedSize;
      memoizedSerializedSize = size;
      return size;
    }
    public static PacketID ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static PacketID ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static PacketID ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static PacketID ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static PacketID ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static PacketID ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static PacketID ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static PacketID ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static PacketID ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static PacketID ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private PacketID MakeReadOnly() {
      return this;
    }

    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(PacketID prototype) {
      return new Builder(prototype);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class Builder : pb::GeneratedBuilder<PacketID, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(PacketID cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }

      private bool resultIsReadOnly;
      private PacketID result;

      private PacketID PrepareBuilder() {
        if (resultIsReadOnly) {
          PacketID original = result;
          result = new PacketID();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }

      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }

      protected override PacketID MessageBeingBuilt {
        get { return PrepareBuilder(); }
      }

      public override Builder Clear() {
        result = DefaultInstance;
        resultIsReadOnly = true;
        return this;
      }

      public override Builder Clone() {
        if (resultIsReadOnly) {
          return new Builder(result);
        } else {
          return new Builder().MergeFrom(result);
        }
      }

      public override pbd::MessageDescriptor DescriptorForType {
        get { return global::Common.PacketID.Descriptor; }
      }

      public override PacketID DefaultInstanceForType {
        get { return global::Common.PacketID.DefaultInstance; }
      }

      public override PacketID BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }

      public override Builder MergeFrom(pb::IMessage other) {
        if (other is PacketID) {
          return MergeFrom((PacketID) other);
        } else {
          base.MergeFrom(other);
          return this;
        }
      }

      public override Builder MergeFrom(PacketID other) {
        if (other == global::Common.PacketID.DefaultInstance) return this;
        PrepareBuilder();
        if (other.HasConnID) {
          ConnID = other.ConnID;
        }
        if (other.HasSerialNo) {
          SerialNo = other.SerialNo;
        }
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override Builder MergeFrom(pb::ICodedInputStream input) {
        return MergeFrom(input, pb::ExtensionRegistry.Empty);
      }

      public override Builder MergeFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
        PrepareBuilder();
        pb::UnknownFieldSet.Builder unknownFields = null;
        uint tag;
        string field_name;
        while (input.ReadTag(out tag, out field_name)) {
          if(tag == 0 && field_name != null) {
            int field_ordinal = global::System.Array.BinarySearch(_packetIDFieldNames, field_name, global::System.StringComparer.Ordinal);
            if(field_ordinal >= 0)
              tag = _packetIDFieldTags[field_ordinal];
            else {
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              continue;
            }
          }
          switch (tag) {
            case 0: {
              throw pb::InvalidProtocolBufferException.InvalidTag();
            }
            default: {
              if (pb::WireFormat.IsEndGroupTag(tag)) {
                if (unknownFields != null) {
                  this.UnknownFields = unknownFields.Build();
                }
                return this;
              }
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              break;
            }
            case 8: {
              result.hasConnID = input.ReadUInt64(ref result.connID_);
              break;
            }
            case 16: {
              result.hasSerialNo = input.ReadUInt32(ref result.serialNo_);
              break;
            }
          }
        }

        if (unknownFields != null) {
          this.UnknownFields = unknownFields.Build();
        }
        return this;
      }


      public bool HasConnID {
        get { return result.hasConnID; }
      }
      public ulong ConnID {
        get { return result.ConnID; }
        set { SetConnID(value); }
      }
      public Builder SetConnID(ulong value) {
        PrepareBuilder();
        result.hasConnID = true;
        result.connID_ = value;
        return this;
      }
      public Builder ClearConnID() {
        PrepareBuilder();
        result.hasConnID = false;
        result.connID_ = 0UL;
        return this;
      }

      public bool HasSerialNo {
        get { return result.hasSerialNo; }
      }
      public uint SerialNo {
        get { return result.SerialNo; }
        set { SetSerialNo(value); }
      }
      public Builder SetSerialNo(uint value) {
        PrepareBuilder();
        result.hasSerialNo = true;
        result.serialNo_ = value;
        return this;
      }
      public Builder ClearSerialNo() {
        PrepareBuilder();
        result.hasSerialNo = false;
        result.serialNo_ = 0;
        return this;
      }
    }
    static PacketID() {
      object.ReferenceEquals(global::Common.Common.Descriptor, null);
    }
  }

  #endregion

}

#endregion Designer generated code