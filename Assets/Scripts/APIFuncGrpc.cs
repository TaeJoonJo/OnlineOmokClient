// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/APIFunc.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace APIServer {
  public static partial class APIFunction
  {
    static readonly string __ServiceName = "APIFunc.APIFunction";

    static readonly grpc::Marshaller<global::APIServer.User> __Marshaller_APIFunc_User = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.User.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.Confirm> __Marshaller_APIFunc_Confirm = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.Confirm.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.Account> __Marshaller_APIFunc_Account = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.Account.Parser.ParseFrom);

    static readonly grpc::Method<global::APIServer.User, global::APIServer.Confirm> __Method_CreateAccount = new grpc::Method<global::APIServer.User, global::APIServer.Confirm>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateAccount",
        __Marshaller_APIFunc_User,
        __Marshaller_APIFunc_Confirm);

    static readonly grpc::Method<global::APIServer.User, global::APIServer.Confirm> __Method_Login = new grpc::Method<global::APIServer.User, global::APIServer.Confirm>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Login",
        __Marshaller_APIFunc_User,
        __Marshaller_APIFunc_Confirm);

    static readonly grpc::Method<global::APIServer.Account, global::APIServer.Confirm> __Method_Attendance = new grpc::Method<global::APIServer.Account, global::APIServer.Confirm>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Attendance",
        __Marshaller_APIFunc_Account,
        __Marshaller_APIFunc_Confirm);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::APIServer.APIFuncReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for APIFunction</summary>
    public partial class APIFunctionClient : grpc::ClientBase<APIFunctionClient>
    {
      /// <summary>Creates a new client for APIFunction</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public APIFunctionClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for APIFunction that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public APIFunctionClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected APIFunctionClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected APIFunctionClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::APIServer.Confirm CreateAccount(global::APIServer.User request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateAccount(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.Confirm CreateAccount(global::APIServer.User request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateAccount, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> CreateAccountAsync(global::APIServer.User request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateAccountAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> CreateAccountAsync(global::APIServer.User request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateAccount, null, options, request);
      }
      public virtual global::APIServer.Confirm Login(global::APIServer.User request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Login(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.Confirm Login(global::APIServer.User request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Login, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> LoginAsync(global::APIServer.User request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LoginAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> LoginAsync(global::APIServer.User request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Login, null, options, request);
      }
      public virtual global::APIServer.Confirm Attendance(global::APIServer.Account request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Attendance(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.Confirm Attendance(global::APIServer.Account request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Attendance, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> AttendanceAsync(global::APIServer.Account request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AttendanceAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> AttendanceAsync(global::APIServer.Account request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Attendance, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override APIFunctionClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new APIFunctionClient(configuration);
      }
    }

  }
}
#endregion