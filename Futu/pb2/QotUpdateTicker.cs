// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: Qot_UpdateTicker.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace Qot_UpdateTicker {

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public static partial class QotUpdateTicker {

    #region Extension registration
    public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
    }
    #endregion
    #region Static variables
    internal static pbd::MessageDescriptor internal__static_Qot_UpdateTicker_S2C__Descriptor;
    internal static pb::FieldAccess.FieldAccessorTable<global::Qot_UpdateTicker.S2C, global::Qot_UpdateTicker.S2C.Builder> internal__static_Qot_UpdateTicker_S2C__FieldAccessorTable;
    internal static pbd::MessageDescriptor internal__static_Qot_UpdateTicker_Response__Descriptor;
    internal static pb::FieldAccess.FieldAccessorTable<global::Qot_UpdateTicker.Response, global::Qot_UpdateTicker.Response.Builder> internal__static_Qot_UpdateTicker_Response__FieldAccessorTable;
    #endregion
    #region Descriptor
    public static pbd::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbd::FileDescriptor descriptor;

    static QotUpdateTicker() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZRb3RfVXBkYXRlVGlja2VyLnByb3RvEhBRb3RfVXBkYXRlVGlja2VyGgxD", 
            "b21tb24ucHJvdG8aEFFvdF9Db21tb24ucHJvdG8iVQoDUzJDEiYKCHNlY3Vy", 
            "aXR5GAEgAigLMhQuUW90X0NvbW1vbi5TZWN1cml0eRImCgp0aWNrZXJMaXN0", 
            "GAIgAygLMhIuUW90X0NvbW1vbi5UaWNrZXIiZgoIUmVzcG9uc2USFQoHcmV0", 
            "VHlwZRgBIAIoBToELTQwMBIOCgZyZXRNc2cYAiABKAkSDwoHZXJyQ29kZRgD", 
          "IAEoBRIiCgNzMmMYBCABKAsyFS5Rb3RfVXBkYXRlVGlja2VyLlMyQw=="));
      pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
        descriptor = root;
        internal__static_Qot_UpdateTicker_S2C__Descriptor = Descriptor.MessageTypes[0];
        internal__static_Qot_UpdateTicker_S2C__FieldAccessorTable = 
            new pb::FieldAccess.FieldAccessorTable<global::Qot_UpdateTicker.S2C, global::Qot_UpdateTicker.S2C.Builder>(internal__static_Qot_UpdateTicker_S2C__Descriptor,
                new string[] { "Security", "TickerList", });
        internal__static_Qot_UpdateTicker_Response__Descriptor = Descriptor.MessageTypes[1];
        internal__static_Qot_UpdateTicker_Response__FieldAccessorTable = 
            new pb::FieldAccess.FieldAccessorTable<global::Qot_UpdateTicker.Response, global::Qot_UpdateTicker.Response.Builder>(internal__static_Qot_UpdateTicker_Response__Descriptor,
                new string[] { "RetType", "RetMsg", "ErrCode", "S2C", });
        pb::ExtensionRegistry registry = pb::ExtensionRegistry.CreateInstance();
        RegisterAllExtensions(registry);
        global::Common.Common.RegisterAllExtensions(registry);
        global::Qot_Common.QotCommon.RegisterAllExtensions(registry);
        return registry;
      };
      pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
          new pbd::FileDescriptor[] {
          global::Common.Common.Descriptor, 
          global::Qot_Common.QotCommon.Descriptor, 
          }, assigner);
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class S2C : pb::GeneratedMessage<S2C, S2C.Builder> {
    private S2C() { }
    private static readonly S2C defaultInstance = new S2C().MakeReadOnly();
    private static readonly string[] _s2CFieldNames = new string[] { "security", "tickerList" };
    private static readonly uint[] _s2CFieldTags = new uint[] { 10, 18 };
    public static S2C DefaultInstance {
      get { return defaultInstance; }
    }

    public override S2C DefaultInstanceForType {
      get { return DefaultInstance; }
    }

    protected override S2C ThisMessage {
      get { return this; }
    }

    public static pbd::MessageDescriptor Descriptor {
      get { return global::Qot_UpdateTicker.QotUpdateTicker.internal__static_Qot_UpdateTicker_S2C__Descriptor; }
    }

    protected override pb::FieldAccess.FieldAccessorTable<S2C, S2C.Builder> InternalFieldAccessors {
      get { return global::Qot_UpdateTicker.QotUpdateTicker.internal__static_Qot_UpdateTicker_S2C__FieldAccessorTable; }
    }

    public const int SecurityFieldNumber = 1;
    private bool hasSecurity;
    private global::Qot_Common.Security security_;
    public bool HasSecurity {
      get { return hasSecurity; }
    }
    public global::Qot_Common.Security Security {
      get { return security_ ?? global::Qot_Common.Security.DefaultInstance; }
    }

    public const int TickerListFieldNumber = 2;
    private pbc::PopsicleList<global::Qot_Common.Ticker> tickerList_ = new pbc::PopsicleList<global::Qot_Common.Ticker>();
    public scg::IList<global::Qot_Common.Ticker> TickerListList {
      get { return tickerList_; }
    }
    public int TickerListCount {
      get { return tickerList_.Count; }
    }
    public global::Qot_Common.Ticker GetTickerList(int index) {
      return tickerList_[index];
    }

    public override bool IsInitialized {
      get {
        if (!hasSecurity) return false;
        if (!Security.IsInitialized) return false;
        foreach (global::Qot_Common.Ticker element in TickerListList) {
          if (!element.IsInitialized) return false;
        }
        return true;
      }
    }

    public override void WriteTo(pb::ICodedOutputStream output) {
      CalcSerializedSize();
      string[] field_names = _s2CFieldNames;
      if (hasSecurity) {
        output.WriteMessage(1, field_names[0], Security);
      }
      if (tickerList_.Count > 0) {
        output.WriteMessageArray(2, field_names[1], tickerList_);
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
      if (hasSecurity) {
        size += pb::CodedOutputStream.ComputeMessageSize(1, Security);
      }
      foreach (global::Qot_Common.Ticker element in TickerListList) {
        size += pb::CodedOutputStream.ComputeMessageSize(2, element);
      }
      size += UnknownFields.SerializedSize;
      memoizedSerializedSize = size;
      return size;
    }
    public static S2C ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static S2C ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static S2C ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static S2C ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static S2C ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static S2C ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static S2C ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static S2C ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static S2C ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static S2C ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private S2C MakeReadOnly() {
      tickerList_.MakeReadOnly();
      return this;
    }

    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(S2C prototype) {
      return new Builder(prototype);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class Builder : pb::GeneratedBuilder<S2C, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(S2C cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }

      private bool resultIsReadOnly;
      private S2C result;

      private S2C PrepareBuilder() {
        if (resultIsReadOnly) {
          S2C original = result;
          result = new S2C();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }

      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }

      protected override S2C MessageBeingBuilt {
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
        get { return global::Qot_UpdateTicker.S2C.Descriptor; }
      }

      public override S2C DefaultInstanceForType {
        get { return global::Qot_UpdateTicker.S2C.DefaultInstance; }
      }

      public override S2C BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }

      public override Builder MergeFrom(pb::IMessage other) {
        if (other is S2C) {
          return MergeFrom((S2C) other);
        } else {
          base.MergeFrom(other);
          return this;
        }
      }

      public override Builder MergeFrom(S2C other) {
        if (other == global::Qot_UpdateTicker.S2C.DefaultInstance) return this;
        PrepareBuilder();
        if (other.HasSecurity) {
          MergeSecurity(other.Security);
        }
        if (other.tickerList_.Count != 0) {
          result.tickerList_.Add(other.tickerList_);
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
            int field_ordinal = global::System.Array.BinarySearch(_s2CFieldNames, field_name, global::System.StringComparer.Ordinal);
            if(field_ordinal >= 0)
              tag = _s2CFieldTags[field_ordinal];
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
            case 10: {
              global::Qot_Common.Security.Builder subBuilder = global::Qot_Common.Security.CreateBuilder();
              if (result.hasSecurity) {
                subBuilder.MergeFrom(Security);
              }
              input.ReadMessage(subBuilder, extensionRegistry);
              Security = subBuilder.BuildPartial();
              break;
            }
            case 18: {
              input.ReadMessageArray(tag, field_name, result.tickerList_, global::Qot_Common.Ticker.DefaultInstance, extensionRegistry);
              break;
            }
          }
        }

        if (unknownFields != null) {
          this.UnknownFields = unknownFields.Build();
        }
        return this;
      }


      public bool HasSecurity {
       get { return result.hasSecurity; }
      }
      public global::Qot_Common.Security Security {
        get { return result.Security; }
        set { SetSecurity(value); }
      }
      public Builder SetSecurity(global::Qot_Common.Security value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasSecurity = true;
        result.security_ = value;
        return this;
      }
      public Builder SetSecurity(global::Qot_Common.Security.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasSecurity = true;
        result.security_ = builderForValue.Build();
        return this;
      }
      public Builder MergeSecurity(global::Qot_Common.Security value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasSecurity &&
            result.security_ != global::Qot_Common.Security.DefaultInstance) {
            result.security_ = global::Qot_Common.Security.CreateBuilder(result.security_).MergeFrom(value).BuildPartial();
        } else {
          result.security_ = value;
        }
        result.hasSecurity = true;
        return this;
      }
      public Builder ClearSecurity() {
        PrepareBuilder();
        result.hasSecurity = false;
        result.security_ = null;
        return this;
      }

      public pbc::IPopsicleList<global::Qot_Common.Ticker> TickerListList {
        get { return PrepareBuilder().tickerList_; }
      }
      public int TickerListCount {
        get { return result.TickerListCount; }
      }
      public global::Qot_Common.Ticker GetTickerList(int index) {
        return result.GetTickerList(index);
      }
      public Builder SetTickerList(int index, global::Qot_Common.Ticker value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.tickerList_[index] = value;
        return this;
      }
      public Builder SetTickerList(int index, global::Qot_Common.Ticker.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.tickerList_[index] = builderForValue.Build();
        return this;
      }
      public Builder AddTickerList(global::Qot_Common.Ticker value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.tickerList_.Add(value);
        return this;
      }
      public Builder AddTickerList(global::Qot_Common.Ticker.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.tickerList_.Add(builderForValue.Build());
        return this;
      }
      public Builder AddRangeTickerList(scg::IEnumerable<global::Qot_Common.Ticker> values) {
        PrepareBuilder();
        result.tickerList_.Add(values);
        return this;
      }
      public Builder ClearTickerList() {
        PrepareBuilder();
        result.tickerList_.Clear();
        return this;
      }
    }
    static S2C() {
      object.ReferenceEquals(global::Qot_UpdateTicker.QotUpdateTicker.Descriptor, null);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class Response : pb::GeneratedMessage<Response, Response.Builder> {
    private Response() { }
    private static readonly Response defaultInstance = new Response().MakeReadOnly();
    private static readonly string[] _responseFieldNames = new string[] { "errCode", "retMsg", "retType", "s2c" };
    private static readonly uint[] _responseFieldTags = new uint[] { 24, 18, 8, 34 };
    public static Response DefaultInstance {
      get { return defaultInstance; }
    }

    public override Response DefaultInstanceForType {
      get { return DefaultInstance; }
    }

    protected override Response ThisMessage {
      get { return this; }
    }

    public static pbd::MessageDescriptor Descriptor {
      get { return global::Qot_UpdateTicker.QotUpdateTicker.internal__static_Qot_UpdateTicker_Response__Descriptor; }
    }

    protected override pb::FieldAccess.FieldAccessorTable<Response, Response.Builder> InternalFieldAccessors {
      get { return global::Qot_UpdateTicker.QotUpdateTicker.internal__static_Qot_UpdateTicker_Response__FieldAccessorTable; }
    }

    public const int RetTypeFieldNumber = 1;
    private bool hasRetType;
    private int retType_ = -400;
    public bool HasRetType {
      get { return hasRetType; }
    }
    public int RetType {
      get { return retType_; }
    }

    public const int RetMsgFieldNumber = 2;
    private bool hasRetMsg;
    private string retMsg_ = "";
    public bool HasRetMsg {
      get { return hasRetMsg; }
    }
    public string RetMsg {
      get { return retMsg_; }
    }

    public const int ErrCodeFieldNumber = 3;
    private bool hasErrCode;
    private int errCode_;
    public bool HasErrCode {
      get { return hasErrCode; }
    }
    public int ErrCode {
      get { return errCode_; }
    }

    public const int S2CFieldNumber = 4;
    private bool hasS2C;
    private global::Qot_UpdateTicker.S2C s2C_;
    public bool HasS2C {
      get { return hasS2C; }
    }
    public global::Qot_UpdateTicker.S2C S2C {
      get { return s2C_ ?? global::Qot_UpdateTicker.S2C.DefaultInstance; }
    }

    public override bool IsInitialized {
      get {
        if (!hasRetType) return false;
        if (HasS2C) {
          if (!S2C.IsInitialized) return false;
        }
        return true;
      }
    }

    public override void WriteTo(pb::ICodedOutputStream output) {
      CalcSerializedSize();
      string[] field_names = _responseFieldNames;
      if (hasRetType) {
        output.WriteInt32(1, field_names[2], RetType);
      }
      if (hasRetMsg) {
        output.WriteString(2, field_names[1], RetMsg);
      }
      if (hasErrCode) {
        output.WriteInt32(3, field_names[0], ErrCode);
      }
      if (hasS2C) {
        output.WriteMessage(4, field_names[3], S2C);
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
      if (hasRetType) {
        size += pb::CodedOutputStream.ComputeInt32Size(1, RetType);
      }
      if (hasRetMsg) {
        size += pb::CodedOutputStream.ComputeStringSize(2, RetMsg);
      }
      if (hasErrCode) {
        size += pb::CodedOutputStream.ComputeInt32Size(3, ErrCode);
      }
      if (hasS2C) {
        size += pb::CodedOutputStream.ComputeMessageSize(4, S2C);
      }
      size += UnknownFields.SerializedSize;
      memoizedSerializedSize = size;
      return size;
    }
    public static Response ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static Response ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static Response ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static Response ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static Response ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static Response ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static Response ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static Response ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static Response ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static Response ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private Response MakeReadOnly() {
      return this;
    }

    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(Response prototype) {
      return new Builder(prototype);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class Builder : pb::GeneratedBuilder<Response, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(Response cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }

      private bool resultIsReadOnly;
      private Response result;

      private Response PrepareBuilder() {
        if (resultIsReadOnly) {
          Response original = result;
          result = new Response();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }

      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }

      protected override Response MessageBeingBuilt {
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
        get { return global::Qot_UpdateTicker.Response.Descriptor; }
      }

      public override Response DefaultInstanceForType {
        get { return global::Qot_UpdateTicker.Response.DefaultInstance; }
      }

      public override Response BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }

      public override Builder MergeFrom(pb::IMessage other) {
        if (other is Response) {
          return MergeFrom((Response) other);
        } else {
          base.MergeFrom(other);
          return this;
        }
      }

      public override Builder MergeFrom(Response other) {
        if (other == global::Qot_UpdateTicker.Response.DefaultInstance) return this;
        PrepareBuilder();
        if (other.HasRetType) {
          RetType = other.RetType;
        }
        if (other.HasRetMsg) {
          RetMsg = other.RetMsg;
        }
        if (other.HasErrCode) {
          ErrCode = other.ErrCode;
        }
        if (other.HasS2C) {
          MergeS2C(other.S2C);
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
            int field_ordinal = global::System.Array.BinarySearch(_responseFieldNames, field_name, global::System.StringComparer.Ordinal);
            if(field_ordinal >= 0)
              tag = _responseFieldTags[field_ordinal];
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
              result.hasRetType = input.ReadInt32(ref result.retType_);
              break;
            }
            case 18: {
              result.hasRetMsg = input.ReadString(ref result.retMsg_);
              break;
            }
            case 24: {
              result.hasErrCode = input.ReadInt32(ref result.errCode_);
              break;
            }
            case 34: {
              global::Qot_UpdateTicker.S2C.Builder subBuilder = global::Qot_UpdateTicker.S2C.CreateBuilder();
              if (result.hasS2C) {
                subBuilder.MergeFrom(S2C);
              }
              input.ReadMessage(subBuilder, extensionRegistry);
              S2C = subBuilder.BuildPartial();
              break;
            }
          }
        }

        if (unknownFields != null) {
          this.UnknownFields = unknownFields.Build();
        }
        return this;
      }


      public bool HasRetType {
        get { return result.hasRetType; }
      }
      public int RetType {
        get { return result.RetType; }
        set { SetRetType(value); }
      }
      public Builder SetRetType(int value) {
        PrepareBuilder();
        result.hasRetType = true;
        result.retType_ = value;
        return this;
      }
      public Builder ClearRetType() {
        PrepareBuilder();
        result.hasRetType = false;
        result.retType_ = -400;
        return this;
      }

      public bool HasRetMsg {
        get { return result.hasRetMsg; }
      }
      public string RetMsg {
        get { return result.RetMsg; }
        set { SetRetMsg(value); }
      }
      public Builder SetRetMsg(string value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasRetMsg = true;
        result.retMsg_ = value;
        return this;
      }
      public Builder ClearRetMsg() {
        PrepareBuilder();
        result.hasRetMsg = false;
        result.retMsg_ = "";
        return this;
      }

      public bool HasErrCode {
        get { return result.hasErrCode; }
      }
      public int ErrCode {
        get { return result.ErrCode; }
        set { SetErrCode(value); }
      }
      public Builder SetErrCode(int value) {
        PrepareBuilder();
        result.hasErrCode = true;
        result.errCode_ = value;
        return this;
      }
      public Builder ClearErrCode() {
        PrepareBuilder();
        result.hasErrCode = false;
        result.errCode_ = 0;
        return this;
      }

      public bool HasS2C {
       get { return result.hasS2C; }
      }
      public global::Qot_UpdateTicker.S2C S2C {
        get { return result.S2C; }
        set { SetS2C(value); }
      }
      public Builder SetS2C(global::Qot_UpdateTicker.S2C value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasS2C = true;
        result.s2C_ = value;
        return this;
      }
      public Builder SetS2C(global::Qot_UpdateTicker.S2C.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasS2C = true;
        result.s2C_ = builderForValue.Build();
        return this;
      }
      public Builder MergeS2C(global::Qot_UpdateTicker.S2C value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasS2C &&
            result.s2C_ != global::Qot_UpdateTicker.S2C.DefaultInstance) {
            result.s2C_ = global::Qot_UpdateTicker.S2C.CreateBuilder(result.s2C_).MergeFrom(value).BuildPartial();
        } else {
          result.s2C_ = value;
        }
        result.hasS2C = true;
        return this;
      }
      public Builder ClearS2C() {
        PrepareBuilder();
        result.hasS2C = false;
        result.s2C_ = null;
        return this;
      }
    }
    static Response() {
      object.ReferenceEquals(global::Qot_UpdateTicker.QotUpdateTicker.Descriptor, null);
    }
  }

  #endregion

}

#endregion Designer generated code
