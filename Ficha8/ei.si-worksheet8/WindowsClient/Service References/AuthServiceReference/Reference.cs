﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsClient.AuthServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/AuthService")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthServiceReference.IAuthService")]
    public interface IAuthService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/VerifyAcessToBD", ReplyAction="http://tempuri.org/IAuthService/VerifyAcessToBDResponse")]
        string VerifyAcessToBD();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/VerifyAcessToBD", ReplyAction="http://tempuri.org/IAuthService/VerifyAcessToBDResponse")]
        System.Threading.Tasks.Task<string> VerifyAcessToBDAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/GetUsers", ReplyAction="http://tempuri.org/IAuthService/GetUsersResponse")]
        WindowsClient.AuthServiceReference.User[] GetUsers(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/GetUsers", ReplyAction="http://tempuri.org/IAuthService/GetUsersResponse")]
        System.Threading.Tasks.Task<WindowsClient.AuthServiceReference.User[]> GetUsersAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/GetUser", ReplyAction="http://tempuri.org/IAuthService/GetUserResponse")]
        WindowsClient.AuthServiceReference.User GetUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/GetUser", ReplyAction="http://tempuri.org/IAuthService/GetUserResponse")]
        System.Threading.Tasks.Task<WindowsClient.AuthServiceReference.User> GetUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/UpdateUserDescription", ReplyAction="http://tempuri.org/IAuthService/UpdateUserDescriptionResponse")]
        bool UpdateUserDescription(string login, string password, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthService/UpdateUserDescription", ReplyAction="http://tempuri.org/IAuthService/UpdateUserDescriptionResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserDescriptionAsync(string login, string password, string description);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthServiceChannel : WindowsClient.AuthServiceReference.IAuthService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthServiceClient : System.ServiceModel.ClientBase<WindowsClient.AuthServiceReference.IAuthService>, WindowsClient.AuthServiceReference.IAuthService {
        
        public AuthServiceClient() {
        }
        
        public AuthServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string VerifyAcessToBD() {
            return base.Channel.VerifyAcessToBD();
        }
        
        public System.Threading.Tasks.Task<string> VerifyAcessToBDAsync() {
            return base.Channel.VerifyAcessToBDAsync();
        }
        
        public WindowsClient.AuthServiceReference.User[] GetUsers(string login, string password) {
            return base.Channel.GetUsers(login, password);
        }
        
        public System.Threading.Tasks.Task<WindowsClient.AuthServiceReference.User[]> GetUsersAsync(string login, string password) {
            return base.Channel.GetUsersAsync(login, password);
        }
        
        public WindowsClient.AuthServiceReference.User GetUser(int id) {
            return base.Channel.GetUser(id);
        }
        
        public System.Threading.Tasks.Task<WindowsClient.AuthServiceReference.User> GetUserAsync(int id) {
            return base.Channel.GetUserAsync(id);
        }
        
        public bool UpdateUserDescription(string login, string password, string description) {
            return base.Channel.UpdateUserDescription(login, password, description);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserDescriptionAsync(string login, string password, string description) {
            return base.Channel.UpdateUserDescriptionAsync(login, password, description);
        }
    }
}
