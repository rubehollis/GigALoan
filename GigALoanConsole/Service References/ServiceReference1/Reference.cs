﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GigALoanConsole.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetName", ReplyAction="http://tempuri.org/IService1/GetNameResponse")]
        string GetName();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetName", ReplyAction="http://tempuri.org/IService1/GetNameResponse")]
        System.Threading.Tasks.Task<string> GetNameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFirstCollege", ReplyAction="http://tempuri.org/IService1/GetFirstCollegeResponse")]
        string GetFirstCollege();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFirstCollege", ReplyAction="http://tempuri.org/IService1/GetFirstCollegeResponse")]
        System.Threading.Tasks.Task<string> GetFirstCollegeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetColleges", ReplyAction="http://tempuri.org/IService1/GetCollegesResponse")]
        GigALoanModel.DTO_College[] GetColleges();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetColleges", ReplyAction="http://tempuri.org/IService1/GetCollegesResponse")]
        System.Threading.Tasks.Task<GigALoanModel.DTO_College[]> GetCollegesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : GigALoanConsole.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<GigALoanConsole.ServiceReference1.IService1>, GigALoanConsole.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetName() {
            return base.Channel.GetName();
        }
        
        public System.Threading.Tasks.Task<string> GetNameAsync() {
            return base.Channel.GetNameAsync();
        }
        
        public string GetFirstCollege() {
            return base.Channel.GetFirstCollege();
        }
        
        public System.Threading.Tasks.Task<string> GetFirstCollegeAsync() {
            return base.Channel.GetFirstCollegeAsync();
        }
        
        public GigALoanModel.DTO_College[] GetColleges() {
            return base.Channel.GetColleges();
        }
        
        public System.Threading.Tasks.Task<GigALoanModel.DTO_College[]> GetCollegesAsync() {
            return base.Channel.GetCollegesAsync();
        }
    }
}
