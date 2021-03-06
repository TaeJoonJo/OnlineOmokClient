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
    static readonly grpc::Marshaller<global::APIServer.LoginConfirm> __Marshaller_APIFunc_LoginConfirm = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.LoginConfirm.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.Account> __Marshaller_APIFunc_Account = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.Account.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.MailList> __Marshaller_APIFunc_MailList = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.MailList.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.ItemInfo> __Marshaller_APIFunc_ItemInfo = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.ItemInfo.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.AccountNickname> __Marshaller_APIFunc_AccountNickname = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.AccountNickname.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.FriendInfo> __Marshaller_APIFunc_FriendInfo = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.FriendInfo.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.FriendList> __Marshaller_APIFunc_FriendList = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.FriendList.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.GameRecordResult> __Marshaller_APIFunc_GameRecordResult = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.GameRecordResult.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.Empty> __Marshaller_APIFunc_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.Empty.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::APIServer.UserLobbyEnterResult> __Marshaller_APIFunc_UserLobbyEnterResult = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::APIServer.UserLobbyEnterResult.Parser.ParseFrom);

    static readonly grpc::Method<global::APIServer.User, global::APIServer.Confirm> __Method_CreateAccount = new grpc::Method<global::APIServer.User, global::APIServer.Confirm>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateAccount",
        __Marshaller_APIFunc_User,
        __Marshaller_APIFunc_Confirm);

    static readonly grpc::Method<global::APIServer.User, global::APIServer.LoginConfirm> __Method_Login = new grpc::Method<global::APIServer.User, global::APIServer.LoginConfirm>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Login",
        __Marshaller_APIFunc_User,
        __Marshaller_APIFunc_LoginConfirm);

    static readonly grpc::Method<global::APIServer.Account, global::APIServer.Confirm> __Method_Attendance = new grpc::Method<global::APIServer.Account, global::APIServer.Confirm>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Attendance",
        __Marshaller_APIFunc_Account,
        __Marshaller_APIFunc_Confirm);

    static readonly grpc::Method<global::APIServer.Account, global::APIServer.MailList> __Method_Mail = new grpc::Method<global::APIServer.Account, global::APIServer.MailList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Mail",
        __Marshaller_APIFunc_Account,
        __Marshaller_APIFunc_MailList);

    static readonly grpc::Method<global::APIServer.ItemInfo, global::APIServer.Confirm> __Method_GetMailItem = new grpc::Method<global::APIServer.ItemInfo, global::APIServer.Confirm>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetMailItem",
        __Marshaller_APIFunc_ItemInfo,
        __Marshaller_APIFunc_Confirm);

    static readonly grpc::Method<global::APIServer.AccountNickname, global::APIServer.Confirm> __Method_FriendFind = new grpc::Method<global::APIServer.AccountNickname, global::APIServer.Confirm>(
        grpc::MethodType.Unary,
        __ServiceName,
        "FriendFind",
        __Marshaller_APIFunc_AccountNickname,
        __Marshaller_APIFunc_Confirm);

    static readonly grpc::Method<global::APIServer.FriendInfo, global::APIServer.Confirm> __Method_FriendApply = new grpc::Method<global::APIServer.FriendInfo, global::APIServer.Confirm>(
        grpc::MethodType.Unary,
        __ServiceName,
        "FriendApply",
        __Marshaller_APIFunc_FriendInfo,
        __Marshaller_APIFunc_Confirm);

    static readonly grpc::Method<global::APIServer.Account, global::APIServer.FriendList> __Method_FriendListForm = new grpc::Method<global::APIServer.Account, global::APIServer.FriendList>(
        grpc::MethodType.Unary,
        __ServiceName,
        "FriendListForm",
        __Marshaller_APIFunc_Account,
        __Marshaller_APIFunc_FriendList);

    static readonly grpc::Method<global::APIServer.Account, global::APIServer.GameRecordResult> __Method_UserGameRecord = new grpc::Method<global::APIServer.Account, global::APIServer.GameRecordResult>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UserGameRecord",
        __Marshaller_APIFunc_Account,
        __Marshaller_APIFunc_GameRecordResult);

    static readonly grpc::Method<global::APIServer.Empty, global::APIServer.UserLobbyEnterResult> __Method_UserLobbyEnter = new grpc::Method<global::APIServer.Empty, global::APIServer.UserLobbyEnterResult>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UserLobbyEnter",
        __Marshaller_APIFunc_Empty,
        __Marshaller_APIFunc_UserLobbyEnterResult);

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
      public virtual global::APIServer.LoginConfirm Login(global::APIServer.User request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Login(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.LoginConfirm Login(global::APIServer.User request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Login, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.LoginConfirm> LoginAsync(global::APIServer.User request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LoginAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.LoginConfirm> LoginAsync(global::APIServer.User request, grpc::CallOptions options)
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
      public virtual global::APIServer.MailList Mail(global::APIServer.Account request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Mail(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.MailList Mail(global::APIServer.Account request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Mail, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.MailList> MailAsync(global::APIServer.Account request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return MailAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.MailList> MailAsync(global::APIServer.Account request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Mail, null, options, request);
      }
      public virtual global::APIServer.Confirm GetMailItem(global::APIServer.ItemInfo request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetMailItem(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.Confirm GetMailItem(global::APIServer.ItemInfo request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetMailItem, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> GetMailItemAsync(global::APIServer.ItemInfo request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetMailItemAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> GetMailItemAsync(global::APIServer.ItemInfo request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetMailItem, null, options, request);
      }
      public virtual global::APIServer.Confirm FriendFind(global::APIServer.AccountNickname request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FriendFind(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.Confirm FriendFind(global::APIServer.AccountNickname request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_FriendFind, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> FriendFindAsync(global::APIServer.AccountNickname request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FriendFindAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> FriendFindAsync(global::APIServer.AccountNickname request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_FriendFind, null, options, request);
      }
      public virtual global::APIServer.Confirm FriendApply(global::APIServer.FriendInfo request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FriendApply(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.Confirm FriendApply(global::APIServer.FriendInfo request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_FriendApply, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> FriendApplyAsync(global::APIServer.FriendInfo request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FriendApplyAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.Confirm> FriendApplyAsync(global::APIServer.FriendInfo request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_FriendApply, null, options, request);
      }
      public virtual global::APIServer.FriendList FriendListForm(global::APIServer.Account request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FriendListForm(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.FriendList FriendListForm(global::APIServer.Account request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_FriendListForm, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.FriendList> FriendListFormAsync(global::APIServer.Account request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FriendListFormAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.FriendList> FriendListFormAsync(global::APIServer.Account request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_FriendListForm, null, options, request);
      }
      public virtual global::APIServer.GameRecordResult UserGameRecord(global::APIServer.Account request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UserGameRecord(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.GameRecordResult UserGameRecord(global::APIServer.Account request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UserGameRecord, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.GameRecordResult> UserGameRecordAsync(global::APIServer.Account request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UserGameRecordAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.GameRecordResult> UserGameRecordAsync(global::APIServer.Account request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UserGameRecord, null, options, request);
      }
      public virtual global::APIServer.UserLobbyEnterResult UserLobbyEnter(global::APIServer.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UserLobbyEnter(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::APIServer.UserLobbyEnterResult UserLobbyEnter(global::APIServer.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UserLobbyEnter, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.UserLobbyEnterResult> UserLobbyEnterAsync(global::APIServer.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UserLobbyEnterAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::APIServer.UserLobbyEnterResult> UserLobbyEnterAsync(global::APIServer.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UserLobbyEnter, null, options, request);
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
